using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    private Light dayLight;
    // Start is called before the first frame update
    void Start()
    {
        dayLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameSettings.day) {
            dayLight.intensity = 1;
        }
        else {
            dayLight.intensity = 0;
        }
    }
}
