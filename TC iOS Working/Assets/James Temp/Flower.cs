using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower{
    private string[] dna;
    private FlowerDatabase data;

    private Color color;
    private int petalCount;
    private GameObject petalShape;

    public Flower(Flower mother, Flower father, FlowerDatabase data)
    {
        this.data = data;
        dna = data.Breed(mother.GetDNA(), father.GetDNA());
    }

    public Flower(string[] dna, FlowerDatabase data)
    {
        this.data = data;
        this.dna = dna;
    }

    public string[] GetDNA()
    {
        return dna;
    }
}
