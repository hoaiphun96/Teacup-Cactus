#include "UnityTrampolineCompatibility.h"
#include "UnityRendering.h"

#if UNITY_CAN_USE_METAL

#include "UnityMetalSupport.h"
#include <QuartzCore/QuartzCore.h>
#include <libkern/OSAtomic.h>

#if UNITY_TRAMPOLINE_IN_USE
#include "UnityAppController.h"
#include "CVTextureCache.h"
#endif

#include <objc/runtime.h>
extern Class MTLTextureDescriptorClass;
static bool hasMTLTextureDescriptorUsage = false;


extern "C" void InitRenderingMTL()
{
#if UNITY_TRAMPOLINE_IN_USE
    extern bool _supportsMSAA;
    _supportsMSAA = true;
#endif

#if __IPHONE_9_0 || __TVOS_9_0 || __MAC_10_11
    hasMTLTextureDescriptorUsage = class_getProperty(MTLTextureDescriptorClass, "usage") != 0;
#endif
}

static bool SupportsTextureSampleCountMTL(MTLDeviceRef device, NSUInteger sampleCount)
{
    if ([device respondsToSelector: @selector(supportsTextureSampleCount:)])
    {
#if __IPHONE_9_0 || __TVOS_9_0 || __MAC_10_11
        return [device supportsTextureSampleCount: sampleCount];
#endif
    }

    // We hit this path only on iOS8. 4x MSAA is known to be supported on all devices.
    return (sampleCount == 1 || sampleCount == 4);
}

static MTLPixelFormat GetColorFormatForSurface(const UnityDisplaySurfaceMTL* surface)
{
    MTLPixelFormat colorFormat = surface->srgb ? MTLPixelFormatBGRA8Unorm_sRGB : MTLPixelFormatBGRA8Unorm;
#if PLATFORM_IOS && __IPHONE_10_0
    if (surface->wideColor)
        colorFormat = surface->srgb ? MTLPixelFormatBGR10_XR_sRGB : MTLPixelFormatBGR10_XR;
#elif PLATFORM_OSX && __MAC_10_12
    if (surface->wideColor)
        colorFormat = MTLPixelFormatRGBA16Float;
#endif
    return colorFormat;
}

extern "C" void CreateSystemRenderingSurfaceMTL(UnityDisplaySurfaceMTL* surface)
{
    DestroySystemRenderingSurfaceMTL(surface);

    MTLPixelFormat colorFormat = GetColorFormatForSurface(surface);
    surface->layer.presentsWithTransaction = NO;
    surface->layer.drawsAsynchronously = YES;

#if PLATFORM_OSX
    MetalUpdateDisplaySync();
#endif

    CGFloat backgroundColorValues[] = {0, 0, 0, 1};
#if (PLATFORM_IOS && __IPHONE_9_0) || PLATFORM_OSX
    CGColorSpaceRef colorSpaceRef = CGColorSpaceCreateWithName(kCGColorSpaceSRGB);
#else
    CGColorSpaceRef colorSpaceRef = CGColorSpaceCreateDeviceRGB();
#endif
#if (PLATFORM_IOS && __IPHONE_10_0) || (PLATFORM_OSX && __MAC_10_12)
    if (surface->wideColor)
        colorSpaceRef = CGColorSpaceCreateWithName(surface->srgb ? kCGColorSpaceExtendedLinearSRGB : kCGColorSpaceExtendedSRGB);
#endif

    CGColorRef backgroundColorRef = CGColorCreate(colorSpaceRef, backgroundColorValues);
    surface->layer.backgroundColor = backgroundColorRef; // retained automatically
#if PLATFORM_OSX && __MAC_10_12
    surface->layer.colorspace = colorSpaceRef;
#endif
    CGColorRelease(backgroundColorRef);
    CGColorSpaceRelease(colorSpaceRef);

    surface->layer.device = surface->device;
    surface->layer.pixelFormat = colorFormat;
    surface->layer.framebufferOnly = (surface->framebufferOnly != 0);
    surface->colorFormat = colorFormat;

    MTLTextureDescriptor* txDesc = [MTLTextureDescriptorClass texture2DDescriptorWithPixelFormat: colorFormat width: surface->systemW height: surface->systemH mipmapped: NO];
#if PLATFORM_OSX
    txDesc.resourceOptions = MTLResourceCPUCacheModeDefaultCache | MTLResourceStorageModeManaged;
#endif
#if __IPHONE_9_0 || __TVOS_9_0 || __MAC_10_11
    if (hasMTLTextureDescriptorUsage)
        txDesc.usage = MTLTextureUsageRenderTarget | MTLTextureUsageShaderRead;
#endif

    @synchronized(surface->layer)
    {
        OSAtomicCompareAndSwap32Barrier(surface->bufferChanged, 0, &surface->bufferChanged);

        for (int i = 0; i < kUnityNumOffscreenSurfaces; i++)
        {
            OSAtomicCompareAndSwap32Barrier(surface->bufferCompleted[i], -1, &surface->bufferCompleted[i]);
            // Allocating a proxy texture is cheap until it's being rendered to and the GPU driver does allocation
            surface->drawableProxyRT[i] = [surface->device newTextureWithDescriptor: txDesc];
        }

#if PLATFORM_OSX
        OSAtomicCompareAndSwap32Barrier(surface->writeCount, surface->writeCount + (kUnityNumOffscreenSurfaces - 1), &surface->writeCount);
        OSAtomicCompareAndSwap32Barrier(surface->readCount, surface->writeCount - 1, &surface->readCount);
#endif
    }
}

