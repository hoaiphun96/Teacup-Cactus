using UnityEngine;
using UnityEngine.UI;

public class GoalTextField : MonoBehaviour {

	public GameObject goalTextField;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey("Goal")) {
			goalTextField.GetComponentInChildren<Text>().text = PlayerPrefs.GetInt ("Goal").ToString ();
		}
	}

	void Awake() {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
