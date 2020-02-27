using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class BasicEnemyActor : MonoBehaviour
{
    public float speed = 10.0f;
    public float bufferDistance = GameSettings.attackDistance;

    private GameObject player;
    private Attacker attacker;
    public int attackDamage = 2;
    public Vector3 attackScale = new Vector3(1, 1, 1);
    public float attackSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        attacker = GetComponent<Attacker>();
        attacker.SetStats(attackDamage, attackScale, attackSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (player && attacker.CanAttack)
        {
            //Track();
            if ((player.transform.position - transform.position).magnitude <= GameSettings.attackDistance + 1)
            {
                attacker.Attack();
            }
        }
    }

    /*
     * Now we are using NavMesh
     * 
     * private void Track()
    {
        float step = speed * Time.deltaTime;
        Vector3 direction = Vector3.Normalize(player.transform.position - transform.position);
        Vector3 target = player.transform.position - direction * bufferDistance;
        target.y = transform.position.y;

        transform.position = Vector3.MoveTowards(transform.position, target, step);
        transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, direction, step, 0.0f));
    }*/
}
