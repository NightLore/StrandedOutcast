using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class RecipeButton : InfoText
{
    public int itemIndex;

    private Item item;

    void OnEnable()
    {
        item = GameSettings.itemList[itemIndex];
    }

    // Update is called once per frame
    void Update()
    {
    }

    public override void UpdateInfo()
    {
        recipeText.text = item.GetName() + "\n" + item.GetRecipe().ToString();
    }
}
