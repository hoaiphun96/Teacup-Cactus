using UnityEngine;
using System.Collections;
using System;

public class UtilsPlugin : MonoBehaviour
{
	
	private static UtilsPlugin instance;
	private static GameObject container;
	private static AUPHolder aupHolder;
	private const string TAG = "[UtilsPlugin]: ";
	
	#if UNITY_ANDROID
	private static AndroidJavaObject jo;
	#endif
	
	public bool isDebug = true;

	public static UtilsPlugin GetInstance ()
	{
		if (instance == null) {
			container = new GameObject ();
			container.name = "UtilsPlugin";
			instance = container.AddComponent (typeof(UtilsPlugin)) as UtilsPlugin;
			DontDestroyOnLoad (instance.gameObject);
			aupHolder = AUPHolder.GetInstance ();
			instance.gameObject.transform.SetParent (aupHolder.gameObject.transform);
		}
		
		return instance;
	}

	private void Awake ()
	{
		#if UNITY_ANDROID
		if (Application.platform == RuntimePlatform.Android) {
			jo = new AndroidJavaObject ("com.gigadrillgames.androidplugin.utils.UtilsPlugin");
		}
		#endif
	}

	/// <summary>
	/// Sets the debug.
	/// 0 - false, 1 - true
	/// </summary>
	/// <param name="debug">Debug.</param>
	public void SetDebug (int debug)
	{
		#if UNITY_ANDROID
		if (Application.platform == RuntimePlatform.Android) {
			jo.CallStatic ("SetDebug", debug);
		} else {
			AUP.Utils.Message (TAG, "warning: must run in actual android device");
		}
		#endif
	}
	
	
	//----------------------------------------------[Immersive]-------------------------------------------------------------
	//immersive
	//only support kitkat and above version
	/// <summary>
	/// set immersive mode on
	/// , note:only support kitkat and above android version 4.4 api 19
	/// </summary>
	/// <param name="delay">Delay.</param>
	public void ImmersiveOn (int delay)
	{
		#if UNITY_ANDROID
		if (Application.platform == RuntimePlatform.Android) {
			jo.CallStatic ("immersiveOn", delay);
		} else {
			AUP.Utils.Message (TAG, "warning: must run in actual android device");
		}
		#endif
	}

	/// <summary>
	/// Immersives the off.
	/// </summary>
	public void ImmersiveOff ()
	{
		#if UNITY_ANDROID
		if (Application.platform == RuntimePlatform.Android) {
			jo.CallStatic ("immersiveOff");
		} else {
			AUP.Utils.Message (TAG, "warning: must run in actual android device");
		}
		#endif
	}
	
	//----------------------------------------------[Immersive]-------------------------------------------------------------
	
	
	//----------------------------------------------[Android Native UI]-------------------------------------------------------------
	/// <summary>
	/// Shows the toast message.
	/// </summary>
	/// <param name="message">Message.</param>
	public void ShowToastMessage (String message)
	{
		#if UNITY_ANDROID
		if (Application.platform == RuntimePlatform.Android) {
			jo.CallStatic ("showToastMessage", message);
		} else {
			AUP.Utils.Message (TAG, "warning: must run in actual android device");
		}
		#endif
	}
	
	
	//native popup
	//rate us
	/// <summary>
	/// Shows the  native rate popup.
	/// </summary>
	/// <param name="title">Title.</param>
	/// <param name="message">Message.</param>
	/// <param name="url">URL.</param>
	public void ShowRatePopup (String title, String message, String url)
	{
		#if UNITY_ANDROID
		if (Application.platform == RuntimePlatform.Android) {
			jo.CallStatic ("showRatePopup", title, message, url);
		} else {
			AUP.Utils.Message (TAG, "warning: must run in actual android device");
		}
		#endif
	}

	/// <summary>
	/// Shows the native alert popup.
	/// </summary>
	/// <param name="title">Title.</param>
	/// <param name="message">Message.</param>
	public void ShowAlertPopup (String title, String message)
	{
		#if UNITY_ANDROID
		if (Application.platform == RuntimePlatform.Android) {
			jo.CallStatic ("showNativePopup", title, message);
		} else {
			AUP.Utils.Message (TAG, "warning: must run in actual android device");
		}
		#endif
	}
	//native popup
	
