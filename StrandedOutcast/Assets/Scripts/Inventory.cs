using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private AudioSource source;
    public AudioClip pickupSound;

    public int numSticks = 0;
    public int numRocks = 0;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
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
                pickup(other.gameObject);
            }
            else if (other.gameObject.name.Contains("Rock"))
            {
                numRocks++;
                pickup(other.gameObject);
            }
        }
    }

    private void pickup(GameObject gameObject)
    {
        Destroy(gameObject);
        source.PlayOneShot(pickupSound, 1.0f);
    }
}
