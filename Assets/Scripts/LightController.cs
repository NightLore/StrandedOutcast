using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    private EnvironmentSpawner spawner;
    private Light dayLight;
    private float lightIntensity;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        dayLight = GetComponent<Light>();
        lightIntensity = 1;
        spawner = GameObject.Find("EnvironmentSpawner").GetComponent<EnvironmentSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        timer = spawner.GetTime();
        if (GameSettings.day) {
            if (timer > GameSettings.waveDelay / 2) {
                lightIntensity = (GameSettings.waveDelay - timer + GameSettings.waveDelay / 2) / GameSettings.waveDelay;
            }
            else {
                lightIntensity = (timer + GameSettings.waveDelay / 2) / GameSettings.waveDelay;
            }
        }
        else { // fix this CLAY
            if (timer > GameSettings.waveDelay / 2) {
                lightIntensity = (timer - GameSettings.waveDelay / 2) / GameSettings.waveDelay;
            }
            else {
                lightIntensity = (GameSettings.waveDelay / 2 - timer) / GameSettings.waveDelay;
            }
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
