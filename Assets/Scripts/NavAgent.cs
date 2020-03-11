using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
 * Resources:
 *https://docs.unity3d.com/ScriptReference/GameObject.Find.html
 */

public class NavAgent : MonoBehaviour
{
    private GameObject target;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        //target = GameObject.Find("Person");
        target = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.pathPending || !target) return;

        if (GameSettings.day)
        {
            /*if (agent.remainingDistance > agent.stoppingDistance) return;

            int[] randomDistances = new int[] { -10, 0, 10 };

            float xval = agent.transform.position.x + randomDistances[Random.Range(0, randomDistances.Length)];
            float zval = agent.transform.position.z + randomDistances[Random.Range(0, randomDistances.Length)];
            Vector3 position = new Vector3(xval, agent.transform.position.y, zval);

            agent.SetDestination(position);*/

            if (Vector3.Distance(agent.transform.position, target.transform.position) < 10)
            {
                agent.SetDestination(target.transform.position);
            }
            else
            {
                agent.SetDestination(Utils.RandomInArea(agent.transform.position, 20));
            }
        }
        else
        {
            agent.SetDestination(target.transform.position);
        }
    }
}
