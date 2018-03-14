using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class PedometerDemo2 : MonoBehaviour
{

	private PedometerPlugin pedometerPlugin;
	private string demoName = "[PedometerDemo] ";
	private UtilsPlugin utilsPlugin;

	public Text hasStepDetectorStatusText;

	public Text prevTotalStepCountText;
	public Text totalStepCountText;
	public Text stepYesterdayCountText;
	public Text stepTodayCountText;
	public Text stepByDateText;

	// Use this for initialization
	void Start ()
	{
		//get the instance of pedometer plugin
		pedometerPlugin = PedometerPlugin.GetInstance ();

		//set to zero to hide debug toast messages
		pedometerPlugin.SetDebug (0);

		utilsPlugin = UtilsPlugin.GetInstance ();
		utilsPlugin.SetDebug (0);

		//check if step detector is supported
		bool hasStepDetector = utilsPlugin.HasStepDetector ();
		bool hasStepCounter = utilsPlugin.HasStepCounter ();

		//if (hasStepDetector) {
		if (hasStepCounter) {
			UpdateStepDetectorStatus ("available");
			// event listeners
			AddEventListeners ();
			//initialze pedometer
			pedometerPlugin.Init ();

		} else {
			UpdateStepDetectorStatus ("not available");
		}
	}

	private void OnDestroy ()
	{
		RemoveEventListeners ();
	}

	private void AddEventListeners ()
	{
		//set call back listener for pedometer events
		pedometerPlugin.OnLoadTotalStepCount += OnLoadTotalStepCount;
		pedometerPlugin.OnLoadPrevStepCount += OnLoadPrevStepCount;
		pedometerPlugin.OnLoadTotalStepToday += OnLoadTotalStepToday;
	}

	private void RemoveEventListeners ()
	{
		//set call back listener for pedometer events
		pedometerPlugin.OnLoadTotalStepCount -= OnLoadTotalStepCount;
		pedometerPlugin.OnLoadPrevStepCount -= OnLoadPrevStepCount;
		pedometerPlugin.OnLoadTotalStepToday -= OnLoadTotalStepToday;
	}

	public void LoadSteps ()
	{
		// test only remove this after testing because usually on 1st run there's no save step
		// from yesteday this value is for testing previos total steps
		// you just need to call this once on 1st run after that remove it or comment it
		// to avoid messing around the step save
		//pedometerPlugin.SetStepYesterday( 1500 );

		pedometerPlugin.LoadPrevTotalStep ();
		pedometerPlugin.LoadTotalStep ();
		pedometerPlugin.LoadStepToday ();

		UpdateYesterdayStepCount (pedometerPlugin.GetStepYesterday ());
		// get step on this date
		// for testing my current date now is april 8,2017 i want to get step yesterday so minus 1 day
		// so i put 3 , 7, 2017 - change this to your current date for testing
		// remember month start's with 0 so jan  = 0, that's why april is 3
		GetStepByDate (3, 7, 2017);
	}

	public void DeleteData ()
	{
		pedometerPlugin.DeleteData ();
		LoadSteps ();
	}

	// get step on specific date if the step is available and save if not zero
	public void GetStepByDate (int month, int day, int year)
	{
		// if there's no step save return 0 here
		int stepCount = pedometerPlugin.GetStepByDate (month, day, year);
		Debug.Log (demoName + "get step by date stepCount: " + stepCount + " on " + month + "/" + day + "/" + year);

		UpdateStepCountByDate (stepCount);
	}


	// for updating text ui
	private void UpdateStepDetectorStatus (string val)
	{
		if (hasStepDetectorStatusText != null) {
			hasStepDetectorStatusText.text = String.Format ("Status: {0}", val);
		}
	}

	private void UpdatePrevStepCount (int stepCount)
	{
		if (prevTotalStepCountText != null) {
			prevTotalStepCountText.text = String.Format ("Prev Step: {0}", stepCount);
		}
	}

	//for updating step count for demo purpose
	private void UpdateTotalStepCount (int stepCount)
	{
		if (totalStepCountText != null) {
			totalStepCountText.text = String.Format ("Total Step: {0}", stepCount);
		}
	}

	private void UpdateStepTodayCount (int stepCount)
	{
		if (stepTodayCountText != null) {
			stepTodayCountText.text = String.Format ("Today Step: {0}", stepCount);
		}
	}

	private void UpdateYesterdayStepCount (int stepCount)
	{
		if (stepYesterdayCountText != null) {
			stepYesterdayCountText.text = String.Format ("Step yesterday: {0}", stepCount);
		}
	}

	private void UpdateStepCountByDate (int stepCount)
	{
		if (stepByDateText != null) {
			stepByDateText.text = String.Format ("Step by date: {0}", stepCount);
		}
	}
	// for updating text ui

	// event handlers
	private void OnLoadTotalStepCount (int stepCount)
	{
		UpdateTotalStepCount (stepCount);
		Debug.Log (demoName + "OnLoadTotalStepCount count " + stepCount);
	}

	private void OnLoadPrevStepCount (int stepCount)
	{		
		UpdatePrevStepCount (stepCount);
		Debug.Log (demoName + "OnLoadPrevStepCount count " + stepCount);
	}

	private void OnLoadTotalStepToday (int stepCountToday)
	{
		UpdateStepTodayCount (stepCountToday);
	}
	// event handlers
}