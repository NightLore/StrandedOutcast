using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceText : MonoBehaviour
{
    private TextMeshProUGUI resourceText;
    public string need;

    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                resourceText.enabled = false;
            }
        }
        if (!resourceText)
        {
            GameObject g = GameObject.Find("ResourceText");
            if (g)
            {
                resourceText = g.GetComponent<TextMeshProUGUI>();
                resourceText.enabled = false;
            }
        }
    }

    public void DisplayText()
    {
        resourceText.text = "Need " + need;
        resourceText.enabled = true;
        timer = 3;
    }
}
