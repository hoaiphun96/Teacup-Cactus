using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class DisplayDate : MonoBehaviour {
	public Text today;
	public Text oneDayAgo;
	public Text twoDaysAgo;
	public Text threeDaysAgo;
	public Text fourDaysAgo;
	public Text fiveDaysAgo;
	public Text sixDaysAgo;
	// Use this for initialization
	void Start () {
		today.text = DateTime.Today.Date.ToString().Substring(0,5);
		oneDayAgo.text = (DateTime.Today.Date - TimeSpan.FromDays(1)).ToString().Substring(0,5);
		twoDaysAgo.text = (DateTime.Today.Date - TimeSpan.FromDays(2)).ToString().Substring(0,5);
		threeDaysAgo.text = (DateTime.Today.Date - TimeSpan.FromDays(3)).ToString().Substring(0,5);
		fourDaysAgo.text = (DateTime.Today.Date - TimeSpan.FromDays(4)).ToString().Substring(0,5);
		fiveDaysAgo.text = (DateTime.Today.Date - TimeSpan.FromDays(5)).ToString().Substring(0,5);
		sixDaysAgo.text = (DateTime.Today.Date - TimeSpan.FromDays(6)).ToString().Substring(0,5);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
