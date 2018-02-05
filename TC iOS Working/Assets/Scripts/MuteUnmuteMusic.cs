using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteUnmuteMusic : MonoBehaviour {
	public bool Music = true;

	public Sprite On;
	public Sprite Off;
	public Button MusicButton;

	// Use this for initialization
	void Start () {
		
	}

	public void MuteUnmute() {
		if (Music == true){
			Music = false;
			PlayMusic.Instance.gameObject.GetComponent<AudioSource> ().mute = true;
			MusicButton.image.sprite = Off;
		} else {
			Music = true;
			PlayMusic.Instance.gameObject.GetComponent<AudioSource> ().mute = false;
			MusicButton.image.sprite = On;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
