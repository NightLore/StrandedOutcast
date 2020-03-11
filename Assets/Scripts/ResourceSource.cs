using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceSource : MonoBehaviour
{
    private TextMeshProUGUI resourceText;
    public string need;
    public GameObject splatterPrefab;
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
        if (!resourceText)
        {
            GameObject g = GameObject.Find("ResourceText");
            if (g)
            {
                resourceText = g.GetComponent<TextMeshProUGUI>();
                resourceText.enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Attack a = other.GetComponent<Attack>();
        if (a && a.IsPlayer())
        {
            if (CanHarvest(a.GetOwner().GetComponent<Attacker>().GetWeapon()))
            {
                if (dropper) dropper.Drop(a.GetOwner().transform.position);
                if (splatterPrefab) a.Die(splatterPrefab);
            }
            else
            {
                resourceText.text = "Need " + need + " to harvest";
                resourceText.enabled = true;
                Invoke("DisableText", 3);
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

    private void DisableText()
    {
        resourceText.enabled = false;
    }
}
