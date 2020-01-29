using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class TrackPlayer : MonoBehaviour
{
    public float speed = 10.0f;
    public float bufferDistance = GameSettings.attackDistance;

    private GameObject player;
    private Attacker attacker;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        player = GameObject.Find("Player");
        attacker = GetComponent<Attacker>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (attacker.CanAttack)
        {
            Track();
            if ((player.transform.position - transform.position).magnitude <= GameSettings.attackDistance + 1)
            {
                attacker.Attack(animator, 1);
            }
        }
    }

    private void Track()
    {
        float step = speed * Time.deltaTime;
        Vector3 direction = Vector3.Normalize(player.transform.position - transform.position);
        Vector3 target = player.transform.position - direction * bufferDistance;
        target.y = transform.position.y;

        transform.position = Vector3.MoveTowards(transform.position, target, step);
        transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, direction, step, 0.0f));
    }
}
