using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerDatabase
{
    Dictionary<string, TraitType> traitTypes;

    public FlowerDatabase()
    {
        traitTypes = new Dictionary<string, TraitType>();
    }

    public void AddTraitType(string traitName, string[] scavengeable, string[] nonscavangable)
    {
        TraitType temp = new TraitType(scavengeable, nonscavangable);
        traitTypes.Add(traitName, temp);
    }

    public void AddMutation(string traitName, string mother, string father, string child, int chance)
    {
        traitTypes[traitName].AddMutation(mother, father, child, chance);
    }

    public string[] Breed(string[] mother, string[] father)
    {
        string[] child = new string[traitTypes.Keys.Count];
        int index = 0;
        foreach (string traitName in traitTypes.Keys)
        {
            child[index] = traitTypes[traitName].Breed(mother[index], father[index]);
            index++;
        }


        return child;
    }

    public string[] Scavenge()
    {
        int size = traitTypes.Keys.Count;
        string[] result = new string[size];

        int count = 0;
        foreach (string traitName in traitTypes.Keys)
        {
            result[count] = traitTypes[traitName].Scavenge();
            count++;
        }

        return result;
    }

    public override string ToString()
    {
        string result = "PlantDatabase: ";
        if (traitTypes.Keys.Count != 0)
        {
            foreach (string traitName in traitTypes.Keys)
            {
                result += traitName + " " + traitTypes[traitName].ToString() + ", ";
            }
            return result.Substring(0, result.Length - 2);
        }
        return result + "empty";
    }

    public int getSize()
    {
        return traitTypes.Keys.Count;
    }
}