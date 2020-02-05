using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public EnvironmentSpawner environmentSpawner;
    public int maxHp;
    public int hp;
    // Start is called before the first frame update
    void Start()
    {
        environmentSpawner = GameObject.Find("EnvironmentSpawner").GetComponent<EnvironmentSpawner>();
        hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //void heal(int amount)
    //{
    //    hp = Mathf.Min(hp + amount, maxHp);
    //}

    public void takeDamage(int amount)
    {
        hp -= amount;
        if (hp <= 0)
        {
            environmentSpawner.killCount++;
            Destroy(gameObject);
        }
    }
}
