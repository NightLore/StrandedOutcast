using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Attacker : MonoBehaviour
{
    public GameObject attack;

    private Animator animator;

    private int damage;
    private Vector3 scale;
    private float speed;
    public Weapon weapon;

    public bool CanAttack { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        CanAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetStats(int d, Vector3 size, float s, Weapon weaponIn)
    {
        damage = d;
        scale = size;
        speed = s;
        weapon = weaponIn;
    }

    public void Attack()
    {
        if (CanAttack)
        {
            animator.SetFloat("Speed_f", 0.0f);
            animator.SetTrigger("Attack_trig");
            animator.speed = speed;
            float delay = GameSettings.attackAnimationLength / speed;
            Invoke("SpawnAttack", delay - GameSettings.attackLifeSpan);
            Invoke("AllowAttack", delay);
            CanAttack = false;
        }
    }

    private void SpawnAttack()
    {
        Vector3 pos = gameObject.transform.position;
        Vector3 dir = gameObject.transform.forward;
        Vector3 spawnPos = pos + dir * GameSettings.attackDistance;

        Attack a = Instantiate(attack, spawnPos, Quaternion.LookRotation(attack.transform.forward, dir)).GetComponent<Attack>();
        a.owner = gameObject;
        a.damage = damage;
        a.gameObject.transform.localScale = scale;
    }

    private void AllowAttack()
    {
        animator.SetFloat("Speed_f", 0.5f);
        CanAttack = true;
    }
}
