using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    public GameObject attack;
    private int damage;
    private Vector3 scale;
    private float speed;

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

    public void SetStats(int d, Vector3 size, float s)
    {
        damage = d;
        scale = size;
        speed = s;
    }

    public void Attack(Animator animator)
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
        //spawnPos.y = attack.transform.position.y;

        Attack a = Instantiate(attack, spawnPos, Quaternion.LookRotation(attack.transform.forward, dir)).GetComponent<Attack>();
        a.owner = gameObject;
        a.damage = damage;
        a.gameObject.transform.localScale = scale;
    }

    private void AllowAttack()
    {
        CanAttack = true;
    }
}
