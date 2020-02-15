using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BonfireFlicker : MonoBehaviour
{
    private Light campfireLight;
    private float lightIntensity;
    // Start is called before the first frame update
    void Start()
    {
        campfireLight = GetComponent<Light>();
        lightIntensity = 1.0f;
        Invoke("Flicker", 0.0f);
    }

    void Flicker() {
        float newIntensity = lightIntensity + UnityEngine.Random.Range(GameSettings.minDeltaFlicker, GameSettings.maxDeltaFlicker);
        lightIntensity = Math.Max(GameSettings.minFlicker, newIntensity);
        lightIntensity = Math.Min(GameSettings.maxFlicker, newIntensity);
        campfireLight.intensity = lightIntensity;
        Invoke("Flicker", GameSettings.flickerSpeed);
    }

    IEnumerator WaitForSeconds(float seconds) {
        yield return new WaitForSeconds(seconds);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
