using System.Collections.Generic;
using System;

public class Flower
{
    public PlantDatabase data;

    public string[] genes;
    public DateTime creationTime;

    //Save and Load Constructor
    public Flower(PlantDatabase data, string str)
    {
        this.data = data;
        string[] inputList = str.Split(',');
        List<string> inputList2 = new List<string>(inputList);
        creationTime = DateTime.Parse(inputList[0]);
        inputList2.Remove(inputList[0]);
        this.genes = inputList2.ToArray();
    }

    public override string ToString()
    {
        string output = "";
        List<string> outputList = new List<string>();
        outputList.Add(creationTime.ToString());
        foreach (string gene in genes)
            outputList.Add(gene);

        foreach (string str in outputList)
            output += str + ",";
        return output.Substring(0, output.Length-1);
    }

    //Scavenged Flower Constructor
    public Flower(PlantDatabase data)
    {
        this.creationTime = DateTime.Now;
        this.data = data;
        this.genes = data.Scavenge();
    }

    //The main constructor
    public Flower(PlantDatabase data, string[] genes)
    {
        this.creationTime = DateTime.Now;
        this.data = data;
        this.genes = genes;
    }

    public Flower Breed(Flower other)
    {
        string[] childgene = data.Breed(this.genes, other.genes);
        return new Flower(data, childgene);
    }
}
