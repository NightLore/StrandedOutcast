using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Must drag and drop in all quantity Texts -- trouble finding them when deactivated
    public QuantityText[] quantityTexts;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateQuantityTexts()
    {
        foreach (QuantityText text in quantityTexts)
        {
            text.UpdateQuantityText();
        }
    }
}
