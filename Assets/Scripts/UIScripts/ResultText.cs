using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultText : MonoBehaviour
{
    public string description;
    private TextMeshProUGUI resultText;
    private EnvironmentSpawner spawner;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnEnable()
    {
        resultText = GetComponent<TextMeshProUGUI>();
        spawner = GameObject.Find("EnvironmentSpawner").GetComponent<EnvironmentSpawner>();
        resultText.text = "You killed " + spawner.GetKillCount() 
            + " creatures and " + description + " " + spawner.GetDayCount() + " days!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
