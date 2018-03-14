using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFlowerPossibilitySpace : MonoBehaviour {

	public List<GameObject> PetalTypes;
	public GameObject round;
	public GameObject pointed;
	public GameObject forked;

	public int petalIndex;
	public int colorIndex;
	public int petalCountE;

	public RangeInt delta;

	public List<Color> Colors;

	public GameObject dot;

	// Use this for initialization
	void Start () {
		PetalTypes = new List<GameObject>();
		Colors = new List<Color> ();

		PetalTypes.Add (round);
		PetalTypes.Add (pointed);
		PetalTypes.Add (forked);

		//Colors.Add ("red", new Color (1.0F, 1.0F, 1.0F, 1.0F)); //red
		Colors.Add (new Color (244.0F/255.0F, 67.0F/255.0F, 54.0F/255.0F, 1.0F)); //red
		Colors.Add (new Color (255F/255.0F, 152F/255.0F, 0F)); //orange
		Colors.Add (new Color (255F/255.0F, 235F/255.0F, 59F/255.0F)); //yellow
		Colors.Add (new Color (33F/255.0F, 150F/255.0F, 243F/255.0F)); //blue
		Colors.Add (new Color (95F/255.0F, 81F/255.0F, 181F/255.0F)); //indigo
		Colors.Add (new Color (156F/255.0F, 39F/255.0F, 176F/255.0F)); //purple
		Colors.Add (new Color (233F/255.0F, 30F/255.0F, 99F/255.0F)); //pink

		StartCoroutine (ExploreSpace());
		/*
		int FlowerIndex = PlayerPrefs.GetInt("Flower Index");
		string[] initGenes = Inventory.GetFlower (FlowerIndex).genes;
		this.ChangeGenes (initGenes);
		*/
	}

	void Update () {
		
	}

	IEnumerator ExploreSpace () {
		while (colorIndex < Colors.Count) {
			this.Render (PetalTypes[petalIndex], Colors[colorIndex], petalCountE);

			if (petalCountE >= 12) {
				petalCountE = 0;
				if (petalIndex >= PetalTypes.Count - 1) {
					petalIndex = 0;
					colorIndex++;
				} else {
					petalIndex++;
				}
			} else {
				petalCountE++;
			}


			yield return new WaitForSeconds (0.1F);
		}
		StopCoroutine (ExploreSpace ());
	}

	/*
	//overloaded method for unpacking
			//petal shape, petal color, petal count
	public void ChangeGenes(string[] data) {
		this.ChangeGenes (data[0], data[1], data[2]);
	}


	public void ChangeGenes(string newPetal, string newColor, string newPetalCount) {
		//Destroys all previous petals and center dot
		DestroyChildren ();
		//Reset scale
		gameObject.transform.localScale = Vector3.one;

		//Change strings to appropriate data types.
		//This is done within CreateFlower, rather than Flower,
		//because CreateFlower is a monobehaviour,
		//and can interact with gameobjects, like the petals and dots
		newPetal = newPetal.ToLower();
		GameObject petalRef = PetalTypes[newPetal];

		newColor = newColor.ToLower();
		Color color = Colors[newColor];

		Debug.Log (color);

		int petalCount = int.Parse (newPetalCount);

		//Repopulates gameobject with petal and dot children
		Render (petalRef, color, petalCount);
	}
	*/

	void DestroyChildren() {
		foreach (Transform child in transform) {
			Destroy (child.gameObject);
		}
	}

	void Render(GameObject petal, Color color, int petalCount) {
		//Destroys all previous petals and center dot
		DestroyChildren ();
		//Reset scale
		gameObject.transform.localScale = Vector3.one;
			
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
