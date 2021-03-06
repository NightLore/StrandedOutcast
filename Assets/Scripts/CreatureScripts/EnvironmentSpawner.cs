﻿using System.Collections;
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
    public GameObject gameWinScreen;

    public GameObject titleObjects;
    public TextMeshProUGUI dayText;
    public TextMeshProUGUI timeText;
    public BoldBlinkText timeWarning;

    public GameObject[] itemsPrefabs;
    public GameObject[] passivePrefabs;
    public GameObject[] aggroPrefabs;

    public GameObject playerPrefab;
    public GameObject passiveCreatures;
    public GameObject aggroCreatures;
    public GameObject items;
    public GameObject boat;
    public GameObject plane;

    private GameObject player;
    private GameObject playerReference;
    private Cheats cheats;
    private bool inGame = false;
    private int killCount;
    private int dayCount;
    private float timer;

    public ParticleSystem Poof;

    // Start is called before the first frame update
    void Start()
    {
        playerReference = GameObject.Find("PlayerReference");
        cheats = GetComponent<Cheats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inGame)
        {
            timer -= Time.deltaTime;
            UpdateTimerText();
            if (timer <= 0)
            {
                GameSettings.day = !GameSettings.day;

                // delete enemies at the end of each round
                DespawnCreatures(aggroCreatures);

                if (GameSettings.day)
                {
                    IncrementDayCount();
                    timer = GameSettings.dayLength;
                }
                else {
                    timer = GameSettings.nightLength;
                }
                SpawnWave();
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
        titleScreen.SetActive(false);
        titleObjects.SetActive(false);

        inGame = true;
        killCount = 0;
        SetDayCount(0);
        GameSettings.day = true;
        timer = GameSettings.dayLength;
        player = Utils.SetParent(SpawnAroundLocation(playerPrefab, plane.transform.position - Vector3.right * 5, 0), playerReference);

        gameScreen.SetActive(true);

        cheats.Initialize(player);
        SpawnAroundLocation(passivePrefabs[1], player.transform.position - Vector3.right * 5, 0);
        StartCoroutine(SpawnRandomItems());
        StartCoroutine(SpawnPassive());
        SpawnWave();
    }
    
    public void GameWin(Vector3 location)
    {
        gameScreen.SetActive(false);
        gameWinScreen.SetActive(true);
        player.transform.position = location;

        // this is really crappy. Maybe I should make a new scene instead?
        boat.transform.position = new Vector3(boat.transform.position.x + 4, boat.transform.position.y, boat.transform.position.z);
        boat.transform.Rotate(0.0f, -90.0f, 0.0f, Space.World);

        inGame = false;
    }

    public void GameOver()
    {
        gameScreen.SetActive(false);
        gameOverScreen.SetActive(true);

        inGame = false;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SpeedUpTimer()
    {
        timer--;
        UpdateTimerText();
    }

    public void UpdateTimerText()
    {
        if (GameSettings.blinkWarningTime < timer 
            && timer <= GameSettings.blinkWarningTime + 0.5)
        {
            timeWarning.Blink();
        }
        if (GameSettings.day)
        {
            timeText.text = "Time left in day: " + Mathf.Round(timer);
        }
        else
        {
            timeText.text = "Time left in night: " + Mathf.Round(timer);
        }
    }

    public int GetDayCount()
    {
        return dayCount;
    }

    public void IncrementDayCount()
    {
        SetDayCount(dayCount + 1);
    }

    public void SetDayCount(int number)
    {
        dayCount = number;
        dayText.text = "Day: " + dayCount;
    }

    public int GetKillCount()
    {
        return killCount;
    }

    public void IncrementKillCount()
    {
        killCount++;
    }
    
    public float GetTime()
    {
        return timer;
    }

    // -------------------------- Spawning ------------------------- //

    IEnumerator SpawnRandomItems()
    {
        while (inGame)
        {
            yield return new WaitForSeconds(Utils.RandomDelay());
            if (items.GetComponentsInChildren<Transform>().Length < GameSettings.maxItems)
            {
                Utils.DestroyAboveSpawnHeight(Utils.SetParent(SpawnAroundLocation(itemsPrefabs[0], GameSettings.stickSpawnCenter, GameSettings.stickSpawnRadius), items));
                Utils.DestroyAboveSpawnHeight(Utils.SetParent(SpawnAroundLocation(itemsPrefabs[0], GameSettings.stickSpawnCenter, GameSettings.stickSpawnRadius), items));
                Utils.DestroyAboveSpawnHeight(Utils.SetParent(SpawnAroundLocation(itemsPrefabs[1], GameSettings.rockSpawnCenter, GameSettings.rockSpawnRadius), items));
                Utils.DestroyAboveSpawnHeight(Utils.SetParent(SpawnAroundLocation(itemsPrefabs[2], GameSettings.rockSpawnCenter, GameSettings.rockSpawnRadius), items));

                Utils.DestroyAboveSpawnHeight(Utils.SetParent(SpawnAroundLocation(itemsPrefabs[0], new Vector3(), GameSettings.maxSpawnRadius), items));
                Utils.DestroyAboveSpawnHeight(Utils.SetParent(SpawnAroundLocation(itemsPrefabs[0], new Vector3(), GameSettings.maxSpawnRadius), items));
                Utils.DestroyAboveSpawnHeight(Utils.SetParent(SpawnAroundLocation(itemsPrefabs[1], new Vector3(), GameSettings.maxSpawnRadius), items));
                Utils.DestroyAboveSpawnHeight(Utils.SetParent(SpawnAroundLocation(itemsPrefabs[2], new Vector3(), GameSettings.maxSpawnRadius), items));
            }
        }
    }

    IEnumerator SpawnPassive()
    {
        while (inGame)
        {
            //yield return new WaitForSeconds(Utils.RandomDelay());
            yield return new WaitForSeconds(0.01f);
            if (passiveCreatures.GetComponentsInChildren<Transform>().Length < GameSettings.maxPassiveCreatures)
            {
                SpawnCreature(Utils.RandomPrefab(passivePrefabs), passiveCreatures, GameSettings.maxSpawnRadius);
            }
        }
    }

    private void SpawnWave()
    {
        SpawnCreatures(aggroPrefabs[0], aggroCreatures, GameSettings.enemySpawnDistance, 
            dayCount % 5 + 1);
        SpawnCreatures(aggroPrefabs[1], aggroCreatures, GameSettings.enemySpawnDistance, 
            dayCount / 5);
        if (!GameSettings.day)
        {
            SpawnCreatures(aggroPrefabs[2], aggroCreatures, GameSettings.enemySpawnDistance, 
                dayCount >= 10 ? dayCount / 10 - dayCount % 5 : 0);
            SpawnCreatures(aggroPrefabs[3], aggroCreatures, GameSettings.enemySpawnDistance, 
                dayCount > 10 && dayCount % 5 == 0 ? (dayCount - 10) / 5 : 0);
        }
    }

    private void SpawnNearPlayer(GameObject prefab, GameObject parent, float bounds)
    {
        Vector3 direction = player.transform.position.normalized;
        Vector3 newCenter = direction * Mathf.Min(GameSettings.maxSpawnRadius - bounds, bounds);
        Utils.SetParent(SpawnAroundLocation(prefab, newCenter, bounds), parent);
    }

    void SpawnCreatures(GameObject prefab, GameObject parent, float bounds, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            if (GameSettings.day)
            {
                SpawnCreature(prefab, parent, GameSettings.maxSpawnRadius);
            }
            else
            {
                SpawnNearPlayer(prefab, parent, bounds);
            }
        }
    }

    void SpawnCreature(GameObject prefab, GameObject parent, float bounds)
    {
        Utils.SetParent(SpawnAroundLocation(prefab, new Vector3(), bounds), parent);
        //InstantiateOffScreen(prefabs, bounds).transform.SetParent(storage.transform, true);
    }

    GameObject SpawnAroundLocation(GameObject prefab, Vector3 center, float maxDistance)
    {
        Vector3 spawnPos = Utils.GetGroundPoint(Utils.RandomInArea(center, maxDistance));
        spawnPos.y += prefab.transform.position.y; // set Offset from ground
        Instantiate(Poof, spawnPos, Utils.RandomYRotation());
        return Instantiate(prefab, spawnPos, Utils.RandomYRotation());
    }

    private void DespawnCreatures(GameObject parent)
    {
        foreach (Transform t in parent.transform)
        {
            Instantiate(Poof, t.position, t.rotation);
            Destroy(t.gameObject);
        }
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
