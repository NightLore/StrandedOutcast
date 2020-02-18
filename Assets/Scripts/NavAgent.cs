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
        if (agent.pathPending) return;
        agent.SetDestination(target.transform.position);
    }
}
