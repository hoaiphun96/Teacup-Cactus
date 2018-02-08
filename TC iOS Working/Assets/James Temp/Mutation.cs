using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
  The mutation class represents possible mutations that can occur in the plant.
  The mutation has two parents, whether the father or the mother it doesn't matter.
  If two plants are breed together that have the same parrents as this mutation it
  will result in true from SameParents. Breed will allow a child trait to be generated
  based on the percent chance represented by an integer between 0 and 100.
  */
class Mutation
{
    private string mother;
    private string father;
    private string child;
    private int chance;

    public Mutation(string mother, string father, string child, int chance)
    {
        this.mother = mother;
        this.father = father;
        this.child = child;
        this.chance = chance;
    }

    public string[] getParents()
    {
        return new string[2] { mother, father };
    }

    public bool SameParents(string otherMother, string otherFather)
    {
        string[] otherParents = new string[2] { otherMother, otherFather };
        if (mother == otherParents[0] && father == otherParents[1])
            return true;
        if (mother == otherParents[1] && father == otherParents[0])
            return true;
        return false;
    }

    public string Breed()
    {
        string[] options = new string[3] { mother, father, child };
        int[] chances = new int[3] { (100 - chance) / 2, (100 - chance) / 2, chance };
        return options[randomChance(chances)];
    }

    public static int randomChance(int[] chances)
    {
        System.Random rnd = new System.Random(DateTime.Now.Ticks.GetHashCode());
        int perCent = rnd.Next(0, 100);

        int temp = 0;
        for (int i = 0; i < chances.Length; i++)
        {
            temp += chances[i];
            if (perCent < temp)
            {
                return i;
            }
        }

        return -1;
    }

    public override string ToString()
    {
        return mother + " + " + father + " -> " + child + "(" + chance + "%)";
    }
}
