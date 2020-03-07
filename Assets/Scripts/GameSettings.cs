using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{

    // SOUND & VOLUME
    public static float musicVolume = 0.10f;
    public static float soundVolume = 1.0f;

    // ----------------- UI ------------------ //
    // HEALTH UI
    public static Vector2 healthBarHorizontal = new Vector2(100, 20);
    public static Vector2 healthBarVertical = new Vector2(40, 200);

    public static float tutorialDelay = 3.0f;
    public static float blinkTextDelay = 1.0f;
    public static float oscillationDistance = 20.0f;
    public static float oscillationSpeed = 10.0f;

    // ----------- GAME STATS -------------- //

    // PLAYER STATS
    public static float saturationDelay = 5;
    public static int saturationRegen = 1;
    public static float hungerRate = 0.3333f;
    public static float playerSpeed = 10.0f;
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
    public static int maxPassiveCreatures = 100;

    public static float dayLength = 60.0f;
    public static float nightLength = 30.0f;

    public static float maxSpawnRadius = 110;
    public static float enemySpawnDistance = 40;

    public static Vector3 stickSpawnCenter = new Vector3(-30, 0, 60);
    public static float stickSpawnRadius = 40;

    public static Vector3 rockSpawnCenter = new Vector3(-60, 0, 50);
    public static float rockSpawnRadius = 40;


    // Note: make an Enum/Class of Items
    public const int FISTS = -1;
    public const int STICK = 0;
    public const int ROCK = 1;
    public const int STONEAXE = 2;
    public const int STONESPEAR = 3;
    public const int STONEKNIFE = 4;
    public const int STONEPICK = 5;
    public const int BATTLEAXE = 6;
    public const int SWORD = 7;
    public const int ROCKimage = 8;
    public const int RAWMEAT = 9;
    public const int COOKEDMEAT = 10;
    public const int BONFIRE = 11;
    public const int NUMITEMTYPES = 12;
    public static string[] itemTypes = 
    {   "Stick", "Rock", "Axe", "Spear", "Knife", "SPick", "Battleaxe", "Sword", "RockImage",
        "RawMeat", "CookedMeat", "Bonfire" };

    /*
     * Weapon defaults
     * 
     * name, recipe, id, damage, size, speed, durability
     * size(width, length, height)
     * recipe{sticks, rocks}
     * 
     * NOTE: ID is deprecated, will try to remove soon.
     */
    private static readonly Recipe.Builder recipe = new Recipe.Builder();
    public static Weapon[] weapons =
    {
        new Weapon(     "Fists", recipe.Reset().Set(STICK, 0).Set(ROCK, 0).GetRecipe(),      FISTS,  1, new Vector3(1.0f, 1.0f, 1.0f), 4.0f, int.MaxValue),
        new Weapon(     "Stick", recipe.Reset().Set(STICK, 1).Set(ROCK, 0).GetRecipe(),      STICK,  1, new Vector3(1.0f, 1.5f, 1.0f), 4.0f, int.MaxValue),
        new Weapon(      "Rock", recipe.Reset().Set(STICK, 0).Set(ROCK, 1).GetRecipe(),       ROCK,  4, new Vector3(1.0f, 1.0f, 1.0f), 1.0f, int.MaxValue),
        new Weapon(  "StoneAxe", recipe.Reset().Set(STICK, 2).Set(ROCK, 2).GetRecipe(),   STONEAXE,  6, new Vector3(4.0f, 1.0f, 4.0f), 2.0f, 15),
        new Weapon("StoneSpear", recipe.Reset().Set(STICK, 3).Set(ROCK, 1).GetRecipe(), STONESPEAR,  6, new Vector3(1.0f, 5.0f, 5.0f), 3.0f, 15),
        new Weapon("StoneKnife", recipe.Reset().Set(STICK, 1).Set(ROCK, 2).GetRecipe(), STONEKNIFE,  3, new Vector3(1.5f, 1.5f, 1.5f), 5.0f, 10),
        new Weapon( "StonePick", recipe.Reset().Set(STICK, 3).Set(ROCK, 3).GetRecipe(),  STONEPICK,  2, new Vector3(2.0f, 1.5f, 1.5f), 2.5f, 10),
        new Weapon( "BattleAxe", recipe.Reset().Set(STICK, 4).Set(ROCK, 7).GetRecipe(),  BATTLEAXE, 12, new Vector3(7.0f, 4.0f, 1.5f), 1.5f, 15),
        new Weapon(     "Sword", recipe.Reset().Set(STICK, 6).Set(ROCK, 4).GetRecipe(),      SWORD,  8, new Vector3(3.0f, 3.0f, 1.5f), 4.0f, 15)
    };

    public static Item[] buildings = 
    {
        new Item(     "Bonfire", recipe.Reset().Set(STICK, 2).Set(ROCK, 2).GetRecipe()),
        new Item(       "Forge", recipe.Reset().Set(STICK, 2).Set(ROCK, 2).GetRecipe())
    };

    public static bool day = true;
    public static float flickerSpeed = 0.2f;
    public static float minFlicker = 0.5f;
    public static float maxFlicker = 1.0f;
    public static float minDeltaFlicker = -0.1f;
    public static float maxDeltaFlicker = 0.1f;

    public static float[] foodvalues = {10.0f};

    public static bool canCook = false;
}
