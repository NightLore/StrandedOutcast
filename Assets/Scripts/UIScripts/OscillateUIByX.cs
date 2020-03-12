using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillateUIByX : MonoBehaviour
{
    private RectTransform rectTransform;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startPos = rectTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.position = startPos 
            + Vector3.left * GameSettings.oscillationDistance * Mathf.Sin(Time.time * GameSettings.oscillationSpeed);
    }
}
