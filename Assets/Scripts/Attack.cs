using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject bloodSplatter;

    private GameObject owner;
    private int damage;
    private float time;
    private bool isPlayer;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Init(GameObject obj, int d, Vector3 scale)
    {
        owner = obj;
        damage = d;
        gameObject.transform.localScale = scale;
        isPlayer = owner.CompareTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > GameSettings.attackLifeSpan)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Health health = other.GetComponent<Health>();
        if (other.gameObject != owner && health)
        {
            health.TakeDamage(damage);
            Instantiate(bloodSplatter, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);

            if (isPlayer)
            {
                Weapon w = owner.GetComponent<Attacker>().GetWeapon();
                if (w.GetMaxDurability() != int.MaxValue && w.DecrementDurability() == 0)
                {
                    owner.GetComponent<Equiper>().breakWeapon(w);
                }
            }
        }
    }

    public bool IsPlayer()
    {
        return isPlayer;
    }

    public GameObject GetOwner()
    {
        return owner;
    }

}
