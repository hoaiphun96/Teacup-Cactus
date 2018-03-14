using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UniPedometer;

public class Sample2 : MonoBehaviour {
	[SerializeField] Text text;
	[SerializeField] InputField hourInput;
	[SerializeField] Button button;

	void Start () {
		button.onClick.AddListener(() => OnButtonClicked());
	}
	void OnButtonClicked() {
		if (UniPedometerManager.IOS.IsPedometerUpdatesStarted) {
			StopPedometerUpdateAndShowText ();
			button.GetComponentInChildren<Text> ().text = "Start";
		} else {
			try {
				StartPedometerUpdateAndShowText (Int32.Parse (hourInput.text));
				button.GetComponentInChildren<Text> ().text = "Stop";
			}
			catch(FormatException e) {
				text.text = "given text is not a number!";
			}
		}
	}

	void StartPedometerUpdateAndShowText(int hoursAgo) {
		UniPedometerManager.IOS
			.StartPedometerUpdatesFromDate (DateTime.Now - TimeSpan.FromHours (hoursAgo), (data, nsError) => ShowPedometerData (data, nsError));
	}

	void ShowPedometerData(CMPedometerData data, NSError nsError) {
		if (data != null) {
			text.text = string.Format ("start date: {0}\nend date: {1}\n number of steps: {2}\ndistance: {3}",
				data.StartDate, data.EndDate, data.NumberOfSteps, data.Distance);
			if(data.HasCurrentPase)
				text.text += "\ncurrent pase: " + data.CurrentPace;
			if(data.HasCurrentCadence)
				text.text += "\ncurrent cadence: " + data.CurrentCadence;
			if(data.HasFloorsAscended)
				text.text += "\nfloors ascended: " + data.FloorsAscended;
			if(data.HasFloorsDescended)
				text.text += "\nfloors descended: " + data.FloorsDescended;
		}
		else
			text.text = nsError.LocalizedDescription;
	}

	void StopPedometerUpdateAndShowText () {
		UniPedometerManager.IOS.StopPedometerUpdates ();
		text.text = "Pedometer updates stopped.";
	}
}
