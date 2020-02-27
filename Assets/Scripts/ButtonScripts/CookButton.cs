using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookButton : MonoBehaviour
{
    private Inventory inventory;
    private Button button;
    // Start is called before the first frame update
    void OnEnable()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Cook);
        inventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Cook() {
        // TODO: use CraftRecipe()
        if (inventory.GetQuantity(GameSettings.RAWMEAT) > 0 && GameSettings.canCook) {
            inventory.DecrementQuantity(GameSettings.RAWMEAT);
            inventory.IncrementQuantity(GameSettings.COOKEDMEAT);
            inventory.UpdateQuantities();
        }
    }
}
