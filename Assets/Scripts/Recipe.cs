using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe
{
    private readonly int[] ingredients;
    private readonly bool needsFire = false;

    public class Builder
    {
        private int[] ingredients = new int[GameSettings.NUMITEMTYPES];
        private bool needsFire = false;

        public Builder Reset()
        {
            ingredients = new int[GameSettings.NUMITEMTYPES];
            needsFire = false;
            return this;
        }

        public Builder Set(int index, int amount)
        {
            ingredients[index] = amount;
            return this;
        }

        public Builder SetNeedsFire()
        {
            needsFire = true;
            return this;
        }

        public Recipe GetRecipe()
        {
            return new Recipe(ingredients, needsFire);
        }
    }


    private Recipe(int[] ingredients, bool needsFire)
    {
        this.ingredients = ingredients;
        this.needsFire = needsFire;
    }

    public int Get(int index)
    {
        return ingredients[index];
    }

    public int[] GetIngredients()
    {
        return ingredients;
    }

    public bool NeedsFire()
    {
        return needsFire;
    }

    public override string ToString()
    {
        string s = "";
        for (int i = 0; i < ingredients.Length; i++)
        {
            if (ingredients[i] > 0)
                s += GameSettings.itemTypes[i] + ": " + ingredients[i] + "\n";
        }
        return s;
    }
}
