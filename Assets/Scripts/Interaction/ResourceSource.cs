using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ResourceText))]
public class ResourceSource : MonoBehaviour
{
    public GameObject splatterPrefab;
    public int[] harvestableTools; // use weapon index

    private ResourceText resourceText;
    private List<Weapon> tools;
    private Dropper dropper;
    // Start is called before the first frame update
    void Start()
    {
        resourceText = GetComponent<ResourceText>();
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
        if (a && a.IsPlayer())
        {
            if (CanHarvest(a.GetOwner().GetComponent<Attacker>().GetWeapon()))
            {
                Equiper e = a.GetOwner().GetComponent<Equiper>();
                if (e) e.CheckCurrentWeapon();
                if (dropper) dropper.Drop(a.GetOwner().transform.position);
                if (splatterPrefab) a.Die(splatterPrefab);
            }
            else
            {
                resourceText.DisplayText();
            }
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
