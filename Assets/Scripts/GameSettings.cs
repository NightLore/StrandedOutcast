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
    public static int saturationRegen = 1;
    public static float hungerRate = 0.3333f;
    public static float hungerRegenThreshold = 75.0f;
    public static float startingSaturation = 10.0f;
    public static float playerSpeed = 10.0f;
    public static float playerTurnSpeed = 100.0f;

    // Red Attack Box
    public static float attackLifeSpan = 0.2f;
    public static int attackDistance = 2;
    public static float attackAnimationLength = 2.28f;

    // ENEMY STATS
    public static float enemyAttackSpeed = 1.0f;

    // SPAWNING
    public static float maxSpawnHeight = 2.0f;

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
    public const int METAL = 2;
    public const int STONEAXE = 3;
    public const int STONESPEAR = 4;
    public const int STONEKNIFE = 5;
    public const int STONEPICK = 6;
    public const int BATTLEAXE = 7;
    public const int SWORD = 8;
    public const int RAWMEAT = 9;
    public const int COOKEDMEAT = 10;
    public const int FIRE = 11;
    public const int FORGE = 12;
    public const int NAILS = 13;
    public const int NUMITEMTYPES = 13;

    private static readonly Recipe.Builder recipe = new Recipe.Builder();

    /*
     * Weapon defaults
     * 
     * name, recipe, id, damage, size, speed, durability
     * size(width, length, height)
     * recipe{sticks, rocks}
     * 
     * NOTE: ID is deprecated, will try to remove soon.
     */
    public static Item[] itemList =
    {
/* 0 */ new Weapon(     "Stick", recipe.Reset().Set(STICK, 1).Set(ROCK, 0).Set(METAL, 0).GetRecipe(),      STICK,  1, new Vector3(1.0f, 1.5f, 1.0f), 4.0f, int.MaxValue),
/* 1 */ new Weapon(      "Rock", recipe.Reset().Set(STICK, 0).Set(ROCK, 1).Set(METAL, 0).GetRecipe(),       ROCK,  4, new Vector3(1.0f, 1.0f, 1.0f), 1.0f, int.MaxValue),
/* 2 */ new Weapon(     "Metal", recipe.Reset().Set(STICK, 0).Set(ROCK, 0).Set(METAL, 1).GetRecipe(),      METAL,  2, new Vector3(1.0f, 1.0f, 1.0f), 2.0f, int.MaxValue),
/* 3 */ new Weapon(  "StoneAxe", recipe.Reset().Set(STICK, 2).Set(ROCK, 2).Set(METAL, 0).GetRecipe(),   STONEAXE,  6, new Vector3(4.0f, 1.0f, 4.0f), 2.0f, 15),
/* 4 */ new Weapon("StoneSpear", recipe.Reset().Set(STICK, 3).Set(ROCK, 1).Set(METAL, 0).GetRecipe(), STONESPEAR,  6, new Vector3(1.0f, 5.0f, 5.0f), 3.0f, 15),
/* 5 */ new Weapon("StoneKnife", recipe.Reset().Set(STICK, 1).Set(ROCK, 2).Set(METAL, 0).GetRecipe(), STONEKNIFE,  3, new Vector3(1.5f, 1.5f, 1.5f), 5.0f, 10),
/* 6 */ new Weapon( "StonePick", recipe.Reset().Set(STICK, 3).Set(ROCK, 3).Set(METAL, 0).GetRecipe(),  STONEPICK,  2, new Vector3(2.0f, 1.5f, 1.5f), 2.5f, 10),
/* 7 */ new Weapon( "BattleAxe", recipe.Reset().Set(STICK, 4).Set(ROCK, 7).Set(METAL, 0).GetRecipe(),  BATTLEAXE, 12, new Vector3(7.0f, 4.0f, 1.5f), 1.5f, 15),
/* 8 */ new Weapon(     "Sword", recipe.Reset().Set(STICK, 6).Set(ROCK, 4).Set(METAL, 0).GetRecipe(),      SWORD,  8, new Vector3(3.0f, 3.0f, 1.5f), 4.0f, 15),
/* 9 */ new Item(     "RawMeat", recipe.Reset().Set(RAWMEAT, 1).GetRecipe()),
/*10 */ new Item(  "CookedMeat", recipe.Reset().Needs(FIRE).Set(RAWMEAT, 1).GetRecipe()),
/*11 */ new Item(        "Fire", recipe.Reset().Set(STICK, 2).Set(ROCK, 2).GetRecipe()),
/*12 */ new Item(       "Forge", recipe.Reset().Set(STICK, 2).Set(ROCK, 2).GetRecipe()),
/*13 */ new Item(       "Nails", recipe.Reset().Needs(FORGE).Set(METAL, 1).GetRecipe())
    };

    public static Item[] materials =
    {
        itemList[STICK],
        itemList[ROCK]
    };

    public static Weapon[] weapons =
    {
        new Weapon("Fists", recipe.Reset().GetRecipe(), FISTS, 1, new Vector3(1.0f, 1.0f, 1.0f), 4.0f, int.MaxValue),
        itemList[STICK] as Weapon,
        itemList[ROCK] as Weapon,
        itemList[STONEAXE] as Weapon,
        itemList[STONESPEAR] as Weapon,
        itemList[STONEKNIFE] as Weapon,
        itemList[STONEPICK] as Weapon,
        itemList[BATTLEAXE] as Weapon,
        itemList[SWORD] as Weapon
    };

    public static bool day = true;
    public static float flickerSpeed = 0.2f;
    public static float minFlicker = 0.5f;
    public static float maxFlicker = 1.0f;
    public static float minDeltaFlicker = -0.1f;
    public static float maxDeltaFlicker = 0.1f;

    public static float foodValue = 15.0f;
}
