using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UniPedometer;

public class Sample3 : MonoBehaviour {
	[SerializeField] Text text;
	[SerializeField] Button queryButton;

	void Start () {
		queryButton.onClick.AddListener(() => CheckAndShow());
	}

	void CheckAndShow () {
		text.text = string.Format ("IsStepCountingAvailable: {0}\nIsDistanceAvailable: {1}\n IsPaceAvailable: {2}\nIsFloorCountingAvailable: {3}\nIsCadenceAvailable: {4}",
			UniPedometerManager.IOS.IsStepCountingAvailable,
			UniPedometerManager.IOS.IsDistanceAvailable,
			UniPedometerManager.IOS.IsPaceAvailable,
			UniPedometerManager.IOS.IsFloorCountingAvailable,
			UniPedometerManager.IOS.IsCadenceAvailable
		);
	}
}
