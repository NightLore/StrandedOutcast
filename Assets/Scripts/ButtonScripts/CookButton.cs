using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookButton : MonoBehaviour
{
    public int food;

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
        Debug.Log("Cook");
        if (inventory.CanCraft(food)) {
            Debug.Log("Success");
            inventory.CraftItem(food);
            inventory.UpdateQuantities();
        }
        Debug.Log("Failed");
        Debug.Log(inventory.CanCraft(food));
    }
}
