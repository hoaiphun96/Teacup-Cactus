using System;
using System.Collections.Generic;

public class Goals{
	private List<Goal> goals;

	/*
	Goals should only be created once in the
	constructor. New Goals are never created.
	*/
	public Goals(){
		goals = new List<Goal> ();

		goals.Add (new TierPlantGoal());
	}

	/*
	This method occurs in Inventory.Update()
	*/
	public List<Goal> CheckCompletedGoals(){
		List<Goal> completedGoals = new List<Goal> ();

		foreach(Goal goal in goals){
			if(goal.isGoalComplete()){
				completedGoals.Add (goal);
			}
		}

		return completedGoals;
	}
}

public abstract class Goal{
	/*
	The ToString method should be implemented in
	every Goal. This is for use in the UI
	*/
	public override string ToString ()
	{
		return null;
	}

	/*
	The Goals class will cause this method to run.
	If the Goal is found, it is assumed that the
	a new goal condition will be created.
	*/
	public abstract bool isGoalComplete ();
}

public class TierPlantGoal: Goal{
	public static PlantGoal goal = Inventory.Goal;

	public override string ToString (){
		string str = "";
		foreach(string trait in goal.GetGoal()){
			str+=trait + ", ";
		}

		return str.Substring(0, str.Length-2);
	}

	public override bool isGoalComplete (){
		//return goal.update (Inventory.getFlowerArray());
		return false;
	} 
} 
