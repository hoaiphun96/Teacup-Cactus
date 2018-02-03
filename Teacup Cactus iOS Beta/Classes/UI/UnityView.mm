#include "UnityView.h"
#include "UnityAppController.h"
#include "UnityAppController+Rendering.h"
#include "OrientationSupport.h"
#include "Unity/DisplayManager.h"
#include "Unity/UnityMetalSupport.h"

extern bool _renderingInited;
extern bool _unityAppReady;
extern bool _skipPresent;
extern bool _supportsMSAA;

@implementation UnityView
{
    CGSize _surfaceSize;
}

@synthesize contentOrientation  = _curOrientation;

- (void)onUpdateSurfaceSize:(CGSize)size
{
    _surfaceSize = size;

    CGSize renderSize = CGSizeMake(size.width * self.contentScaleFactor, size.height * self.contentScaleFactor);
    _curOrientation = (ScreenOrientation)UnityReportResizeView(renderSize.width, renderSize.height, _curOrientation);

#if UNITY_CAN_USE_METAL
    if (UnitySelectedRenderingAPI() == apiMetal)
        ((CAMetalLayer*)self.layer).drawableSize = renderSize;
#endif
}

- (void)initImpl:(CGRect)frame scaleFactor:(CGFloat)scale
{
#if !PLATFORM_TVOS
    self.multipleTouchEnabled   = YES;
    self.exclusiveTouch         = YES;
#endif
    self.contentScaleFactor     = scale;
    self.isAccessibilityElement = TRUE;
    self.accessibilityTraits    = UIAccessibilityTraitAllowsDirectInteraction;

#if UNITY_TVOS
    _curOrientation = UNITY_TVOS_ORIENTATION;
#endif

    [self onUpdateSurfaceSize: frame.size];

#if UNITY_CAN_USE_METAL
    if (UnitySelectedRenderingAPI() == apiMetal)
        ((CAMetalLayer*)self.layer).framebufferOnly = NO;
#endif
}

- (id)initWithFrame:(CGRect)frame scaleFactor:(CGFloat)scale;
{
    if ((self = [super initWithFrame: frame]))
        [self initImpl: frame scaleFactor: scale];
    return self;
}
- (id)initWithFrame:(CGRect)frame
{
    if ((self = [super initWithFrame: frame]))
        [self initImpl: frame scaleFactor: 1.0f];
    return self;
}

- (id)initFromMainScreen
{
    CGRect  frame   = [UIScreen mainScreen].bounds;
    CGFloat scale   = UnityScreenScaleFactor([UIScreen mainScreen]);
    if ((self = [super initWithFrame: frame]))
        [self initImpl: frame scaleFactor: scale];
    return self;
}

- (void)layoutSubviews
{
    if (_surfaceSize.width != self.bounds.size.width || _surfaceSize.height != self.bounds.size.height)
        _shouldRecreateView = YES;
    [self onUpdateSurfaceSize: self.bounds.size];

    for (UIView* subView in self.subviews)
    {
        if ([subView respondsToSelector: @selector(onUnityUpdateViewLayout)])
            [subView performSelector: @selector(onUnityUpdateViewLayout)];
    }

    [super layoutSubviews];
}

- (void)recreateRenderingSurfaceIfNeeded
{
    unsigned requestedW, requestedH;    UnityGetRenderingResolution(&requestedW, &requestedH);
    int requestedMSAA = UnityGetDesiredMSAASampleCount(MSAA_DEFAULT_SAMPLE_COUNT);
    int requestedSRGB = UnityGetSRGBRequested();
    int requestedWideColor = UnityGetWideColorRequested();

    UnityDisplaySurfaceBase* surf = GetMainDisplaySurface();

    if (_shouldRecreateView == YES
        ||  surf->targetW != requestedW || surf->targetH != requestedH
        ||  surf->disableDepthAndStencil != UnityDisableDepthAndStencilBuffers()
        ||  (_supportsMSAA && surf->msaaSamples != requestedMSAA)
        ||  surf->srgb != requestedSRGB
        ||  surf->wideColor != requestedWideColor
        )
    {
        [self recreateRenderingSurface];
    }
}

- (void)recreateRenderingSurface
{
    if (_renderingInited)
    {
        unsigned requestedW, requestedH;
        UnityGetRenderingResolution(&requestedW, &requestedH);

        RenderingSurfaceParams params =
        {
            UnityGetDesiredMSAASampleCount(MSAA_DEFAULT_SAMPLE_COUNT),
            (int)requestedW, (int)requestedH,
            UnityGetSRGBRequested(),
            UnityGetWideColorRequested(),
            UnityMetalFramebufferOnly(),
            UnityDisableDepthAndStencilBuffers(), 0
        };

        APP_CONTROLLER_RENDER_PLUGIN_METHOD_ARG(onBeforeMainDisplaySurfaceRecreate, &params);
        [GetMainDisplay() recreateSurface: params];

        // actually poke unity about updated back buffer and notify that extents were changed
        UnityReportBackbufferChange(GetMainDisplaySurface()->unityColorBuffer, GetMainDisplaySurface()->unityDepthBuffer);
        APP_CONTROLLER_RENDER_PLUGIN_METHOD(onAfterMainDisplaySurfaceRecreate);

        if (_unityAppReady)
        {
            // seems like ios sometimes got confused about abrupt swap chain destroy
            // draw 2 times to fill both buffers
            // present only once to make sure correct image goes to CA
            // if we are calling this from inside repaint, second draw and present will be done automatically
            _skipPresent = true;
            if (!UnityIsPaused())
                UnityRepaint();
            _skipPresent = false;
        }
    }

    _shouldRecreateView = NO;
}

@end

@implementation UnityView (Deprecated)
- (void)recreateGLESSurfaceIfNeeded { [self recreateRenderingSurfaceIfNeeded]; }
- (void)recreateGLESSurface         { [self recreateRenderingSurface]; }
@end


#include "objc/runtime.h"

static Class UnityRenderingView_LayerClassGLES(id self_, SEL _cmd)
{
    return [CAEAGLLayer class];
}

static Class UnityRenderingView_LayerClassMTL(id self_, SEL _cmd)
{
    return [[NSBundle bundleWithPath: @"/System/Library/Frameworks/QuartzCore.framework"] classNamed: @"CAMetalLayer"];
}

@implementation UnityRenderingView
+ (Class)layerClass
{
    return nil;
}

+ (void)InitializeForAPI:(UnityRenderingAPI)api
{
    IMP layerClassImpl = 0;
    if (api == apiOpenGLES2 || api == apiOpenGLES3)
        layerClassImpl = (IMP)UnityRenderingView_LayerClassGLES;
    else if (api == apiMetal)
        layerClassImpl = (IMP)UnityRenderingView_LayerClassMTL;

    Method layerClassMethod = class_getClassMethod([UnityRenderingView class], @selector(layerClass));

    if (layerClassMethod)
        method_setImplementation(layerClassMethod, layerClassImpl);
    else
        class_addMethod([UnityRenderingView class], @selector(layerClass), layerClassImpl, "#8@0:4");
}

@end
