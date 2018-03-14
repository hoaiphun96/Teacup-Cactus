// Credits to https://www.youtube.com/watch?v=up6HcYph_bo
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Challenge {
	public string Description { get; set; }
	public bool Completed { get; set; }
	public int CurrentAmount { get; set; }
	public int RequiredAmount { get; set; }
	public string RewardName { get; set; }

	public virtual void Init() {
		//default init stuff

	}
	public void Evaluate() {
		if (CurrentAmount >= RequiredAmount && Completed != true) {
			Complete ();
		}
	}


	public virtual void Complete() {
		Completed = true;
	}
}
