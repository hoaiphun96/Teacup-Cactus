using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory{

    private FlowerDatabase data;
    private List<Flower> flowers;

    // Use this for initialization
    public Inventory() {
        data = new TeacupCactusDatabase();
        flowers = new List<Flower>();
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

    public Flower Breed(Flower mother, Flower father)
    {
        return new Flower(mother, father, data);
    }

    public Flower Scavenge()
    {
        return new Flower(data.Scavenge(),data);
    }

    public Flower get(int index)
    {
        return flowers[index];
    }

    /*
    Methods used for interacting with the flowers List
    */

    public void RemoveFlowerAt(int index)
    {
        flowers.RemoveAt(index);
    }

    public Flower GetFlower(int index)
    {
        return flowers[index];
    }

    public void AddFlower(Flower flower)
    {
        flowers.Add(flower);
    }

    public int GetFlowerCount()
    {
        return flowers.Count;
    }


}
