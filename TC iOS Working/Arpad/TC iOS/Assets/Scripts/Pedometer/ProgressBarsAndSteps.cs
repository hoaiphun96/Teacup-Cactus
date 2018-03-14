
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
public class ProgressBarsAndSteps : MonoBehaviour {

	public GameObject stepText;
	public GameObject teacupPickerUI, flowerPickerUI;
	public GameObject congratulationsPanel;
	public GameObject walkingProgressBar;


	// Update is called once per frame
	void Update () {
		stepText.GetComponentInChildren<Text> ().text = string.Format ("{0} steps", PlayerPrefs.GetInt("Steps"));
		if (PlayerPrefs.GetInt("Steps") >= PlayerPrefs.GetInt("Goal")) {
			walkingProgressBar.GetComponent<Slider> ().value = 1.0f;
			if (PlayerPrefs.HasKey(DateTime.Now.Date.ToString())) {
				if (PlayerPrefs.GetInt (DateTime.Now.Date.ToString ()) == 0) {
					Flower child = Inventory.ScavengeFlower ();
					disableUIs ();
					congratulationsPanel.SetActive(true);
					congratulationsPanel.GetComponentInChildren<CreateFlower>().ChangeGenes(child.genes);
					PlayerPrefs.SetInt (DateTime.Now.Date.ToString (), 1);
				}
			}
	
		} else { 
			walkingProgressBar.GetComponent<Slider>().value = (float) (PlayerPrefs.GetInt("Steps") ) / PlayerPrefs.GetInt("Goal");
		} 

		// Debug Space Bar
		if (Input.GetKeyDown ("space")) {
			PlayerPrefs.SetInt("Steps", PlayerPrefs.GetInt("Steps") + 100);
	
		}
		if (Input.GetKeyDown (KeyCode.B)) {
			PlayerPrefs.SetInt("Steps", PlayerPrefs.GetInt("Steps") - 100);

		}
		if (Input.GetKeyDown(KeyCode.A)) {
			DebugAddNewFlower ();
		}
	}

	void disableUIs() {
		teacupPickerUI.SetActive (false);
		flowerPickerUI.SetActive (false);
	}

	public void DebugAddNewFlower(){
		Flower child = Inventory.ScavengeFlower ();
		congratulationsPanel.SetActive (true);
		congratulationsPanel.GetComponentInChildren<CreateFlower> ().ChangeGenes (child.genes);
	}
	/* used for debugging
	void Awake(){
		PlayerPrefs.SetInt (DateTime.Now.Date.ToString (), 0);
	}
	*/
}
