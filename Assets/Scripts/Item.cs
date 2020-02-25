using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    private readonly string name;
    private readonly Recipe recipe;

    public Item(string name, Recipe recipe)
    {
        this.name = name;
        this.recipe = recipe;
    }

    public string GetName()
    {
        return name;
    }

    public Recipe GetRecipe()
    {
        return recipe;
    }
}
