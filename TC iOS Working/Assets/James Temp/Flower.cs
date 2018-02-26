using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerCreator{
    [SerializeField]
    public static List<GameObject> PetalTypes;

    private string[] dna;
    private FlowerDatabase data;

    private Color color;
    private int petalCount;
    private GameObject petalShape;

    public Flower(Flower mother, Flower father, FlowerDatabase data)
    {
        this.data = data;
        dna = data.Breed(mother.GetDNA(), father.GetDNA());
        setGameObjectValues();
    }

    public Flower(string[] dna, FlowerDatabase data)
    {
        this.data = data;
        this.dna = dna;
        setGameObjectValues();
    }

    public string[] GetDNA()
    {
        return dna;
    }

    private void setGameObjectValues()
    {
        color = getPetalColor();
        petalCount = getPetalCount();
        petalShape = getPetalShape();
    }

    public Color getPetalColor()//{ "Red", "Yellow", "Blue" }, new string[] { "Orange", "Purple", "Green" });
    {
        string str = dna[2];
        if (str == "Red")
            return Color.red;
        if (str == "Yellow")
            return Color.yellow;
        if (str == "Blue")
            return Color.blue;
        if (str == "Orange")
            return Color.black;
        if (str == "Purple")
            return Color.magenta;
        if (str == "Green")
            return Color.green;

        return Color.white;
    }

    public int getPetalCount()//{ "2", "3", "4", "5" }, new string[] { });
    {
        string str = dna[1];
        if (str == "2")
            return 2;
        if (str == "3")
            return 3;
        if (str == "4")
            return 4;
        if (str == "5")
            return 5;

        return -1;
    }

    public GameObject getPetalShape()//{ "pointed", "forked", "round" }
    {
        string str = dna[0];
        if(str == "pointed")
            return PetalTypes[0];
        if (str == "forked")
            return PetalTypes[1];
        if (str == "round")
            return PetalTypes[2];

        return null;
    }

}
