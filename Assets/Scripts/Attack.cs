using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject bloodSplatter;
    public GameObject owner;
    public GameObject meat;
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
        Vector3 enemyPosition = other.GetComponent<Transform>().position;
        enemyPosition.y = 0;

        if (other.gameObject != owner && health != null)
        {
            if (health.takeDamage(damage) && owner.CompareTag("Player")) // if killed "other" and is from player
            {
                /* Spawn meat when enemies are killed, 50% chance of dropping */
                // if (Random.Range(0, 10) % 2 == 0)
                // {
                //     Instantiate(meat, enemyPosition, owner.GetComponent<Transform>().rotation);
                // }
            }
            Instantiate(bloodSplatter, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }

        if (owner.CompareTag("Player") && owner.GetComponent<Attacker>().weapon.GetMaxDurability() != int.MaxValue)
        {
            if (owner.GetComponent<Attacker>().weapon.DecrementDurability() == 0)
            {
                owner.GetComponent<Equiper>().breakWeapon(owner.GetComponent<Attacker>().weapon);
            }
        }
    }
}
