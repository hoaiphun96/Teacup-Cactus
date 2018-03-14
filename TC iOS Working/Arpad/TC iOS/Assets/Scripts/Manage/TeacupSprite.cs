using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacupSprite : MonoBehaviour {

	// Use this for initialization
	void Start () {

		if (PlayerPrefs.HasKey("Teacup Index")) {
			gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("TeacupAssets/" + Inventory.TeacupList[PlayerPrefs.GetInt ("Teacup Index")].Value.ToString());
		} else {
			gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("TeacupAssets/" + Inventory.TeacupList[0].Value.ToString()) ;
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
