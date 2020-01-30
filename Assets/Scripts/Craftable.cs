using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Craftable : MonoBehaviour
{
    public GameObject recipeText;

    public int item;
    // Start is called before the first frame update
    void Start()
    {
        recipeText.GetComponent<TextMeshProUGUI>().text = "Sticks: " + GameSettings.weaponParts[item][GameSettings.STICK]
                                                        + "\nRocks: " + GameSettings.weaponParts[item][GameSettings.ROCK];
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
