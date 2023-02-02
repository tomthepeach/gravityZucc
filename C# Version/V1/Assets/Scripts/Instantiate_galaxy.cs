using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Instantiate_galaxy : MonoBehaviour
{
    public GameObject Star;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 1000; i++)
        {
            GameObject star_i;
            star_i = Instantiate(Star, Random.insideUnitSphere*1000, Quaternion.identity);

            float scaler = Random.value;
            float inpmass = 1 + scaler * 1700;

            Vector3 inpinitialVelocity = Random.insideUnitSphere*100;
            Vector3 inpradius = Vector3.one + Vector3.one*17*scaler;

            star_i.GetComponent<Rigidbody>().mass = inpmass;
            star_i.GetComponent<Rigidbody>().velocity = inpinitialVelocity;
            star_i.transform.localScale = inpradius;

            // star_i.PhysicsBody.Init(inpmass, inpinitialVelocity, inpradius);
        }   

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
