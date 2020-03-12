using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Hunger))]
public class PlayerDisplay : MonoBehaviour
{
    private Health health;
    private Hunger hunger;
    private Weapon weapon;

    private RectTransform healthBar;
    private RectTransform hungerBar;
    private RectTransform durabilityBar;

    private Vector2 barSizes;
    private Vector2 durabilityBarSize;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
        hunger = GetComponent<Hunger>();
        
        healthBar = GameObject.Find("FullHealthBar").GetComponent<RectTransform>();
        hungerBar = GameObject.Find("FullHungerBar").GetComponent<RectTransform>();
        durabilityBar = GameObject.Find("FullDurabilityBar").GetComponent<RectTransform>();

        barSizes = healthBar.sizeDelta; // assumes that healthBar and hungerbar are the same size
        durabilityBarSize = durabilityBar.sizeDelta;
    }

    void Update()
    {

    }

    void OnGUI()
    {
        weapon = GetComponent<Equiper>().GetCurrentWeapon();
        // update bar sizes based on corresponding stat
        healthBar.sizeDelta = new Vector2(barSizes.x * health.GetHP() / health.maxHp, barSizes.y);
        hungerBar.sizeDelta = new Vector2(barSizes.x * hunger.GetHunger() / hunger.GetMaxHunger(), barSizes.y);
        durabilityBar.sizeDelta
            = new Vector2(durabilityBarSize.x * weapon.GetDurability() / weapon.GetMaxDurability(), durabilityBarSize.y);
    }
}
