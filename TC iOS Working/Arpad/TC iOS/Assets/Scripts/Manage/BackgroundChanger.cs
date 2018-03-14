using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BackgroundChanger : MonoBehaviour {

	public Sprite bgDaytime;
	public Sprite bgGoldenHour;
	public Sprite bgNighttime;

	// Use this for initialization
	void Start () {
		int currentHour = DateTime.Now.Hour;
		SpriteRenderer mySpriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
		//range for day time is 9am to 5pm
		//range for golden hour is 6 to 9am and 5 to 8pm
		//time for night is everything else, 8pm to 6am 
		if (currentHour >= 9 && currentHour <= 12 + 5) {
			mySpriteRenderer.sprite = bgDaytime;
		} else if (currentHour >= 6 && currentHour <= 12 + 8) {
			mySpriteRenderer.sprite = bgGoldenHour;
		} else {
			mySpriteRenderer.sprite = bgNighttime;
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
