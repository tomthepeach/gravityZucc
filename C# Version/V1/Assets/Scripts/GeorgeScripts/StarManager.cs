using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StarManager : MonoBehaviour
{

    //Will want to reduce this once it is know how many threads on headset
    //const int threadGroupSize = 1024;
    //public ComputeShader compute;

    Star[] stars;


    void Awake()
    {
        stars = FindObjectsOfType<Star> ();
        foreach (Star s in stars)
        {
            s.Initialize();
        }
        Time.timeScale = 10;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;

    }

    void Update()
    {
        if (stars != null)
        {
            int numStars = stars.Length;

            for (int i = 0; i < numStars; i++)
            {
                stars[i].UpdateVelocity(stars, Time.fixedDeltaTime);
            }

            for (int i = 0; i < numStars; i++)
            {
                stars[i].UpdatePosition(Time.fixedDeltaTime);
            }
        }
    }


}