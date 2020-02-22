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
        if (inventory.itemCounts[GameSettings.RAWMEAT] > 0 && GameSettings.canCook) {
            inventory.itemCounts[GameSettings.RAWMEAT]--;
            inventory.itemCounts[GameSettings.COOKEDMEAT]++;
            inventory.UpdateQuantityText(GameSettings.RAWMEAT);
            inventory.UpdateQuantityText(GameSettings.COOKEDMEAT);
        }
    }
}
