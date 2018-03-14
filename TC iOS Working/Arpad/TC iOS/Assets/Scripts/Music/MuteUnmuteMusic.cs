using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteUnmuteMusic : MonoBehaviour {
	public bool Music = true;
	//public GameObject MuteSlider;
	// Use this for initialization
	void Start () {
		/*
		if (PlayMusic.Instance.gameObject.GetComponent<AudioSource> ().mute == true) {
			//ShowOff ();
			MuteSlider.GetComponent<Slider>().value = 0;
		} else {
			//ShowOn ();
			MuteSlider.GetComponent<Slider>().value = 1;
		} */
	}

	/*
	void ShowOff () {
		ColorBlock colorBlock = gameObject.GetComponent<Slider> ().colors;
		colorBlock.highlightedColor = new Color (127, 130, 154, 255);
		colorBlock.normalColor = new Color (127, 130, 154, 255);
		colorBlock.pressedColor = new Color (127, 130, 154, 255);
		gameObject.GetComponent<Slider> ().colors = colorBlock;
	}

	void ShowOn () {
		ColorBlock colorBlock = gameObject.GetComponent<Slider> ().colors;
		print (colorBlock);
		colorBlock.highlightedColor = new Color (144, 103, 153, 255);
		colorBlock.normalColor = new Color (144, 103, 153, 255);
		colorBlock.pressedColor = new Color (144, 103, 153, 255);
		gameObject.GetComponent<Slider> ().colors = colorBlock;
		print ("On");
	}
	*/

	public void MuteUnmute() {
		if (Music == true){
			//ShowOff ();
			Music = false;
			PlayMusic.Instance.gameObject.GetComponent<AudioSource> ().mute = true;
			PlayerPrefs.SetInt ("Mute", 1);

		} else {
			//ShowOn ();
			Music = true;
			PlayMusic.Instance.gameObject.GetComponent<AudioSource> ().mute = false;
			Debug.Log ("Playing Music");
			PlayerPrefs.SetInt ("Mute", 0);
		}
	}


	// Update is called once per frame
	void Update () {

	}
}
