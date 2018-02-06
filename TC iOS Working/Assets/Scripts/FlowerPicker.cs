using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowerPicker : MonoBehaviour {

	public Image SelectionImage;
	public List<Sprite> FlowersInventory;
	private int itemSpot = 0;
	public void RightSelection()
	{
		if (itemSpot < FlowersInventory.Count - 1) {
			itemSpot++;
		} else {
			itemSpot = 0;
		}
		SelectionImage.sprite = FlowersInventory [itemSpot];
	}

	public void LeftSelection()
	{
		if (itemSpot > 0) {
			itemSpot--;
		} else {
			itemSpot = FlowersInventory.Count - 1;
		}
		SelectionImage.sprite = FlowersInventory [itemSpot];
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
