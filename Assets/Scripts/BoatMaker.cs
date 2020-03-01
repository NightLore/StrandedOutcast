﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMaker : MonoBehaviour
{
    public GameObject boat; // drag in
    public ParticleSystem buildParticle;
    private EnvironmentSpawner spawner;

    private Health boatHealth;
    // Start is called before the first frame update
    void Start()
    {
        boatHealth = boat.GetComponent<Health>();
        spawner = GameObject.Find("EnvironmentSpawner").GetComponent<EnvironmentSpawner>();
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
            Inventory inventory = a.GetOwner().GetComponent<Inventory>();
            if (inventory.GetQuantity(GameSettings.STICK) > 0)
            {
                inventory.DecrementQuantity(GameSettings.STICK);
                inventory.UpdateQuantities();
                buildParticle.Play();
                if (boatHealth.Heal(1))
                {
                    spawner.GameWin(boat.transform.position + Vector3.up * 2);
                }
            }
        }
    }
}
