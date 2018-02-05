using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMusic : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayMusic.Instance.gameObject.GetComponent<AudioSource> ().Pause ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
}
