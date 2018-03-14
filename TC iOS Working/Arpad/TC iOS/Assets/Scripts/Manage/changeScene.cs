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
		SceneManager.LoadScene ("Main Scene", LoadSceneMode.Single);
	}

	public void changeToSettingsScene() {
		SceneManager.LoadScene ("Settings Scene", LoadSceneMode.Single);
	}

	public void changeToFlowerPickerScene() {
		SceneManager.LoadScene ("Flower Picker Scene", LoadSceneMode.Single);
	}

	public void changeToTeacupPickerScene() {
		SceneManager.LoadScene ("Teacup Picker", LoadSceneMode.Single);
	}

	public void changeToTitleScene() {
		SceneManager.LoadScene ("Title Scene", LoadSceneMode.Single);
	}

	public void changeToAboutScene() {
		SceneManager.LoadScene ("About Scene", LoadSceneMode.Single);
	}

	public void changeToSeedScene() {
		SceneManager.LoadScene ("Seed Scene", LoadSceneMode.Single);

		//TO DO: display pop up: You need more than 2 flowers to breed
	}

	public void changeToChallengeScene() {
		SceneManager.LoadScene ("Challenge Scene", LoadSceneMode.Single);
	}

	public void changeToStatisticsScene() {
		SceneManager.LoadScene ("Statistics Scene", LoadSceneMode.Single);
	}

	public void changeToDebugScene() {
		SceneManager.LoadScene ("Debug Scene", LoadSceneMode.Single);
	}
}
