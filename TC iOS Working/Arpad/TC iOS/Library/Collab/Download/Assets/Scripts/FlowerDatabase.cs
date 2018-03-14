using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

/////////////////////////////////////////////////////////////////
//REAL WORK
/////////////////////////////////////////////////////////////////

/*
A Plantdatabase that is given default values
*/

/*
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
*/

public class TeacupCactusDatabase: PlantDatabase{
	public TeacupCactusDatabase() : base(){
		this.AddTraitType("PetalShape",new string[]{"pointed", "forked", "round"}, new string[] {});
		this.AddTraitType("PetalColor", new string[] { "red", "yellow", "blue", "white"}, 
			new string[] { "pink", "lightblue", "lightyellow", "purple", "lightpurple", "orange", "lightorange"});
		this.AddTraitType("PetalCount", new string[]{"2","3","4","5","6","7","8","9","10"}, new string[]{});

		this.AddMutation("PetalColor","red","white","pink",80,false);
		this.AddMutation("PetalColor","blue","white","lightblue",80,false);
		this.AddMutation("PetalColor","yellow","white","lightyellow",80,false);

		this.AddMutation("PetalColor","red","yellow","orange",20,false);
		this.AddMutation("PetalColor","red","blue","purple",20,false);

		this.AddMutation("PetalColor","orange","white","lightorange",80,false);
		this.AddMutation("PetalColor","purple","white","lightpurple",80,false);
	}

}

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

/*
  A Plantdatabase is meant to keep track of all the diffrent types of traits, and thus
  what a valid flower will look like. It can be given new trait types or new mutations.
  It can also give a user a plant child when given two parrents.
  */
public class PlantDatabase{
	Dictionary<string, TraitType> traitTypes;

	public PlantDatabase(){
		traitTypes = new Dictionary<string, TraitType>();
	}

	public bool IsValidFlower(string[] flower,bool isTheoretical=false){
		string[] keys = traitTypes.Keys.ToArray();
		int length = keys.Length;
		if(flower.Length != length){
			return false;
		}

		for(int i = 0; i < length; i++){
			if(!traitTypes[keys[i]].IsValid(flower[i])){
				if(flower[i] == "" && isTheoretical)
					return true;
				return false;
			}
		}
		return true;
	}

	public int getTier(string[] flower){
		Dictionary<string, List<string>[]> tiers = this.GetTiers();
		int tier = 0;
		for(int i = 0; i < traitTypes.Keys.Count; i++){
			string key = traitTypes.Keys.ToArray()[i];
			List<string>[] lists = tiers[key];
			for(int j = 1; j < lists.Length;j++){
				List<string> list = lists[j];
				if(list.Contains(flower[j])){
					if(tier < j){
						tier=j;
						break;
					}
				}
			}
		}

		return tier + 1;
	}

	public string TiersToString(bool debug = false){
		string output = "";
		Dictionary<string, List<string>[]> tiers = this.GetTiers();
		if(debug) Console.WriteLine("tiers.Count: " + tiers.Count);
		foreach(string tier_key in tiers.Keys){
			output+=tier_key+"\n";
			List<string>[] tier_value = tiers[tier_key];
			if(debug) Console.WriteLine(tier_key + ".Length = " + tier_key.Length);
			for(int i = 0; i < tier_value.Length; i++){
				output+="tier " + i + ": ";
				List<string> list = tier_value[i];
				if(debug) Console.WriteLine("tier_value[" + i + "].Length = " + list.Count);
				foreach(string str in list){
					output+=str + ", ";
				}
				if(tier_value.Length != 0)
					output= output.Substring(0,output.Length-2);
				output+="\n";
			}
		}
		return output;  
	}

	public Dictionary<string, List<string>[]> GetTiers(){
		Dictionary<string, List<string>[]> tiers = new Dictionary<string, List<string>[]>();
		foreach(string key in traitTypes.Keys){
			tiers[key] = traitTypes[key].GetTiers();
		}
		return tiers;
	}

	public TraitType get(string str){
		return traitTypes[str];
	}

	public void AddTraitType(string traitName, TraitType traitType){
		traitTypes.Add(traitName, traitType);
	}

	public void AddTraitType(string traitName, string[] scavengeable, string[] nonscavangable){
		TraitType traitType = new TraitType(scavengeable, nonscavangable);
		traitTypes.Add(traitName, traitType);
	}

	public void AddMutation(string traitName, string mother, string father, string child, int chance, bool isOccured){
		traitTypes[traitName].AddMutation(mother,father,child,chance,isOccured);
	}

