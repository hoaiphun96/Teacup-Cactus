using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
	private static List<Flower> Flowers = new List<Flower>();
		
	public static List<Flower> FlowersInventory {
		get { return Flowers; }
	}

	// Use this for initialization
	void Start () {
		
	}

	void addNewFlower() {
		
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}

public class Flower: MonoBehaviour {
	public GameObject petal;
	public GameObject dot;
	public Color color;
	public int petalCount;
}

public class Teacup: MonoBehaviour {
}	