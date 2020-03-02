using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheats : MonoBehaviour
{
    private bool initialized = false;
    private GameObject player;
    private Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {

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

        // Metal
        if (Input.GetKeyDown(KeyCode.Comma))
        {

        }
    }
}
