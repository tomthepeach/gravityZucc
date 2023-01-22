using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate_galaxy : MonoBehaviour
{
    public GameObject Star;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 1000; i++)
        {
            Instantiate(Star, new Vector3(Random.Range(-10000, 10000), Random.Range(-10000, 10000), Random.Range(-100, 100)), Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
