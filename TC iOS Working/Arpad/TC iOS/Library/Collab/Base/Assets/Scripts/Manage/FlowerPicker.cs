using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class FlowerPicker : MonoBehaviour {
	public GameObject HeadFlower;
	public GameObject PickerFlower;

	public void ChangeIndex(int indexChange)
	{	
		int flowersLen = Inventory.FlowerList.Count;
		int flowerIndex = PlayerPrefs.GetInt ("Flower Index");
		if (indexChange == -1) {
			bool done = false;
			while (!done) {
				if (flowerIndex == 0) {
					flowerIndex = LastFlower ();
				} else {
					flowerIndex -= 1;
				}
				if (Inventory.FlowerList [flowerIndex] != null) {
					done = true;
				}
			}
		} else if (indexChange == 1) {
			bool done = false;
			while (!done) {
				if (flowerIndex == flowersLen - 1) {
					flowerIndex = FirstFlower ();
				} else {
					flowerIndex += 1;
				}
				if (Inventory.FlowerList [flowerIndex] != null) {
					done = true;
				}
			}
		}
		PlayerPrefs.SetInt ("Flower Index", flowerIndex);
		PlayerPrefs.Save ();
		UpdateGameObjects ();
	}
	int FirstFlower(){
		for (int i = 0; i < Inventory.FlowerList.Count; i++) {
			if (Inventory.FlowerList [i] != null) {
				print (String.Format ("Firstflower index {0}", i));
				return i;
			}
		}
		print ("Firstflower index by default 0");
		return 0;
	}

	int LastFlower(){
		int flowerLen = Inventory.FlowerList.Count;
		for (int i = flowerLen - 1; i >= 0; i--) {
			if (Inventory.FlowerList[i] != null) {
				print (String.Format ("lastflower index {0}", i));
				return i;
			}
		}
		print ("lastflower index by default 0");
		return 0;
	}

	void UpdateGameObjects () {
		int index = PlayerPrefs.GetInt ("Flower Index");
		//check in case the head flower was deleted
		if (Inventory.FlowerList [index] != null) {
			string[] newGenes = Inventory.GetFlower (index).genes;
			//Debug.Log (newGenes);
			UpdateHeadFlower (newGenes);
			UpdatePickerFlower (newGenes);
		} else {
			ChangeIndex (-1);
			UpdateGameObjects ();
		}
	}

	void UpdateHeadFlower(string[] newGenes)
	{
		HeadFlower.GetComponent<CreateFlower>().ChangeGenes(newGenes);
	}

	void UpdatePickerFlower(string[] newGenes)
	{
		PickerFlower.GetComponent<CreateFlower>().ChangeGenes(newGenes);
	}


	void Start () {
		StartCoroutine(UpdateGameObjectsShortlyAfterStart ());
	}

	IEnumerator UpdateGameObjectsShortlyAfterStart () {
		yield return new WaitForSeconds (0.001F);
		UpdateGameObjects ();
		StopCoroutine (UpdateGameObjectsShortlyAfterStart ());
	}

	void Awake(){
		//gameObject.SetActive (true);
	}
}
