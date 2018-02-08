using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowerPicker : MonoBehaviour {

    /*
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
    */

	public GameObject HeadFlower;
	public GameObject PickerFlower;
	private int itemSpot = 0;
	public List<GameObject> PetalTypes;

    public Inventory inventory;


    public void RightSelection()
	{
		if (itemSpot < inventory.GetFlowerCount() - 1) {
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
			itemSpot = inventory.GetFlowerCount() - 1;
		}

		//FlowersInventory [itemSpot];
		UpdateHeadFlower ();
		UpdatePickerFlower ();
	}

	void UpdateHeadFlower()
	{
		// sf means selected flower
		Flower sf = inventory.GetFlower(itemSpot); 
		HeadFlower.GetComponent<CreateFlower>().Change(sf.getPetalShape(), sf.getPetalColor(), sf.getPetalCount());
	}

	void UpdatePickerFlower()
	{
		// sf means selected flower
		Flower sf = inventory.GetFlower(itemSpot); 
		PickerFlower.GetComponent<CreateFlower>().Change(sf.getPetalShape(), sf.getPetalColor(), sf.getPetalCount());
    }

	// Use this for initialization
	void Start () {
        inventory = new Inventory();
        inventory.AddFlower(inventory.Scavenge());
        inventory.AddFlower(inventory.Scavenge());
        inventory.AddFlower(inventory.Scavenge());
        inventory.AddFlower(inventory.Scavenge());
        inventory.AddFlower(inventory.Scavenge());
        inventory.AddFlower(inventory.Scavenge());

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