	public string[] Breed(string[] mother, string[] father){
		string[] child = new string[traitTypes.Keys.Count];
		int index = 0;
		foreach(string traitName in traitTypes.Keys){
			child[index] = traitTypes[traitName].Breed(mother[index],father[index]);
			index++;
		}

		return child;
	}

	public string[][] GetPossibleChildTraits(string[] mother, string[] father){
		string[][] possibleChildTraits = new string[mother.Length][];
		string[] keys = traitTypes.Keys.ToArray();
		for(int i = 0; i < mother.Length; i++){
			TraitType traitType = traitTypes[keys[i]];
			possibleChildTraits[i] = traitType.GetPossibleChildTrait(mother[i],father[i]);
		}
		return possibleChildTraits;
	}

	public string[] Scavenge(){
		int size = traitTypes.Keys.Count;
		string[] result = new string[size];

		int count = 0;
		foreach(string traitName in traitTypes.Keys){
			result[count] = traitTypes[traitName].Scavenge();
			count++;
		}

		return result;
	}

	public static PlantDatabase Load(string str,bool debug=false){
		PlantDatabase loaded = new PlantDatabase();
		if(debug) Console.WriteLine("PlantDatabase Load: " + str);
		string[] parsed = str.Split('\n');
		if(debug) Console.WriteLine("Parsed string");

		foreach(string line in parsed){
			if(line.Length == 0) continue;

			if(debug) Console.WriteLine("Load: " + line);
			string[] traitstrings = line.Split(';');
			string trait_name = traitstrings[0];
			if(debug) Console.WriteLine("trait_name: " + trait_name);
			string trait_data = traitstrings[1];
			if(debug) Console.WriteLine("trait_data: " + trait_data);
			TraitType trait = TraitType.Load(trait_data);
			loaded.AddTraitType(trait_name,trait);
			if(debug) Console.WriteLine("Local Load Complete");
		}
		if(debug) Console.WriteLine("PlantDatabase Load Complete");
		return loaded;
	}

	public override string ToString(){
		string result = "";
		if(traitTypes.Keys.Count != 0){
			foreach(string traitName in traitTypes.Keys){
				result+=traitName+ ";" + traitTypes[traitName].ToString() + ";\n";
			}
			return result;
		}
		return result + "empty";
	}

	public int getSize(){
		return traitTypes.Keys.Count;
	}

	public List<TraitType> Values(){
		List<TraitType> _traitTypes = new List<TraitType>();
		foreach(string str in this.Keys()){
			_traitTypes.Add(this.Get(str));
		}
		return _traitTypes;
	}

	public List<string> Keys(){
		return new List<string>(traitTypes.Keys);
	}

	public TraitType Get(string key){
		return traitTypes[key];
	}
}

/*
  The mutation class represents possible mutations that can occur in the plant.
  The mutation has two parents, whether the father or the mother it doesn't matter.
  If two plants are breed together that have the same parrents as this mutation it
  will result in true from SameParents. Breed will allow a child trait to be generated
  based on the percent chance represented by an integer between 0 and 100.
  */
public class Mutation{
	private string mother;
	private string father;
	private string child;
	private int chance;
	private bool isOccured;

	public Mutation(string mother, string father, string child, int chance, bool isOccured){
		this.mother = mother;
		this.father = father;
		this.child = child;
		this.chance = chance;
		this.isOccured = isOccured;
	}

	public string[] getParents(){
		return new string[2] {mother, father};
	}

	public bool SameParents(string otherMother, string otherFather){
		string[] otherParents = new string[2]{otherMother, otherFather};
		if(mother == otherParents[0] && father == otherParents[1])
			return true;
		if(mother == otherParents[1] && father == otherParents[0])
			return true;
		return false;
	}

	public string Breed(){
		string[] options = new string[3] {mother,father, child};
		int[] chances = new int[3] {(100-chance)/2,(100-chance)/2,chance};
		return options[randomChance(chances)];
	}

	public static int randomChance(int[] chances){
		Random rnd = new Random(Guid.NewGuid().GetHashCode());
		int perCent = rnd.Next(0,100);

		int temp = 0;
		for(int i = 0; i < chances.Length; i++){
			temp+=chances[i];
			if(perCent <temp){
				return i;
			}
		}

		return -1;
	}

	public string getMother(){
		return mother;
	}

	public string getFather(){
		return father;
	}

	public string getChild(){
		return child;
	}

	public override string ToString(){
		return mother + "," + father + "," + child + "," + chance + "," + isOccured;
	}
}

/*
  TraitType
  */
public class TraitType{
	List<string> scavengeable;
	List<string> nonscavangable;
	List<string>[] tiers;
	List<Mutation> mutations;

