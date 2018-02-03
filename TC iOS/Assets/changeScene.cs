using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void changeToScene() {
		SceneManager.LoadScene ("Main Scene", LoadSceneMode.Additive);
	}

	public void changeToSettingsScene() {
		SceneManager.LoadScene ("Settings Scene", LoadSceneMode.Additive);
	}

	public void changeToFlowerPickerScene() {
		SceneManager.LoadScene ("Flower Picker Scene", LoadSceneMode.Additive);
	}

	public void changeToTeacupPickerScene() {
		SceneManager.LoadScene ("Teacup Picker Scene", LoadSceneMode.Additive);
	}

	public void changeToTitleScene() {
		SceneManager.LoadScene ("Title Scene", LoadSceneMode.Additive);
	}
}
