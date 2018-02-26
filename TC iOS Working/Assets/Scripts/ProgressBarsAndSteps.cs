
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class ProgressBarsAndSteps : MonoBehaviour {

	public GameObject stepText;
	public GameObject breedingProgressBar;
	public GameObject walkingProgressBar;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		stepText.GetComponentInChildren<Text> ().text = string.Format("Steps: {0}", PedometerIOS.Steps);
		if (PedometerIOS.Steps > PedometerIOS.Goal) {
			walkingProgressBar.GetComponent<Slider> ().value = 1.0f;
		} else {
			walkingProgressBar.GetComponent<Slider>().value =(float)PedometerIOS.Steps / PedometerIOS.Goal;
			Debug.Log ((float)PedometerIOS.Steps / PedometerIOS.Goal);
		} 
	}
}
