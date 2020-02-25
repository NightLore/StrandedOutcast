using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoButton : MonoBehaviour
{
    private GameObject infoPanel;
    // Start is called before the first frame update
    void Start()
    {
        infoPanel = GameObject.Find("/Canvas/GameScreen/InfoPanel");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerEnter()
    {
        infoPanel.SetActive(true);
    }

    public void OnPointerExit()
    {
        infoPanel.SetActive(false);
    }
}
