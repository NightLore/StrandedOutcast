using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CraftButton : MonoBehaviour
{
    public GameObject recipeText;

    public int itemIndex;

    private Weapon weapon;
    private Item item;
    // Start is called before the first frame update
    void OnEnable()
    {
        if (transform.parent.name.Equals("WeaponButton")) {
            weapon = GameSettings.weapons[itemIndex];
            int[] recipe = weapon.GetRecipe();
            recipeText.GetComponent<TextMeshProUGUI>().text = "Sticks: " + recipe[GameSettings.STICK]
                                                        + "\nRocks: " + recipe[GameSettings.ROCK];
        }
        else if (transform.parent.name.Equals("BuildingButton")) {
            item = GameSettings.buildings[itemIndex];
            int[] recipe = item.GetRecipe();
            recipeText.GetComponent<TextMeshProUGUI>().text = "Sticks: " + recipe[GameSettings.STICK]
                                                        + "\nRocks: " + recipe[GameSettings.ROCK];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent.name.Equals("FoodButton")) {
            recipeText.GetComponent<TextMeshProUGUI>().text = "Can Cook?\n" + (GameSettings.canCook ? "Yes" : "No");
        }
    }

    public void onPointerEnter()
    {
        recipeText.SetActive(true);
    }

    public void OnPointerExit()
    {
        recipeText.SetActive(false);
    }
}
