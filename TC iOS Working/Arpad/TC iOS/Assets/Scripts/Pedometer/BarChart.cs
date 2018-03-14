using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniPedometer;
using System;

public class BarChart : MonoBehaviour {
	static float chartHeight;
	public Bar BarPrefab;
	public List<Bar> bars = new List<Bar>();
	static int[] values = new int[7];
	static int maxSteps = 5000;
	public Text TotalStepsText;
	public Text TotalDistanceText;
	private int TotalSteps;
	private float TotalDistance; 
	// Use this for initialization
	void Start () {
		chartHeight = 700;

		QueryAndShow(6,0);
		QueryAndShow(5,1);
		QueryAndShow(4,2);
		QueryAndShow(3,3);
		QueryAndShow(2,4);
		QueryAndShow(1,5);
		QueryAndShow (0, 6);

		/*
		//FOR DEBUGGING BAR GRAPH COMMENT THE QUERY CALLS ABOVE AND UNCOMMON THE BLOCK BELOW,
		values[0] = 1000;
		values[1] = 2000;
		values[2] = 3000;
		values[3] = 4000;
		values[4] = 1000;
		values[5] = 2500;
		values[6] = 4500;
		DisplayStats ();
		*/

	}


	void QueryAndShow(int fromDaysAgo, int atIndex) {
		UniPedometerManager.IOS
			.QueryPedometerDataFromDate (
				DateTime.Now - TimeSpan.FromHours (DateTime.Now.Hour)
				- TimeSpan.FromMinutes (DateTime.Now.Minute)
				- TimeSpan.FromSeconds (DateTime.Now.Second) - TimeSpan.FromDays (fromDaysAgo),
				DateTime.Now - TimeSpan.FromHours (DateTime.Now.Hour)
				- TimeSpan.FromMinutes (DateTime.Now.Minute)
				- TimeSpan.FromSeconds (DateTime.Now.Second) - TimeSpan.FromDays (fromDaysAgo) 
				+ TimeSpan.FromHours(23.00) + TimeSpan.FromMinutes(59.00) + TimeSpan.FromSeconds(59.00),
				(CMPedometerData data, NSError error) => ShowPedometerData (data, error, atIndex)); 
	}
	void ShowPedometerData(CMPedometerData data,  NSError error, int i) {
		if (error == null) {
			values[i] = data.NumberOfSteps;
			TotalSteps += values[i];
			TotalDistance += data.Distance;
			Debug.Log(String.Format("steps {0} day(s) ago is {1}, distance is {2}", i,data.NumberOfSteps, data.Distance));
			if (values [i] > maxSteps) {
				maxSteps = values [i];
			}
			//DisplayGraph (values, i);
		} else {
			values [i] = 0;
			Debug.Log(String.Format("There was an error in getting steps of {0} days ago at index of {1} error detail {2}", 6-i, i,error.LocalizedDescription));
			}
		if (i == 6) {
			DisplayStats ();
		}
	}
		
	void DisplayGraph(int[] vals) {
		
		for (int i = 0; i < vals.Length; i++) {
			RectTransform rt = bars [i].bar.GetComponent<RectTransform> ();
			rt.sizeDelta = new Vector2 (rt.sizeDelta.x, (float)chartHeight * vals [i] / (maxSteps + 500));
		}
	}

	void GetTotalSteps(){
		TotalStepsText.text = String.Format("Total walking + running steps: {0}", TotalSteps.ToString ());
	}

	void GetToalDistance(){
		float TotalDistanceInMiles = TotalDistance/1609.34398f;
		//converting meter to miles and rounding to 2 decimals
		TotalDistanceText.text = String.Format ("Total distance: {0} mile(s)", (Math.Round((double)TotalDistanceInMiles,2)).ToString ());
		//for unity debugging uncomment line below
		//TotalDistanceText.text = String.Format ("Total distance: {0} mile(s)", (TotalSteps*0.0007).ToString ());
	}

	void DisplayStats(){
		DisplayGraph (values);
		GetTotalSteps ();
		GetToalDistance();
	}
}
