using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour {
	private static PlayMusic instance;
	public static PlayMusic Instance {
		get { return instance; }
	}

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
		
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
