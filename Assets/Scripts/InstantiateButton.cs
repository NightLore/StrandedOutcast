using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateButton : MonoBehaviour
{
    public GameObject toCreate;

    public int itemIndex;

    private Button button;
    private Inventory inventory;
    private Transform playerTransform;
    private Item item;
    private int[] recipe;
    // Start is called before the first frame update
    void OnEnable() {
        button = GetComponent<Button>();
        button.onClick.AddListener(Create);
        playerTransform = GameObject.FindWithTag("Player").transform;
        inventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();
        item = GameSettings.buildings[itemIndex];
        recipe = item.GetRecipe();
    }

    void Create() {
        if (inventory.itemCounts[GameSettings.STICK] >= recipe[GameSettings.STICK] &&
            inventory.itemCounts[GameSettings.ROCK] >= recipe[GameSettings.ROCK]) {
            inventory.itemCounts[GameSettings.STICK] -= recipe[GameSettings.STICK];
            inventory.itemCounts[GameSettings.ROCK] -= recipe[GameSettings.ROCK];
            inventory.itemCounts[GameSettings.STICKimage] -= recipe[GameSettings.STICK];
            inventory.itemCounts[GameSettings.ROCKimage] -= recipe[GameSettings.ROCK];
            inventory.UpdateQuantityText(GameSettings.ROCK);
            inventory.UpdateQuantityText(GameSettings.STICK);
            inventory.UpdateQuantityText(GameSettings.ROCKimage);
            inventory.UpdateQuantityText(GameSettings.STICKimage);
            Instantiate(toCreate, playerTransform.position, toCreate.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
