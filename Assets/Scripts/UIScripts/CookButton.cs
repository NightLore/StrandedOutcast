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
        if (inventory.CanCraft(food)) {
            inventory.CraftItem(food);
            inventory.UpdateQuantities();
        }
        else
        {
            Debug.Log("Cook Failed");
        }
    }
}
