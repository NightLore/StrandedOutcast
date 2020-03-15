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
            if (timer > GameSettings.dayLength / 2) {
                lightIntensity = (GameSettings.dayLength - timer + GameSettings.dayLength / 2) / GameSettings.dayLength;
            }
            else {
                lightIntensity = (timer + GameSettings.dayLength / 2) / GameSettings.dayLength;
            }
        }
        else { // fix this CLAY
            if (timer > GameSettings.nightLength / 2) {
                lightIntensity = (timer - GameSettings.nightLength / 2) / GameSettings.nightLength;
            }
            else {
                lightIntensity = (GameSettings.nightLength / 2 - timer) / GameSettings.nightLength;
            }
        }
        dayLight.intensity = Mathf.Max(lightIntensity, GameSettings.nightDarkness);
    }
}
