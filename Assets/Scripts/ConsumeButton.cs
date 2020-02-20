using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsumeButton : MonoBehaviour
{
    public int food;

    private Inventory inventory;
    private Button button;
    private Hunger hunger;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Consume);
        hunger = GameObject.FindWithTag("Player").GetComponent<Hunger>();
        inventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Consume() {
        if (inventory.itemCounts[GameSettings.COOKEDMEAT] > 0) {
            hunger.IncreaseHunger(GameSettings.foodvalues[food]);
            inventory.itemCounts[GameSettings.COOKEDMEAT]--;
            inventory.UpdateQuantityText(GameSettings.COOKEDMEAT);
        }
    }
}
