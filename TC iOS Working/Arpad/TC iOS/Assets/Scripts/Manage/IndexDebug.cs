using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System;

public class IndexDebug : MonoBehaviour {
	string debugInfo = "";
	Text debugText;
	// Use this for initialization
	void Start () {
		debugText = gameObject.GetComponent<Text> ();
	}

	// Update is called once per frame
	void Update () {
		//Append new debug information here.
		debugInfo = String.Format("Flowers len {0}, Current Index {1}", Inventory.FlowerList.Count, PlayerPrefs.GetInt("Flower Index"));
		debugText.text = debugInfo;
	}
}
