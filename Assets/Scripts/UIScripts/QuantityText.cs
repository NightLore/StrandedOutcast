using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuantityText : MonoBehaviour
{
    public int item; // Item ID (not weapon index)
    private Inventory inventory;
    private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateQuantityText()
    {
        // Set inventory and text in realtime because it sadly doesn't work in start or onEnable
        if (!inventory)
        {
            inventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();
        }
        if (!text)
        {
            text = GetComponent<TextMeshProUGUI>();
        }
        text.text = "" + inventory.GetQuantity(item);
        //Debug.Log(inventory.GetQuantity(item));
    }
}
