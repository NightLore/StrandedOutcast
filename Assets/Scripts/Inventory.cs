using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    private AudioSource source;
    public AudioClip pickupSound;
    private int[] itemCounts;

    private UIManager manager;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        itemCounts = new int[GameSettings.NUMITEMTYPES];
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
            pickup(other.gameObject);
        }
    }

    private void pickup(GameObject gameObject)
    {
        if (gameObject.name.Contains("Stick"))
        {
            itemCounts[GameSettings.STICK]++;
        }
        else if (gameObject.name.Contains("Rock"))
        {
            itemCounts[GameSettings.ROCK]++;
        }
        else if (gameObject.name.Contains("RawMeat"))
        {
            itemCounts[GameSettings.RAWMEAT]++;
        }
        else if (gameObject.name.Contains("CookedMeat"))
        {
            itemCounts[GameSettings.COOKEDMEAT]++;
        }
        Destroy(gameObject);
        source.PlayOneShot(pickupSound, GameSettings.soundVolume);
        UpdateQuantities();
    }

    public bool CheckRecipe(Recipe recipe)
    {
        Dictionary<int, int> ingredients = recipe.GetIngredients();
        foreach (KeyValuePair<int, int> pair in ingredients)
        {
            if (pair.Value > itemCounts[pair.Key])
                return false;
        }
        return true;
    }

    public void CraftRecipe(Recipe recipe)
    {
        Dictionary<int, int> ingredients = recipe.GetIngredients();
        foreach (KeyValuePair<int, int> pair in ingredients)
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
        if (item == GameSettings.SWORD) {
            Debug.Log("sword: " + itemCounts[item]);
        }
        else if (item == GameSettings.STONEAXE) {
            Debug.Log("stoneaxe: " + itemCounts[item]);
        }
        if (item > 1) {
           // Debug.Log(item + ": " + itemCounts[item]);
        }
        
        
        return itemCounts[item];
    }
}
