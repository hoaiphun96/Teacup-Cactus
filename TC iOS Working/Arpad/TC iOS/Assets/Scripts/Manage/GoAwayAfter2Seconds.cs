using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoAwayAfter2Seconds : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		StartCoroutine (Dissapear());
	}

	IEnumerator Dissapear() {
		yield return new WaitForSeconds (2);
		gameObject.SetActive (false);
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
