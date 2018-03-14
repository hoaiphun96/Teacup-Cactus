using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthOpener : MonoBehaviour {

	public GameObject myMouth;
	public Sprite openSmile;
	public Sprite regularSmile;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseEnter() {
		myMouth.GetComponent<SpriteRenderer> ().sprite = openSmile;
	}

	void OnMouseExit() {
		myMouth.GetComponent<SpriteRenderer> ().sprite = regularSmile;	
	}
}
