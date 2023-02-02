using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Instantiate_galaxy : MonoBehaviour
{
    public GameObject Star;
    public int starCount = 1000;
    public float numRounds = 1.0f;
    public int y_range = 10;
    public int galaxyNoise = 10;
    public float galaxyRadius = 1000.0f;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < starCount/2; i++)
        {
            float scaler = Random.value;
            float inpmass = 1 + scaler * 1700;

            // Vector3 initialVelocity = Random.insideUnitSphere*100;
            Vector3 starRadius = Vector3.one + Vector3.one*17*scaler;

            // star_i.GetComponent<Rigidbody>().mass = inpmass;
            // star_i.GetComponent<Rigidbody>().velocity = inpinitialVelocity;

            float theta = ((2 * 2 * Mathf.PI * i) / starCount) * numRounds ;
            float r = theta * theta;
            float x = galaxyRadius * r * Mathf.Cos(theta);
            float z = galaxyRadius * r * Mathf.Sin(theta);

            Vector3 pos;
            pos.x = x + Random.Range(-galaxyNoise, galaxyNoise);
            pos.z = z + Random.Range(-galaxyNoise, galaxyNoise);
            pos.y = Random.Range(-y_range, y_range); //Dont want a flat top -Use gaussian

            GameObject star1 = Instantiate(Star);
            star1.transform.position = pos;
            star1.transform.localScale = starRadius;

            pos.x = -x + Random.Range(-galaxyNoise, galaxyNoise);
            pos.z = -z + Random.Range(-galaxyNoise, galaxyNoise);
            pos.y = Random.Range(-y_range, y_range);

            GameObject star2 = Instantiate(Star);
            star2.transform.position = pos;
            star2.transform.localScale = starRadius;


            // star_i.PhysicsBody.Init(inpmass, inpinitialVelocity, inpgalaxyNoise);
        }   

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