extern "C" void CreateRenderingSurfaceMTL(UnityDisplaySurfaceMTL* surface)
{
    DestroyRenderingSurfaceMTL(surface);

    MTLPixelFormat colorFormat = GetColorFormatForSurface(surface);

    const int w = surface->targetW, h = surface->targetH;

    if (w != surface->systemW || h != surface->systemH || surface->useCVTextureCache)
    {
#if PLATFORM_IOS || PLATFORM_TVOS
        if (surface->useCVTextureCache)
            surface->cvTextureCache = CreateCVTextureCache();

        if (surface->cvTextureCache)
        {
            surface->cvTextureCacheTexture = CreateReadableRTFromCVTextureCache(surface->cvTextureCache, surface->targetW, surface->targetH, &surface->cvPixelBuffer);
            surface->targetColorRT = GetMetalTextureFromCVTextureCache(surface->cvTextureCacheTexture);
        }
        else
#endif
        {
            MTLTextureDescriptor* txDesc = [MTLTextureDescriptorClass new];
            txDesc.textureType = MTLTextureType2D;
            txDesc.width = w;
            txDesc.height = h;
            txDesc.depth = 1;
            txDesc.pixelFormat = colorFormat;
            txDesc.arrayLength = 1;
            txDesc.mipmapLevelCount = 1;
#if PLATFORM_OSX
            txDesc.resourceOptions = MTLResourceCPUCacheModeDefaultCache | MTLResourceStorageModeManaged;
#endif
#if __IPHONE_9_0 || __TVOS_9_0 || __MAC_10_11
            if (hasMTLTextureDescriptorUsage)
                txDesc.usage = MTLTextureUsageRenderTarget | MTLTextureUsageShaderRead;
#endif

            surface->targetColorRT = [surface->device newTextureWithDescriptor: txDesc];
        }
        surface->targetColorRT.label = @"targetColorRT";
    }

    if (surface->msaaSamples > 1)
    {
        MTLTextureDescriptor* txDesc = [MTLTextureDescriptorClass new];
        txDesc.textureType = MTLTextureType2DMultisample;
        txDesc.width = w;
        txDesc.height = h;
        txDesc.depth = 1;
        txDesc.pixelFormat = colorFormat;
        txDesc.arrayLength = 1;
        txDesc.mipmapLevelCount = 1;
        txDesc.sampleCount = surface->msaaSamples;
#if PLATFORM_OSX
        txDesc.resourceOptions = MTLResourceCPUCacheModeDefaultCache | MTLResourceStorageModePrivate;
#endif
#if __IPHONE_9_0 || __TVOS_9_0 || __MAC_10_11
        if (hasMTLTextureDescriptorUsage)
            txDesc.usage = MTLTextureUsageRenderTarget;
#endif
        if (!SupportsTextureSampleCountMTL(surface->device, txDesc.sampleCount))
            txDesc.sampleCount = 4;
        surface->targetAAColorRT = [surface->device newTextureWithDescriptor: txDesc];
        surface->targetAAColorRT.label = @"targetAAColorRT";
    }
}

extern "C" void DestroyRenderingSurfaceMTL(UnityDisplaySurfaceMTL* surface)
{
    surface->targetColorRT = nil;
    surface->targetAAColorRT = nil;

    if (surface->cvTextureCacheTexture)
        CFRelease(surface->cvTextureCacheTexture);
    if (surface->cvPixelBuffer)
        CFRelease(surface->cvPixelBuffer);
    if (surface->cvTextureCache)
        CFRelease(surface->cvTextureCache);
    surface->cvTextureCache = 0;
}

