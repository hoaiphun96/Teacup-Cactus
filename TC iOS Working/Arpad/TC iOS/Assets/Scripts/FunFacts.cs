using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FunFacts : MonoBehaviour {
	public static List<string> Facts = new List<string>(5);

	// Use this for initialization

	void Start () {
		Facts.Add ("The experts agree, walk 6,000 steps a day to improve your health, and 10,000 to lose weight.");
		Facts.Add ("One mile is about 2,000 steps, or a 20-minute walk.");
		Facts.Add ("Walking one mile a day burns 100 calories. You could lose ten pounds in a year without changing your eating habits.");
		Facts.Add ("Avoiding just 10 miles of driving every week would eliminate 500 pounds of carbon dioxide emissions a year.");
		Facts.Add ("My grandmother started walking five miles a day when she was sixty. She's ninety-seven now, and we don't know where the heck she is.\n- Ellen DeGeneres\n");

		int i = Random.Range (0, Facts.Count - 1);
		gameObject.GetComponent<Text>().text = Facts [i];
		Debug.Log (gameObject.GetComponent<Text> ().text);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
