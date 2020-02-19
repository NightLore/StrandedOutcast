using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        GameSettings.canCook = true;
    }

    void OnTriggerExit(Collider other)
    {
        GameSettings.canCook = false;
    }

}
