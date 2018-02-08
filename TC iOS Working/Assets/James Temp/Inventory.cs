using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    private FlowerDatabase data;
    private List<Flower> flowers;

    // Use this for initialization
    void Start () {
        data = new TeacupCactusDatabase();
        flowers = new List<Flower>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public class TeacupCactusDatabase : FlowerDatabase
    {
        public TeacupCactusDatabase() : base()
        {
            this.AddTraitType("PetalShape", new string[] { "pointed", "forked", "round" }, new string[] { });
            this.AddTraitType("PetalCount", new string[] { "2", "3", "4", "5" }, new string[] { });
            this.AddTraitType("PetalColor", new string[] { "Red", "Yellow", "Blue" }, new string[] { "Orange", "Purple", "Green" });
            this.AddMutation("PetalColor", "Red", "Yellow", "Orange", 20);
            this.AddMutation("PetalColor", "Red", "Blue", "Purple", 20);
            this.AddMutation("PetalColor", "Yellow", "Blue", "Green", 20);
        }
    }

    /*
    Methods used for interacting with the flowers List
    */

    public void RemoveAt(int index)
    {
        flowers.RemoveAt(index);
    }

    public Flower Get()
    {

    }

    public void Add(Flower flower)
    {
        flowers.Add(flower);
    }

    public int GetFlowerCount()
    {
        return flowers.Count;
    }


}
