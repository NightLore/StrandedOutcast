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

    public void Die(GameObject replacement)
    {
        Instantiate(replacement, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }

    public bool IsPlayer()
    {
        return isPlayer;
    }

    public GameObject GetOwner()
    {
        return owner;
    }

    public int GetDamage()
    {
        return damage;
    }

}
