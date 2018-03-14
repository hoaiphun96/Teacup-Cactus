using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParentManager : MonoBehaviour {

	public GameObject Parent1;
	public GameObject Parent2;

	public GameObject FlowerPickerUI;
	public GameObject ConfirmButton;

	public int IndexForParent1 { get; set;}
	public int IndexForParent2 { get; set;}

	private GameObject LinkedParent;

	public GameObject Child;
	public GameObject ChildPopupUI;

	// Use this for initialization
	void Start () {
		LinkedParent = null;
		IndexForParent1 = -1;
		IndexForParent2 = -1;
		//UpdateParentFlower ();
	}

	public void UpdateLinkedParent(GameObject Parent){
		if (FlowerPickerUI.activeInHierarchy == true) {
			if (Parent.Equals (LinkedParent)) {
				FlowerPickerUI.SetActive (false);
				Debug.Log ("Really?");
			} else {
				LinkedParent = Parent;
				UpdateIndexOfFlowerPickerUI ();
			}
		} else {
			FlowerPickerUI.SetActive (true);
			LinkedParent = Parent;
			UpdateIndexOfFlowerPickerUI ();
		}
	}

	private void UpdateIndexOfFlowerPickerUI(){
		int newIndex = 0;
		if (LinkedParent.Equals (Parent1) && IndexForParent1 != -1)
			newIndex = IndexForParent1;
		else if (IndexForParent2 != -1)
			newIndex = IndexForParent2;
		FlowerPickerUI.GetComponent<FlowerParentPicker>().SetIndexToLinkedParentIndex (newIndex);
	}

	void UpdateParentFlower() {
		if (IndexForParent1 != -1) {
			string[] Parent1Genes = Inventory.GetFlower (IndexForParent1).genes;
			Parent1.GetComponent<CreateFlowerForParent> ().ChangeGenes (Parent1Genes);
		}

		if (IndexForParent2 != -1) {
			string[] Parent2Genes = Inventory.GetFlower (IndexForParent2).genes;
			Parent2.GetComponent<CreateFlowerForParent>().ChangeGenes (Parent2Genes);
		}
	}

	public bool UpdateIndicesOfParentManager(int newIndex){
		if(LinkedParent.Equals(Parent1)) {
			if (newIndex == IndexForParent2)
				return false;
			IndexForParent1 = newIndex;
				
		} else {
			if (newIndex == IndexForParent1)
				return false;
			IndexForParent2 = newIndex;
		}

		UpdateParentFlower ();
		return true;
	}

	// Combine Parents
	public void CombineParents(){
		Flower child = Inventory.BreedFlower (IndexForParent1, IndexForParent2);
		Inventory.FlowerList.Remove (Inventory.FlowerList[IndexForParent1].Value);
		Inventory.FlowerList.Remove (Inventory.FlowerList[IndexForParent2].Value);

		// remove parent flowers from seed slots
		Parent1.GetComponent<CreateFlowerForParent>().DestroyChildren();
		Parent2.GetComponent<CreateFlowerForParent>().DestroyChildren();
		LinkedParent = Parent1;
		IndexForParent1 = -1;
		IndexForParent2 = -1;

		// display new flower in pop up
		// retrieve last flower in list
		ChildPopupUI.SetActive (true);
		CreateFlower childScript = Child.GetComponent<CreateFlower> ();
		childScript.ChangeGenes (child.genes);
		childScript.enabled = true;

	}

	// Update is called once per frame
	void Update () {
		bool confirmButtonInteractability = false;
		if (IndexForParent1 != -1 && IndexForParent2 != -1) {
			confirmButtonInteractability = true;
		}
		ConfirmButton.GetComponent<Button> ().interactable = confirmButtonInteractability;
	}
}
