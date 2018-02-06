using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeacupPicker : MonoBehaviour {

	public Image SelectionImage;
	public List<Sprite> TeacupsInventory;
	private int itemSpot = 0;
	public GameObject PunkinsTeacup;

	public void RightSelection()
	{
		if (itemSpot < TeacupsInventory.Count - 1) {
			itemSpot++;
		} else {
			itemSpot = 0;
		}
		SelectionImage.sprite = TeacupsInventory [itemSpot];
		UpdatePunkinsTeacup ();
	}

	public void LeftSelection()
	{
		if (itemSpot > 0) {
			itemSpot--;
		} else {
			itemSpot = TeacupsInventory.Count - 1;
		}
		SelectionImage.sprite = TeacupsInventory [itemSpot];
		UpdatePunkinsTeacup ();
	}

	void UpdatePunkinsTeacup ()
	{
		PunkinsTeacup.GetComponent<SpriteRenderer> ().sprite = SelectionImage.sprite;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
