using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UniPedometer;

public class PedometerIOS : MonoBehaviour {
	public static PedometerIOS instance;
	public static PedometerIOS Instance {
		get { return instance; }
	}

	void Awake() {
		if (instance != null && instance != this) {
			Destroy (this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad (this.gameObject);
	}

	void Start () {
		if (PlayerPrefs.HasKey ("Goal") == false) {
			PlayerPrefs.SetInt ("Goal",5000);
		}
		if (PlayerPrefs.HasKey ("Steps") == false) {
			PlayerPrefs.SetInt ("Steps", 0);
		}

		StartPedometerUpdate ();
	}

	void StartPedometerUpdate() {
		//getiing pedometer data since the beginning of the day at 00:00:00
		UniPedometerManager.IOS
			.StartPedometerUpdatesFromDate (DateTime.Now - TimeSpan.FromHours (DateTime.Now.Hour) 
				- TimeSpan.FromMinutes (DateTime.Now.Minute) 
				- TimeSpan.FromSeconds (DateTime.Now.Second), (data, nsError) => UpdatePedometerData (data, nsError));
	}

	void UpdatePedometerData(CMPedometerData data, NSError nsError) {
		
		if (data != null) {
			PlayerPrefs.SetInt ("Steps", data.NumberOfSteps);

		} else {
			PlayerPrefs.SetInt("Steps", 0);
			Debug.Log ("Cannot fetch data, setting steps to 0");
		}
	}

}
