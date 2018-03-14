using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


/*
This class will read and write save data. It is not a script and thus its static methods must be called by the inventory script
*/

public class SaveData {
	private static string plantdatabasePath = Application.persistentDataPath + "/plantDatabase.txt";
	private static string flowerPath = Application.persistentDataPath + "/inventory_flower.txt";
	private static string goalPath = Application.persistentDataPath + "/goal.txt";

	/*//////////////////////////////////////////////////////////////////////////////
	Saving and Loading all savefiles
	SaveData.Load (PlantDatabase FlowerData,List<Flower> Flowers,PlantGoal Goal);
	*///////////////////////////////////////////////////////////////////////////////
	public static void Load(){
		Inventory.FlowerData = LoadPlantDatabase ();
		Debug.Log ("Inventory.FlowerData: " + (Inventory.FlowerData == null));
		Inventory.Flowers = LoadFlowers (Inventory.FlowerData);
		Debug.Log ("Inventory.Flowers: " + (Inventory.Flowers == null));
		Inventory.Goal = LoadPlantGoal (Inventory.FlowerData);
		Debug.Log ("Inventory.Goal: " + (Inventory.Goal == null));
	}

	public static void Save(PlantDatabase FlowerData,List<Flower> Flowers,PlantGoal Goal){
		SavePlantDatabase (FlowerData);
		SaveFlowers (Flowers);
		SavePlantGoal (Goal);
	}

	/*//////////////////////////////////////////////////////////////////////////////
	Saving and Loading PlantDatabase
	//FlowerData = SaveData.LoadFlowerData ();
	*///////////////////////////////////////////////////////////////////////////////

	private string GetPlantdatabasePath(){
		return plantdatabasePath;
	}

	private static void SavePlantDatabase(PlantDatabase data){
		try{
			using (StreamWriter sw = new StreamWriter(plantdatabasePath,false))
			{
				sw.Write(data.ToString());
				//Console.WriteLine("Saved " + PlantDatabase_path);
				//Console.WriteLine(data.ToString());
			}
		}catch(System.Exception e){
			//Console.WriteLine("error saving at" + PlantDatabase_path);
			//Console.WriteLine(e);
			//Environment.Exit(1);
		}
	}

	private static PlantDatabase LoadPlantDatabase(){
		try{
			if(!File.Exists(plantdatabasePath)){
				//Console.WriteLine(Path.GetFullPath(PlantDatabase_path) + " does not exist");
			}
			else{
				using (StreamReader sr = new StreamReader(plantdatabasePath))
				{
					string readPlantDatabase = sr.ReadToEnd();
					return PlantDatabase.Load(readPlantDatabase);
				}
			}    

		}catch(System.Exception e){
			//Console.WriteLine("error loading at" + PlantDatabase_path);
			//Console.WriteLine(e);
			//Environment.Exit(1);
		}
		return new TeacupCactusDatabase();
	}

	/*//////////////////////////////////////////////////////////////////////////////
	Saving and Loading Goal
	//Goal = SaveData.LoadGoal (FlowerData);
	*///////////////////////////////////////////////////////////////////////////////
	private string GetGoalPath(){
		return goalPath;
	}

	private static void SavePlantGoal(PlantGoal goal){
		try{
			using (StreamWriter sw = new StreamWriter(goalPath,false))
			{
				string _str = goal.ToString();
				sw.Write(_str);
				//Console.WriteLine("Saved " + PlantGoal_path);
				//Console.WriteLine(_str);
			}
		}catch(System.Exception e){
			//Console.WriteLine("error saving at" + PlantGoal_path);
			//Console.WriteLine(e);
			//Environment.Exit(1);
		}
	}

	private static PlantGoal LoadPlantGoal(PlantDatabase data){
		try{
			if(!File.Exists(goalPath)){
				//Console.WriteLine(Path.GetFullPath(goalPath) + " does not exist");
			}
			else{
				using (StreamReader sr = new StreamReader(goalPath)){
					string str = sr.ReadToEnd();
					return new PlantGoal(data,str);
					//Console.WriteLine("Loaded: "+ PlantGoal_path);
					//Console.WriteLine(goal);
				}
			}
		}catch(System.Exception e){
			//Console.WriteLine("error  loading at" + Flowers_path);
			//Console.WriteLine(e);
			//Environment.Exit(1);
		}

		return new PlantGoal(data);
	}

	/*//////////////////////////////////////////////////////////////////////////////
	Saving and Loading Flowers

	Flowers = SaveData.LoadFlowers(FlowerData);
	*///////////////////////////////////////////////////////////////////////////////

	private string GetFlowerPath(){
		return flowerPath;
	}

    private static void SaveFlowers(List<Flower> flowers)
    {
        using (StreamWriter sw = new StreamWriter(flowerPath, false))
        {
            foreach (Flower flower in flowers)
            {
				if (flower != null) {
					Debug.Log ("Save Flower: " + flower.ToString ());
					sw.WriteLine (flower.ToString ());
				}
            }
        }
    }

    private static List<Flower> LoadFlowers(PlantDatabase data)
    {
        List<Flower> flowers = new List<Flower>();

		if (File.Exists (flowerPath)) {
			using (StreamReader sr = new StreamReader (flowerPath)) {
				string line;
				while ((line = sr.ReadLine ()) != null) {
					//Debug.Log("Load Flower: " + line);
					flowers.Add (new Flower (data, line));
					//Inventory.NumberOfFlower++;
				}
			}
		} 
		if (flowers.Count == 0) {

			flowers.Add(new Flower(data, data.Scavenge()));
			flowers.Add(new Flower(data, data.Scavenge()));
			flowers.Add(new Flower(data, data.Scavenge()));
		}

		Debug.Log (flowers.Count);
        return flowers;
    }
		
	//Oprah 2020
}
