using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public int numSticks = 0;
    public int numRocks = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Item"))
        {
            if (other.gameObject.name.Contains("Stick"))
            {
                numSticks++;
                Destroy(other.gameObject);
            }
            else if (other.gameObject.name.Contains("Rock"))
            {
                numRocks++;
                Destroy(other.gameObject);
            }
        }
    }
}
