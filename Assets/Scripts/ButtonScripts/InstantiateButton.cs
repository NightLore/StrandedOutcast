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
    // Start is called before the first frame update
    void OnEnable() {
        button = GetComponent<Button>();
        button.onClick.AddListener(Create);
        playerTransform = GameObject.FindWithTag("Player").transform;
        inventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();
    }

    void Create() {
        if (inventory.CanCraft(itemIndex)) {
            inventory.CraftItem(itemIndex);
            Instantiate(toCreate, playerTransform.position, toCreate.transform.rotation);
            inventory.DecrementQuantity(itemIndex);
            inventory.UpdateQuantities();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
