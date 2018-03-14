using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour {

	public static Inventory instance;
	public static Inventory Instance {
		get { return instance; }
	}
	public static PlantDatabase FlowerData;
	public static PlantGoal Goal;
	public static List<Flower> Flowers;
	public List<Sprite> Teacups;
	//public static Dictionary<DateTime, bool> GoalCompleted = new Dictionary<DateTime, bool>();
	private string[] nextFlower_dna;

	void Start () {
		UnityEngine.Random.InitState((int)System.DateTime.Now.Ticks);

		SaveData.Load ();

		if (!PlayerPrefs.HasKey ("Flower Index")) {
			PlayerPrefs.SetInt ("Flower Index", 0);
		} else if (PlayerPrefs.GetInt ("Flower Index") > Flowers.Count - 1) {
			PlayerPrefs.SetInt ("Flower Index",0);
		}
		//if (GoalCompleted.ContainsKey(DateTime.Now.Date) == false) {
		//	GoalCompleted.Add (DateTime.Now.Date, false); }
		if (PlayerPrefs.HasKey (DateTime.Now.Date.ToString ()) == false) {
			PlayerPrefs.SetInt (DateTime.Now.Date.ToString (), 0);
			Debug.Log ("Setting goal completed today to false");
		}
		if (!PlayerPrefs.HasKey ("Next Flower")) {
		}
			
    }

	void Awake() {
		if (instance != null && instance != this) {
			Destroy (this.gameObject);
			return;
		} else {
			instance = this;
		}
		//Oprah 2020
		DontDestroyOnLoad (this.gameObject);

	}

    public static int ScavengeFlower()
    {
        Flower child = new Flower(FlowerData);
		AddNewFlower (child);
        return Flowers.Count;
    }

    public static int BreedFlower(int motherIndex, int fatherIndex)
    {
        Flower mother = GetFlower(motherIndex);
        Flower father = GetFlower(fatherIndex);
        Flower childFlower = mother.Breed(father);
        AddNewFlower(childFlower);
        return Flowers.Count;
    }

    public static void AddNewFlower(Flower flower)
    {
		bool foundNullSlot = false;
		for (int i = 0; i < Flowers.Count; i++) {
			if (Flowers [i] == null) {
				foundNullSlot = true;
				Flowers [i] = flower;
				SaveData.Save(FlowerData, Flowers, Goal);
				break;
			}
		}
		//if no empty slot found, add to the end of list
		if (foundNullSlot == false) {
			Flowers.Add (flower);
			SaveData.Save(FlowerData, Flowers, Goal);
		}
    }

	public static void RemoveFlower(int i,int j) 
	{
		Flowers [i] = null;
		Flowers [j] = null;
		SaveData.Save(FlowerData, Flowers, Goal);
	}

    public static Flower GetFlower(int index)
    {
        return Flowers[index];
    }

}

public class Teacup: MonoBehaviour {
}	