using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UniPedometer;

public class ShowSettingsValues : MonoBehaviour {
	public GameObject MuteSlider;
	public InputField goalTextField;

	public bool Music = true;

	// Use this for initialization
	void Start () {
		
		if (PlayerPrefs.HasKey ("Sound")) {
			Debug.Log (String.Format ("Sound is {0}", PlayerPrefs.GetInt ("Sound")));
			MuteSlider.GetComponent<Slider>().value = PlayerPrefs.GetInt("Sound");
		}
		if (PlayerPrefs.HasKey ("Goal")) {
			goalTextField.GetComponentInChildren<InputField>().text = PlayerPrefs.GetInt ("Goal").ToString ();
		}
	}

	public void updateGoal() {
		PlayerPrefs.SetInt ("Goal", Convert.ToInt32(goalTextField.GetComponentInChildren<InputField>().text));
	}

	public void MuteUnmute() {
		if (Music == true){
			//ShowOff ();
			Music = false;
			PlayMusic.Instance.gameObject.GetComponent<AudioSource> ().mute = true;
			PlayerPrefs.SetInt ("Sound", 0);

		} else {
			//ShowOn ();
			Music = true;
			PlayMusic.Instance.gameObject.GetComponent<AudioSource> ().mute = false;
			Debug.Log ("Playing Music");
			PlayerPrefs.SetInt ("Sound", 1);
		}
	}

}
