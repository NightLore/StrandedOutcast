using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Hunger))]
public class PlayerDisplay : MonoBehaviour
{
    private Health health;
    private Hunger hunger;

    private RectTransform healthBar;
    private RectTransform hungerBar;

    private Vector2 barSizes;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
        hunger = GetComponent<Hunger>();

        healthBar = GameObject.Find("FullHealthBar").GetComponent<RectTransform>();
        hungerBar = GameObject.Find("FullHungerBar").GetComponent<RectTransform>();

        barSizes = healthBar.sizeDelta; // assumes that healthBar and hungerbar are the same size
    }

    void Update()
    {

    }

    void OnGUI()
    {
        // update bar sizes based on corresponding stat
        healthBar.sizeDelta = new Vector2(barSizes.x, barSizes.y * health.GetHP() / health.maxHp);
        hungerBar.sizeDelta = new Vector2(barSizes.x, barSizes.y * hunger.GetHunger() / hunger.GetMaxHunger());
    }
}
