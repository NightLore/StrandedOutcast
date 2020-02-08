﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject bloodSplatter;
    public GameObject owner;
    public int damage;
    public static float lifeSpan = 0.2f;

    private float time;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > lifeSpan)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Health health = other.gameObject.GetComponent<Health>();
        if (other.gameObject != owner && health != null)
        {
            health.takeDamage(damage);
            Instantiate(bloodSplatter, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }
}