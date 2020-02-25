using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    private readonly int id;
    private readonly int damage;
    private readonly Vector3 size;
    private readonly float speed;
    private readonly int maxDurability;
    private int durability;

    public Weapon(
        string name,
        Recipe recipe,
        int id,
        int damage,
        Vector3 size,
        float speed,
        int maxDurability) : base(name, recipe)
    {
        this.id = id;
        this.damage = damage;
        this.size = size;
        this.speed = speed;
        this.maxDurability = maxDurability;
        this.durability = maxDurability;
    }

    public Weapon Clone()
    {
        return new Weapon(
            GetName(),
            GetRecipe(),
            id,
            damage,
            size,
            speed,
            maxDurability);
    }

    public int GetID()
    {
        return id;
    }

    public int GetDamage()
    {
        return damage;
    }

    public Vector3 GetSize()
    {
        return size;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public int GetDurability()
    {
        return durability;
    }

    public int GetMaxDurability()
    {
        return maxDurability;
    }
}
