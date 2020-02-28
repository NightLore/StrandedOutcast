using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSource : MonoBehaviour
{

    public int[] harvestableTools; // use weapon index

    private List<Weapon> tools;
    private Dropper dropper;
    // Start is called before the first frame update
    void Start()
    {
        tools = new List<Weapon>();
        foreach (int index in harvestableTools)
        {
            tools.Add(GameSettings.weapons[index]);
        }
        dropper = GetComponent<Dropper>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Attack a = other.GetComponent<Attack>();
        if (a && a.IsPlayer() 
         && CanHarvest(a.GetOwner().GetComponent<Attacker>().GetWeapon()))
        {
            Vector3 spawnPos = a.GetOwner().transform.position;
            spawnPos.y += 5;
            dropper.Drop(spawnPos);
        }
    }

    private bool CanHarvest(Weapon tool)
    {
        foreach (Weapon w in tools)
        {
            if (tool == w)
                return true;
        }
        return false;
    }
}
