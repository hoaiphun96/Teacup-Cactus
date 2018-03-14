using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugFindFlower : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DebugFind () {
		Inventory.ScavengeFlower();
		Debug.Log ("New flower added");
	}
}
