#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <cstring>
#include <string.h>
#include <stdio.h>
#include <cmath>
#include <limits>
#include <assert.h>
#include <stdint.h>

#include "class-internals.h"
#include "codegen/il2cpp-codegen.h"
#include "object-internals.h"

// changeScene
struct changeScene_t2085063124;
// UnityEngine.MonoBehaviour
struct MonoBehaviour_t1158329972;
// System.String
struct String_t;
// MuteUnmuteMusic
struct MuteUnmuteMusic_t1642836682;
// PlayMusic
struct PlayMusic_t2005096559;
// UnityEngine.Component
struct Component_t3819376471;
// UnityEngine.GameObject
struct GameObject_t1756533147;
// UnityEngine.AudioSource
struct AudioSource_t1135106623;
// PauseMusic
struct PauseMusic_t2827853909;
// UnityEngine.Object
struct Object_t1021602117;
// ProgressBar
struct ProgressBar_t192201240;
// System.Char[]
struct CharU5BU5D_t1328083999;
// System.Void
struct Void_t1841601450;
// UnityEngine.AudioSourceExtension
struct AudioSourceExtension_t1813599864;
// UnityEngine.Texture2D
struct Texture2D_t3542995729;

extern Il2CppCodeGenString* _stringLiteral1572100361;
extern const uint32_t changeScene_changeToScene_m1126648592_MetadataUsageId;
extern Il2CppCodeGenString* _stringLiteral2042359555;
extern const uint32_t changeScene_changeToSettingsScene_m517506769_MetadataUsageId;
extern Il2CppCodeGenString* _stringLiteral3375240061;
extern const uint32_t changeScene_changeToFlowerPickerScene_m4223595579_MetadataUsageId;
extern Il2CppCodeGenString* _stringLiteral57323982;
extern const uint32_t changeScene_changeToTeacupPickerScene_m4237967508_MetadataUsageId;
extern Il2CppCodeGenString* _stringLiteral4182229268;
extern const uint32_t changeScene_changeToTitleScene_m2891124892_MetadataUsageId;
extern RuntimeClass* PlayMusic_t2005096559_il2cpp_TypeInfo_var;
extern const RuntimeMethod* GameObject_GetComponent_TisAudioSource_t1135106623_m3309832039_RuntimeMethod_var;
extern const uint32_t MuteUnmuteMusic_MuteUnmute_m4062677570_MetadataUsageId;
extern const uint32_t PauseMusic_Start_m478704704_MetadataUsageId;
extern const uint32_t PlayMusic_get_Instance_m3170436882_MetadataUsageId;
extern RuntimeClass* Object_t1021602117_il2cpp_TypeInfo_var;
extern const uint32_t PlayMusic_Awake_m1001761935_MetadataUsageId;
extern const uint32_t PlayMusic__cctor_m2533931453_MetadataUsageId;



#ifndef U3CMODULEU3E_T3783534234_H
#define U3CMODULEU3E_T3783534234_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// <Module>
struct  U3CModuleU3E_t3783534234 
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // U3CMODULEU3E_T3783534234_H
#ifndef RUNTIMEOBJECT_H
#define RUNTIMEOBJECT_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Object

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // RUNTIMEOBJECT_H
struct Il2CppArrayBounds;
#ifndef RUNTIMEARRAY_H
#define RUNTIMEARRAY_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Array

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // RUNTIMEARRAY_H
#ifndef STRING_T_H
#define STRING_T_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.String
struct  String_t  : public RuntimeObject
{
public:
	// System.Int32 System.String::length
	int32_t ___length_0;
	// System.Char System.String::start_char
	Il2CppChar ___start_char_1;

public:
	inline static int32_t get_offset_of_length_0() { return static_cast<int32_t>(offsetof(String_t, ___length_0)); }
	inline int32_t get_length_0() const { return ___length_0; }
	inline int32_t* get_address_of_length_0() { return &___length_0; }
	inline void set_length_0(int32_t value)
	{
		___length_0 = value;
	}

	inline static int32_t get_offset_of_start_char_1() { return static_cast<int32_t>(offsetof(String_t, ___start_char_1)); }
	inline Il2CppChar get_start_char_1() const { return ___start_char_1; }
	inline Il2CppChar* get_address_of_start_char_1() { return &___start_char_1; }
	inline void set_start_char_1(Il2CppChar value)
	{
		___start_char_1 = value;
	}
};

struct String_t_StaticFields
{
public:
	// System.String System.String::Empty
	String_t* ___Empty_2;
	// System.Char[] System.String::WhiteChars
	CharU5BU5D_t1328083999* ___WhiteChars_3;

public:
	inline static int32_t get_offset_of_Empty_2() { return static_cast<int32_t>(offsetof(String_t_StaticFields, ___Empty_2)); }
	inline String_t* get_Empty_2() const { return ___Empty_2; }
	inline String_t** get_address_of_Empty_2() { return &___Empty_2; }
	inline void set_Empty_2(String_t* value)
	{
		___Empty_2 = value;
		Il2CppCodeGenWriteBarrier((&___Empty_2), value);
	}

