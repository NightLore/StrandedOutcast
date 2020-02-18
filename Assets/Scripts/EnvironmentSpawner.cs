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
    public GameObject[] decorPrefabs;
    public GameObject[] passivePrefabs;
    public GameObject[] aggroPrefabs;
    public GameObject water;

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
                SpawnWave();
            }
            if (!player)
            {
                GameOver();
            }
        }
    }

    // -------------------------- Screens ------------------------- //

    public void StartGame()
    {
        inGame = true;
        killCount = 0;
        waveNumber = -1;
        player = Instantiate(playerCharacter);
        Instantiate(campfire);
        player.transform.SetParent(playerReference.transform);
        //SpawnWaterAtBounds(water, GameSettings.bounds, GameSettings.waterAmount);
        //SpawnDecoration(GameSettings.decorAmount, GameSettings.bounds / 2);
        StartCoroutine(SpawnRandomItems(GameSettings.bounds / 2));
        StartCoroutine(SpawnPassive(GameSettings.bounds / 2));
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

    // -------------------------- Spawning ------------------------- //

    float RandomDelay()
    {
        return Random.Range(GameSettings.minSpawnDelay, GameSettings.maxSpawnDelay);
    }

    GameObject RandomPrefab(GameObject[] prefabs)
    {
        return prefabs[Random.Range(0, prefabs.Length)];
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

    void SpawnDecoration(int amount, float bounds)
    {
        for (int i = 0; i < amount; i++)
        {
            SpawnInBounds(RandomPrefab(decorPrefabs), bounds).transform.SetParent(environment.transform);
        }
    }

    IEnumerator SpawnRandomItems(float bounds)
    {
        while (inGame)
        {
            yield return new WaitForSeconds(RandomDelay());
            if (items.GetComponentsInChildren<Transform>().Length < GameSettings.maxItems)
            {
                SpawnInBounds(itemsPrefabs[0], bounds).transform.SetParent(items.transform);
                SpawnInBounds(itemsPrefabs[0], bounds).transform.SetParent(items.transform);
                SpawnInBounds(itemsPrefabs[1], bounds).transform.SetParent(items.transform);
                SpawnInBounds(itemsPrefabs[2], bounds).transform.SetParent(items.transform);
            }
        }
    }

    IEnumerator SpawnPassive(float bounds)
    {
        while (inGame)
        {
            yield return new WaitForSeconds(RandomDelay());
            if (passiveCreatures.GetComponentsInChildren<Transform>().Length < GameSettings.maxPassiveCreatures)
            {
                SpawnCreature(RandomPrefab(passivePrefabs), passiveCreatures, bounds);
            }
        }
    }

    private void SpawnWave()
    {
        waveNumber++;
        waveText.text = "Wave: " + waveNumber;
        timer = GameSettings.waveDelay;
        // if (GameSettings.day) {
        //     timeText.text = "Time left in day: " + Mathf.Round(timer);
        // }
        // else {
        //     timeText.text = "Time left in night: " + Mathf.Round(timer);
        // }
        SpawnCreatures(aggroPrefabs[0], aggroCreatures, GameSettings.bounds / 2, waveNumber % 5);
        SpawnCreatures(aggroPrefabs[1], aggroCreatures, GameSettings.bounds / 2, waveNumber / 5);
    }

    GameObject SpawnInBounds(GameObject prefab, float bounds)
    {
        Vector3 spawnPos = new Vector3(Random.Range(-bounds, bounds), prefab.transform.position.y, Random.Range(-bounds, bounds));
        return Instantiate(prefab, spawnPos, Quaternion.Euler(Vector3.up * Random.Range(0, 360)));
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
        SpawnInBounds(prefab, bounds).transform.SetParent(parent.transform, true);
        //InstantiateOffScreen(prefabs, bounds).transform.SetParent(storage.transform, true);
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
