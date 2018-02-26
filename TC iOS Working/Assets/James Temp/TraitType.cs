using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

class TraitType
{
    List<string> scavengeable;
    List<string> nonscavangable;
    List<Mutation> mutations;

    public TraitType(string[] scav, string[] nonscav)
    {
        this.scavengeable = new List<string>();
        this.nonscavangable = new List<string>();
        this.mutations = new List<Mutation>();

        foreach (string str in scav)
            this.scavengeable.Add(str);
        foreach (string str in nonscav)
            this.nonscavangable.Add(str);
    }

    public Mutation getMutation(string mother, string father)
    {
        if (!this.IsValid(mother) | !this.IsValid(father))
            throw new System.Exception("Invalid Trait String!");

        foreach (Mutation mutation in mutations)
        {
            if (mutation.SameParents(mother, father))
                return mutation;
        }
        return null;
    }

    public string Breed(string mother, string father)
    {
        if (!this.IsValid(mother) | !this.IsValid(father))
            throw new System.Exception("Invalid Trait String!");

        System.Random rnd = new System.Random(DateTime.Now.Ticks.GetHashCode());
        Mutation mutation = getMutation(mother, father);
        if (mutation == null)
        {
            int index = rnd.Next(0, 2);
            string[] options = new string[2] { mother, father };
            return options[index];
        }
        else
        {
            return mutation.Breed();
        }


    }

    public string Scavenge()
    {
        System.Random rnd = new System.Random(DateTime.Now.Ticks.GetHashCode());
        int index = rnd.Next(0, scavengeable.Count);
        return scavengeable[index];
    }

    public bool IsValid(string str)
    {
        return this.GetValidTraits().Contains(str);
    }

    public void AddMutation(string mother, string father, string child, int chance)
    {
        if (!this.IsValid(mother) | !this.IsValid(father) | !this.IsValid(child))
        {
            throw new System.Exception("Invalid Trait String!");
        }
        if (0 > chance | chance > 100)
        {
            throw new System.Exception("Invalid Chance Integer!");
        }
        mutations.Add(new Mutation(mother, father, child, chance));

    }

    public override string ToString()
    {
        string result = "TraitType: ";

        if (scavengeable.Count != 0)
        {
            result += "scavengeable[";
            foreach (string str in scavengeable)
            {
                result += str + ", ";
            }
            result = result.Substring(0, result.Length - 2) + "], ";
        }
        if (nonscavangable.Count != 0)
        {
            result += "non-scavengeable [";
            foreach (string str in nonscavangable)
            {
                result += str + ", ";
            }
            result = result.Substring(0, result.Length - 2) + "], ";
        }
        if (mutations.Count != 0)
        {
            result += "mutations [";
            foreach (Mutation mutation in mutations)
            {
                result += mutation + ", ";
            }
            result = result.Substring(0, result.Length - 2) + "], ";
        }

        if (result == "TraitType: ")
        {
            return "TraitType: empty";
        }
        else
        {
            return result.Substring(0, result.Length - 2);
        }
    }

    public List<string> GetValidTraits()
    {
        List<string> result = new List<string>();
        foreach (string str in scavengeable)
        {
            result.Add(str);
        }
        foreach (string str in nonscavangable)
        {
            result.Add(str);
        }
        return result;
    }
}
