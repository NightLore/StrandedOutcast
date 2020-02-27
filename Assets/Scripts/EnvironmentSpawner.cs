using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class EnvironmentSpawner : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject gameScreen;
    public GameObject gameOverScreen;
    public GameObject creditsScreen;

    public GameObject titleObjects;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI timeText;

    public TextMeshProUGUI resultText;

    public GameObject[] itemsPrefabs;
    public GameObject[] passivePrefabs;
    public GameObject[] aggroPrefabs;

    public GameObject playerCharacter;
    public GameObject passiveCreatures;
    public GameObject aggroCreatures;
    public GameObject environment;
    public GameObject items;
    public GameObject campfire;

    private GameObject player;
    private GameObject playerReference;
    private bool inGame = false;
    public int killCount;
    private int waveNumber;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        playerReference = GameObject.Find("PlayerReference");
    }

    // Update is called once per frame
    void Update()
    {
        if (inGame)
        {
            timer -= Time.deltaTime;
            if (GameSettings.day) {
                timeText.text = "Time left in day: " + Mathf.Round(timer);
            }
            else {
                timeText.text = "Time left in night: " + Mathf.Round(timer);
            }
            if (timer <= 0)
            {
                GameSettings.day = !GameSettings.day;

                // delete enemies at the end of each round
                foreach (Transform t in aggroCreatures.transform)
                {
                    Destroy(t.gameObject);
                }

                SpawnWave();
                timer = GameSettings.waveDelay;
            }
            if (!player)
            {
                GameOver();
            }
        }
    }

    // -------------------------- Screen Management ------------------------- //

    public void StartGame()
    {
        inGame = true;
        killCount = 0;
        waveNumber = -1;
        GameSettings.day = true;
        timer = GameSettings.waveDelay;
        player = SetParent(Instantiate(playerCharacter), playerReference);
        Instantiate(campfire);
        StartCoroutine(SpawnRandomItems());
        StartCoroutine(SpawnPassive());
        SpawnWave();

        titleScreen.SetActive(false);
        titleObjects.SetActive(false);
        gameScreen.SetActive(true);
    }

    public void GameOver()
    {
        gameScreen.SetActive(false);
        gameOverScreen.SetActive(true);

        inGame = false;
        resultText.text = "You killed " + (killCount-1) + " creatures and survived " + waveNumber + " waves!";
    }

    public void Credits()
    {
        titleScreen.SetActive(false);
        titleObjects.SetActive(false);
        creditsScreen.SetActive(true);
    }

    public void MainMenu()
    {
        creditsScreen.SetActive(false);
        titleScreen.SetActive(true);
        titleObjects.SetActive(true);
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // -------------------------- Utilities ------------------------- //

    float RandomDelay()
    {
        return Random.Range(GameSettings.minSpawnDelay, GameSettings.maxSpawnDelay);
    }

    GameObject RandomPrefab(GameObject[] prefabs)
    {
        return prefabs[Random.Range(0, prefabs.Length)];
    }

    Vector3 RandomInArea(Vector3 center, float maxDistance)
    {
        return center + Random.insideUnitSphere * maxDistance;
    }

    float RandomDirection()
    {
        return Random.Range(0, 360);
    }

    GameObject SetParent(GameObject child, GameObject parent)
    {
        child.transform.SetParent(parent.transform);
        return child;
    }

    Vector3 GetGroundPoint(Vector3 position)
    {
        position.y = 100;
        // Note: only works if ground is within +/-100 of starting spot
        if (Physics.Raycast(position, Vector3.down, out RaycastHit hit, 200.0f))
        {
            return hit.point;
        }
        else
        {
            Debug.Log("No ground detected at this position: " + position);
            return position;
        }
    }

    // -------------------------- Spawning ------------------------- //

    IEnumerator SpawnRandomItems()
    {
        while (inGame)
        {
            yield return new WaitForSeconds(RandomDelay());
            if (items.GetComponentsInChildren<Transform>().Length < GameSettings.maxItems)
            {
                SetParent(SpawnAroundLocation(itemsPrefabs[0], GameSettings.stickSpawnCenter, GameSettings.stickSpawnRadius), items);
                SetParent(SpawnAroundLocation(itemsPrefabs[0], GameSettings.stickSpawnCenter, GameSettings.stickSpawnRadius), items);
                SetParent(SpawnAroundLocation(itemsPrefabs[1], GameSettings.rockSpawnCenter, GameSettings.rockSpawnRadius), items);
                SetParent(SpawnAroundLocation(itemsPrefabs[2], GameSettings.rockSpawnCenter, GameSettings.rockSpawnRadius), items);

                SetParent(SpawnAroundLocation(itemsPrefabs[0], new Vector3(), GameSettings.maxSpawnRadius), items);
                SetParent(SpawnAroundLocation(itemsPrefabs[0], new Vector3(), GameSettings.maxSpawnRadius), items);
                SetParent(SpawnAroundLocation(itemsPrefabs[1], new Vector3(), GameSettings.maxSpawnRadius), items);
                SetParent(SpawnAroundLocation(itemsPrefabs[2], new Vector3(), GameSettings.maxSpawnRadius), items);
            }
        }
    }

    IEnumerator SpawnPassive()
    {
        while (inGame)
        {
            yield return new WaitForSeconds(RandomDelay());
            if (passiveCreatures.GetComponentsInChildren<Transform>().Length < GameSettings.maxPassiveCreatures)
            {
                SpawnCreature(RandomPrefab(passivePrefabs), passiveCreatures, GameSettings.maxSpawnRadius);
            }
        }
    }

    private void SpawnWave()
    {
        waveNumber++;
        waveText.text = "Wave: " + waveNumber;
        SpawnCreatures(aggroPrefabs[0], aggroCreatures, GameSettings.maxSpawnRadius, waveNumber % 5);
        SpawnCreatures(aggroPrefabs[1], aggroCreatures, GameSettings.maxSpawnRadius, waveNumber / 5);
        SpawnCreatures(aggroPrefabs[2], aggroCreatures, GameSettings.maxSpawnRadius, waveNumber);
    }

    void SpawnCreatures(GameObject prefab, GameObject parent, float bounds, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            SpawnCreature(prefab, parent, bounds);
        }
    }

    void SpawnCreature(GameObject prefab, GameObject parent, float bounds)
    {
        SetParent(SpawnAroundLocation(prefab, new Vector3(), bounds), parent);
        //InstantiateOffScreen(prefabs, bounds).transform.SetParent(storage.transform, true);
    }

    GameObject SpawnAroundLocation(GameObject prefab, Vector3 center, float maxDistance)
    {
        Vector3 spawnPos = GetGroundPoint(RandomInArea(center, maxDistance));
        spawnPos.y += prefab.transform.position.y; // set Offset from ground
        return Instantiate(prefab, spawnPos, Quaternion.Euler(Vector3.up * RandomDirection()));
    }

    //GameObject InstantiateOffScreen(GameObject prefab, float bounds)
    //{
    //    float x = 0;
    //    float z = 0;
    //    switch(Random.Range(0, 4)) // random side of the screen to spawn off from
    //    {
    //        case 0: // left
    //            x = -0.1f;
    //            z = Random.value;
    //            break;
    //        case 1: // top
    //            x = Random.value;
    //            z = -0.1f;
    //            break;
    //        case 2: // right
    //            x = 1.1f;
    //            z = Random.value;
    //            break;
    //        case 3: // bottom
    //            x = Random.value;
    //            z = 1.1f;
    //            break;
    //    }
    //    Vector3 position = Camera.main.ViewportToWorldPoint(new Vector3(x, z, Camera.main.transform.position.y));
    //    position.y = prefab.transform.position.y;

    //    return Instantiate(prefab, position, Quaternion.Euler(Vector3.up * Random.Range(0, 360)));
    //}
}
