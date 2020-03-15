using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PassiveNavAgent : MonoBehaviour
{
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != agent.destination || agent.pathPending) return;
        agent.SetDestination(Utils.RandomInArea(agent.transform.position, 5));
    }
}
