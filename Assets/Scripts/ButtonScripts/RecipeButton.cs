using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecipeButton : MonoBehaviour
{
    private TextMeshProUGUI recipeText;

    public int itemIndex;

    private Weapon weapon;
    private Item item;


    void OnEnable()
    {
        recipeText = GameObject.Find("/Canvas/GameScreen/InfoPanel/RecipeText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateInfo()
    {
        if (transform.parent.name.Equals("WeaponButton") || 
            transform.parent.parent.name.Equals("WeaponButton"))
        {
            weapon = GameSettings.weapons[itemIndex];
            recipeText.text = weapon.GetName() + "\n" + weapon.GetRecipe().ToString();
        }
        else if (transform.parent.name.Equals("BuildingButton") ||
                 transform.parent.parent.name.Equals("BuildingButton"))
        {
            item = GameSettings.buildings[itemIndex];
            recipeText.text = item.GetName() + "\n" +  item.GetRecipe().ToString();
        }
        else if (transform.parent.name.Equals("FoodButton") ||
                 transform.parent.parent.name.Equals("FoodButton"))
        {
            recipeText.text = "Can Cook?\n" + (GameSettings.canCook ? "Yes" : "No");
        }
    }
}
