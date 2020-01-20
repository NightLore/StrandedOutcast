using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayer : MonoBehaviour
{
    public float speed = 10.0f;
    private float bufferDistance = 2.0f;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = player.transform.position - Vector3.Normalize(player.transform.position - transform.position) * bufferDistance;

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.x, transform.position.y, target.z), speed * Time.deltaTime);
    }
}
