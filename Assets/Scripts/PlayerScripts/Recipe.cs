using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe
{
    private readonly Dictionary<int, int> ingredients;
    private readonly Dictionary<int, bool> needs;

    public class Builder
    {
        private Dictionary<int, int> ingredients;
        private Dictionary<int, bool> needs;

        public Builder()
        {
            Reset();
        }

        public Builder Reset()
        {
            ingredients = new Dictionary<int, int>();
            needs = new Dictionary<int, bool>();
            return this;
        }

        public Builder Set(int index, int amount)
        {
            ingredients[index] = amount;
            return this;
        }

        public Builder Needs(int index)
        {
            needs[index] = true;
            return this;
        }

        public Recipe GetRecipe()
        {
            return new Recipe(ingredients, needs);
        }
    }


    private Recipe(Dictionary<int, int> ingredients, Dictionary<int, bool> needs)
    {
        this.ingredients = ingredients;
        this.needs = needs;
    }

    public Dictionary<int, int> GetIngredients()
    {
        return ingredients;
    }

    public Dictionary<int, bool> GetNeeds()
    {
        return needs;
    }

    public override string ToString()
    {
        string s = "";
        foreach (KeyValuePair<int, bool> pair in needs)
        {
            if (pair.Value)
                s += "Need " + GameSettings.itemList[pair.Key].GetName() + "\n";
        }
        foreach (KeyValuePair<int, int> pair in ingredients)
        {
            if (pair.Value > 0)
                s += GameSettings.itemList[pair.Key].GetName() + ": " + pair.Value + "\n";
        }
        return s;
    }
}
