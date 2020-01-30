using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipButton : MonoBehaviour
{
    public int equipment;

    private Button button;
    private Equiper equiper;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Equip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        equiper = GameObject.FindWithTag("Player").GetComponent<Equiper>();
    }

    private void Equip()
    {
        equiper.Equip(equipment);
    }
}
