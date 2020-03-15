using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    private AudioSource source;
    public AudioClip pickupSound;
    private int[] itemCounts;
    private bool[] hasNeeds;

    private UIManager manager;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        itemCounts = new int[GameSettings.itemList.Length];
        hasNeeds = new bool[GameSettings.itemList.Length];
        manager = GameObject.Find("GameScreen").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            Pickup(other.gameObject);
        }
    }

    private void Pickup(GameObject obj)
    {
        for (int i = 0; i < GameSettings.itemList.Length; i++)
        {
            if (obj.name.Contains(GameSettings.itemList[i].GetName()))
            {
                itemCounts[i]++;
                break;
            }
        }
        Destroy(obj);
        source.PlayOneShot(pickupSound, GameSettings.soundVolume);
        UpdateQuantities();
    }

    public bool CanCraft(int index)
    {
        return CheckRecipe(GameSettings.itemList[index].GetRecipe());
    }

    public bool CheckRecipe(Recipe recipe)
    {
        foreach (KeyValuePair<int, int> pair in recipe.GetIngredients())
        {
            if (pair.Value > itemCounts[pair.Key])
                return false;
        }
        foreach (KeyValuePair<int, bool> pair in recipe.GetNeeds())
        {
            if (pair.Value && !hasNeeds[pair.Key])
                return false;
        }
        return true;
    }

    public void CraftItem(int index)
    {
        Item item = GameSettings.itemList[index];
        IncrementQuantity(index);
        foreach (KeyValuePair<int, int> pair in item.GetRecipe().GetIngredients())
        {
            itemCounts[pair.Key] -= pair.Value;
        }
    }

    // ------------------ Accesesors ------------------ //

    public void UpdateQuantities()
    {
        manager.UpdateQuantityTexts();
    }

    public void IncrementQuantity(int item)
    {
        AddQuantity(item, 1);
    }

    public void SubtractQuantity(int item, int amount)
    {
        AddQuantity(item, -amount);
    }

    public void DecrementQuantity(int item)
    {
        AddQuantity(item, -1);
    }

    public void AddQuantity(int item, int amount)
    {
        itemCounts[item] += amount;
    }

    public int GetQuantity(int item)
    {
        return itemCounts[item];
    }

    public void SetNeed(int index, bool has)
    {
        hasNeeds[index] = has;
    }
}
