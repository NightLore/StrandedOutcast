using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayer : MonoBehaviour
{
    public float speed = 10.0f;
    public float bufferDistance = 2.5f;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        Vector3 direction = Vector3.Normalize(player.transform.position - transform.position);
        Vector3 target = player.transform.position - direction * bufferDistance;
        target.y = transform.position.y;

        transform.position = Vector3.MoveTowards(transform.position, target, step);
        transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, direction, step, 0.0f));
    }
}
