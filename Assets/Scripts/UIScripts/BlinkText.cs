using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlinkText : MonoBehaviour
{
    private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        Invoke("DisableText", GameSettings.blinkTextDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void EnableText()
    {
        text.enabled = true;
        Invoke("DisableText", GameSettings.blinkTextDelay);
    }

    private void DisableText()
    {
        text.enabled = false;
        Invoke("EnableText", GameSettings.blinkTextDelay);
    }
}
