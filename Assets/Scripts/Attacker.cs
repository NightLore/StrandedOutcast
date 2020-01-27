using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    public GameObject attack;
    public int damage = 5;
    public int spawnDistance = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnAttack()
    {
        Vector3 pos = gameObject.transform.position;
        Vector3 dir = gameObject.transform.forward;
        Vector3 spawnPos = pos + dir * spawnDistance;
        spawnPos.y = attack.transform.position.y;

        Attack a = Instantiate(attack, spawnPos, Quaternion.LookRotation(attack.transform.forward, dir)).GetComponent<Attack>();
        a.owner = gameObject;
        a.damage = damage;
    }
}
