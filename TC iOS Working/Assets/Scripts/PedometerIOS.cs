using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UniPedometer;

public class PedometerIOS : MonoBehaviour {

	private static int steps = 1000;
	private static float distance;
	public static int Steps {
		get { return steps; }
	}
	public static float Distance {
		get { return distance; }
	}
	private static int goalStep = 5000;
	public static int Goal {
		get { return goalStep; }
		set { goalStep = value; }
	}
	public InputField goalTextField;
	public Button enableTrackingButton;
	/*
	void Awake() {
		DontDestroyOnLoad (this.gameObject);
	} */
	// Update is called once per frame
	void Update () {
		
	}

	void Start () {
		enableTrackingButton.onClick.AddListener(() => OnButtonClicked());
	}

	public void updateGoal() {
		goalStep = Convert.ToInt32(goalTextField.GetComponentInChildren<InputField>().text);
		Debug.Log (goalStep);
	}

	void OnButtonClicked() {
		if (UniPedometerManager.IOS.IsPedometerUpdatesStarted) {
			StopPedometerUpdateAndShowText ();
			enableTrackingButton.GetComponentInChildren<Text> ().text = "Step Tracking Off";
		} else {
			StartPedometerUpdateAndShowText ();
			enableTrackingButton.GetComponentInChildren<Text> ().text = "Step Tracking On";
		}
	}

	void StartPedometerUpdateAndShowText() {
		//getiing pedometer data since the beginning of the day at 00:00:00
		UniPedometerManager.IOS
			.StartPedometerUpdatesFromDate (DateTime.Now - TimeSpan.FromHours (DateTime.Now.Hour) 
				- TimeSpan.FromMinutes (DateTime.Now.Minute) 
				- TimeSpan.FromSeconds (DateTime.Now.Second), (data, nsError) => UpdatePedometerData (data, nsError));
	}


	void UpdatePedometerData(CMPedometerData data, NSError nsError) {
		
		if (data != null) {
			steps = data.NumberOfSteps;
			distance = data.Distance;
		} else {
			steps = 0;
			distance = 0;
		}
	}

	void StopPedometerUpdateAndShowText () {
		UniPedometerManager.IOS.StopPedometerUpdates ();
	}
}