extern "C" void CreateSharedDepthbufferMTL(UnityDisplaySurfaceMTL* surface)
{
    DestroySharedDepthbufferMTL(surface);

#if PLATFORM_OSX
    MTLPixelFormat pixelFormat = MTLPixelFormatDepth32Float_Stencil8;
#else
    MTLPixelFormat pixelFormat = MTLPixelFormatDepth32Float;
#endif

    MTLTextureDescriptor* depthTexDesc = [MTLTextureDescriptorClass texture2DDescriptorWithPixelFormat: pixelFormat width: surface->targetW height: surface->targetH mipmapped: NO];
#if PLATFORM_OSX
    depthTexDesc.resourceOptions = MTLResourceCPUCacheModeDefaultCache | MTLResourceStorageModePrivate;
#endif
#if __IPHONE_9_0 || __TVOS_9_0 || __MAC_10_11
    if (hasMTLTextureDescriptorUsage)
        depthTexDesc.usage = MTLTextureUsageRenderTarget;
#endif
    if (surface->msaaSamples > 1)
    {
        depthTexDesc.textureType = MTLTextureType2DMultisample;
        depthTexDesc.sampleCount = surface->msaaSamples;
        if (!SupportsTextureSampleCountMTL(surface->device, depthTexDesc.sampleCount))
            depthTexDesc.sampleCount = 4;
    }
    surface->depthRB = [surface->device newTextureWithDescriptor: depthTexDesc];

#if PLATFORM_OSX
    surface->stencilRB = surface->depthRB;
#else
    MTLTextureDescriptor* stencilTexDesc = [MTLTextureDescriptorClass texture2DDescriptorWithPixelFormat: MTLPixelFormatStencil8 width: surface->targetW height: surface->targetH mipmapped: NO];
#if __IPHONE_9_0 || __TVOS_9_0 || __MAC_10_11
    if (hasMTLTextureDescriptorUsage)
        stencilTexDesc.usage = MTLTextureUsageRenderTarget;
#endif
    if (surface->msaaSamples > 1)
    {
        stencilTexDesc.textureType = MTLTextureType2DMultisample;
        stencilTexDesc.sampleCount = surface->msaaSamples;
        if (!SupportsTextureSampleCountMTL(surface->device, stencilTexDesc.sampleCount))
            stencilTexDesc.sampleCount = 4;
    }
    surface->stencilRB = [surface->device newTextureWithDescriptor: stencilTexDesc];
#endif
}

extern "C" void DestroySharedDepthbufferMTL(UnityDisplaySurfaceMTL* surface)
{
    surface->depthRB = nil;
    surface->stencilRB = nil;
}

extern "C" void CreateUnityRenderBuffersMTL(UnityDisplaySurfaceMTL* surface)
{
    UnityRenderBufferDesc sys_desc = { surface->systemW, surface->systemH, 1, 1, 1 };
    UnityRenderBufferDesc tgt_desc = { surface->targetW, surface->targetH, 1, (unsigned int)surface->msaaSamples, 1 };

    // drawable (final color texture) we will be updating on every frame
    // in case of rendering to native + AA, we will also update native target every frame

    if (surface->targetAAColorRT)
        surface->unityColorBuffer   = UnityCreateExternalColorSurfaceMTL(surface->unityColorBuffer, surface->targetAAColorRT, surface->targetColorRT, &tgt_desc, nil);
    else if (surface->targetColorRT)
        surface->unityColorBuffer   = UnityCreateExternalColorSurfaceMTL(surface->unityColorBuffer, surface->targetColorRT, nil, &tgt_desc, nil);
    else
        surface->unityColorBuffer   = UnityCreateDummySurface(surface->unityColorBuffer, true, &sys_desc);

    surface->unityDepthBuffer       = UnityCreateExternalDepthSurfaceMTL(surface->unityDepthBuffer, surface->depthRB, surface->stencilRB, &tgt_desc);

    surface->systemColorBuffer = UnityCreateDummySurface(surface->systemColorBuffer, true, &sys_desc);
    surface->systemDepthBuffer = UnityCreateDummySurface(surface->systemDepthBuffer, false, &sys_desc);
}

extern "C" void DestroySystemRenderingSurfaceMTL(UnityDisplaySurfaceMTL* surface)
{
    surface->systemColorRB = nil;
}

extern "C" void DestroyUnityRenderBuffersMTL(UnityDisplaySurfaceMTL* surface)
{
    UnityDestroyExternalSurface(surface->unityColorBuffer);
    UnityDestroyExternalSurface(surface->systemColorBuffer);
    surface->unityColorBuffer = surface->systemColorBuffer = 0;

    UnityDestroyExternalSurface(surface->unityDepthBuffer);
    UnityDestroyExternalSurface(surface->systemDepthBuffer);
    surface->unityDepthBuffer = surface->systemDepthBuffer = 0;
}

