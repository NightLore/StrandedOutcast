using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Attacker))]
[RequireComponent(typeof(Inventory))]
public class Equiper : MonoBehaviour
{
    /*
     * variables for scripts, references assigned in start()
     */
    private Attacker attacker;
    private Inventory inventory;


    public GameObject[] weapons;
    public Sprite[] weaponImages;
    public Sprite defaultImage;
    public ParticleSystem weaponExplosion;

    /*
     * references to scripts
     */
    private Weapon currentWeapon = GameSettings.weapons[0];

    /*
     * Objects with references assigned in start()
     */
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

    /* Equip
     * 
     * Equips a weapon in the players hand, sets proper attack: damage,speed, size
     *      -will not equip if in middle of an attack
     *      -will not equip if weapon is not craftable
     *      -crafts weapon when selected and possible to craft
     * 
     * References:
     *      Scripts:    
     *          attacker
     *          GameSettings
     *          Inventory
     *          
     *      GameOjects: 
     *          currentWeaponText
     *          equipImage
     */
    public void Equip(Weapon weapon, bool force = false)
    {
        // if attacking, don't equip -- current purpose is to avoid hacking the attack speed
        if (!attacker.CanAttack && !force)
            return;

        // don't equip non-default weapons that you don't have and can't craft
        if (weapon != GameSettings.weapons[0] && inventory.GetQuantity(weapon.GetID()) <= 0 && !CraftWeapon(weapon))
            return;
        currentWeaponText.text = weapon.GetName();
        attacker.SetStats(weapon.GetDamage(),
                            weapon.GetSize(),
                            weapon.GetSpeed(),
                            weapon);
        // update visual
        if (weapon == GameSettings.weapons[0])
        {
            equipImage.sprite = defaultImage;
        }
        else
        {
            weapons[weapon.GetID()].SetActive(true);
            equipImage.sprite = weaponImages[weapon.GetID()];
        }

        // deactivate old weapon if not default weapon
        if (currentWeapon != GameSettings.weapons[0])
            weapons[currentWeapon.GetID()].SetActive(false);

        // update currentWeapon to new weapon
        currentWeapon = weapon;
    }

    /* CraftWeapon
     * 
     * Attempt to craft weapon. Return true if successful.
     *      -Checks current inventory counts against saved 'recipe' counts
     *      -If current inventory is enough item is crafted:
     *          -counts in inventory is reduced by 'recipe' counts
     *      -UI is updated for inventory quantity
     *      
     * References:
     *      Scripts:
     *          GameSettings
     *          inventory
     * 
     */
    private bool CraftWeapon(Weapon weapon)
    {
        Debug.Log(inventory);
        Recipe recipe = weapon.GetRecipe();
        if (inventory.CheckRecipe(recipe))
        {
            // TODO: combine these lines into the same function
            inventory.IncrementQuantity(weapon.GetID());
            inventory.CraftRecipe(recipe);
            inventory.UpdateQuantities();
            Debug.Log("Successfully Crafted Weapon");
            return true;
        }
        Debug.Log("Failed to Craft Weapon");
        return false;
    }

    public void breakWeapon(Weapon weapon)
    {
        currentWeapon.SetDurability(weapon.GetMaxDurability());
        inventory.DecrementQuantity(weapon.GetID());
        inventory.UpdateQuantities();
        Equip(GameSettings.weapons[0], true);
        //weaponExplosion.Play(); TO-DO: Fix particle effect
    }
}
