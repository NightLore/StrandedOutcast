using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BonfireController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NightEnemy")) {
            NavMeshAgent agent = other.gameObject.GetComponent<NavMeshAgent>();
            agent.speed /= 2;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("NightEnemy")) {
            NavMeshAgent agent = other.gameObject.GetComponent<NavMeshAgent>();
            agent.speed *= 2;
        }
    }

}
