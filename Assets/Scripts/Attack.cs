using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject bloodSplatter;
    public GameObject owner;
    public int damage;
    public static float lifeSpan = 0.2f;

    private float time;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > lifeSpan)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Health health = other.gameObject.GetComponent<Health>();
        if (other.gameObject != owner && health != null)
        {
            if (health.takeDamage(damage) && owner.CompareTag("Player")) // if killed "other" and is from player
            {
                Hunger hunger = owner.GetComponent<Hunger>();
                hunger.IncreaseHunger(10);
            }
            Instantiate(bloodSplatter, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }
}
