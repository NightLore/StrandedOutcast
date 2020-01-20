using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentSpawner : MonoBehaviour
{
    public float bounds = 50.0f;
    private int decorAmount = 200;
    private int waterAmount = 50;

    public int itemsMax = 10;
    public int passiveMax = 20;
    public int aggroMax = 10;
    public GameObject[] itemsPrefabs;
    public GameObject[] decorPrefabs;
    public GameObject[] passivePrefabs;
    public GameObject[] aggroPrefabs;
    public GameObject water;
     
    public GameObject passiveCreatures;
    public GameObject aggroCreatures;
    public GameObject environment;
    public GameObject items;

    public float minDelay = 2f;
    public float maxDelay = 10f;
    // Start is called before the first frame update
    void Start()
    {
        SpawnWaterAtBounds(water, bounds, waterAmount);
        SpawnDecoration(decorAmount);
        Invoke("SpawnRandomItems", RandomDelay());
        Invoke("SpawnAggro", RandomDelay());
        Invoke("SpawnPassive", RandomDelay());

    }

    // Update is called once per frame
    void Update()
    {

    }

    float RandomDelay()
    {
        return Random.Range(minDelay, maxDelay);
    }

    void SpawnWaterAtBounds(GameObject water, float bounds, int amount)
    {
        float increment = 2 * Mathf.PI / amount;
        for (int i = 0; i < amount; i++)
        {
            float theta = i * increment;
            float x = bounds * Mathf.Cos(theta);
            float y = water.transform.position.y;
            float z = bounds * Mathf.Sin(theta);

            GameObject w = Instantiate(water, new Vector3(x, y, z), Quaternion.Euler(-Vector3.up * (theta - Mathf.PI / 2) * 180 / Mathf.PI));
            w.transform.SetParent(environment.transform);
        }
    }

    void SpawnDecoration(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            SpawnInBounds(decorPrefabs, bounds).transform.SetParent(environment.transform);
        }
    }

    void SpawnRandomItems()
    {
        SpawnInBounds(itemsPrefabs, bounds).transform.SetParent(items.transform);
        Invoke("SpawnRandomItems", RandomDelay());
    }

    GameObject SpawnInBounds(GameObject[] objects, float bounds)
    {
        int index = Random.Range(0, objects.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-bounds, bounds), objects[index].transform.position.y, Random.Range(-bounds, bounds));

        return Instantiate(objects[index], spawnPos, Quaternion.Euler(Vector3.up * Random.Range(0, 360)));
    }

    void SpawnAggro()
    {
        SpawnCreature(aggroPrefabs, aggroCreatures, aggroMax, bounds);
        Invoke("SpawnAggro", RandomDelay());
    }

    void SpawnPassive()
    {
        SpawnCreature(passivePrefabs, passiveCreatures, passiveMax, bounds);
        Invoke("SpawnPassive", RandomDelay());

    }

    void SpawnCreature(GameObject[] objects, GameObject storage, int max, float bounds)
    {
        if (storage.GetComponentsInChildren<Transform>().Length < max)
        {
            SpawnOffScreen(objects[Random.Range(0, objects.Length)], bounds).transform.SetParent(storage.transform, true);
        }
    }

    GameObject SpawnOffScreen(GameObject obj, float bounds)
    {
        float x = 0;
        float z = 0;
        switch(Random.Range(0, 4)) // random side of the screen to spawn off from
        {
            case 0: // left
                x = -0.1f;
                z = Random.value;
                break;
            case 1: // top
                x = Random.value;
                z = -0.1f;
                break;
            case 2: // right
                x = 1.1f;
                z = Random.value;
                break;
            case 3: // bottom
                x = Random.value;
                z = 1.1f;
                break;
        }
        Vector3 position = Camera.main.ViewportToWorldPoint(new Vector3(x, z, Camera.main.transform.position.y));
        position.y = obj.transform.position.y;

        return Instantiate(obj, position, obj.transform.rotation);
    }
}
