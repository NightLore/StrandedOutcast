using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Hunger : MonoBehaviour
{
    private Health health;

    private float maxHunger = 100;
    private float hunger;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
        hunger = maxHunger;

        InvokeRepeating("DecreaseHunger", GameSettings.saturationDelay, 1.0f / GameSettings.hungerRate);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public float GetMaxHunger()
    {
        return maxHunger;
    }

    public float GetHunger()
    {
        return hunger;
    }

    /* 
     * Increases Hunger by amount up to max hunger. 
     * Heals by GameSettings.saturationRegen each time it goes above max hunger.
     */
    public void IncreaseHunger(float amount)
    {
        hunger += amount;
        if (hunger > GetMaxHunger())
        {
            health.Heal(GameSettings.saturationRegen);
            hunger = GetMaxHunger();
        }
    }

    /*
     * Decreases the Hunger by one. If hunger drops below 0, reset to 0 and take health damage
     * This function is intended to be continuously called at a delay of 1 / hungerRate
     * 
     * References:
     *      health
     */
    void DecreaseHunger()
    {
        hunger--;
        if (hunger < 0)
        {
            health.TakeDamage(1); // damage taken from no hunger determined by hunger rate
            hunger = 0;
        }
    }
}