	//native loading
	/// <summary>
	/// Shows the native loading.
	/// </summary>
	/// <param name="message">Message.</param>
	/// <param name="isCancelable">If set to <c>true</c> is cancelable.</param>
	public void ShowNativeLoading (String message, bool isCancelable)
	{
		#if UNITY_ANDROID
		if (Application.platform == RuntimePlatform.Android) {
			jo.CallStatic ("showNativeLoading", message, isCancelable);
		} else {
			AUP.Utils.Message (TAG, "warning: must run in actual android device");
		}
		#endif
	}

	/// <summary>
	/// Hides the native loading.
	/// </summary>
	public void HideNativeLoading ()
	{
		#if UNITY_ANDROID
		if (Application.platform == RuntimePlatform.Android) {
			jo.CallStatic ("hideNativeLoading");
		} else {
			AUP.Utils.Message (TAG, "warning: must run in actual android device");
		}
		#endif
	}
	//----------------------------------------------[Android Native UI]-------------------------------------------------------------
	
	
	//----------------------------------------------[Android Information]-------------------------------------------------------------
	/// <summary>
	/// Gets the package identifier.
	/// </summary>
	/// <returns>The package identifier.</returns>
	public String GetPackageId ()
	{
		#if UNITY_ANDROID
		if (Application.platform == RuntimePlatform.Android) {
			return jo.CallStatic<String> ("getPackageId");
		} else {
			AUP.Utils.Message (TAG, "warning: must run in actual android device");
		}
		#endif
		
		return "";
	}

	/// <summary>
	/// Gets the android version.
	/// </summary>
	/// <returns>The android version.</returns>
	public String GetAndroidVersion ()
	{
		#if UNITY_ANDROID
		if (Application.platform == RuntimePlatform.Android) {
			return jo.CallStatic<String> ("getAndroidVersion");
		} else {
			AUP.Utils.Message (TAG, "warning: must run in actual android device");
		}
		#endif
		
		return "";
	}
	//----------------------------------------------[Android Information]-------------------------------------------------------------

	/// <summary>
	/// Creates the folder.
	/// </summary>
	/// <returns>The folder directory path if successful else return "".</returns>
	/// <param name="folderName">Folder name.</param>
	/// <param name="dir">if 1 picture directory, if 2 DCIM directory, default picture directory</param>
	public String CreateFolder (string folderName, int dir)
	{
		#if UNITY_ANDROID
		if (Application.platform == RuntimePlatform.Android) {
			return jo.CallStatic<String> ("createFolder", folderName, dir);
		} else {
			AUP.Utils.Message (TAG, "warning: must run in actual android device");
		}
		#endif
		
		return "";
	}

	public String GetDCIMPath ()
	{
		#if UNITY_ANDROID
		if (Application.platform == RuntimePlatform.Android) {
			return jo.CallStatic<String> ("getDCIMPath");
		} else {
			AUP.Utils.Message (TAG, "warning: must run in actual android device");
		}
		#endif
		
		return "";
	}

	public String GetPicturePath ()
	{
		#if UNITY_ANDROID
		if (Application.platform == RuntimePlatform.Android) {
			return jo.CallStatic<String> ("getPicturePath");
		} else {
			AUP.Utils.Message (TAG, "warning: must run in actual android device");
		}
		#endif
		
		return "";
	}

	/// <summary>
	/// Determines whether the current android device has a step detector
	/// </summary>
	/// <returns><c>true</c> if this current android device has a step detector feature; otherwise, <c>false</c>.</returns>
	public bool HasStepDetector ()
	{
		#if UNITY_ANDROID
		if (Application.platform == RuntimePlatform.Android) {
			return jo.CallStatic<bool> ("hasStepDetector");
		} else {
			AUP.Utils.Message (TAG, "warning: must run in actual android device");
		}
		#endif
		
		return false;
	}

	public bool HasStepCounter ()
	{
		#if UNITY_ANDROID
		if (Application.platform == RuntimePlatform.Android) {
			return jo.CallStatic<bool> ("hasStepCounter");
		} else {
			AUP.Utils.Message (TAG, "warning: must run in actual android device");
		}
		#endif

		return false;
	}
}