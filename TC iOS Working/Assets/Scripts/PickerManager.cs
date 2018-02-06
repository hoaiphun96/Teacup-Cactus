using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickerManager : MonoBehaviour {

	public GameObject TeacupPickerUI;
	public GameObject FlowerPickerUI;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void SelectTeacupPicker() {
		TeacupPickerUI.SetActive (!TeacupPickerUI.activeInHierarchy);
		FlowerPickerUI.SetActive (false);
		Debug.Log ("teacup");
	}

	public void SelectFlowerPicker() {
		FlowerPickerUI.SetActive (!FlowerPickerUI.activeInHierarchy);
		TeacupPickerUI.SetActive (false);
		Debug.Log ("flower");
	}
}