	public TraitType(string[] scav, string[] nonscav){
		this.scavengeable = new List<string>();
		this.nonscavangable = new List<string>();
		this.mutations = new List<Mutation>();

		foreach(string str in scav)
			this.scavengeable.Add(str);
		foreach(string str in nonscav)
			this.nonscavangable.Add(str);

		this.tiers = setUpTiers();

	}

	public List<string>[] GetTiers(){
		return tiers;
	}

	public List<string>[] setUpTiers(bool debug=false){
		Dictionary<string,int> tier = new Dictionary<string,int>();
		foreach(string trait in scavengeable){
			tier[trait] = 1;
		}

		if(debug){
			Console.Write("tier: ");
			foreach(string key in tier.Keys){
				Console.Write("[" + key + "] = " + tier[key] + ", ");
			}
			Console.Write("\n");
		}

		List<string> raw = new List<string>();
		foreach(string trait in nonscavangable.ToArray()){
			raw.Add(trait);
		}

		if(debug){
			Console.Write("Raw: ");
			foreach(string trait in raw.ToArray()){
				Console.Write(trait + ", ");
			}
			Console.Write("\n");
		}

		for(int i = 0; i < 1000; i++){
			foreach(string trait in raw.ToArray()){
				Mutation mutation = this.getMutation(trait);
				if(mutation == null)
					break;
				if(debug) Console.WriteLine("mutation == null = false");

				string mother = mutation.getMother();
				string father = mutation.getFather();

				if(!tier.ContainsKey(mother) | !tier.ContainsKey(father))
					break;
				if(debug) Console.WriteLine("!tier.ContainsKey(mother) | !tier.ContainsKey(father) = false");

				raw.Remove(trait);

				int mother_tier = tier[mother];
				int father_tier = tier[father];

				tier[trait] = mother_tier + father_tier;
				if(debug) Console.WriteLine("Found: [" + trait + "] = m" + mother_tier + " + f" +father_tier + " (" + tier[trait]+")");
			}

			if(raw.Count == 0)
				break;
		}

		if(debug){
			Console.Write("tier: ");
			foreach(string key in tier.Keys.ToArray()){
				Console.Write("[" + key + "] = " + tier[key] + ", ");
			}
			Console.Write("\n");
		}

		if(raw.Count != 0){
			foreach(string trait in raw.ToArray()){
				tier[trait] = 0;
			}
		}

		if(debug){
			Console.Write("tier: ");
			foreach(string key in tier.Keys.ToArray()){
				Console.Write("[" + key + "] = " + tier[key] + ", ");
			}
			Console.Write("\n");
		}

		Dictionary<int,List<string>> _tiers = new Dictionary<int,List<string>>();

		foreach(string key in tier.Keys.ToArray()){
			int value = tier[key];
			if(!_tiers.ContainsKey(value)){
				_tiers[value] = new List<string>();
			}
			_tiers[value].Add(key);
		}


		int maxint = -1;
		foreach(int key in _tiers.Keys.ToArray()){
			if(key > maxint)
				maxint = key;
		}
		maxint+=1;

		List<string>[] tiers = new List<string>[maxint];

		if(debug) Console.WriteLine("");
		if(debug) Console.WriteLine("Final tiers: maxInt = " + maxint);
		for(int i = 0; i < maxint; i++){
			if(!_tiers.ContainsKey(i))
				tiers[i] = new List<string>();
			else
				tiers[i] = _tiers[i];
			if(debug){
				Console.Write(i + ". ");
				foreach(string str in tiers[i].ToArray()){
					Console.Write(str + ", ");
				}
			}
		}
		if(debug) Console.Write("\n");

		if(debug) Console.WriteLine("");

		return tiers;

	}

	public Mutation getMutation(string child, bool debug = false){
		//if(debug) Console.Write("!this.IsValid("+child+") = " + (!this.IsValid(child)));
		if(!this.IsValid(child))
			throw new System.Exception("Invalid Trait string!");

		if(debug) Console.WriteLine("mutations " + mutations.Count);

		foreach(Mutation mutation in mutations.ToArray()){
			if(debug) Console.WriteLine(mutation.getChild() + " == " + child + " " + (mutation.getChild() == child));
			if(mutation.getChild() == child){
				if(debug) Console.WriteLine("... mutation = " + mutation);
				return mutation;
			}
		}
		//if(debug) Console.WriteLine("... mutation = null");
		return null;

	}

	public Mutation getMutation(string mother, string father){
		if(!this.IsValid(mother) | !this.IsValid(father))
			throw new System.Exception("Invalid Trait string!");

		foreach(Mutation mutation in mutations.ToArray()){
			if(mutation.SameParents(mother,father))
				return mutation;
		}
		return null;
	}

