// reducing updates code from https://answers.unity.com/questions/17131/execute-code-every-x-seconds-with-update.html

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChallengeManager : MonoBehaviour {
	public List<Text> Challenges;
	public static bool isWC1Completed;
	public static bool isWC2Completed;
	public static bool isWC3Completed;
	public Button ClaimReward1;
	public Button ClaimReward2;
	public Button ClaimReward3;
	public GameObject Panel1;
	public GameObject Panel2;
	public GameObject Panel3;

	private float nextActionTime = 0.0f;
	public float period = 0.1f;

	void Update() {
		if (Time.time > nextActionTime) {
			nextActionTime += period;
			Inventory.evaluateChallenges ();
			if (isWC1Completed == true) {
				Panel1.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("ChallengeSceneAssets/1x/challenge-scene-done-panel");
				if (!PlayerPrefs.HasKey ("Challenge 1")) {
					ClaimReward1.interactable = true;
					Debug.Log ("Complete WC1");
				}
			}
			if (isWC2Completed == true) {
				Panel2.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("ChallengeSceneAssets/1x/challenge-scene-done-panel");
				if (!PlayerPrefs.HasKey ("Challenge 2")) {
					ClaimReward2.interactable = true;
					Debug.Log ("Complete WC2");
				}
			}
			
			Challenges [2].text = Inventory.Goal.GetGoalString ();
			if (isWC3Completed == true) {
				Panel3.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("ChallengeSceneAssets/1x/challenge-scene-done-panel");
				if (!PlayerPrefs.HasKey ("Challenge 3")) {
					ClaimReward3.interactable = true;
					Debug.Log ("Complete WC3");
				}
			}
		}
			
		
	}

	public void ClaimButtonClicked(int rewardNumber) {
		//if 1 add knox teacup, if 2 add polka dot, if 3 add heart teacup
		if (rewardNumber == 1) {
			Inventory.AddTeacup ("special-knox");
			ClaimReward1.interactable = false;
			PlayerPrefs.SetInt ("Challenge 1", 1);
		} else if (rewardNumber == 2) {
			Inventory.AddTeacup("special-polkadot");
			ClaimReward2.interactable = false;
			PlayerPrefs.SetInt ("Challenge 2", 1);
		} else {
			Inventory.AddTeacup("special_round_heart");
			ClaimReward3.interactable = false;
			PlayerPrefs.SetInt ("Challenge 3", 1);
		}
		//call this function from Claim button OnClick()
	}
}
