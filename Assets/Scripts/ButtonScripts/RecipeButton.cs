using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecipeButton : MonoBehaviour
{
    public int itemIndex;

    private Item item;
    private TextMeshProUGUI recipeText;

    void OnEnable()
    {
        item = GameSettings.itemList[itemIndex];
        recipeText = GameObject.Find("/Canvas/GameScreen/InfoPanel/RecipeText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateInfo()
    {
        recipeText.text = item.GetName() + "\n" + item.GetRecipe().ToString();
    }
}
