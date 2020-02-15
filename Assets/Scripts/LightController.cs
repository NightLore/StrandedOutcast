using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    private Light dayLight;
    private float lightIntensity;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        dayLight = GetComponent<Light>();
        lightIntensity = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timer = GameObject.Find("EnvironmentSpawner").GetComponent<EnvironmentSpawner>().timer;
        if (GameSettings.day) {
            lightIntensity = timer / GameSettings.waveDelay;
        }
        else {
            lightIntensity = (GameSettings.waveDelay - timer) / GameSettings.waveDelay;
        }
        dayLight.intensity = lightIntensity;
        // if (GameSettings.day) {

        //     dayLight.intensity = 1;
        // }
        // else {
        //     dayLight.intensity = 0;
        // }
    }
}
