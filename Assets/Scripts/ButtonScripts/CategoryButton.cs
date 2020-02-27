﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CategoryButton : MonoBehaviour
{
    public GameObject[] categoryButtons;
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        // categoryButtons[0] = GameObject.Find("WeaponButton");
        // categoryButtons[1] = GameObject.Find("BuildingButton");
        // categoryButtons[2] = GameObject.Find("FoodButton");
        // categoryButtons[3] = GameObject.Find("MaterialsButton");
        
        button = GetComponent<Button>();
        button.onClick.AddListener(DisplaySubButtons);
        button.onClick.AddListener(CloseOtherSubButtons);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DisplaySubButtons() {
        foreach (Transform child in transform) {
            if (child.CompareTag("Button")) {
                if (child.gameObject.activeSelf) {
                    child.gameObject.SetActive(false);
                } 
                else {
                    child.gameObject.SetActive(true);
                }
            }
        }
    }

    private void CloseOtherSubButtons() {
        foreach (GameObject button in categoryButtons) {
            foreach (Transform child in button.transform) {
                if (child.CompareTag("Button")) {
                    child.gameObject.SetActive(false);
                }
            }
        }
    }
}