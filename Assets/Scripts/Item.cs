using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    private readonly string name;
    private readonly int[] recipe;

    public Item(string name, int[] recipe)
    {
        this.name = name;
        this.recipe = recipe;
    }

    public string GetName()
    {
        return name;
    }

    public int[] GetRecipe()
    {
        return recipe;
    }
}
