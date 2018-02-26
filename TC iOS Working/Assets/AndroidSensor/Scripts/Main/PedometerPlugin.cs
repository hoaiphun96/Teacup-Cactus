using UnityEngine;
using System.Collections;
using System;

public class PedometerPlugin : MonoBehaviour {
	// events where you can listen
	private Action <int>LoadTotalStepCount;
	public event Action <int>OnLoadTotalStepCount{
		add{ LoadTotalStepCount+=value;}
		remove{ LoadTotalStepCount-=value;}
	}

	private Action <int>LoadTotalStepToday;
	public event Action <int>OnLoadTotalStepToday{
		add{ LoadTotalStepToday+=value;}
		remove{ LoadTotalStepToday-=value;}
	}

	private Action <int>LoadPrevStepCount;
	public event Action <int>OnLoadPrevStepCount{
		add{ LoadPrevStepCount+=value;}
		remove{ LoadPrevStepCount-=value;}
	}

	private Action StepDetect;
	public event Action OnStepDetect{
		add{ StepDetect+=value;}
		remove{ StepDetect-=value;}
	}

	private Action <int>StepCount;
	public event Action <int>OnStepCount{
		add{ StepCount+=value;}
		remove{ StepCount-=value;}
	}

	private Action <int>StepCountToday;
	public event Action <int>OnStepCountToday{
		add{ StepCountToday+=value;}
		remove{ StepCountToday-=value;}
	}
	// events where you can listen
	
	private static PedometerPlugin instance;
	private static GameObject container;
	private static AUPHolder aupHolder;
	
	#if UNITY_ANDROID
	private static AndroidJavaObject jo;
	#endif	
	
	public bool isDebug =true;
	
	public static PedometerPlugin GetInstance(){
		if(instance==null){
			container = new GameObject();
			container.name="PedometerPlugin";
			instance = container.AddComponent( typeof(PedometerPlugin) ) as PedometerPlugin;
			DontDestroyOnLoad(instance.gameObject);
			aupHolder = AUPHolder.GetInstance();
			instance.gameObject.transform.SetParent(aupHolder.gameObject.transform);
		}
		
		return instance;
	}
	
