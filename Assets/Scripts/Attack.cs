using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
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
        Attackable attackable = other.gameObject.GetComponent<Attackable>();
        if (other.gameObject != owner && attackable != null)
        {
            attackable.takeDamage(damage);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Attackable attackable = collision.gameObject.GetComponent<Attackable>();
        if (collision.gameObject != owner && attackable != null)
        {
            attackable.takeDamage(damage);
            Destroy(gameObject);
        }
    }
}
