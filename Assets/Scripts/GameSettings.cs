using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    // ENVIRONMENT
    public static float bounds = 120;
    public static int decorAmount = 200;
    public static int waterAmount = Mathf.RoundToInt(bounds * 0.60f);

    // SOUND & VOLUME
    public static float musicVolume = 0.10f;
    public static float soundVolume = 1.0f;

    // HEALTH UI
    public static Vector2 healthBarHorizontal = new Vector2(100, 20);
    public static Vector2 healthBarVertical = new Vector2(40, 200);

    // PLAYER STATS
    public static float saturationDelay = 5;
    public static int saturationRegen = 1;
    public static float hungerRate = 1.0f;
    public static float playerSpeed = 300.0f;
    public static float playerTurnSpeed = 100.0f;

    // Red Attack Box
    public static float attackLifeSpan = 0.2f;
    public static int attackDistance = 2;
    public static float attackAnimationLength = 2.28f;

    // ENEMY STATS
    public static float enemyAttackSpeed = 1.0f;

    // SPAWNING
    public static float minSpawnDelay = 1f;
    public static float maxSpawnDelay = 10f;

    public static int maxItems = 20;
    public static int maxPassiveCreatures = 20;

    public static float waveDelay = 10.0f;


    // Note: make an Enum/Class of Items
    public const int FISTS = -1;
    public const int STICK = 0;
    public const int ROCK = 1;
    public const int STONEAXE = 2;
    public const int STONESPEAR = 3;
    public const int STONEKNIFE = 4;
    public const int STICKimage = 5;
    public const int ROCKimage = 6;
    public const int NUMITEMTYPES = 7;
    public static string[] itemTypes = { "Stick", "Rock", "Axe", "Spear", "Knife", "StickImage", "RockImage" };

    /*
     * Weapon defaults
     * 
     * name, recipe, id, damage, size, speed, durability
     * size(width, length, height)
     * recipe{sticks, rocks}
     * 
     * NOTE: ID is deprecated, will try to remove soon.
     */
    public static Weapon[] weapons =
    {
        new Weapon(     "Fists", new int[]{0, 0},      FISTS, 1, new Vector3(1.0f, 1.0f, 1.0f), 4.0f, int.MaxValue),
        new Weapon(     "Stick", new int[]{1, 0},      STICK, 1, new Vector3(1.0f, 1.5f, 1.0f), 4.0f, int.MaxValue),
        new Weapon(      "Rock", new int[]{0, 1},       ROCK, 4, new Vector3(1.0f, 1.0f, 1.0f), 1.0f, int.MaxValue),
        new Weapon(  "StoneAxe", new int[]{2, 2},   STONEAXE, 6, new Vector3(4.0f, 1.0f, 4.0f), 2.0f, 15),
        new Weapon("StoneSpear", new int[]{3, 1}, STONESPEAR, 6, new Vector3(1.0f, 5.0f, 5.0f), 3.0f, 15),
        new Weapon("StoneKnife", new int[]{1, 2}, STONEKNIFE, 3, new Vector3(1.5f, 1.5f, 1.5f), 5.0f, 10),
    };

    public static bool day = true;
    public static float flickerSpeed = 0.2f;
    public static float minFlicker = 0.5f;
    public static float maxFlicker = 1.0f;
    public static float minDeltaFlicker = -0.1f;
    public static float maxDeltaFlicker = 0.1f;
}