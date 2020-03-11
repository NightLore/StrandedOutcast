using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{

    // -------------------------- Utilities ------------------------- //

    public static float RandomDelay()
    {
        return Random.Range(GameSettings.minSpawnDelay, GameSettings.maxSpawnDelay);
    }

    public static GameObject RandomPrefab(GameObject[] prefabs)
    {
        return prefabs[Random.Range(0, prefabs.Length)];
    }

    public static Vector3 RandomInArea(Vector3 center, float maxDistance)
    {
        return center + Random.insideUnitSphere * maxDistance;
    }

    public static Quaternion RandomYRotation()
    {
        return Quaternion.Euler(Vector3.up * RandomDirection());
    }

    public static float RandomDirection()
    {
        return Random.Range(0, 360);
    }

    public static GameObject SetParent(GameObject child, GameObject parent)
    {
        child.transform.SetParent(parent.transform);
        return child;
    }

    public static bool DestroyAboveSpawnHeight(GameObject obj)
    {
        if(obj.transform.position.y > GameSettings.maxSpawnHeight)
        {
            Destroy(obj);
            return true;
        }
        return false;
    }

    public static Vector3 GetGroundPoint(Vector3 position)
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
}
