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
    private Recipe recipe;
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
        if (inventory.CheckRecipe(recipe)) {
            inventory.IncrementQuantity(itemIndex);
            inventory.CraftRecipe(recipe);
            inventory.UpdateQuantities();
            Instantiate(toCreate, playerTransform.position, toCreate.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
