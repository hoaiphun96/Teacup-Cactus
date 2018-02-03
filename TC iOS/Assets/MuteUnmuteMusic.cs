using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteUnmuteMusic : MonoBehaviour {
	bool Music = true;
	// Use this for initialization
	void Start () {
		
	}

	public void MuteUnmute() {
		if (Music == true){
			Music = false;
			PlayMusic.Instance.gameObject.GetComponent<AudioSource> ().mute = true;
		} else {
			Music = true;
			PlayMusic.Instance.gameObject.GetComponent<AudioSource> ().mute = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