	public string[] GetPossibleChildTrait(string mother, string father){
		string[] possibleChildTrait;
		if(!this.IsValid(mother) | !this.IsValid(father))
			throw new System.Exception("Invalid Trait string!");

		Mutation mutation = getMutation(mother, father);
		if(mutation == null){
			possibleChildTrait = new string[2];
			possibleChildTrait[0] = mother;
			possibleChildTrait[1] = father;
		}
		else{
			possibleChildTrait = new string[3];
			possibleChildTrait[0] = mother;
			possibleChildTrait[1] = father;
			possibleChildTrait[2] = mutation.getChild();
		}
		return possibleChildTrait;
	}

	public string Breed(string mother, string father){
		if(!this.IsValid(mother) | !this.IsValid(father))
			throw new System.Exception("Invalid Trait string!");

		Random rnd = new Random(Guid.NewGuid().GetHashCode());
		Mutation mutation = getMutation(mother, father);
		if(mutation == null){
			int index = rnd.Next(0,2);
			string [] options = new string[2] {mother,father};
			return options[index];
		}
		else{
			return mutation.Breed();
		}

	}

	public string Scavenge(){
		Random rnd = new Random(Guid.NewGuid().GetHashCode());
		int index = rnd.Next(0,scavengeable.Count);
		return scavengeable[index];
	}

	public bool IsValid(string str){
		return this.GetValidTraits().Contains(str);
	}

	public void AddMutation(string mother, string father, string child, int chance, bool isOccured){
		if(!this.IsValid(mother) | !this.IsValid(father) | !this.IsValid(child)){
			throw new System.Exception("Invalid Trait string!");
		}
		if(0 > chance | chance > 100){
			throw new System.Exception("Invalid Chance Integer!");
		}
		mutations.Add(new Mutation(mother,father,child,chance,isOccured));

		tiers = setUpTiers();
	}

	public List<string> GetValidTraits(){
		List<string> result = new List<string>();
		foreach(string str in scavengeable.ToArray()){
			result.Add(str);
		}
		foreach(string str in nonscavangable.ToArray()){
			result.Add(str);
		}
		return result;
	}

	public static TraitType Load(string str,bool debug=false){
		int scavengeable_index_start = str.IndexOf("scavengeable");
		int scavengeable_index_end = 0;
		if(scavengeable_index_start != -1){
			scavengeable_index_end = scavengeable_index_start + "scavengeable [".Length - 1;
		}

		int nonscavengeable_index_start = str.IndexOf("non-scavengeable");
		int nonscavengeable_index_end = 0;
		if(nonscavengeable_index_start != -1){
			nonscavengeable_index_end= nonscavengeable_index_start + "non-scavengeable [".Length - 1;
		}
		int mutations_index_start = str.IndexOf("mutations");
		int mutations_index_end = 0;
		if(mutations_index_start != -1)
			mutations_index_end = mutations_index_start + "mutations [".Length - 1;

		if(debug){
			Console.WriteLine("scavengeable_index: " + scavengeable_index_start + " " + scavengeable_index_end);
			Console.WriteLine("nonscavengeable_index: " + nonscavengeable_index_start + " " + nonscavengeable_index_end);
			Console.WriteLine("mutations_index: " + mutations_index_start + " " + mutations_index_end);
		}

		string scavengeable_raw = "";
		if(scavengeable_index_start != -1){
			if(nonscavengeable_index_start != -1){
				scavengeable_raw = str.Substring(scavengeable_index_end,nonscavengeable_index_start-scavengeable_index_end-1);
			}
			else if(mutations_index_start != -1){
				scavengeable_raw = str.Substring(scavengeable_index_end,mutations_index_start-scavengeable_index_end-1);
			}
			else{
				scavengeable_raw = str.Substring(scavengeable_index_end,str.Length-scavengeable_index_end-1);
			}
		}

		if(debug){
			Console.WriteLine("scavengeable_raw: " + scavengeable_raw);
		}

		string nonscavengeable_raw = "";
		if(nonscavengeable_index_start != -1){
			if(mutations_index_start != -1){
				nonscavengeable_raw = str.Substring(nonscavengeable_index_end,mutations_index_start-nonscavengeable_index_end-1);
			}
			else{
				nonscavengeable_raw = str.Substring(nonscavengeable_index_end,str.Length-nonscavengeable_index_end-1);
			}
		}

		if(debug){
			Console.WriteLine("nonscavengeable_raw: " + nonscavengeable_raw);
		}

		string mutations_raw = "";
		if(mutations_index_start != -1){
			mutations_raw = str.Substring(mutations_index_end,str.Length-mutations_index_end-1);
		}

		if(debug){
			Console.WriteLine("mutations_raw: " + mutations_raw);
		}

		scavengeable_raw = scavengeable_raw.Trim( new Char[] { '[', ',', ']' } );
		nonscavengeable_raw = nonscavengeable_raw.Trim( new Char[] { '[', ',', ']' } );
		mutations_raw= mutations_raw.Trim( new Char[] { '[', ',', ']' } );

		if(debug){
			Console.WriteLine("Trim in progress");
			Console.WriteLine("scavengeable_raw: " + scavengeable_raw);
			Console.WriteLine("nonscavengeable_raw: " + nonscavengeable_raw);
			Console.WriteLine("mutations_raw: " + mutations_raw);
			Console.WriteLine("Trim finished");
		}

		string[] scav = new string[0];
		if(scavengeable_raw.Length > 0)
			scav = scavengeable_raw.Split(',');
		string[] nonscav = new string[0];
		if(nonscavengeable_raw.Length > 0)
			nonscav = nonscavengeable_raw.Split(',');

		if(debug){
			Console.WriteLine("scav and nonscav arrays created");
		}
		TraitType trait = new TraitType(scav,nonscav);
		if(debug){
			Console.WriteLine("TraitType object created: " + trait.ToString());
		}


		string[] mutations = new string[0];
		if(mutations_raw.Length > 0)
			mutations = mutations_raw.Split('.');

		if(debug){
			Console.WriteLine("mutations array created");
		}

		foreach(string mutation in mutations){
			if(debug){
				Console.WriteLine("mutation: "+ mutation);
			}

			string[] mutation_parsed = mutation.Split(',');

			if(debug){
				Console.WriteLine("mutation_parsed.Length: " + mutation_parsed.Length);
				Console.WriteLine(mutation);
			}

			string mother = mutation_parsed[0];
			if(debug) Console.WriteLine(0+ " " + mother);
			string father = mutation_parsed[1];
			if(debug) Console.WriteLine(1+ " " + father);
			string child = mutation_parsed[2];
			if(debug) Console.WriteLine(2+ " " + child);
			int chance = int.Parse(mutation_parsed[3]);
			if(debug) Console.WriteLine(3+ " " + chance);
			bool isOccured = bool.Parse(mutation_parsed[4]);
			if(debug) Console.WriteLine(4 + " " + isOccured);
			trait.AddMutation(mother,father,child,chance,isOccured);
			if(debug) Console.WriteLine("Finished adding Mutation");
		}

		if(debug)
			Console.WriteLine("Finished TraitType Load");

		return trait;

	}

