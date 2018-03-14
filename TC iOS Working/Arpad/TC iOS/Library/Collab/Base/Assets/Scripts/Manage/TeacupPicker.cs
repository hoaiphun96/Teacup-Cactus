using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeacupPicker : MonoBehaviour {

	public Image SelectionImage;
	private int itemSpot = 0;
	public GameObject PunkinsTeacup;

	void Start() {
		if (PlayerPrefs.HasKey ("Teacup Index")) {
			itemSpot = PlayerPrefs.GetInt ("Teacup Index");
		}
		SelectionImage.sprite = Resources.Load<Sprite>("TeacupAssets/" + Inventory.TeacupList[itemSpot].Value.ToString()) as Sprite;
	}

	public void RightSelection()
	{
		if (itemSpot < Inventory.TeacupList.Count - 1) {
			itemSpot++;
		} else {
			itemSpot = 0;
		}
		SelectionImage.sprite = Resources.Load<Sprite>("TeacupAssets/" + Inventory.TeacupList[itemSpot].Value.ToString()) as Sprite;
		UpdatePunkinsTeacup ();
	}

	public void LeftSelection()
	{
		if (itemSpot > 0) {
			itemSpot--;
		} else {
			//itemSpot = Inventory.Instance.Teacups.Count - 1;
		itemSpot = Inventory.TeacupList.Count - 1;
		} 

		//SelectionImage.sprite = Inventory.Instance.Teacups[itemSpot];
		SelectionImage.sprite = Resources.Load<Sprite>("TeacupAssets/" + Inventory.TeacupList[itemSpot].Value.ToString());
		UpdatePunkinsTeacup ();
	}

	void UpdatePunkinsTeacup ()
	{
		PlayerPrefs.SetInt ("Teacup Index", itemSpot);
		PlayerPrefs.Save ();
		PunkinsTeacup.GetComponent<SpriteRenderer> ().sprite = SelectionImage.sprite;
	}

}
