using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    public GameObject attack;
    public int damage = 5;

    public bool CanAttack { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        CanAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack(Animator animator, float lengthModifier)
    {
        if (CanAttack)
        {
            animator.SetFloat("Speed_f", 0.0f);
            animator.SetTrigger("Attack_trig");
            animator.speed = lengthModifier;
            float delay = GameSettings.attackAnimationLength / lengthModifier - GameSettings.attackLifeSpan;
            Invoke("SpawnAttack", delay);
            Invoke("AllowAttack", GameSettings.attackAnimationLength);
            CanAttack = false;
        }
    }

    private void SpawnAttack()
    {
        Vector3 pos = gameObject.transform.position;
        Vector3 dir = gameObject.transform.forward;
        Vector3 spawnPos = pos + dir * GameSettings.attackDistance;
        spawnPos.y = attack.transform.position.y;

        Attack a = Instantiate(attack, spawnPos, Quaternion.LookRotation(attack.transform.forward, dir)).GetComponent<Attack>();
        a.owner = gameObject;
        a.damage = damage;
    }

    private void AllowAttack()
    {
        CanAttack = true;
    }
}