extern "C" void PreparePresentMTL(UnityDisplaySurfaceMTL* surface)
{
    if (surface->targetColorRT)
        UnityBlitToBackbuffer(surface->unityColorBuffer, surface->systemColorBuffer, surface->systemDepthBuffer);
#if UNITY_TRAMPOLINE_IN_USE
    APP_CONTROLLER_RENDER_PLUGIN_METHOD(onFrameResolved);
#endif
}

extern "C" void PresentMTL(UnityDisplaySurfaceMTL* surface)
{
    if (surface->drawable)
        [UnityCurrentMTLCommandBuffer() presentDrawable: surface->drawable];
}

extern "C" MTLTextureRef AcquireDrawableMTL(UnityDisplaySurfaceMTL* surface)
{
    if (!surface)
        return nil;

    surface->drawable = [surface->layer nextDrawable];

    // on A7 SoC nextDrawable may be nil before locking the screen
    if (!surface->drawable)
        return nil;

    surface->systemColorRB = [surface->drawable texture];
    return surface->systemColorRB;
}

extern "C" void StartFrameRenderingMTL(UnityDisplaySurfaceMTL* surface)
{
    // we will acquire drawable lazily in AcquireDrawableMTL
    surface->drawable = nil;

#if PLATFORM_OSX
    // For non-Mac platforms, writeCount remains static
    bool bufferChanged = (bool)surface->bufferChanged;
    OSAtomicCompareAndSwap32Barrier(surface->bufferChanged, 0, &surface->bufferChanged);

    if (bufferChanged && surface->writeCount <= surface->readCount)
        OSAtomicAdd32Barrier(1, &surface->writeCount);
    OSAtomicCompareAndSwap32Barrier(surface->bufferCompleted[surface->writeCount % kUnityNumOffscreenSurfaces], 0, &surface->bufferCompleted[surface->writeCount % kUnityNumOffscreenSurfaces]);
#endif
    surface->systemColorRB  = surface->drawableProxyRT[surface->writeCount % kUnityNumOffscreenSurfaces];

    // screen disconnect notification comes asynchronously
    // even better when preparing render we might still have [UIScreen screens].count == 2, but drawable would be nil already
    if (surface->systemColorRB)
    {
        UnityRenderBufferDesc sys_desc = { surface->systemW, surface->systemH, 1, 1, 1};
        UnityRenderBufferDesc tgt_desc = { surface->targetW, surface->targetH, 1, (unsigned int)surface->msaaSamples, 1};

        surface->systemColorBuffer = UnityCreateExternalColorSurfaceMTL(surface->systemColorBuffer, surface->systemColorRB, nil, &sys_desc, surface);
        if (surface->targetColorRT == nil)
        {
            if (surface->targetAAColorRT)
                surface->unityColorBuffer = UnityCreateExternalColorSurfaceMTL(surface->unityColorBuffer, surface->targetAAColorRT, surface->systemColorRB, &tgt_desc, surface);
            else
                surface->unityColorBuffer = UnityCreateExternalColorSurfaceMTL(surface->unityColorBuffer, surface->systemColorRB, nil, &tgt_desc, surface);
        }
    }
    else
    {
        UnityDisableRenderBuffers(surface->unityColorBuffer, surface->unityDepthBuffer);
    }
}

extern "C" void EndFrameRenderingMTL(UnityDisplaySurfaceMTL* surface)
{
    surface->systemColorRB  = nil;
    surface->drawable       = nil;
}

#else

extern "C" void InitRenderingMTL()                                          {}

extern "C" void CreateSystemRenderingSurfaceMTL(UnityDisplaySurfaceMTL*)    {}
extern "C" void CreateRenderingSurfaceMTL(UnityDisplaySurfaceMTL*)          {}
extern "C" void DestroyRenderingSurfaceMTL(UnityDisplaySurfaceMTL*)         {}
extern "C" void CreateSharedDepthbufferMTL(UnityDisplaySurfaceMTL*)         {}
extern "C" void DestroySharedDepthbufferMTL(UnityDisplaySurfaceMTL*)        {}
extern "C" void CreateUnityRenderBuffersMTL(UnityDisplaySurfaceMTL*)        {}
extern "C" void DestroySystemRenderingSurfaceMTL(UnityDisplaySurfaceMTL*)   {}
extern "C" void DestroyUnityRenderBuffersMTL(UnityDisplaySurfaceMTL*)       {}
extern "C" void StartFrameRenderingMTL(UnityDisplaySurfaceMTL*)             {}
extern "C" void EndFrameRenderingMTL(UnityDisplaySurfaceMTL*)               {}
extern "C" void PreparePresentMTL(UnityDisplaySurfaceMTL*)                  {}
extern "C" void PresentMTL(UnityDisplaySurfaceMTL*)                         {}

#endif
