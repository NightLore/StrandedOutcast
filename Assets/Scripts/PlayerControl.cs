using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Attacker))]
public class PlayerControl : MonoBehaviour
{
    private CharacterController controller;
    private Animator animator;
    private Attacker attacker;
    public ParticleSystem dirtSplatter;

    public float speed = 10;
    private Vector3 lastPos;
    private bool wasAttacking;

    // Start is called before the first frame updateSpee
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (attacker.CanAttack)
        {
            Move();
            CheckAttack();
        }
    }

    private void Move()
    {
        float step = speed * Time.deltaTime;
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(direction * step);
        
        //transform.position = new Vector3(transform.position.x, 0, transform.position.z); // force player on the ground
        transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, direction, step, 0.0f));

        animator.SetBool("Static_b", false);
        if (lastPos != transform.position)
        {
            animator.SetFloat("Speed_f", 0.6f);
            dirtSplatter.Play();
        }
        else
        {
            animator.SetFloat("Speed_f", 0.0f);
            dirtSplatter.Stop();
        }
        lastPos = transform.position;
    }

    private void CheckAttack()
    {
        if (Input.GetAxis("Fire1") == 0)
            return;

        //animator.SetFloat("Speed_f", 0.0f);
        //animator.SetTrigger("Attack_trig");
        //animator.SetInteger("Animation_int", 5);
        attacker.Attack(animator, animator.GetCurrentAnimatorStateInfo(0).length - GameSettings.attackLifeSpan);
    }

    private bool IsAttacking()
    {
        var a = animator.GetCurrentAnimatorStateInfo(0);
        return a.IsName("Attack") && (a.normalizedTime <= 1 || animator.IsInTransition(0));
    }
}
