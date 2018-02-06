using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFlower : MonoBehaviour {

	public GameObject petal;
	public GameObject dot;
	public Color color;
	public int petalCount;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Change(GameObject newPetal, Color newColor, int newPetalCount) {
		petal = newPetal;
		color = newColor;
		petalCount = newPetalCount;
		DestroyChildren ();
		//Reset scale
		gameObject.transform.localScale = Vector3.one;
		Render ();
	}

	void DestroyChildren() {
		foreach (Transform child in transform) {
			Destroy (child.gameObject);
		}
	}

	void Render() {

		for (int i = 0; i < petalCount; i++) 
		{
			GameObject child = Instantiate(petal) as GameObject;
			SpriteRenderer childSpriteRenderer = child.GetComponent<SpriteRenderer> ();
			childSpriteRenderer.color = color;
			child.transform.parent = gameObject.transform;

			child.transform.localPosition = Vector2.up * (childSpriteRenderer.bounds.extents.magnitude);

			float petal_rotation = ((360f / petalCount) * i);
			child.transform.RotateAround(gameObject.transform.position, Vector3.forward, petal_rotation);
		}


		// Instantiating the center dot of the flower as a child.
		GameObject dotChild = Instantiate(dot) as GameObject;
		dotChild.transform.parent = gameObject.transform;
		//may cause layer issues
		dotChild.transform.localPosition = new Vector3(0f,0f,-1f);
		SpriteRenderer dotChildSpriteRenderer = dotChild.GetComponent<SpriteRenderer> ();
		dotChildSpriteRenderer.color = Color.white;

		gameObject.transform.localScale = Vector3.one * 0.3f;
	}
}
