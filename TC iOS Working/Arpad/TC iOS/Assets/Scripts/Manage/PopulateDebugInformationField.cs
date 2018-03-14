using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PopulateDebugInformationField : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Text myInformationField = gameObject.GetComponent<Text> ();

		string debugInfo = "";

		//Append new debug information here.
		debugInfo += String.Format("Persistent Data Path: {0}\n", Application.persistentDataPath);

		foreach(string trait in Inventory.Goal.GetGoal()){
			debugInfo += String.Format ("{0}, ",trait);
		}
		debugInfo+="\n";


		myInformationField.text = debugInfo;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
