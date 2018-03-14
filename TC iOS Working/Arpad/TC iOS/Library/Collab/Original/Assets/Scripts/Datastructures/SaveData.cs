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
	private static string teacupdatabasePath = Application.persistentDataPath + "/teacupDatabase.txt";
	private static string teacupPath = Application.persistentDataPath + "/teacup.txt";
	private static string machinePath = Application.persistentDataPath + "/lastmachine.txt";

	/*//////////////////////////////////////////////////////////////////////////////
	Saving and Loading all savefiles
	SaveData.Load (PlantDatabase FlowerData,List<Flower> Flowers,PlantGoal Goal);
	*///////////////////////////////////////////////////////////////////////////////
	public static void Load(){
		string loadedMachineInfo = LoadMachine ();


		//Deletes all files if not used on the same computer
		//so everything resets
		if (loadedMachineInfo != getMachineInfo ()) {
			File.Delete (plantdatabasePath);
			File.Delete (flowerPath);
			File.Delete (goalPath);
			File.Delete (teacupdatabasePath);
			File.Delete (teacupPath);
		}



		PlantDatabase plantData = LoadPlantDatabase ();//1
		Inventory.FlowerData = plantData;

		TeacupDatabase teacupData = LoadTeacupDatabase ();//2
		Inventory.TeacupData = teacupData; 

		List<Flower> flowers = LoadFlowers (Inventory.FlowerData);//3
		Inventory.FlowerList =  new CircularLinkedList<Flower>(flowers);

		List<Teacup> teacups = LoadTeacups (teacupData);//4
		Inventory.TeacupList = new CircularLinkedList<Teacup>(teacups);

		Inventory.Goal = LoadPlantGoal (Inventory.FlowerData);//5

		Save ();
		Debug.Log (check());
	}

	public static void Save(){
		Save(Inventory.FlowerData,Inventory.FlowerList,Inventory.Goal, Inventory.TeacupData,Inventory.TeacupList);
		Debug.Log ("DONE SAVING DATA");
	}

	private static void Save(PlantDatabase FlowerData,CircularLinkedList<Flower> Flowers,PlantGoal Goal, TeacupDatabase TeacupData, CircularLinkedList<Teacup> Teacups){
		List<Flower> flowers = new List<Flower>();
		foreach(Flower flower in Flowers){
			flowers.Add (flower);
		}
		List<Teacup> teacups = new List<Teacup>();
		foreach(Teacup teacup in Teacups){
			teacups.Add(teacup);
		}

		Save (FlowerData,flowers,Goal,TeacupData,teacups);
	}

	public static string check(){
		string result = "";

		string[] names = new string[] {"plantdatabase","flowers","goal","teacupdatabase","teacup","machine"};
		string[] paths = new string[] {plantdatabasePath,flowerPath,goalPath,teacupdatabasePath,teacupPath,machinePath};
		object[] objects = new object[] {Inventory.FlowerData,Inventory.FlowerList,Inventory.Goal,Inventory.TeacupData,Inventory.TeacupList, ""};

		for (int i = 0; i < names.Length; i++) {
			string name = names [i];
			string path = paths [i];
			object obj = objects [i];

			bool pathExists = File.Exists (path);
			bool objectExists = obj != null;

			if (!pathExists || !objectExists) {
				result += name + "'s ";
				if(!pathExists){
					result += "file " + path + " doesn't exist";
				}
				if(!pathExists && !objectExists){
					result+=" and ";
				}
				if(!objectExists){
					result += " object doesn't exist.";
				}
				result+="\n";
			}
		}

		return result;
	}

	private static void Save(PlantDatabase FlowerData,List<Flower> Flowers,PlantGoal Goal, TeacupDatabase TeacupData, List<Teacup> Teacups){
		SaveMachine ();
		SavePlantDatabase (FlowerData);
		SaveFlowers (Flowers);
		SavePlantGoal (Goal);
		SaveTeacupDatabase (TeacupData);
		SaveTeacups (Teacups);
		Debug.Log (Application.persistentDataPath);
	}

	/*//////////////////////////////////////////////////////////////////////////////
	Saving and Loading System information
	*///////////////////////////////////////////////////////////////////////////////

	private static string GetMachinePath(){
		return machinePath;
	}

	private static string getMachineInfo(){
		return System.Environment.MachineName + "/n" + System.Environment.OSVersion;

	}

	private static void SaveMachine(){
		string save = getMachineInfo();

		try{
			using (StreamWriter sw = new StreamWriter(machinePath,false))
			{
				sw.Write(save);
			}
		}
		catch(System.Exception e){
			
		}
	}

	private static string LoadMachine(){
		string load = getMachineInfo();

		if (File.Exists (machinePath)) {
			using (StreamReader sr = new StreamReader (machinePath)) {
				load = sr.ReadToEnd();
			}

		} else {

		}

		return load;
	}

	/*//////////////////////////////////////////////////////////////////////////////
	Saving and Loading Teacups
	*///////////////////////////////////////////////////////////////////////////////
	private static string GetTeacupPath(){
		return teacupPath;
	}

	private static void SaveTeacups(List<Teacup> teacups){
		try{
			using (StreamWriter sw = new StreamWriter(teacupPath,false))
			{
				foreach(Teacup teacup in teacups){
					Debug.Log(string.Format("Saving tecup {0}", teacup.ToString()));
					sw.Write(teacup.ToString() + "\n");
				}
			}
		}catch(System.Exception e){
		}
	}

	private static List<Teacup> LoadTeacups(TeacupDatabase data){
		List<Teacup> teacups = new List<Teacup>();

		if (File.Exists (teacupPath)) {
			using (StreamReader sr = new StreamReader (teacupPath)) {
				string line = sr.ReadLine ();
				teacups.Add (new Teacup(data, line));
			}

		} else {
			teacups.Add (new Teacup (data, "round_red"));
			teacups.Add (new Teacup (data, "round_purple"));
			teacups.Add (new Teacup (data, "elegant_dark"));
			/*
			teacups.Add (data.Scavenge());
			teacups.Add (data.Scavenge());
			teacups.Add (data.Scavenge());
			*/
		}

		return teacups;
	}


	/*//////////////////////////////////////////////////////////////////////////////
	Saving and Loading TeacupDatabase
	*///////////////////////////////////////////////////////////////////////////////

	private static string GetTeacupDatabasePath(){
		return teacupdatabasePath;
	}

	private static void SaveTeacupDatabase(TeacupDatabase data){
		try{
			using (StreamWriter sw = new StreamWriter(teacupdatabasePath,false))
			{
				sw.Write(data.ToString());
			}
		}catch(System.Exception e){
		}
	}

	private static TeacupDatabase LoadTeacupDatabase(){
		try{
			if(!File.Exists(teacupdatabasePath)){
				//Console.WriteLine(Path.GetFullPath(PlantDatabase_path) + " does not exist");
			}
			else{
				using (StreamReader sr = new StreamReader(teacupdatabasePath))
				{
					string readTeacupDatabase = sr.ReadToEnd();
					return TeacupDatabase.Load(readTeacupDatabase);
				}
			}    

		}catch(System.Exception e){
			//Console.WriteLine("error loading at" + PlantDatabase_path);
			//Console.WriteLine(e);
			//Environment.Exit(1);
		}
		return new TeacupDatabase();
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
					Inventory.NumberOfFlower++;
				}
			}
		} 
		if (flowers.Count == 0) {

			flowers.Add(new Flower(data, data.Scavenge()));
			flowers.Add(new Flower(data, data.Scavenge()));
			flowers.Add(new Flower(data, data.Scavenge()));
			Inventory.NumberOfFlower += 3;
		}

		Debug.Log (flowers.Count);
        return flowers;
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
}
