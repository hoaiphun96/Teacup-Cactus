using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingChallenge: Challenge {
	public int ChallengeID { get; set; }

	public WalkingChallenge(int challengeID, string description, bool completed, int currentAmount, int requiredAmount, string rewardName) {
		this.ChallengeID = ChallengeID;
		this.Description = description;
		this.Completed = completed;
		this.CurrentAmount = currentAmount;
		this.RequiredAmount = requiredAmount;
		this.RewardName = rewardName;
	}

	public override void Init()
	{
		base.Init ();

	}

	public void UpdateCurrentAmount() {
		CurrentAmount = PlayerPrefs.GetInt ("Steps");
	}

	public override void Complete() {
		base.Complete ();
	}




}
