using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowerPicker : MonoBehaviour {

	public class Flower
	{
		public Color color;
		public int petalCount;
		public GameObject petalShape;

		public Flower(GameObject pShape, Color pColor, int pCount) 
		{
			color = pColor;
			petalCount = pCount;
			petalShape = pShape; 
		}
	}

	public List<Flower> FlowersInventory;
	public GameObject HeadFlower;
	public GameObject PickerFlower;
	private int itemSpot = 0;
	public List<GameObject> PetalTypes;

	public void RightSelection()
	{
		if (itemSpot < FlowersInventory.Count - 1) {
			itemSpot++;
		} else {
			itemSpot = 0;
		}

		//FlowersInventory [itemSpot];
		UpdateHeadFlower ();
		UpdatePickerFlower ();
	}

	public void LeftSelection()
	{
		if (itemSpot > 0) {
			itemSpot--;
		} else {
			itemSpot = FlowersInventory.Count - 1;
		}

		//FlowersInventory [itemSpot];
		UpdateHeadFlower ();
		UpdatePickerFlower ();
	}

	void UpdateHeadFlower()
	{
		// sf means selected flower
		Flower sf = FlowersInventory [itemSpot]; 
		HeadFlower.GetComponent<CreateFlower>().Change(sf.petalShape, sf.color, sf.petalCount);
	}

	void UpdatePickerFlower()
	{
		// sf means selected flower
		Flower sf = FlowersInventory [itemSpot]; 
		PickerFlower.GetComponent<CreateFlower>().Change(sf.petalShape, sf.color, sf.petalCount);
	}

	// Use this for initialization
	void Start () {
		FlowersInventory = new List<Flower> (3);
		FlowersInventory.Add (new Flower (PetalTypes[0], new Color(.3F,.3F,.95F, 1F), 3));
		FlowersInventory.Add (new Flower (PetalTypes[1], new Color(.95F,.3F,.3F, 1F), 4));
		FlowersInventory.Add (new Flower (PetalTypes[2], Color.yellow, 6));

		FlowersInventory.Add (new Flower (PetalTypes[0], new Color(.95F,.5F,.95F, 1F), 8));
		FlowersInventory.Add (new Flower (PetalTypes[1], new Color(.95F, .3F, .3F, 1F), 5));
		FlowersInventory.Add (new Flower (PetalTypes[2], Color.yellow, 2));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