	public override string ToString()
	{
		string result = "";

		if(scavengeable.Count != 0)
		{
			result+="scavengeable[";
			foreach(string str in scavengeable){
				result += str + ",";
			}
			result = result.Substring(0, result.Length-1) + "], ";
		}
		if(nonscavangable.Count != 0){
			result+= "non-scavengeable [";
			foreach(string str in nonscavangable){
				result += str + ",";
			}
			result = result.Substring(0, result.Length-1) + "], ";
		}
		if(mutations.Count != 0){
			result+= "mutations [";
			foreach(Mutation mutation in mutations){
				result+= mutation + ".";
			}
			result = result.Substring(0, result.Length-1) + "], ";
		}

		if(result == ""){
			return "empty";
		}
		else{
			result = result.Substring(0,result.Length-2);
			return result;
		}
	}
}


/*
class Runner {
	static string PlantDatabase_path = "PlantDatabase.pd";
	static string Flowers_path = "Flowers.fw";
	static string PlantGoal_path = "Goal.gl";

	public static void Main (string[] args) {
		PlantDatabase data = new TeacupCactusDatabase();
		Console.WriteLine("This build tests the loading command: \"load\" and \"save\" and \"steps\" and \"breed until\"");

		//Console.WriteLine("Attempting to create new flowers...");
		int flowerCount = 15;
		int steps = 0;

		string[][] flowers = new string[flowerCount][];
		for(int i = 0; i < flowerCount; i++){
			flowers[i] = data.Scavenge();
		}

		//Console.WriteLine("Creating Plant Goal...");
		PlantGoal goal = new PlantGoal(data);

		while(true){
			string userinput = "bob";
			while(userinput != "print" && userinput != "mate" && userinput != "scavenge" && userinput != "help" && userinput != "check" && userinput != "plant data" && userinput != "exit" && userinput != "clear" && userinput != "James Woolley" && userinput != "load" && userinput != "save" && userinput != "breed until" && userinput != "steps" && userinput != "tiers" && userinput != "tier" && userinput !="goal"){
				Console.WriteLine("Please input command: print, mate, scavenge, or help for more options. ");
				userinput = Console.ReadLine();
				Console.WriteLine();
			}
			if(userinput == "print"){
				Console.ForegroundColor = ConsoleColor.Green;
				printFlowerArray(flowerCount, flowers,data);
			}
			else if(userinput == "mate"){
				Console.ForegroundColor = ConsoleColor.Red;
				createNewChild(flowerCount, flowers, data);
				steps++;
			}
			else if(userinput == "scavenge"){
				newScavenge(flowerCount, flowers,data);
				steps++;
			}
			else if(userinput == "help"){
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.WriteLine("\"print\" to print the flower array.\n\"mate\" to create a child of two parrents.\n \"scavenge\" to generate a new flower.\n\"check\" will perform a check of the genetics you set up.\n\"plant data\" will show you the plant genetics you made.\n\"exit\" will exit the program.\n \"clear\" will clear the console.\n \"save\" will save the plantDatabase to a file.\n\"load\" will load the plantDatabase from that same file location and print out the loaded plantDatabase.\n\"steps\" will get you the steps.\n\"tier\" will prompt you for a plant and tell you its tier\n\"tiers\" prints out tiers.\n\"goal\"prints out goal");
			}
			else if(userinput == "check"){
				BreedCheck();
			}
			else if(userinput == "plant data"){
				Console.WriteLine(data);
			}
			else if(userinput == "exit"){
				break;
			}
			else if(userinput == "clear"){
				Console.Clear();
			}
			else if(userinput == "James Woolley"){
				Console.WriteLine("That's me!");

				for(int i = 0; i < flowerCount;i++){
					int length = flowers[i].Length;
					flowers[i] = new string[length];
					for(int j = 0; j < length; j++){
						flowers[i][j] = userinput.Substring(0,5);
					}
				}
			}
			else if(userinput == "load"){
				Console.ForegroundColor = ConsoleColor.Magenta;
				Load(data,flowers,goal);
			}
			else if(userinput == "save"){
				Console.ForegroundColor = ConsoleColor.Magenta;
				Save(data,flowers,goal);
			}
			else if(userinput == "breed until"){
				steps += breedUntil(flowerCount, flowers,data);

			}
			else if(userinput == "steps"){
				Console.WriteLine("Steps " + steps);
			}
			else if(userinput == "tiers"){
				Console.WriteLine(data.TiersToString());
			}
			else if(userinput == "tier"){
				int index = -1;
				while(index < 1 | index > flowerCount){
					Console.WriteLine("Select a plant. 1-" + flowerCount);
					index = Convert.ToInt32(Console.ReadLine());
				}
				string[] flower = flowers[index-1];
				PrintFlower(flower, "Picked");
				Console.WriteLine("Picked Flower tier is " + data.getTier(flower));
			}
			else if(userinput == "goal"){
				PrintFlower(goal.GetGoal(),"Goal");
				Console.WriteLine("Plant Goal is at tier " + goal.GetTier());
			}


			Console.WriteLine();

			if(goal.update(flowers)){
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("Congrats you got the goal!");
				Console.WriteLine("You have been playing for " + steps + " turns.");
				Console.WriteLine("And reached level " + goal.GetTier());
				PrintFlower(goal.GetGoal(),"Goal");
				Console.WriteLine("");
			}

			Console.ForegroundColor = ConsoleColor.White;
		}

	}

	public static int breedUntil(int flowerCount, string[][] flowers, PlantDatabase data){

		int index = -1;
		while(index < 1 | index > flowerCount){
			Console.WriteLine("Select mother plant. 1-" + flowerCount);
			index = Convert.ToInt32(Console.ReadLine());
		}
		string[] mother = flowers[index-1];
		PrintFlower(mother, "Mother");

		index = -1;
		while(index < 1 | index > flowerCount){
			Console.WriteLine("Select father plant. 1-" + flowerCount);
			index = Convert.ToInt32(Console.ReadLine());
		}
		string[] father = flowers[index-1];
		PrintFlower(father, "Father");

		string[] desired_child;

		while(true){
			Console.WriteLine("Enter Desired input: ");
			string desired_userinput = Console.ReadLine();
			desired_child = desired_userinput.Split(',');

			string[][] possibleChildTraits = data.GetPossibleChildTraits(mother,father);
			bool foundAllTraits = true;
			for(int i = 0; i < data.Keys().Count; i++){
				foundAllTraits = false;

				desired_child[i] = desired_child[i].Trim();

				foreach(string possibleTrait in possibleChildTraits[i]){
					if(desired_child[i] == "" | desired_child[i] == possibleTrait){
						foundAllTraits = true;
					}
				}
				if(!foundAllTraits){
					break;
				}
			}

			if(foundAllTraits){
				break;
			}

		}

		index = -1;
		while(index < 1 | index > flowerCount){
			Console.WriteLine("Which plant to replace with child. 1-" + flowerCount);
			index = Convert.ToInt32(Console.ReadLine());
		}
		index-=1;

		string[] child;
		int count = 0;
		while(true){
			count++;
			child = data.Breed(mother,father);
			bool foundChild = false;
			for(int i = 0; i < child.Length; i++){
				foundChild = false;
				if(desired_child[i] == "" | child[i] == desired_child[i]){
					foundChild = true;
				}
				else{
					break;
				}
			}
			if(foundChild){
				break;
			}
		}

		Console.WriteLine("Got child after " + count + " breeds.");
		flowers[index] = child;
		return count;
	}

	public static void Save(PlantDatabase data, string[][] flowers, PlantGoal goal){
		try{
			using (StreamWriter sw = new StreamWriter(PlantDatabase_path,false))
			{
				sw.Write(data.ToString());
				Console.WriteLine("Saved " + PlantDatabase_path);
				Console.WriteLine(data.ToString());
			}
		}catch(System.Exception e){
			Console.WriteLine("error saving at" + PlantDatabase_path);
			Console.WriteLine(e);
			Environment.Exit(1);
		}

		try{
			using (StreamWriter sw = new StreamWriter(Flowers_path,false))
			{
				string _str = "";
				foreach(string[] _flower in flowers){
					foreach(string _flowerTrait in _flower){
						_str+=_flowerTrait+",";
					}
				}
				sw.Write(_str);
				Console.WriteLine("Saved " + Flowers_path);
				Console.WriteLine(_str);
			}
		}catch(System.Exception e){
			Console.WriteLine("error saving at" + Flowers_path);
			Console.WriteLine(e);
			Environment.Exit(1);
		}

		try{
			using (StreamWriter sw = new StreamWriter(PlantGoal_path,false))
			{
				string _str = goal.ToString();
				sw.Write(_str);
				Console.WriteLine("Saved " + PlantGoal_path);
				Console.WriteLine(_str);
			}
		}catch(System.Exception e){
			Console.WriteLine("error saving at" + PlantGoal_path);
			Console.WriteLine(e);
			Environment.Exit(1);
		}

		Console.WriteLine("");

	}

	public static void Load(PlantDatabase data, string[][] flowers, PlantGoal goal){
		int flowerCount = flowers.Length;

		try{
			if(!File.Exists(PlantDatabase_path)){
				Console.WriteLine(Path.GetFullPath(PlantDatabase_path) + " does not exist");
			}
			else{
				using (StreamReader sr = new StreamReader(PlantDatabase_path))
				{
					string readPlantDatabase = sr.ReadToEnd();
					data = PlantDatabase.Load(readPlantDatabase);
					Console.WriteLine("Loaded: " + PlantDatabase_path);
					Console.WriteLine(data);
				}
			}    

		}catch(System.Exception e){
			Console.WriteLine("error loading at" + PlantDatabase_path);
			Console.WriteLine(e);
			Environment.Exit(1);
		}

		try{
			if(!File.Exists(Flowers_path)){
				Console.WriteLine(Path.GetFullPath(Flowers_path) + " does not exist");
			}
			else{
				using (StreamReader sr = new StreamReader(Flowers_path))
				{
					string[] readPlants = sr.ReadToEnd().Split('\n');
					flowerCount = readPlants.Length;
					flowers = new string[flowerCount][];
					for(int i = 0; i < flowerCount; i++){
						flowers[i] = readPlants[i].Split(',');
					}
				}
				Console.WriteLine("Loaded: " + Flowers_path);
				printFlowerArray(flowerCount, flowers,data);
			}    

		}catch(System.Exception e){
			Console.WriteLine("error  loading at" + Flowers_path);
			Console.WriteLine(e);
			Environment.Exit(1);
		}

		try{
			if(!File.Exists(PlantGoal_path)){
				Console.WriteLine(Path.GetFullPath(PlantGoal_path) + " does not exist");
			}
			else{
				using (StreamReader sr = new StreamReader(PlantGoal_path)){
					string str = sr.ReadToEnd();
					goal = new PlantGoal(data,str);
					Console.WriteLine("Loaded: "+ PlantGoal_path);
					Console.WriteLine(goal);
				}
			}
		}catch(System.Exception e){
			Console.WriteLine("error  loading at" + Flowers_path);
			Console.WriteLine(e);
			Environment.Exit(1);
		}

		Console.WriteLine();
	}

	public static void printFlowerArray(int flowerCount, string[][] flowers, PlantDatabase data){
		for(int i = 0; i < flowerCount; i++){
			PrintFlower(flowers[i],"#" + (i+1));
		}
	}

	public static void newScavenge(int flowerCount, string[][] flowers, PlantDatabase data){
		int index = -1;
		while(index < 1 | index > flowerCount){
			Console.WriteLine("Select a plant to replace with a foraged plant. 1-" + flowerCount);
			index = Convert.ToInt32(Console.ReadLine());
		}
		string[] scavenged = data.Scavenge();
		flowers[index-1] = scavenged;
		PrintFlower(scavenged, "Scavenged");
	}

	public static void createNewChild(int flowerCount, string[][] flowers, PlantDatabase data){
		int index = -1;
		while(index < 1 | index > flowerCount){
			Console.WriteLine("Select mother plant. 1-" + flowerCount);
			index = Convert.ToInt32(Console.ReadLine());
		}
		string[] mother = flowers[index-1];
		PrintFlower(mother, "Mother");

		index = -1;
		while(index < 1 | index > flowerCount){
			Console.WriteLine("Select father plant. 1-" + flowerCount);
			index = Convert.ToInt32(Console.ReadLine());
		}
		string[] father = flowers[index-1];
		PrintFlower(father, "Father");

		index = -1;
		while(index < 1 | index > flowerCount){
			Console.WriteLine("Which plant to replace with child. 1-" + flowerCount);
			index = Convert.ToInt32(Console.ReadLine());
		}
		string[] child = data.Breed(father, mother);
		PrintFlower(child, "Child");
		flowers[index-1] = child;
	}

	
  //BreedCheck creates a PlantDatabase, and asks the user how many children plant the user wants to generate.
  //Then the program will create parents, and children this many times. It will print all of the flowers if
  //the number of children is under 30. It will then print out the number of time each trait showed up for
  //every Trait type.

	public static void BreedCheck(){
		PlantDatabase data = new TeacupCactusDatabase();
		int size = 1;

		Console.WriteLine("How many plant children do you wish to generate? Input positive integer to continue.");
		size = Convert.ToInt32(Console.ReadLine());

		CounterDatabase parentCounter = new CounterDatabase(data);
		CounterDatabase childCounter = new CounterDatabase(data);

		for(int i = 0; i < size; i++){
			string[] mother = data.Scavenge();
			string[] father = data.Scavenge();
			string[] child = data.Breed(mother, father);

			parentCounter.addFlower(mother);
			parentCounter.addFlower(father);
			childCounter.addFlower(child);

			if(size <= 30){
				PrintFlower(mother,"Mother");
				PrintFlower(father,"Father");
				PrintFlower(child,"Child");
				Console.WriteLine();
			}

		}
		Console.WriteLine();
		Console.WriteLine("PARENT DATA");
		parentCounter.Print();
		Console.WriteLine();
		Console.WriteLine("CHILD DATA");
		childCounter.Print();
	}


  //The CounterDatabase is given flowers, and it keeps track of how many of each trait it recieves.
  //This class allows a user to figure out what traits are the most common.
 
	public class CounterDatabase{
		private Dictionary<string, int>[] counterDatabase;

		public CounterDatabase(PlantDatabase data){
			int size = data.getSize();
			counterDatabase = new Dictionary<string, int>[size];
			for(int i = 0; i < size; i++){
				counterDatabase[i] = new Dictionary<string, int>();
			}
		}

		public void Print(){
			foreach(Dictionary<string, int> dict in counterDatabase){
				string[] keys = new string[dict.Keys.Count];
				int[] values = new int[dict.Keys.Count];

				int counter = 0;
				foreach(string key in dict.Keys){
					keys[counter] = key;
					values[counter] = dict[key];
					counter++;
				}
				float total = 0;
				foreach(int value in values)
					total+=value;

				for(int i = 0; i < dict.Keys.Count; i++){
					string key = keys[i];
					int value = values[i];
					float percent = 100*(values[i]/total);
					Console.WriteLine("\t" + key + ": " + value + "/" + total + " (" + percent + "%)");
				}
				Console.WriteLine();
			}
		}

		public void addFlower(string[] flower){
			if (flower.Length != counterDatabase.Length)
				throw new System.Exception("Invalid Trait string!");

			for(int i = 0; i < counterDatabase.Length; i++){
				Dictionary<string, int> dict = counterDatabase[i];
				string trait = flower[i];
				if(dict.ContainsKey(trait)){
					dict[trait] = dict[trait]+1;
				}
				else{
					dict.Add(trait,1);
				}
			}
		}
	}

	
  //A simple flower printing method. Flowers are represented as an array of strings of their traits
  
	public static void PrintFlower(string[] flower, string flowerName){
		string result = flowerName + " Flower: ";
		foreach(string str in flower){
			result+= str + ", ";
		}
		result = result.Substring(0,result.Length-2);
		Console.WriteLine(result);
	}

}

*/