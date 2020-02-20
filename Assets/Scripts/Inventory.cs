using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    private AudioSource source;
    public AudioClip pickupSound;
    public GameObject owner;

    public int[] itemCounts;
    private TextMeshProUGUI[] quantityTexts;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        itemCounts = new int[GameSettings.NUMITEMTYPES];
        quantityTexts = new TextMeshProUGUI[GameSettings.NUMITEMTYPES];
        for (int i = 0; i < GameSettings.NUMITEMTYPES; i++)
        {
            TextMeshProUGUI objectText = GameObject.Find(GameSettings.itemTypes[i] + "QuantityText").GetComponent<TextMeshProUGUI>();
            quantityTexts[i] = objectText;
            objectText.transform.parent.gameObject.SetActive(false); //turn buttons off
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateQuantityText(int item)
    {
        quantityTexts[item].text = "" + itemCounts[item];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Item"))
        {
            if (other.gameObject.name.Contains("Stick"))
            {
                itemCounts[GameSettings.STICK]++;
                itemCounts[GameSettings.STICKimage]++;
                UpdateQuantityText(GameSettings.STICK);
                UpdateQuantityText(GameSettings.STICKimage);
                pickup(other.gameObject);
            }
            else if (other.gameObject.name.Contains("Rock"))
            {
                itemCounts[GameSettings.ROCK]++;
                itemCounts[GameSettings.ROCKimage]++;
                UpdateQuantityText(GameSettings.ROCK);
                UpdateQuantityText(GameSettings.ROCKimage);
                pickup(other.gameObject);
            }
            else if (other.gameObject.name.Contains("Raw Meat"))
            {
                itemCounts[GameSettings.RAWMEAT]++;
                UpdateQuantityText(GameSettings.RAWMEAT);
                // Hunger hunger = owner.GetComponent<Hunger>();
                // hunger.IncreaseHunger(10);
                pickup(other.gameObject);
            }
        }
    }

    private void pickup(GameObject gameObject)
    {
        Destroy(gameObject);
        source.PlayOneShot(pickupSound, GameSettings.soundVolume);
    }
}
