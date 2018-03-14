using UnityEngine;
using System.Collections;
using UniPedometer;
using System;
using UnityEngine.UI;

public class Sample1 : MonoBehaviour {
	[SerializeField] Text text;
	[SerializeField] InputField fromHourInput;
	[SerializeField] InputField toHourInput;
	[SerializeField] Button queryButton;

	void Start () {
		queryButton.onClick.AddListener(() => {
			try {
				QueryAndShow(Int32.Parse(fromHourInput.text), Int32.Parse(toHourInput.text));
			}
			catch(FormatException e) {
				text.text = "given text is not a number!";
			}
		});
	}

	public void QueryAndShow(int fromHoursAgo, int toHoursAgo) {
		UniPedometerManager.IOS
			.QueryPedometerDataFromDate (
				DateTime.Now - TimeSpan.FromHours (fromHoursAgo),
				DateTime.Now - TimeSpan.FromHours(toHoursAgo),
				(CMPedometerData data, NSError error) => ShowPedometerData (data, error));
	}

	void ShowPedometerData(CMPedometerData data,  NSError error) {
		if (error == null) {
			text.text = string.Format ("start date: {0}\nend date: {1}\n number of steps: {2}\ndistance: {3}",
				data.StartDate, data.EndDate, data.NumberOfSteps, data.Distance);
			if(data.HasFloorsAscended)
				text.text += "\nfloors ascended: " + data.FloorsAscended;
			if(data.HasFloorsDescended)
				text.text += "\nfloors descended: " + data.FloorsDescended;
		}
		else {
			text.text = error.LocalizedDescription;
		}


	}
}
