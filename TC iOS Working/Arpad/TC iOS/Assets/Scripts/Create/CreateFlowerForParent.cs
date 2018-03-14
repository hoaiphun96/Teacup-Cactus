using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CreateFlowerForParent : MonoBehaviour {

	public Dictionary<string, GameObject> PetalTypes;
	public GameObject round;
	public GameObject pointed;
	public GameObject forked;

	public float scale;
	public float transformScalar;

	public Dictionary<string, Color> Colors;

	public GameObject dot;

	// Use this for initialization
	void Awake () {
		PetalTypes = new Dictionary<string, GameObject>();
		Colors = new Dictionary<string, Color> ();

		PetalTypes.Add ("round", round);
		PetalTypes.Add ("pointed", pointed);
		PetalTypes.Add ("forked", forked);

		Colors.Add ("white", HexToColor ("fa fa fa"));
		Colors.Add ("red", HexToColor ("f4 43 36"));
		Colors.Add ("pink", HexToColor ("f4 8f b1"));
		Colors.Add ("blue", HexToColor ("21 96 f3"));
		Colors.Add ("lightblue", HexToColor ("90 ca f9"));
		Colors.Add ("purple", HexToColor ("8e 24 aa"));
		Colors.Add ("lightpurple", HexToColor ("ba 68 c8"));
		Colors.Add ("orange", HexToColor ("ff 98 00"));
		Colors.Add ("lightorange", HexToColor ("ff cc 80"));
		Colors.Add ("yellow", HexToColor ("fd d8 35"));
		Colors.Add ("lightyellow", HexToColor ("ff f1 76"));

		//ChangeGenes (Inventory.GetFlower(PlayerPrefs.GetInt("Flower Index")).genes);
	}

	void Start () {
		enabled = true;
	}

	Color HexToColor(string hex) {
		string[] hex_rgb_components = hex.Split (' ');
		float[] float_rbg_components = hex_rgb_components.Select(x => HexComponentToFloat(x)).ToArray();
		return new Color (float_rbg_components[0], float_rbg_components[1], float_rbg_components[2]);
	}

	float HexComponentToFloat(string hex_component) {
		return ((float) System.Convert.ToInt32(hex_component, 16) / 255);
	}

	// Update is called once per frame
	void Update () {

	}

	//overloaded method for unpacking
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

		int petalCount = int.Parse (newPetalCount);

		//Repopulates gameobject with petal and dot children
		Render (petalRef, color, petalCount);
	}

	public void DestroyChildren() {
		foreach (Transform child in transform) {
			Destroy (child.gameObject);
		}
	}

	void Render(GameObject petal, Color color, int petalCount) {

		for (int i = 0; i < petalCount; i++) 
		{
			GameObject child = Instantiate(petal) as GameObject;
			SpriteRenderer childSpriteRenderer = child.GetComponent<SpriteRenderer> ();
			childSpriteRenderer.color = color;
			child.transform.parent = gameObject.transform;
			child.transform.localScale = new Vector3(scale, scale, 1);
			child.transform.localPosition = Vector2.up * (childSpriteRenderer.bounds.extents.magnitude) * transformScalar;

			float petal_rotation = ((360f / petalCount) * i);
			child.transform.RotateAround(gameObject.transform.position, Vector3.forward, petal_rotation);

		}


		// Instantiating the center dot of the flower as a child.
		GameObject dotChild = Instantiate(dot) as GameObject;
		dotChild.transform.parent = gameObject.transform;
		//may cause layer issues
		dotChild.transform.localPosition = new Vector3(0f,0f,-1f);
		dotChild.transform.localScale = new Vector3(scale, scale, 1);
		SpriteRenderer dotChildSpriteRenderer = dotChild.GetComponent<SpriteRenderer> ();

		// if the color is not white, then the center is white. if the color is white, the center is yellow. for now.
		if(!color.Equals(Colors["white"])) {
			dotChildSpriteRenderer.color = Color.white;
		} else {
			dotChildSpriteRenderer.color = Colors["yellow"];
		}
	}


}
