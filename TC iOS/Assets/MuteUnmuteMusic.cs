using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteUnmuteMusic : MonoBehaviour {
	bool Music = true;
	public Button MusicButton;
	public Sprite OnImage;
	public Sprite OffImage;
	// Use this for initialization

	void Start () {
		
	}

	public void MuteUnmute() {
		if (Music == true){
			Music = false;
			PlayMusic.Instance.gameObject.GetComponent<AudioSource> ().mute = true;
			MusicButton.image.sprite = OffImage;
		} else {
			Music = true;
			PlayMusic.Instance.gameObject.GetComponent<AudioSource> ().mute = false;
			MusicButton.image.sprite = OnImage;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
