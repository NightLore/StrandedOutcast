using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Attacker))]
[RequireComponent(typeof(Inventory))]
public class Equiper : MonoBehaviour
{
    private Attacker attacker;
    private Inventory inventory;

    public GameObject[] weapons;
    public Sprite[] weaponImages;
    public Sprite defaultImage;
    private int currentWeapon = GameSettings.FISTS;
    private TextMeshProUGUI currentWeaponText;
    private Image equipImage;

    // Start is called before the first frame update
    void Start()
    {
        attacker = GetComponent<Attacker>();
        inventory = GetComponent<Inventory>();
        currentWeaponText = GameObject.Find("EquipText").GetComponent<TextMeshProUGUI>();
        equipImage = GameObject.Find("EquipButton").GetComponent<Image>();
        Equip(currentWeapon);
    }

    public void Equip(int weapon)
    {
        // if attacking, don't equip
        if (!attacker.CanAttack)
            return;
        if (weapon < 0) // if default weapon
        {
            currentWeaponText.text = "Fists";
            attacker.SetStats(GameSettings.defaultDamage, 
                              GameSettings.defaultAttackSize, 
                              GameSettings.defaultAttackSpeed);
            equipImage.sprite = defaultImage;
        }
        else
        {
            // don't equip weapons that you don't have and can't craft
            if (inventory.itemCounts[weapon] <= 0 && !CraftWeapon(weapon))
                return;
            currentWeaponText.text = GameSettings.itemTypes[weapon];
            attacker.SetStats(GameSettings.weaponDamages[weapon],
                              GameSettings.weaponSizes[weapon],
                              GameSettings.weaponSpeeds[weapon]);
            weapons[weapon].SetActive(true);
            equipImage.sprite = weaponImages[weapon];
        }
        if (currentWeapon >= 0) // deactivate old weapon
            weapons[currentWeapon].SetActive(false);
        currentWeapon = weapon; // update currentWeapon to new weapon
    }

    // Attempt to craft weapon. Return true if successful.
    private bool CraftWeapon(int weapon)
    {
        int[] recipe = GameSettings.weaponParts[weapon];
        if (inventory.itemCounts[GameSettings.STICK] >= recipe[GameSettings.STICK] 
         && inventory.itemCounts[GameSettings.ROCK] >= recipe[GameSettings.ROCK])
        {
            inventory.itemCounts[weapon]++;
            inventory.UpdateQuantityText(weapon);
            inventory.itemCounts[GameSettings.STICK] -= recipe[GameSettings.STICK];
            inventory.UpdateQuantityText(GameSettings.STICK);
            inventory.itemCounts[GameSettings.ROCK] -= recipe[GameSettings.ROCK];
            inventory.UpdateQuantityText(GameSettings.ROCK);
            return true;
        }
        return false;
    }
}
