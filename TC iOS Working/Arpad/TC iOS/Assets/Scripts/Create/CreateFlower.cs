using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class CreateFlower : MonoBehaviour {

	public Dictionary<string, GameObject> PetalTypes;
	public GameObject round;
	public GameObject pointed;
	public GameObject forked;
	public GameObject dot;

	public float scale;
	public float transformScalar;
	public float desiredZPos;
	public bool rotationEnabled;
	public bool popup;

	public Dictionary<string, Color> Colors;

	private float rotationAnimationOffset;

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
	}

	void Start() {
		rotationAnimationOffset = ((float)GetComponentInParent<Transform> ().rotation.z) / 2.5f;

		//gameObject.transform.localScale = Vector3.one;
		this.gameObject.transform.localScale = Vector2.one * scale;
		ChangeGenes (Inventory.GetFlower(PlayerPrefs.GetInt("Flower Index")).genes);
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
		if (rotationEnabled) {
			int period = 120;
			float max_degrees_of_rotation = 360 / (transform.childCount-1);

			//[-1,1]
			float sinusoidal_scalar = Mathf.Sin (2 * Mathf.PI * ((float)(Time.frameCount % period) / period) + rotationAnimationOffset);

			foreach (Transform child in transform) {
				//float petal_rotation = child.localRotation.eulerAngles.z;
				float rotation_amt = sinusoidal_scalar * 2 * max_degrees_of_rotation / period;
				//petal_rotation += rotation_amt;

				child.transform.RotateAround (this.gameObject.transform.position, Vector3.forward, rotation_amt);
			}
		}

	}

	//overloaded method for unpacking
	public void ChangeGenes(string[] data) {
		this.ChangeGenes (data[0], data[1], data[2]);
	}

	public void ChangeGenes(string newPetal, string newColor, string newPetalCount) {
		//Destroys all previous petals and center dot
		DestroyChildren ();
		//Reset scale
		//gameObject.transform.localScale = Vector3.one;

		//update the animationoffset
		rotationAnimationOffset = ((float)GetComponentInParent<Transform> ().rotation.z) / 2.5f;

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

	void DestroyChildren() {
		foreach (Transform child in transform) {
			Destroy (child.gameObject);
		}
	}

	void Render(GameObject petal, Color color, int petalCount) {
//		Vector3 p = this.gameObject.transform.localPosition;
//		Debug.Log (String.Format("Parent transform position: x:{0} y:{1} z:{2}", p.x, p.y, p.z));

		for (int i = 0; i < petalCount; i++) 
		{
			

			GameObject child = Instantiate(petal) as GameObject;
			child.transform.SetParent(this.gameObject.transform);
			child.transform.localPosition = new Vector3 (0, 0, 0);
			child.transform.localScale = Vector2.one * scale;

//			p = child.transform.localPosition;
//			Debug.Log (String.Format("Petal pre-transform position: x:{0} y:{1} z:{2}", p.x, p.y, p.z));


			SpriteRenderer childSpriteRenderer = child.GetComponent<SpriteRenderer> ();
			child.transform.localPosition = (Vector2.up * (childSpriteRenderer.bounds.extents.magnitude)) * (transformScalar);
			childSpriteRenderer.color = color;
			if(popup)
				childSpriteRenderer.sortingLayerName = "Popups";
			
			float petal_rotation = ((360f / petalCount) * i);
			child.transform.RotateAround(this.gameObject.transform.position, Vector3.forward, petal_rotation);

//			p = child.transform.localPosition;
//			Debug.Log (String.Format("Petal post-transform position: x:{0} y:{1} z:{2}", p.x, p.y, p.z));
		}

		GameObject dotChild = Instantiate(dot) as GameObject;

		dotChild.transform.parent = this.gameObject.transform;
		dotChild.transform.localPosition = new Vector3 (0, 0, 0);
		dotChild.transform.localScale = Vector2.one * scale;

//		p = dotChild.transform.localPosition;
//		Debug.Log (String.Format("Dot transform position: x:{0} y:{1} z:{2}", p.x, p.y, p.z));

		SpriteRenderer dotChildSpriteRenderer = dotChild.GetComponent<SpriteRenderer> ();
		dotChildSpriteRenderer.sortingOrder = 1;
		if(popup)
			dotChildSpriteRenderer.sortingLayerName = "Popups";
		// if the color is not white, then the center is white. if the color is white, the center is yellow. for now.
		if(!color.Equals(Colors["white"])) {
			dotChildSpriteRenderer.color = Color.white;
		} else {
			dotChildSpriteRenderer.color = Colors["yellow"];
		}
	}
}
