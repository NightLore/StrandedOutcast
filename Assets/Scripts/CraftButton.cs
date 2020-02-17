using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CraftButton : MonoBehaviour
{
    public GameObject recipeText;

    public int item;

    private Weapon weapon;
    // Start is called before the first frame update
    void Start()
    {
        weapon = GameSettings.weapons[item];
        int[] recipe = weapon.GetRecipe();
        recipeText.GetComponent<TextMeshProUGUI>().text = "Sticks: " + recipe[GameSettings.STICK]
                                                        + "\nRocks: " + recipe[GameSettings.ROCK];
    }

    // Update is called once per frame
    void Update()
    {
        
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
