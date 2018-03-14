using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

public class TeacupDatabase
{
	Dictionary<int,List<string>> tiers  ;
	Dictionary<string, bool> seen;

	public TeacupDatabase ()
	{
		tiers = new Dictionary<int,List<string>> ();
		seen = new Dictionary<string, bool> ();
		addTeacup (0, "squarish_dark");
		addTeacup(0,"squarish_purple");
		addTeacup(0,"squarish_red");
		addTeacup(0,"round_dark");
		addTeacup(0,"round_purple");
		addTeacup(0,"round_red");

		addTeacup(1,"elegant_dark");
		addTeacup(1,"elegant_purple");
		addTeacup(1,"elegant_red");

		addTeacup(2,"special_oldstyle_porcelain");
		addTeacup(2,"special_round_heart");
		addTeacup(2,"special_squarish_stars");
		addTeacup(2,"special-polkadot");
		addTeacup(2,"special-knox");
	}		
		
	public static TeacupDatabase Load(string str){
		return new TeacupDatabase ();
	}

	public string[] ToArray(){
		List<string> teacups = new List<string>();

		int[] keys = tiers.Keys.ToArray();
		foreach(int key in keys){
			List<string> list = tiers [key];
			foreach (string teacup in list) {
				teacups.Add(teacup);
			}
		}

		return teacups.ToArray();
	}

	public bool isValid(int t, string teacup){
		List<string> list = tiers [t];
		foreach (string teacup2 in list) {
			if (teacup == teacup2)
				return true;
		}
		return false;
	}

	public bool isValid(string teacup){
		foreach (string teacup2 in this.ToArray()) {
			if (teacup2 == teacup)
				return true;
		}
		return false;
	}

	public Teacup Scavenge(int t = 0){
		Random rnd = new Random(Guid.NewGuid().GetHashCode());
		int index = rnd.Next(0,tiers[t].Count);

		return new Teacup(this,tiers[t][index]);
	}

	private void addTeacup(int tier, string str){
		for (int i = 0; i <= tier; i++) {
			if(!tiers.ContainsKey(i))
				tiers.Add (i,new List<string>());
		}
	
		tiers [tier].Add (str);


	}
}

