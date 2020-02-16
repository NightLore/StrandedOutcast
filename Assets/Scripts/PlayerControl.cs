using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Attacker))]
public class PlayerControl : MonoBehaviour
{
    private GameObject playerLocation;
    private CharacterController controller;
    private Animator animator;
    private Attacker attacker;
    public ParticleSystem dirtSplatter;

    private Vector3 lastPos;

    void Start()
    {
        playerLocation = GameObject.Find("PlayerLocation");
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
        lastPos = transform.position;
    }

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
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.SimpleMove(direction.normalized * GameSettings.playerSpeed * Time.deltaTime);

        //transform.position = new Vector3(transform.position.x, 0, transform.position.z); // force player on the ground

        Vector3 r = Vector3.RotateTowards(transform.forward, direction, GameSettings.playerTurnSpeed * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(r);

        // Animate 
        animator.SetBool("Static_b", false);
        if (lastPos != transform.position)
        {
            animator.speed = 1.0f;
            animator.SetFloat("Speed_f", 0.6f);
            dirtSplatter.Play();
        }
        else
        {
            animator.SetFloat("Speed_f", 0.0f);
            dirtSplatter.Stop();
        }
        lastPos = transform.position;

        playerLocation.transform.position = transform.position;
        playerLocation.transform.rotation = transform.rotation;
    }

    private void CheckAttack()
    {
        if (Input.GetAxis("Fire1") == 0)
            return;

        attacker.Attack(animator);
    }
}
