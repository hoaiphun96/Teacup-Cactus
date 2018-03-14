using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableSeedButton : MonoBehaviour {

	void Update() {
		if (Inventory.NumberOfFlower < 2) {
			gameObject.GetComponent<Button> ().interactable = false;
		} else {
			gameObject.GetComponent<Button>().interactable = true;
		}

	}
}
