using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private EnvironmentSpawner environmentSpawner;
    private Dropper dropper;

    public bool controlStartHealth = false;
    public int maxHp;
    private int hp;
    // Start is called before the first frame update
    void Start()
    {
        environmentSpawner = GameObject.Find("EnvironmentSpawner").GetComponent<EnvironmentSpawner>();
        dropper = GetComponent<Dropper>();
        if (!controlStartHealth)
        {
            hp = maxHp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetHP()
    {
        return hp;
    }

    // sets the starting hp, does not do any checking (use Heal() or TakeDamage() for checking
    public void SetHP(int newHp)
    {
        hp = newHp;
    }

    /*
     * Increases health by the specified amount until maxHp
     * If hp heals to maxHp, returns true, else returns false
     */ 
    public bool Heal(int amount)
    {
        hp += amount;
        if (hp >= maxHp)
        {
            hp = maxHp;
            return true;
        }
        return false;
    }

    /*
     * Decreases health by the specified amount. Returns true if health is less than or equal to 0 and Destroys this gameobject
     */
    public bool TakeDamage(int amount)
    {
        hp -= amount;
        if (hp <= 0)
        {
            if (dropper) dropper.Drop();
            environmentSpawner.killCount++;
            Destroy(gameObject);
            return true;
        }
        return false;
    }
}
