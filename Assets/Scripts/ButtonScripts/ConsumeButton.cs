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
        if (inventory.GetQuantity(food) > 0) {
            hunger.IncreaseHunger(GameSettings.foodValue);
            inventory.DecrementQuantity(food);
            inventory.UpdateQuantities();
        }
    }
}
