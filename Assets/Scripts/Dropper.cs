using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    public GameObject[] drops; // Drag and drop
    public float[] percentages; // indexes align with drops
    public int maxDrops;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Drop() // Enemies
    {
        Drop(transform.position);
    }

    public void Drop(Vector3 position) // ResourceSources
    {
        int index = 0;
        for (int i = 0; i < maxDrops; i++)
        {
            int j = index;
            index = (index + drops.Length) % (drops.Length + 1);
            for (; j != index; j++)
            {
                if (j >= drops.Length)
                    j = -1;
                else if (Random.value < percentages[j])
                {
                    Vector3 spawnPos = Utils.GetGroundPoint(position);
                    spawnPos.y += drops[j].transform.position.y; // set Offset from ground
                    Instantiate(drops[j], Utils.GetGroundPoint(spawnPos), Utils.RandomYRotation());
                    index = j + 1;
                }
            }
        }
    }
}
