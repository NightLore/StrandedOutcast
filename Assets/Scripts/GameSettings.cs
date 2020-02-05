using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static float bounds = 50.0f;
    public static int decorAmount = 200;
    public static int waterAmount = 50;

    public static float musicVolume = 0.10f;
    public static float soundVolume = 1.0f;

    public static Vector2 healthBarSize = new Vector2(100, 20);

    public static float attackLifeSpan = 0.2f;
    public static int attackDistance = 2;
    public static float attackAnimationLength = 2.28f;

    public static float playerSpeed = 10.0f;
    public static float playerTurnSpeed = 30.0f;

    public static float enemyAttackSpeed = 1.0f;

    public static float minSpawnDelay = 1f;
    public static float maxSpawnDelay = 10f;

    public static int maxItems = 20;
    public static int maxPassiveCreatures = 20;

    public static float waveDelay = 10.0f;

    // Note: make an Enum
    public const int FISTS = -1;
    public const int STICK = 0;
    public const int ROCK = 1;
    public const int AXE = 2;
    public const int SPEAR = 3;
    public const int KNIFE = 4;
    public const int NUMITEMTYPES = 5;
    public static string[] itemTypes = { "Stick", "Rock", "Axe", "Spear", "Knife" };


    public static int defaultDamage = 1;
    public static Vector3 defaultAttackSize = new Vector3(1, 1, 1);
    public static float defaultAttackSpeed = 4.0f;

    public static int[] weaponDamages = { 2, 4, 6, 6, 3 };
    public static Vector3[] weaponSizes = 
    { 
        new Vector3(1, 1.5f, 1),
        new Vector3(1, 1, 1),
        new Vector3(4, 1, 1),
        new Vector3(1, 5, 1),
        new Vector3(1.5f, 1.5f, 1.5f)
    };
    public static float[] weaponSpeeds = { 4, 1, 2, 2, 5 };

    public static int[][] weaponParts =
    {
        new int[]{ 1, 0 },
        new int[]{ 0, 1 },
        new int[]{ 2, 2 },
        new int[]{ 3, 1 },
        new int[]{ 1, 1 }
    };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
