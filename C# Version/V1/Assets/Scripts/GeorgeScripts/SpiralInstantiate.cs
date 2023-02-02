using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralInstantiate : MonoBehaviour
{
    public Star prefab;
    public int spawnCount = 10;

    public float numRounds = 1.0f;
    public int y_range = 10;
    public int noise = 10;
    public float radius = 1.0f;

    void Awake()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            float theta = ((2 * Mathf.PI * i) / spawnCount) * numRounds ;
            float r = theta * theta;
            float x = radius * r * Mathf.Cos(theta) + Random.Range(-noise, noise);
            float z = radius * r * Mathf.Sin(theta) + Random.Range(-noise, noise);

            Vector3 pos;
            pos.x = x;
            pos.z = z;
            pos.y = 50 + Random.Range(-y_range, y_range); //Might want to make this range a negative probability, dont want a flat top

            Star star = Instantiate(prefab);
            star.transform.position = pos;
    
        }

    }
}
