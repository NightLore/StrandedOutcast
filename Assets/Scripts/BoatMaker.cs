using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMaker : MonoBehaviour
{
    public GameObject boat; // drag in
    public ParticleSystem buildParticle;
    public AudioClip buildSound;

    private EnvironmentSpawner spawner;
    private AudioSource audioSource;
    private Rigidbody boatRigidBody;

    private ResourceText resourceText;
    private Health boatHealth;
    private int[] ingredients;
    private bool won;
    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.Find("EnvironmentSpawner").GetComponent<EnvironmentSpawner>();
        audioSource = boat.GetComponent<AudioSource>();
        resourceText = boat.GetComponent<ResourceText>();
        boatHealth = boat.GetComponent<Health>();
        boatRigidBody = boat.GetComponent<Rigidbody>();

        ingredients = new int[GameSettings.NUMITEMTYPES];
        int total = 0;
        foreach (KeyValuePair<int, int> pair in GameSettings.itemList[GameSettings.BOAT].GetRecipe().GetIngredients())
        {
            ingredients[pair.Key] = pair.Value;
            total += pair.Value;
        }
        boatHealth.maxHp = total;
        won = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (won)
        {
            boatRigidBody.velocity = new Vector3(1, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Attack a = other.GetComponent<Attack>();
        if (a && a.IsPlayer())
        {
            TakeIngredient(a.GetOwner().GetComponent<Inventory>());
            UpdateText();
        }
    }

    private void TakeIngredient(Inventory inventory)
    {
        for (int i = ingredients.Length - 1; i >= 0; i--)
        {
            if (ingredients[i] > 0 && inventory.GetQuantity(i) > 0)
            {
                ingredients[i]--;
                inventory.DecrementQuantity(i);
                inventory.UpdateQuantities();
                buildParticle.Play();
                audioSource.PlayOneShot(buildSound, GameSettings.soundVolume);
                if (boatHealth.Heal(1))
                {
                    spawner.GameWin(boat.transform.position + Vector3.up * 2);
                    won = true;
                }
                break;
            }
        }
    }

    private void UpdateText()
    {
        string text = "";
        string padding = "";
        for (int i = ingredients.Length - 1; i >= 0; i--)
        {
            if (ingredients[i] > 0)
            {
                text += padding + ingredients[i] + " more " + GameSettings.itemList[i].GetName();
                padding = " and ";
            }
        }
        resourceText.need = text;
        resourceText.DisplayText();
    }
}
