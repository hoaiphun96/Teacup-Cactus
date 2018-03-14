using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour {
	private static PlayMusic instance;
	public static PlayMusic Instance {
		get { return instance; }
	}

	public List<AudioClip> Songs;

	void Awake() {
		if (instance != null && instance != this) {
			Destroy (this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad (this.gameObject);
	}
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey ("Sound")) {
			if (PlayerPrefs.GetInt ("Sound") == 0) {
				gameObject.GetComponent<AudioSource> ().mute = true;
			} else {
				gameObject.GetComponent<AudioSource> ().mute = false;
			}
		}

		if (PlayerPrefs.HasKey ("Song")) {
			gameObject.GetComponent<AudioSource> ().clip = Songs [PlayerPrefs.GetInt ("Song")];
			gameObject.GetComponent<AudioSource> ().Play ();
		}
	}
}
