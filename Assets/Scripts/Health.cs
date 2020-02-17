using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public EnvironmentSpawner environmentSpawner;
    public int maxHp;
    private int hp;
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

    public int GetHP()
    {
        return hp;
    }

    /*
     * Increases health by the specified amount until maxHp
     */ 
    public void Heal(int amount)
    {
        hp = Mathf.Min(hp + amount, maxHp);
    }

    /*
     * Decreases health by the specified amount. Returns true if health is less than or equal to 0 and Destroys this gameobject
     */
    public bool takeDamage(int amount)
    {
        hp -= amount;
        if (hp <= 0)
        {
            environmentSpawner.killCount++;
            Destroy(gameObject);
            return true;
        }
        return false;
    }
}
