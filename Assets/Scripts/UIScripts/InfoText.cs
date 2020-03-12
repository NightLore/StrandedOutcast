using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoText : MonoBehaviour
{
    public string info;
    private TextMeshProUGUI recipeText;
    // Start is called before the first frame update
    void Start()
    {
        recipeText = GameObject.Find("/Canvas/GameScreen/InfoPanel/RecipeText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateInfo()
    {
        recipeText.text = info;
    }
}
