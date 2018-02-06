using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeacupPicker : MonoBehaviour {

	public Image SelectionImage;
	public List<Sprite> TeacupsInventory;
	private int itemSpot = 0;
	public void RightSelection()
	{
		if (itemSpot < TeacupsInventory.Count - 1) {
			itemSpot++;
		} else {
			itemSpot = 0;
		}
		SelectionImage.sprite = TeacupsInventory [itemSpot];

	}

	public void LeftSelection()
	{
		if (itemSpot > 0) {
			itemSpot--;
		} else {
			itemSpot = TeacupsInventory.Count - 1;
		}
		SelectionImage.sprite = TeacupsInventory [itemSpot];
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
