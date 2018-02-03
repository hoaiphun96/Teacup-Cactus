#pragma once

#include <Availability.h>

//------------------------------------------------------------------------------
//
// ensuring proper compiler/xcode/whatever selection
//

#ifndef __clang__
#error please use clang compiler.
#endif

// NOT the best way but apple do not care about adding extensions properly
#if __clang_major__ < 6
#error please use xcode 6.0 or newer
#endif

#if !defined(__IPHONE_8_0) || __IPHONE_OS_VERSION_MAX_ALLOWED < __IPHONE_8_0
#error please use ios sdk 8.0 or newer
#endif

#if !defined(__IPHONE_7_0) || __IPHONE_OS_VERSION_MIN_REQUIRED < __IPHONE_7_0
#error please target ios 7.0 or newer
#endif

#define UNITY_TRAMPOLINE_IN_USE 1

//------------------------------------------------------------------------------
//
// defines for sdk/target version
//

#define UNITY_PRE_IOS7_TARGET (__IPHONE_OS_VERSION_MIN_REQUIRED < __IPHONE_7_0)

#if !TARGET_IPHONE_SIMULATOR && !TARGET_TVOS_SIMULATOR
    #define UNITY_CAN_USE_METAL     1
#else
    #define UNITY_CAN_USE_METAL     0
#endif

// The following UNITY_USES_* flags disable functionality in the trampoline project
// whenever the user does not use it from his scripts. We detect the API usage and
// adjust the value of these flags whenever the project is built (including when the
// project is appended)
#define UNITY_USES_REMOTE_NOTIFICATIONS 0
#define UNITY_USES_WEBCAM 0
#define UNITY_USES_MICROPHONE 0
#define UNITY_USES_REPLAY_KIT 0
#define UNITY_SNAPSHOT_VIEW_ON_APPLICATION_PAUSE 0
#define UNITY_DEVELOPER_BUILD 1

#define USE_IL2CPP_PCH 0

#if defined(TARGET_OS_TV) && TARGET_OS_TV
#define PLATFORM_TVOS 0
#define PLATFORM_IOS 1
#else
#define PLATFORM_TVOS 0
#define PLATFORM_IOS 1
#endif

#define PLATFORM_OSX 0
#define UNITY_SUPPORT_ROTATION PLATFORM_IOS

#if !defined(__IPHONE_9_0) && !defined(__TVOS_10_0)
    #define UNITY_REPLAY_KIT_AVAILABLE 0
#else
    #define UNITY_REPLAY_KIT_AVAILABLE (UNITY_USES_REPLAY_KIT && ((PLATFORM_IOS || PLATFORM_TVOS) && (__IPHONE_OS_VERSION_MAX_ALLOWED >= __IPHONE_9_0 || __TVOS_OS_VERSION_MAX_ALLOWED >= __TVOS_10_0)))
#endif

#if PLATFORM_TVOS
    #define UNITY_TVOS_ORIENTATION landscapeLeft
#endif

// On tvOS simulator we implement a fake remote as tvOS simulator does not support controllers (yet)
#define UNITY_TVOS_SIMULATOR_FAKE_REMOTE (PLATFORM_TVOS && TARGET_TVOS_SIMULATOR)
