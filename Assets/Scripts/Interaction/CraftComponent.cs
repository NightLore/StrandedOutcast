using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftComponent : MonoBehaviour
{
    public int need;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        Inventory inventory = other.GetComponent<Inventory>();
        if (inventory)
        {
            inventory.SetNeed(need, true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        Inventory inventory = other.GetComponent<Inventory>();
        if (inventory)
        {
            inventory.SetNeed(need, false);
        }
    }
}
