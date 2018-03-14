using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour {

	public static Inventory instance;
	public static Inventory Instance {
		get { return instance; }
	}
	public static PlantDatabase FlowerData;
	public static TeacupDatabase TeacupData;
	public static PlantGoal Goal;

	public static CircularLinkedList<Flower> FlowerList;
	public static CircularLinkedList<Teacup> TeacupList;

	public static List<WalkingChallenge> WalkingChallenges = new List<WalkingChallenge>();

	private string[] nextFlower_dna;
	public static int NumberOfFlower;


	void Start () {
		UnityEngine.Random.InitState((int)System.DateTime.Now.Ticks);


		if (!PlayerPrefs.HasKey ("Flower Index")) {
			PlayerPrefs.SetInt ("Flower Index", 0);
		} else if (PlayerPrefs.GetInt ("Flower Index") > FlowerList.Count - 1) {
			PlayerPrefs.SetInt ("Flower Index",0);
		}
		if (PlayerPrefs.HasKey (DateTime.Now.Date.ToString ()) == false) {
			PlayerPrefs.SetInt (DateTime.Now.Date.ToString (), 0);
		}
		if (!PlayerPrefs.HasKey ("Next Flower")) {
		}

		addNewChallenge ();

	}

	void addNewChallenge() {
		WalkingChallenge wc1 = new WalkingChallenge (0, "Walk 31000 steps in one day", false, PlayerPrefs.GetInt ("Steps"), 31000, "special-knox");
		WalkingChallenge wc2 = new WalkingChallenge (1, "Walk 315000 steps in one day", false, PlayerPrefs.GetInt ("Steps"), 31500, "special-polkadot");
		WalkingChallenges.Add (wc1);
		WalkingChallenges.Add (wc2);
	}
	void Awake() {
		if (instance != null && instance != this) {
			Destroy (this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad (this.gameObject);
		SaveData.Load ();
	}

	public static Teacup AddTeacup(string str){
		Teacup teacup = new Teacup (TeacupData, str);

		Inventory.TeacupList.AddFirst(teacup);
		SaveData.Save ();

		return teacup;
	}

	public static Flower ScavengeFlower()
	{
		Flower childFlower = new Flower(FlowerData);
		FlowerList.AddLast(childFlower);
		SaveData.Save ();

		return childFlower;
	}

	public static Flower BreedFlower(int motherIndex, int fatherIndex)
	{
		Flower mother = Inventory.GetFlower(motherIndex);
		Flower father = Inventory.GetFlower(fatherIndex);
		Flower childFlower = mother.Breed(father);
		FlowerList.AddLast(childFlower);
		SaveData.Save ();
		//Remove Flower

		return childFlower;
	}

	public static Flower GetFlower(int index){
		return FlowerList[index].Value;
	}
		


	public static void evaluateChallenges() {
		WalkingChallenge wc1 = WalkingChallenges [0];
		wc1.UpdateCurrentAmount ();
		wc1.Evaluate ();
		if (wc1.Completed == true) {
			Debug.Log ("Completed wc1");
			ChallengeManager.isWC1Completed = true;
		}

		WalkingChallenge wc2 = WalkingChallenges [1];
		wc2.UpdateCurrentAmount ();
		wc2.Evaluate ();
		if (wc2.Completed == true) {
			Debug.Log ("Completed wc2");
			ChallengeManager.isWC2Completed = true;
		}

		int prevTier = Goal.GetTier();
		string[] prevGoal = Goal.GetGoal ();

		if(Goal.isGoal(FlowerList)){
			Debug.Log ("Completed Flower Goal t#" + prevTier + ", " + prevGoal);
			ChallengeManager.isWC3Completed = true;
			//Remove Flower
		}


	}
} 