	inline static int32_t get_offset_of_WhiteChars_3() { return static_cast<int32_t>(offsetof(String_t_StaticFields, ___WhiteChars_3)); }
	inline CharU5BU5D_t1328083999* get_WhiteChars_3() const { return ___WhiteChars_3; }
	inline CharU5BU5D_t1328083999** get_address_of_WhiteChars_3() { return &___WhiteChars_3; }
	inline void set_WhiteChars_3(CharU5BU5D_t1328083999* value)
	{
		___WhiteChars_3 = value;
		Il2CppCodeGenWriteBarrier((&___WhiteChars_3), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // STRING_T_H
#ifndef VALUETYPE_T3507792607_H
#define VALUETYPE_T3507792607_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.ValueType
struct  ValueType_t3507792607  : public RuntimeObject
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of System.ValueType
struct ValueType_t3507792607_marshaled_pinvoke
{
};
// Native definition for COM marshalling of System.ValueType
struct ValueType_t3507792607_marshaled_com
{
};
#endif // VALUETYPE_T3507792607_H
#ifndef ENUM_T2459695545_H
#define ENUM_T2459695545_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Enum
struct  Enum_t2459695545  : public ValueType_t3507792607
{
public:

public:
};

struct Enum_t2459695545_StaticFields
{
public:
	// System.Char[] System.Enum::split_char
	CharU5BU5D_t1328083999* ___split_char_0;

public:
	inline static int32_t get_offset_of_split_char_0() { return static_cast<int32_t>(offsetof(Enum_t2459695545_StaticFields, ___split_char_0)); }
	inline CharU5BU5D_t1328083999* get_split_char_0() const { return ___split_char_0; }
	inline CharU5BU5D_t1328083999** get_address_of_split_char_0() { return &___split_char_0; }
	inline void set_split_char_0(CharU5BU5D_t1328083999* value)
	{
		___split_char_0 = value;
		Il2CppCodeGenWriteBarrier((&___split_char_0), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of System.Enum
struct Enum_t2459695545_marshaled_pinvoke
{
};
// Native definition for COM marshalling of System.Enum
struct Enum_t2459695545_marshaled_com
{
};
#endif // ENUM_T2459695545_H
#ifndef INTPTR_T_H
#define INTPTR_T_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.IntPtr
struct  IntPtr_t 
{
public:
	// System.Void* System.IntPtr::m_value
	void* ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(IntPtr_t, ___m_value_0)); }
	inline void* get_m_value_0() const { return ___m_value_0; }
	inline void** get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(void* value)
	{
		___m_value_0 = value;
	}
};

struct IntPtr_t_StaticFields
{
public:
	// System.IntPtr System.IntPtr::Zero
	intptr_t ___Zero_1;

public:
	inline static int32_t get_offset_of_Zero_1() { return static_cast<int32_t>(offsetof(IntPtr_t_StaticFields, ___Zero_1)); }
	inline intptr_t get_Zero_1() const { return ___Zero_1; }
	inline intptr_t* get_address_of_Zero_1() { return &___Zero_1; }
	inline void set_Zero_1(intptr_t value)
	{
		___Zero_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // INTPTR_T_H
#ifndef BOOLEAN_T3825574718_H
#define BOOLEAN_T3825574718_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Boolean
struct  Boolean_t3825574718 
{
public:
	// System.Boolean System.Boolean::m_value
	bool ___m_value_2;

public:
	inline static int32_t get_offset_of_m_value_2() { return static_cast<int32_t>(offsetof(Boolean_t3825574718, ___m_value_2)); }
	inline bool get_m_value_2() const { return ___m_value_2; }
	inline bool* get_address_of_m_value_2() { return &___m_value_2; }
	inline void set_m_value_2(bool value)
	{
		___m_value_2 = value;
	}
};

struct Boolean_t3825574718_StaticFields
{
public:
	// System.String System.Boolean::FalseString
	String_t* ___FalseString_0;
	// System.String System.Boolean::TrueString
	String_t* ___TrueString_1;

public:
	inline static int32_t get_offset_of_FalseString_0() { return static_cast<int32_t>(offsetof(Boolean_t3825574718_StaticFields, ___FalseString_0)); }
	inline String_t* get_FalseString_0() const { return ___FalseString_0; }
	inline String_t** get_address_of_FalseString_0() { return &___FalseString_0; }
	inline void set_FalseString_0(String_t* value)
	{
		___FalseString_0 = value;
		Il2CppCodeGenWriteBarrier((&___FalseString_0), value);
	}

	inline static int32_t get_offset_of_TrueString_1() { return static_cast<int32_t>(offsetof(Boolean_t3825574718_StaticFields, ___TrueString_1)); }
	inline String_t* get_TrueString_1() const { return ___TrueString_1; }
	inline String_t** get_address_of_TrueString_1() { return &___TrueString_1; }
	inline void set_TrueString_1(String_t* value)
	{
		___TrueString_1 = value;
		Il2CppCodeGenWriteBarrier((&___TrueString_1), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // BOOLEAN_T3825574718_H
#ifndef VOID_T1841601450_H
#define VOID_T1841601450_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Void
struct  Void_t1841601450 
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // VOID_T1841601450_H
#ifndef OBJECT_T1021602117_H
#define OBJECT_T1021602117_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Object
struct  Object_t1021602117  : public RuntimeObject
{
public:
	// System.IntPtr UnityEngine.Object::m_CachedPtr
	intptr_t ___m_CachedPtr_0;

public:
	inline static int32_t get_offset_of_m_CachedPtr_0() { return static_cast<int32_t>(offsetof(Object_t1021602117, ___m_CachedPtr_0)); }
	inline intptr_t get_m_CachedPtr_0() const { return ___m_CachedPtr_0; }
	inline intptr_t* get_address_of_m_CachedPtr_0() { return &___m_CachedPtr_0; }
	inline void set_m_CachedPtr_0(intptr_t value)
	{
		___m_CachedPtr_0 = value;
	}
};

struct Object_t1021602117_StaticFields
{
public:
	// System.Int32 UnityEngine.Object::OffsetOfInstanceIDInCPlusPlusObject
	int32_t ___OffsetOfInstanceIDInCPlusPlusObject_1;

public:
	inline static int32_t get_offset_of_OffsetOfInstanceIDInCPlusPlusObject_1() { return static_cast<int32_t>(offsetof(Object_t1021602117_StaticFields, ___OffsetOfInstanceIDInCPlusPlusObject_1)); }
	inline int32_t get_OffsetOfInstanceIDInCPlusPlusObject_1() const { return ___OffsetOfInstanceIDInCPlusPlusObject_1; }
	inline int32_t* get_address_of_OffsetOfInstanceIDInCPlusPlusObject_1() { return &___OffsetOfInstanceIDInCPlusPlusObject_1; }
	inline void set_OffsetOfInstanceIDInCPlusPlusObject_1(int32_t value)
	{
		___OffsetOfInstanceIDInCPlusPlusObject_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of UnityEngine.Object
struct Object_t1021602117_marshaled_pinvoke
{
	intptr_t ___m_CachedPtr_0;
};
// Native definition for COM marshalling of UnityEngine.Object
struct Object_t1021602117_marshaled_com
{
	intptr_t ___m_CachedPtr_0;
};
#endif // OBJECT_T1021602117_H
#ifndef LOADSCENEMODE_T2981886439_H
#define LOADSCENEMODE_T2981886439_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.SceneManagement.LoadSceneMode
struct  LoadSceneMode_t2981886439 
{
public:
	// System.Int32 UnityEngine.SceneManagement.LoadSceneMode::value__
	int32_t ___value___1;

public:
	inline static int32_t get_offset_of_value___1() { return static_cast<int32_t>(offsetof(LoadSceneMode_t2981886439, ___value___1)); }
	inline int32_t get_value___1() const { return ___value___1; }
	inline int32_t* get_address_of_value___1() { return &___value___1; }
	inline void set_value___1(int32_t value)
	{
		___value___1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // LOADSCENEMODE_T2981886439_H
#ifndef GAMEOBJECT_T1756533147_H
#define GAMEOBJECT_T1756533147_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.GameObject
struct  GameObject_t1756533147  : public Object_t1021602117
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // GAMEOBJECT_T1756533147_H
#ifndef COMPONENT_T3819376471_H
#define COMPONENT_T3819376471_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Component
struct  Component_t3819376471  : public Object_t1021602117
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // COMPONENT_T3819376471_H
#ifndef BEHAVIOUR_T955675639_H
#define BEHAVIOUR_T955675639_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Behaviour
struct  Behaviour_t955675639  : public Component_t3819376471
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // BEHAVIOUR_T955675639_H
#ifndef AUDIOSOURCE_T1135106623_H
#define AUDIOSOURCE_T1135106623_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.AudioSource
struct  AudioSource_t1135106623  : public Behaviour_t955675639
{
public:
	// UnityEngine.AudioSourceExtension UnityEngine.AudioSource::spatializerExtension
	AudioSourceExtension_t1813599864 * ___spatializerExtension_2;
	// UnityEngine.AudioSourceExtension UnityEngine.AudioSource::ambisonicExtension
	AudioSourceExtension_t1813599864 * ___ambisonicExtension_3;

public:
	inline static int32_t get_offset_of_spatializerExtension_2() { return static_cast<int32_t>(offsetof(AudioSource_t1135106623, ___spatializerExtension_2)); }
	inline AudioSourceExtension_t1813599864 * get_spatializerExtension_2() const { return ___spatializerExtension_2; }
	inline AudioSourceExtension_t1813599864 ** get_address_of_spatializerExtension_2() { return &___spatializerExtension_2; }
	inline void set_spatializerExtension_2(AudioSourceExtension_t1813599864 * value)
	{
		___spatializerExtension_2 = value;
		Il2CppCodeGenWriteBarrier((&___spatializerExtension_2), value);
	}

	inline static int32_t get_offset_of_ambisonicExtension_3() { return static_cast<int32_t>(offsetof(AudioSource_t1135106623, ___ambisonicExtension_3)); }
	inline AudioSourceExtension_t1813599864 * get_ambisonicExtension_3() const { return ___ambisonicExtension_3; }
	inline AudioSourceExtension_t1813599864 ** get_address_of_ambisonicExtension_3() { return &___ambisonicExtension_3; }
	inline void set_ambisonicExtension_3(AudioSourceExtension_t1813599864 * value)
	{
		___ambisonicExtension_3 = value;
		Il2CppCodeGenWriteBarrier((&___ambisonicExtension_3), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // AUDIOSOURCE_T1135106623_H
#ifndef MONOBEHAVIOUR_T1158329972_H
#define MONOBEHAVIOUR_T1158329972_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.MonoBehaviour
struct  MonoBehaviour_t1158329972  : public Behaviour_t955675639
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // MONOBEHAVIOUR_T1158329972_H
#ifndef PROGRESSBAR_T192201240_H
#define PROGRESSBAR_T192201240_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ProgressBar
struct  ProgressBar_t192201240  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.Texture2D ProgressBar::progressBarEmpty
	Texture2D_t3542995729 * ___progressBarEmpty_2;
	// UnityEngine.Texture2D ProgressBar::progressBarFull
	Texture2D_t3542995729 * ___progressBarFull_3;

public:
	inline static int32_t get_offset_of_progressBarEmpty_2() { return static_cast<int32_t>(offsetof(ProgressBar_t192201240, ___progressBarEmpty_2)); }
	inline Texture2D_t3542995729 * get_progressBarEmpty_2() const { return ___progressBarEmpty_2; }
	inline Texture2D_t3542995729 ** get_address_of_progressBarEmpty_2() { return &___progressBarEmpty_2; }
	inline void set_progressBarEmpty_2(Texture2D_t3542995729 * value)
	{
		___progressBarEmpty_2 = value;
		Il2CppCodeGenWriteBarrier((&___progressBarEmpty_2), value);
	}

	inline static int32_t get_offset_of_progressBarFull_3() { return static_cast<int32_t>(offsetof(ProgressBar_t192201240, ___progressBarFull_3)); }
	inline Texture2D_t3542995729 * get_progressBarFull_3() const { return ___progressBarFull_3; }
	inline Texture2D_t3542995729 ** get_address_of_progressBarFull_3() { return &___progressBarFull_3; }
	inline void set_progressBarFull_3(Texture2D_t3542995729 * value)
	{
		___progressBarFull_3 = value;
		Il2CppCodeGenWriteBarrier((&___progressBarFull_3), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // PROGRESSBAR_T192201240_H
#ifndef MUTEUNMUTEMUSIC_T1642836682_H
#define MUTEUNMUTEMUSIC_T1642836682_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// MuteUnmuteMusic
struct  MuteUnmuteMusic_t1642836682  : public MonoBehaviour_t1158329972
{
public:
	// System.Boolean MuteUnmuteMusic::Music
	bool ___Music_2;

public:
	inline static int32_t get_offset_of_Music_2() { return static_cast<int32_t>(offsetof(MuteUnmuteMusic_t1642836682, ___Music_2)); }
	inline bool get_Music_2() const { return ___Music_2; }
	inline bool* get_address_of_Music_2() { return &___Music_2; }
	inline void set_Music_2(bool value)
	{
		___Music_2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // MUTEUNMUTEMUSIC_T1642836682_H
#ifndef PLAYMUSIC_T2005096559_H
#define PLAYMUSIC_T2005096559_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayMusic
struct  PlayMusic_t2005096559  : public MonoBehaviour_t1158329972
{
public:

public:
};

struct PlayMusic_t2005096559_StaticFields
{
public:
	// PlayMusic PlayMusic::instance
	PlayMusic_t2005096559 * ___instance_2;

public:
	inline static int32_t get_offset_of_instance_2() { return static_cast<int32_t>(offsetof(PlayMusic_t2005096559_StaticFields, ___instance_2)); }
	inline PlayMusic_t2005096559 * get_instance_2() const { return ___instance_2; }
	inline PlayMusic_t2005096559 ** get_address_of_instance_2() { return &___instance_2; }
	inline void set_instance_2(PlayMusic_t2005096559 * value)
	{
		___instance_2 = value;
		Il2CppCodeGenWriteBarrier((&___instance_2), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // PLAYMUSIC_T2005096559_H
#ifndef CHANGESCENE_T2085063124_H
#define CHANGESCENE_T2085063124_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// changeScene
struct  changeScene_t2085063124  : public MonoBehaviour_t1158329972
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // CHANGESCENE_T2085063124_H
#ifndef PAUSEMUSIC_T2827853909_H
#define PAUSEMUSIC_T2827853909_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PauseMusic
struct  PauseMusic_t2827853909  : public MonoBehaviour_t1158329972
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // PAUSEMUSIC_T2827853909_H


// !!0 UnityEngine.GameObject::GetComponent<System.Object>()
extern "C"  RuntimeObject * GameObject_GetComponent_TisRuntimeObject_m2812611596_gshared (GameObject_t1756533147 * __this, const RuntimeMethod* method);

// System.Void UnityEngine.MonoBehaviour::.ctor()
extern "C"  void MonoBehaviour__ctor_m1825328214 (MonoBehaviour_t1158329972 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void UnityEngine.SceneManagement.SceneManager::LoadScene(System.String,UnityEngine.SceneManagement.LoadSceneMode)
extern "C"  void SceneManager_LoadScene_m3031418609 (RuntimeObject * __this /* static, unused */, String_t* p0, int32_t p1, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// PlayMusic PlayMusic::get_Instance()
extern "C"  PlayMusic_t2005096559 * PlayMusic_get_Instance_m3170436882 (RuntimeObject * __this /* static, unused */, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// UnityEngine.GameObject UnityEngine.Component::get_gameObject()
extern "C"  GameObject_t1756533147 * Component_get_gameObject_m2159020946 (Component_t3819376471 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// !!0 UnityEngine.GameObject::GetComponent<UnityEngine.AudioSource>()
#define GameObject_GetComponent_TisAudioSource_t1135106623_m3309832039(__this, method) ((  AudioSource_t1135106623 * (*) (GameObject_t1756533147 *, const RuntimeMethod*))GameObject_GetComponent_TisRuntimeObject_m2812611596_gshared)(__this, method)
// System.Void UnityEngine.AudioSource::set_mute(System.Boolean)
extern "C"  void AudioSource_set_mute_m2903354555 (AudioSource_t1135106623 * __this, bool p0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void UnityEngine.AudioSource::Pause()
extern "C"  void AudioSource_Pause_m4211249198 (AudioSource_t1135106623 * __this, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Boolean UnityEngine.Object::op_Inequality(UnityEngine.Object,UnityEngine.Object)
extern "C"  bool Object_op_Inequality_m3768854296 (RuntimeObject * __this /* static, unused */, Object_t1021602117 * p0, Object_t1021602117 * p1, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void UnityEngine.Object::Destroy(UnityEngine.Object)
extern "C"  void Object_Destroy_m3959286051 (RuntimeObject * __this /* static, unused */, Object_t1021602117 * p0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
// System.Void UnityEngine.Object::DontDestroyOnLoad(UnityEngine.Object)
extern "C"  void Object_DontDestroyOnLoad_m2658633409 (RuntimeObject * __this /* static, unused */, Object_t1021602117 * p0, const RuntimeMethod* method) IL2CPP_METHOD_ATTR;
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void changeScene::.ctor()
extern "C"  void changeScene__ctor_m2573961399 (changeScene_t2085063124 * __this, const RuntimeMethod* method)
{
	{
		MonoBehaviour__ctor_m1825328214(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.Void changeScene::Start()
extern "C"  void changeScene_Start_m1283540315 (changeScene_t2085063124 * __this, const RuntimeMethod* method)
{
	{
		// }
		return;
	}
}
// System.Void changeScene::Update()
extern "C"  void changeScene_Update_m3884375474 (changeScene_t2085063124 * __this, const RuntimeMethod* method)
{
	{
		// }
		return;
	}
}
// System.Void changeScene::changeToScene()
extern "C"  void changeScene_changeToScene_m1126648592 (changeScene_t2085063124 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (changeScene_changeToScene_m1126648592_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		// SceneManager.LoadScene ("Main Scene", LoadSceneMode.Additive);
		// SceneManager.LoadScene ("Main Scene", LoadSceneMode.Additive);
		SceneManager_LoadScene_m3031418609(NULL /*static, unused*/, _stringLiteral1572100361, 1, /*hidden argument*/NULL);
		// }
		return;
	}
}
// System.Void changeScene::changeToSettingsScene()
extern "C"  void changeScene_changeToSettingsScene_m517506769 (changeScene_t2085063124 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (changeScene_changeToSettingsScene_m517506769_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		// SceneManager.LoadScene ("Settings Scene", LoadSceneMode.Additive);
		// SceneManager.LoadScene ("Settings Scene", LoadSceneMode.Additive);
		SceneManager_LoadScene_m3031418609(NULL /*static, unused*/, _stringLiteral2042359555, 1, /*hidden argument*/NULL);
		// }
		return;
	}
}
// System.Void changeScene::changeToFlowerPickerScene()
extern "C"  void changeScene_changeToFlowerPickerScene_m4223595579 (changeScene_t2085063124 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (changeScene_changeToFlowerPickerScene_m4223595579_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		// SceneManager.LoadScene ("Flower Picker Scene", LoadSceneMode.Additive);
		// SceneManager.LoadScene ("Flower Picker Scene", LoadSceneMode.Additive);
		SceneManager_LoadScene_m3031418609(NULL /*static, unused*/, _stringLiteral3375240061, 1, /*hidden argument*/NULL);
		// }
		return;
	}
}
// System.Void changeScene::changeToTeacupPickerScene()
extern "C"  void changeScene_changeToTeacupPickerScene_m4237967508 (changeScene_t2085063124 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (changeScene_changeToTeacupPickerScene_m4237967508_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		// SceneManager.LoadScene ("Teacup Picker Scene", LoadSceneMode.Additive);
		// SceneManager.LoadScene ("Teacup Picker Scene", LoadSceneMode.Additive);
		SceneManager_LoadScene_m3031418609(NULL /*static, unused*/, _stringLiteral57323982, 1, /*hidden argument*/NULL);
		// }
		return;
	}
}
// System.Void changeScene::changeToTitleScene()
extern "C"  void changeScene_changeToTitleScene_m2891124892 (changeScene_t2085063124 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (changeScene_changeToTitleScene_m2891124892_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		// SceneManager.LoadScene ("Title Scene", LoadSceneMode.Additive);
		// SceneManager.LoadScene ("Title Scene", LoadSceneMode.Additive);
		SceneManager_LoadScene_m3031418609(NULL /*static, unused*/, _stringLiteral4182229268, 1, /*hidden argument*/NULL);
		// }
		return;
	}
}
// System.Void MuteUnmuteMusic::.ctor()
extern "C"  void MuteUnmuteMusic__ctor_m148030921 (MuteUnmuteMusic_t1642836682 * __this, const RuntimeMethod* method)
{
	{
		// bool Music = true;
		__this->set_Music_2((bool)1);
		MonoBehaviour__ctor_m1825328214(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.Void MuteUnmuteMusic::Start()
extern "C"  void MuteUnmuteMusic_Start_m399746513 (MuteUnmuteMusic_t1642836682 * __this, const RuntimeMethod* method)
{
	{
		// }
		return;
	}
}
// System.Void MuteUnmuteMusic::MuteUnmute()
extern "C"  void MuteUnmuteMusic_MuteUnmute_m4062677570 (MuteUnmuteMusic_t1642836682 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (MuteUnmuteMusic_MuteUnmute_m4062677570_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (Music == true){
		bool L_0 = __this->get_Music_2();
		if (!L_0)
		{
			goto IL_002f;
		}
	}
	{
		// Music = false;
		__this->set_Music_2((bool)0);
		// PlayMusic.Instance.gameObject.GetComponent<AudioSource> ().mute = true;
		IL2CPP_RUNTIME_CLASS_INIT(PlayMusic_t2005096559_il2cpp_TypeInfo_var);
		PlayMusic_t2005096559 * L_1 = PlayMusic_get_Instance_m3170436882(NULL /*static, unused*/, /*hidden argument*/NULL);
		// PlayMusic.Instance.gameObject.GetComponent<AudioSource> ().mute = true;
		NullCheck(L_1);
		GameObject_t1756533147 * L_2 = Component_get_gameObject_m2159020946(L_1, /*hidden argument*/NULL);
		// PlayMusic.Instance.gameObject.GetComponent<AudioSource> ().mute = true;
		NullCheck(L_2);
		AudioSource_t1135106623 * L_3 = GameObject_GetComponent_TisAudioSource_t1135106623_m3309832039(L_2, /*hidden argument*/GameObject_GetComponent_TisAudioSource_t1135106623_m3309832039_RuntimeMethod_var);
		// PlayMusic.Instance.gameObject.GetComponent<AudioSource> ().mute = true;
		NullCheck(L_3);
		AudioSource_set_mute_m2903354555(L_3, (bool)1, /*hidden argument*/NULL);
		goto IL_004d;
	}

IL_002f:
	{
		// Music = true;
		__this->set_Music_2((bool)1);
		// PlayMusic.Instance.gameObject.GetComponent<AudioSource> ().mute = false;
		IL2CPP_RUNTIME_CLASS_INIT(PlayMusic_t2005096559_il2cpp_TypeInfo_var);
		PlayMusic_t2005096559 * L_4 = PlayMusic_get_Instance_m3170436882(NULL /*static, unused*/, /*hidden argument*/NULL);
		// PlayMusic.Instance.gameObject.GetComponent<AudioSource> ().mute = false;
		NullCheck(L_4);
		GameObject_t1756533147 * L_5 = Component_get_gameObject_m2159020946(L_4, /*hidden argument*/NULL);
		// PlayMusic.Instance.gameObject.GetComponent<AudioSource> ().mute = false;
		NullCheck(L_5);
		AudioSource_t1135106623 * L_6 = GameObject_GetComponent_TisAudioSource_t1135106623_m3309832039(L_5, /*hidden argument*/GameObject_GetComponent_TisAudioSource_t1135106623_m3309832039_RuntimeMethod_var);
		// PlayMusic.Instance.gameObject.GetComponent<AudioSource> ().mute = false;
		NullCheck(L_6);
		AudioSource_set_mute_m2903354555(L_6, (bool)0, /*hidden argument*/NULL);
	}

IL_004d:
	{
		// }
		return;
	}
}
// System.Void MuteUnmuteMusic::Update()
extern "C"  void MuteUnmuteMusic_Update_m3961205132 (MuteUnmuteMusic_t1642836682 * __this, const RuntimeMethod* method)
{
	{
		// }
		return;
	}
}
// System.Void PauseMusic::.ctor()
extern "C"  void PauseMusic__ctor_m3012263872 (PauseMusic_t2827853909 * __this, const RuntimeMethod* method)
{
	{
		MonoBehaviour__ctor_m1825328214(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.Void PauseMusic::Start()
extern "C"  void PauseMusic_Start_m478704704 (PauseMusic_t2827853909 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (PauseMusic_Start_m478704704_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		// PlayMusic.Instance.gameObject.GetComponent<AudioSource> ().Pause ();
		IL2CPP_RUNTIME_CLASS_INIT(PlayMusic_t2005096559_il2cpp_TypeInfo_var);
		PlayMusic_t2005096559 * L_0 = PlayMusic_get_Instance_m3170436882(NULL /*static, unused*/, /*hidden argument*/NULL);
		// PlayMusic.Instance.gameObject.GetComponent<AudioSource> ().Pause ();
		NullCheck(L_0);
		GameObject_t1756533147 * L_1 = Component_get_gameObject_m2159020946(L_0, /*hidden argument*/NULL);
		// PlayMusic.Instance.gameObject.GetComponent<AudioSource> ().Pause ();
		NullCheck(L_1);
		AudioSource_t1135106623 * L_2 = GameObject_GetComponent_TisAudioSource_t1135106623_m3309832039(L_1, /*hidden argument*/GameObject_GetComponent_TisAudioSource_t1135106623_m3309832039_RuntimeMethod_var);
		// PlayMusic.Instance.gameObject.GetComponent<AudioSource> ().Pause ();
		NullCheck(L_2);
		AudioSource_Pause_m4211249198(L_2, /*hidden argument*/NULL);
		// }
		return;
	}
}
// System.Void PauseMusic::Update()
extern "C"  void PauseMusic_Update_m1933231169 (PauseMusic_t2827853909 * __this, const RuntimeMethod* method)
{
	{
		// }
		return;
	}
}
// System.Void PlayMusic::.ctor()
extern "C"  void PlayMusic__ctor_m2935226632 (PlayMusic_t2005096559 * __this, const RuntimeMethod* method)
{
	{
		MonoBehaviour__ctor_m1825328214(__this, /*hidden argument*/NULL);
		return;
	}
}
// PlayMusic PlayMusic::get_Instance()
extern "C"  PlayMusic_t2005096559 * PlayMusic_get_Instance_m3170436882 (RuntimeObject * __this /* static, unused */, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (PlayMusic_get_Instance_m3170436882_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	PlayMusic_t2005096559 * V_0 = NULL;
	{
		// get { return instance; }
		IL2CPP_RUNTIME_CLASS_INIT(PlayMusic_t2005096559_il2cpp_TypeInfo_var);
		PlayMusic_t2005096559 * L_0 = ((PlayMusic_t2005096559_StaticFields*)il2cpp_codegen_static_fields_for(PlayMusic_t2005096559_il2cpp_TypeInfo_var))->get_instance_2();
		V_0 = L_0;
		goto IL_000c;
	}

IL_000c:
	{
		// get { return instance; }
		PlayMusic_t2005096559 * L_1 = V_0;
		return L_1;
	}
}
// System.Void PlayMusic::Awake()
extern "C"  void PlayMusic_Awake_m1001761935 (PlayMusic_t2005096559 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (PlayMusic_Awake_m1001761935_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (instance != null && instance != this) {
		IL2CPP_RUNTIME_CLASS_INIT(PlayMusic_t2005096559_il2cpp_TypeInfo_var);
		PlayMusic_t2005096559 * L_0 = ((PlayMusic_t2005096559_StaticFields*)il2cpp_codegen_static_fields_for(PlayMusic_t2005096559_il2cpp_TypeInfo_var))->get_instance_2();
		// if (instance != null && instance != this) {
		IL2CPP_RUNTIME_CLASS_INIT(Object_t1021602117_il2cpp_TypeInfo_var);
		bool L_1 = Object_op_Inequality_m3768854296(NULL /*static, unused*/, L_0, (Object_t1021602117 *)NULL, /*hidden argument*/NULL);
		if (!L_1)
		{
			goto IL_0032;
		}
	}
	{
		IL2CPP_RUNTIME_CLASS_INIT(PlayMusic_t2005096559_il2cpp_TypeInfo_var);
		PlayMusic_t2005096559 * L_2 = ((PlayMusic_t2005096559_StaticFields*)il2cpp_codegen_static_fields_for(PlayMusic_t2005096559_il2cpp_TypeInfo_var))->get_instance_2();
		// if (instance != null && instance != this) {
		IL2CPP_RUNTIME_CLASS_INIT(Object_t1021602117_il2cpp_TypeInfo_var);
		bool L_3 = Object_op_Inequality_m3768854296(NULL /*static, unused*/, L_2, __this, /*hidden argument*/NULL);
		if (!L_3)
		{
			goto IL_0032;
		}
	}
	{
		// Destroy (this.gameObject);
		// Destroy (this.gameObject);
		GameObject_t1756533147 * L_4 = Component_get_gameObject_m2159020946(__this, /*hidden argument*/NULL);
		// Destroy (this.gameObject);
		IL2CPP_RUNTIME_CLASS_INIT(Object_t1021602117_il2cpp_TypeInfo_var);
		Object_Destroy_m3959286051(NULL /*static, unused*/, L_4, /*hidden argument*/NULL);
		// return;
		goto IL_0045;
	}

IL_0032:
	{
		// instance = this;
		IL2CPP_RUNTIME_CLASS_INIT(PlayMusic_t2005096559_il2cpp_TypeInfo_var);
		((PlayMusic_t2005096559_StaticFields*)il2cpp_codegen_static_fields_for(PlayMusic_t2005096559_il2cpp_TypeInfo_var))->set_instance_2(__this);
		// DontDestroyOnLoad (this.gameObject);
		// DontDestroyOnLoad (this.gameObject);
		GameObject_t1756533147 * L_5 = Component_get_gameObject_m2159020946(__this, /*hidden argument*/NULL);
		// DontDestroyOnLoad (this.gameObject);
		IL2CPP_RUNTIME_CLASS_INIT(Object_t1021602117_il2cpp_TypeInfo_var);
		Object_DontDestroyOnLoad_m2658633409(NULL /*static, unused*/, L_5, /*hidden argument*/NULL);
	}

IL_0045:
	{
		// }
		return;
	}
}
// System.Void PlayMusic::Start()
extern "C"  void PlayMusic_Start_m2127494708 (PlayMusic_t2005096559 * __this, const RuntimeMethod* method)
{
	{
		// }
		return;
	}
}
// System.Void PlayMusic::Update()
extern "C"  void PlayMusic_Update_m2012966491 (PlayMusic_t2005096559 * __this, const RuntimeMethod* method)
{
	{
		// }
		return;
	}
}
// System.Void PlayMusic::.cctor()
extern "C"  void PlayMusic__cctor_m2533931453 (RuntimeObject * __this /* static, unused */, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (PlayMusic__cctor_m2533931453_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		// private static PlayMusic instance = null;
		((PlayMusic_t2005096559_StaticFields*)il2cpp_codegen_static_fields_for(PlayMusic_t2005096559_il2cpp_TypeInfo_var))->set_instance_2((PlayMusic_t2005096559 *)NULL);
		return;
	}
}
// System.Void ProgressBar::.ctor()
extern "C"  void ProgressBar__ctor_m4144027091 (ProgressBar_t192201240 * __this, const RuntimeMethod* method)
{
	{
		MonoBehaviour__ctor_m1825328214(__this, /*hidden argument*/NULL);
		return;
	}
}
// System.Void ProgressBar::Start()
extern "C"  void ProgressBar_Start_m2539731103 (ProgressBar_t192201240 * __this, const RuntimeMethod* method)
{
	{
		// }
		return;
	}
}
// System.Void ProgressBar::Update()
extern "C"  void ProgressBar_Update_m3399376918 (ProgressBar_t192201240 * __this, const RuntimeMethod* method)
{
	{
		// }
		return;
	}
}
// System.Void ProgressBar::OnGUI()
extern "C"  void ProgressBar_OnGUI_m125667813 (ProgressBar_t192201240 * __this, const RuntimeMethod* method)
{
	{
		// }
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
