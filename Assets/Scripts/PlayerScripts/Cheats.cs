using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheats : MonoBehaviour
{
    private bool initialized = false;
    private GameObject player;
    private Inventory inventory;
    private EnvironmentSpawner spawner;
    // Start is called before the first frame update
    void Start()
    {
        spawner = GetComponent<EnvironmentSpawner>();
    }

    public void Initialize(GameObject player)
    {
        initialized = true;
        this.player = player;
        inventory = player.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!initialized)
            return;
        // Stick
        if (Input.GetKeyDown(KeyCode.Slash))
        {
            inventory.IncrementQuantity(GameSettings.STICK);
            inventory.UpdateQuantities();
        }

        // Rock
        if (Input.GetKeyDown(KeyCode.Period))
        {
            inventory.IncrementQuantity(GameSettings.ROCK);
            inventory.UpdateQuantities();
        }

        // Raw Meat
        if (Input.GetKeyDown(KeyCode.Comma))
        {
            inventory.IncrementQuantity(GameSettings.RAWMEAT);
            inventory.UpdateQuantities();
        }

        // Cooked Meat
        if (Input.GetKeyDown(KeyCode.Semicolon))
        {
            inventory.IncrementQuantity(GameSettings.COOKEDMEAT);
            inventory.UpdateQuantities();
        }

        // Metal ore
        if (Input.GetKeyDown(KeyCode.Quote))
        {
            inventory.IncrementQuantity(GameSettings.METAL);
            inventory.UpdateQuantities();
        }

        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            spawner.SpeedUpTimer();
        }
    }
}
