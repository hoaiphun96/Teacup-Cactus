using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

public class PlantGoal{
	private string[] myGoal;
	private PlantDatabase myDatabase;
	private int myGoalTier;

	public PlantGoal(PlantDatabase data, string str): this(data,pgt(str),pg(str)){

	}

	public int GetTier(){
		return myGoalTier;
	}

	private static string[] pg(string str){
		return str.Split(';')[1].Split(',');
	}

	private static int pgt(string str){
		return int.Parse(str.Split(';')[0]);
	}

	public override string ToString(){
		string str = myGoalTier + ";";
		foreach(string trait in myGoal){
			str+=trait + ",";
		}

		return str.Substring(0,str.Length-1);
	}

	public PlantGoal(PlantDatabase data): this(data,1,GetGenerateGoal(data,1)){

	}

	public PlantGoal(PlantDatabase data,int goalTier): this(data,goalTier, GetGenerateGoal(data,goalTier)){

	}

	public PlantGoal(PlantDatabase data,int goalTier,string[] goal){
		myDatabase = data;
		if(!data.IsValidFlower(goal,true))
			throw new System.Exception("invalid trait");
		myGoalTier = goalTier;
		myGoal = goal;
	}

	public string GetGoalString(){
		string str = "";
		foreach (string str2 in myGoal) {
			str+=str2+", ";
		}
		return str.Substring (0, str.Length - 2);
	}

	public string[] GetGoal(){
		return myGoal;
	}


	public bool update(string[][] flowers){
		if(isGoal(flowers)){
			myGoalTier++;
			myGoal = GenerateGoal();
			return true;
		}
		return false;
	}

	public bool isGoal(CircularLinkedList<Flower> flowers){
		foreach(Flower flower in flowers){
			if(isGoal(flower.genes))
				return true;
		}
		return false;
	}

	public bool isGoal(string[][] flowers){
		foreach(string[] flower in flowers){
			if(isGoal(flower))
				return true;
		}
		return false;
	}

	public bool isGoal(string[] flower){
		if(flower.Length != myGoal.Length)
			return false;

		for(int i = 0; i < flower.Length; i++){
			if(flower[i] != myGoal[i])
				return false;
		}
		return true;
	}

	public string[] GenerateGoal(){
		return GetGenerateGoal(myDatabase,myGoalTier);
	}

	private static string[] GetGenerateGoal(PlantDatabase data, int goalTier){
		Random rnd = new Random(Guid.NewGuid().GetHashCode());

		Dictionary<string, List<string>[]> tierDictonary = data.GetTiers();
		string[] keys = tierDictonary.Keys.ToArray();
		string[] goal = new string[keys.Length];


		int[] tierOfGoal = new int[keys.Length];
		for(int i = 0; i < keys.Length;i++){
			string key = keys[i];
			List<string>[] tierArray = tierDictonary[key];
			int maxTier = tierArray.Length;

			tierOfGoal[i] = rnd.Next(1,maxTier);
		}

		for(int i = 0; i < keys.Length; i++){
			string key = keys[i];
			List<string>[] tierArray = tierDictonary[key];

			int currTier = tierOfGoal[i];
			//Console.WriteLine(currTier + "/" + tierArray.Length);

			string[] array = tierArray[currTier].ToArray();
			int index = rnd.Next(0,array.Length);
			//Console.WriteLine(index + "/" + array.Length);

			goal[i] = array[index];
		}

		return goal;

	}
}