	private void Awake(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo = new AndroidJavaObject("com.gigadrillgames.androidsensor.pedometer.PedometerPlugin");
		}
		#endif
	}
	
	/// <summary>
	/// Sets the debug.
	/// 0 - false, 1 - true
	/// </summary>
	/// <param name="debug">Debug.</param>
	public void SetDebug(int debug){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("SetDebug",debug);
		}else{
			Message("warning: must run in actual android device");
		}
		#endif
	}


	/// <summary>
	/// Init create the activity for Pedometer
	/// </summary>
	public void Init(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("init");
			// set the event callback  methods
			SetCallbackListener(
				onLoadPrevStepCount,
				onLoadTotalStepCount,
				onLoadTotalStepToday,
				onStepDetect,
				onStepCount,
				onStepCountToday);
		}else{
			Message("warning: must run in actual android device");
		}
		#endif
	}

	/// <summary>
	/// Sets the callback listener for the pedometer events
	/// </summary>
	/// <param name="onActivityCreated">On activity created dispatch when the activity for pedometer is ready.</param>
	/// <param name="OnLoadPrevStepCount">On load previous step count dispatch when prev step loaded.</param>
	/// <param name="OnStepDetect">On step detect dispatch when step is detected.</param>
	/// <param name="OnStepCount">On step count dispatch for every valid steps you make.</param>
	private void SetCallbackListener(
		Action <int>OnLoadPrevStepCount,
		Action <int>OnLoadTotalStepCount,
		Action <int>OnLoadTotalStepToday,
		Action OnStepDetect,
		Action <int>OnStepCount,
		Action <int>OnStepCountToday
	){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			
			IPedometerCallback ipedometerCallback = new IPedometerCallback();
			ipedometerCallback.OnLoadPrevStepCount = OnLoadPrevStepCount;
			ipedometerCallback.OnLoadTotalStepCount = OnLoadTotalStepCount;
			ipedometerCallback.OnLoadTotalStepToday = OnLoadTotalStepToday;
			ipedometerCallback.OnStepDetect = OnStepDetect;
			ipedometerCallback.OnStepCount = OnStepCount;
			ipedometerCallback.OnStepCountToday = OnStepCountToday;

			jo.CallStatic("setCallbackListener",ipedometerCallback);
		}else{
			Message("warning: must run in actual android device");
		}
		#endif
	}


	/// <summary>
	/// Starts the pedometer background service.
	/// note: when you close the app the service will stop
	/// and restart again and run even the app is close to
	/// continue counting steps
	/// note: without starting this you will not get the 
	/// callback so start this before doing any thing else
	/// </summary>
	/// <param name="sensorType">Sensor type.</param>
	public void StartPedometerService(SensorDelay sensorType){
		int selectedSensorType = (int)sensorType;
		Message("check selected sensor type: " + selectedSensorType);
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("startPedometerService",selectedSensorType);
		}else{
			Message("warning: must run in actual android device");
		}
		#endif
	}

	/// <summary>
	/// Stops the pedometer background service.
	/// note: stop service meaning the callback will not trigger anymore and the saving
	/// of step will also stop, so becareful
	/// </summary>
	public void StopPedometerService(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("stopPedometerService");
		}else{
			Message("warning: must run in actual android device");
		}
		#endif
	}

	/// <summary>
	/// Clears the data.
	/// this will clear all the save step data 
	/// so becareful on using this one most of the time
	/// you dont need to call this
	/// and note even you clear everying the step count will not reset
	/// reason this step count is in android service system
	/// you need to restart you device if you want to start with
	/// zero step count
	/// </summary>
	public void DeleteData(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("clearData");
		}else{
			Message("warning: must run in actual android device");
		}
		#endif
	}

	 /// <summary>
	 /// Loads the total step since the pedometer starts
	 /// </summary>
	public void LoadTotalStep(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("loadTotalStep");
		}else{
			Message("warning: must run in actual android device");
		}
		#endif
	}

	/// <summary>
	/// Loads the step today.
	/// </summary>
	public void LoadStepToday(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("loadTotalStepToday");
		}else{
			Message("warning: must run in actual android device");
		}
		#endif
	}

	/// <summary>
	/// Loads the previous total step since phone boot minus 1 day steps.
	/// this is yesterday total steps
	/// </summary>
	public void LoadPrevTotalStep(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("loadPrevTotalStep");
		}else{
			Message("warning: must run in actual android device");
		}
		#endif
	}

	/// <summary>
	/// Gets the total step since phone boot.
	/// same with LoadTotalStep but LoadTotalStep is better
	/// this one might give the not the latest data
	/// </summary>
	/// <returns>The total step.</returns>
	public int GetTotalStep(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){			
			return jo.CallStatic<int>("getTotalStep");
		}else{
			Message("warning: must run in actual android device");
		}
		#endif
		return 0;
	}


	// get total steps since pedometer starts until yesterday
	public int GetTotalStepYesterday(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			return jo.CallStatic<int>("getTotalStepYesterday");
		}else{
			Message("warning: must run in actual android device");
		}
		#endif
		return 0;
	}

	// get total step today
	public int GetTotalStepToday(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){			
			return jo.CallStatic<int>("getTotalStepToday");
		}else{
			Message("warning: must run in actual android device");
		}
		#endif
		return 0;
	}

	/// <summary>
	/// Gets the previous or yesterday total steps,total step since phone boot.
	/// </summary>
	/// <returns>The previous total step.</returns>
	public int GetPrevTotalStep(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){			
			return jo.CallStatic<int>("getPrevTotalStep");
		}else{
			Message("warning: must run in actual android device");
		}
		#endif
		return 0;
	}

	public int GetStepByDate(int month,int day, int year){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			return jo.CallStatic<int>("getStepByDate",month,day,year);
		}else{
			Message("warning: must run in actual android device");
		}
		#endif

		return 0;
	}

	/// <summary>
	/// Gets the total step today.
	/// </summary>
	/// <returns>The step today.</returns>
	public int GetStepToday(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			return jo.CallStatic<int>("getStepToday");
		}else{
			Message("warning: must run in actual android device");
		}
		#endif

		return 0;
	}

	/// <summary>
	/// Gets the total step yesterday.
	/// </summary>
	/// <returns>The step yesterday.</returns>
	public int GetStepYesterday(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			return jo.CallStatic<int>("getStepYesterday");
		}else{
			Message("warning: must run in actual android device");
		}
		#endif

		return 0;
	}


	/// <summary>
	/// Gets the step last day.
	/// now - day count you put ex. if you put 1 on day = yesterday total steps
	/// </summary>
	/// <returns>The step last day.</returns>
	/// <param name="day">Day.</param>
	public int GetStepLastDay(int day){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			return jo.CallStatic<int>("getStepLastDay",day);
		}else{
			Message("warning: must run in actual android device");
		}
		#endif

		return 0;
	}

	
	/// <summary>
	/// Shows the native alert popup.
	/// </summary>
	/// <param name="title">Title.</param>
	/// <param name="message">Message.</param>
	public void ShowAlertPopup(String title,String message){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("showNativePopup",title,message);
		}else{
			Message("warning: must run in actual android device");
		}
		#endif
	}
	
	
	public void ShowMessage(string message){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.Call("ShowMessage", message);
		}else{
			Message("warning: must run in actual android device");
		}
		#endif
	}
	
	private void Message(string message){
		if(isDebug){
			Debug.LogWarning(message);
		}
	}

	// the prev step is loaded
	private void onLoadTotalStepCount(int val){
		if(null!= LoadTotalStepCount){
			LoadTotalStepCount(val);
		}
	}

	private void onLoadTotalStepToday(int val){
		if(null!= LoadTotalStepToday){
			LoadTotalStepToday(val);
		}
	}

	// the prev step is loaded
	private void onLoadPrevStepCount(int val){
		if(null!= LoadPrevStepCount){
			LoadPrevStepCount(val);
		}
	}

	// a valid step is detected
	private void onStepDetect(){
		if(null!= StepDetect){
			StepDetect();
		}
	}

	// a step happened
	private void onStepCount(int val){
		if(null!= StepCount){
			StepCount(val);
		}
	}

	private void onStepCountToday(int val){
		if(null!= StepCountToday){
			StepCountToday(val);
		}
	}

	// pedometer events
}