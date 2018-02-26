using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class PedometerDemo : MonoBehaviour
{
	
	private PedometerPlugin pedometerPlugin;
	private string demoName = "[PedometerDemo] ";
	private UtilsPlugin utilsPlugin;

	public Text hasStepDetectorStatusText;

	public Text prevTotalStepCountText;
	public Text totalStepCountText;
	public Text stepTodayCountText;
	public Text stepDetectText;
	
	// Use this for initialization
	void Start ()
	{
		//get the instance of pedometer plugin
		pedometerPlugin = PedometerPlugin.GetInstance ();

		//set to zero to hide debug toast messages
		pedometerPlugin.SetDebug (0);

		utilsPlugin = UtilsPlugin.GetInstance ();
		utilsPlugin.SetDebug (0);

		//check if step detector is supported on the current android mobile device
		bool hasStepDetector = utilsPlugin.HasStepDetector ();
		bool hasStepCounter = utilsPlugin.HasStepCounter ();

		//if (hasStepDetector) {
		if (hasStepCounter) {
			// yehey your android mobile device support pedometer

			UpdateStepDetectorStatus ("available");
			// event listeners
			AddEventListeners ();
			//initialze pedometer
			pedometerPlugin.Init ();
		} else {
			// if you get this meaning
			// pedometer is not available on your android mobile device sorry!
			UpdateStepDetectorStatus ("not available");
		}
	}

	private void OnDestroy ()
	{
		RemoveEventListeners ();
	}

	// for listening on pedometer events
	private void AddEventListeners ()
	{
		//set call back listener for pedometer events
		pedometerPlugin.OnLoadTotalStepCount += OnLoadTotalStepCount;
		pedometerPlugin.OnLoadPrevStepCount += OnLoadPrevStepCount;
		pedometerPlugin.OnLoadTotalStepToday += OnLoadTotalStepToday;
		pedometerPlugin.OnStepCount += OnStepCount;
		pedometerPlugin.OnStepCountToday += OnStepCountToday;
		pedometerPlugin.OnStepDetect += OnStepDetect;
	}

	// for listening on pedometer events
	private void RemoveEventListeners ()
	{
		//set call back listener for pedometer events
		pedometerPlugin.OnLoadTotalStepCount -= OnLoadTotalStepCount;
		pedometerPlugin.OnLoadPrevStepCount -= OnLoadPrevStepCount;
		pedometerPlugin.OnLoadTotalStepToday -= OnLoadTotalStepToday;
		pedometerPlugin.OnStepCount -= OnStepCount;
		pedometerPlugin.OnStepCountToday -= OnStepCountToday;
		pedometerPlugin.OnStepDetect -= OnStepDetect;
	}

	// the pedometer service is not auto start
	// call this to start the service
	// and don't worry after you close or quit the unity3d application the
	// pedometer service will start and run again
	public void StartPedometerService ()
	{
		// here you start and pass the sensor delay that you want to use
		pedometerPlugin.StartPedometerService (SensorDelay.SENSOR_DELAY_FASTEST);
		UpdateStepDetectorStatus ("Service Started");
		Debug.Log (demoName + "StartPedometerService has been called");
	}

	// call this to stop the pedometer service
	public void StopPedometerService ()
	{
		pedometerPlugin.StopPedometerService ();
		UpdateStepDetectorStatus ("Service Stopped");
	}

	// for loading steps
	public void LoadSteps ()
	{
		pedometerPlugin.LoadPrevTotalStep ();
		pedometerPlugin.LoadTotalStep ();
		pedometerPlugin.LoadStepToday ();
	}

	// get step on specific date if the step is available and save if not zero
	public void GetStepByDate (int month, int day, int year)
	{
		int stepCount = pedometerPlugin.GetStepByDate (month, day, year);
		Debug.Log (demoName + "stepCount: " + stepCount + " on " + month + "/" + day + "/" + year);
	}

	// for updating the demo text ui
	private void UpdateStepDetectorStatus (string val)
	{
		if (hasStepDetectorStatusText != null) {
			hasStepDetectorStatusText.text = String.Format ("Status: {0}", val);
		}
	}

	private void UpdatePrevStepCount (int totalPrevStepCount)
	{
		if (prevTotalStepCountText != null) {
			prevTotalStepCountText.text = String.Format ("Prev Step: {0}", totalPrevStepCount);
		}
	}

	//for updating step count for demo purpose
	private void UpdateTotalStepCount (int count)
	{
		if (totalStepCountText != null) {
			totalStepCountText.text = String.Format ("Total Step: {0}", count);
		}
	}

	private void UpdateStepTodayCount (int stepsToday)
	{
		if (stepTodayCountText != null) {
			stepTodayCountText.text = String.Format ("Today Step: {0}", stepsToday);
		}
	}

	private void UpdateStepDetect (string status)
	{
		if (stepDetectText != null) {
			stepDetectText.text = String.Format ("Step Detect: {0}", status);
		}
	}
	// for updating the demo text ui

	// event handlers
	private void OnStepCountToday (int totalStepToday)
	{
		UpdateStepTodayCount (totalStepToday);
	}

	private void OnLoadTotalStepCount (int totalStepCount)
	{
		UpdateTotalStepCount (totalStepCount);
		Debug.Log (demoName + "OnLoadTotalStepCount count " + totalStepCount);
	}

	private void OnLoadPrevStepCount (int totalStepCount)
	{		
		UpdatePrevStepCount (totalStepCount);
		Debug.Log (demoName + "OnLoadPrevStepCount count " + totalStepCount);
	}

	private void OnLoadTotalStepToday (int stepCountToday)
	{
		UpdateStepTodayCount (stepCountToday);
	}

	//step detect event is triggered
	private void OnStepDetect ()
	{
		UpdateStepDetect ("Ok!");
		Debug.Log (demoName + "OnStepDetect");
	}

	//step count event is triggered
	private void OnStepCount (int totalStepCount)
	{
		Debug.Log (demoName + "OnStepCount count " + totalStepCount);
		// for updating total step count
		UpdateTotalStepCount (totalStepCount);
	}
	// event handlers
}