using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disc : MonoBehaviour
{
    public GameObject Star;
    public RandomNormal gaussian = new RandomNormal();
    public int starCount = 1000;
    public int y_range = 10;
    public float sigma = 100f;


    // Need to combine this disc and spiral spawners into one. Challenge is balancing the spawning
    void Awake()
    {
        
        for (int i = 0; i < starCount; i++)
        {
            
            float x = gaussian.value(transform.position.x,sigma);
            float z = gaussian.value(transform.position.z,sigma);

            Vector3 pos;
            pos.x = x;
            pos.z = z;
            pos.y = Random.Range(-y_range, y_range); //Flat top once again.

            GameObject star = Instantiate(Star);
            star.transform.position = pos;

        }
    }
}