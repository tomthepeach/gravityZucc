using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Instantiate_galaxy : MonoBehaviour
{
    public GameObject Body;
    public RandomNormal gaussian = new RandomNormal();
    public int starCount = 1000;
    public float numRounds = 1.0f;
    public int y_range = 10;
    public int galaxyNoise = 10;
    public float galaxyRadius = 1000.0f;
    public float stdDev = 3f;

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

            float theta = ((2 * 2 * Mathf.PI * i) / starCount) * numRounds;
            float r = theta * theta;
            float x = galaxyRadius * r * Mathf.Cos(theta);
            float z = galaxyRadius * r * Mathf.Sin(theta);
            Vector3 pos;

            pos.x = x + Random.Range(-galaxyNoise, galaxyNoise);
            pos.z = z + Random.Range(-galaxyNoise, galaxyNoise);
            pos.y = Random.Range(-y_range, y_range); //dont want a flat top -use gaussian

            GameObject star1 = Instantiate(Body);
            star1.transform.position = pos;

            pos.x = -x + Random.Range(-galaxyNoise, galaxyNoise);
            pos.z = -z + Random.Range(-galaxyNoise, galaxyNoise);
            pos.y = Random.Range(-y_range, y_range);

            GameObject star2 = Instantiate(Body);
            star2.transform.position = pos;
            star2.transform.localScale = starRadius;
            star2.mass = inpmass;


            pos.x = galaxyRadius * gaussian.value(transform.position.x, stdDev);
            pos.z = galaxyRadius * gaussian.value(transform.position.z, stdDev);
            pos.y = Random.Range(-y_range, y_range); //Flat top once again.

            GameObject star3 = Instantiate(Body);
            star3.transform.position = pos;
            star3.transform.localScale = starRadius;
            star3.mass = inpmass;

            pos.x = galaxyRadius * gaussian.value(transform.position.x, stdDev);
            pos.z = galaxyRadius * gaussian.value(transform.position.z, stdDev);
            pos.y = Random.Range(-y_range, y_range); //Flat top once again.

            GameObject star4 = Instantiate(Body);
            star4.transform.position = pos;
            star4.transform.localScale = starRadius;
            star4.mass = inpmass;



            // star_i.PhysicsBody.Init(inpmass, inpinitialVelocity, inpgalaxyNoise);
        }   

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

/*

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public GameObject obj;
	public int spawnCount = 100;

	public float numRounds = 1.0f;
	public int y_range = 10;
	public int noise = 10;
	public float radius = 1.0f;
	public float speed = 1.0f;

	void Awake()
	{
		
		//Double spiral
		for (int i = 0; i < spawnCount/2; i++)
		{
			float theta = ((2 * Mathf.PI * i) / spawnCount) * numRounds;
			float r = theta * theta;
			float x = radius * r * Mathf.Cos(theta);
			float z = radius * r * Mathf.Sin(theta);

			Vector3 pos;
			pos.x = x + Random.Range(-noise, noise);
			pos.z = z + Random.Range(-noise, noise);
			pos.y = 50 + Random.Range(-y_range, y_range);


			GameObject _go = Instantiate(obj, pos, transform.rotation);
			

		}

		for (int i = 0; i < spawnCount / 2; i++)
		{
			float theta = ((2 * Mathf.PI * i) / spawnCount) * numRounds;
			float r = theta * theta;
			float x = radius * r * Mathf.Cos(theta);
			float z = radius * r * Mathf.Sin(theta);

			Vector3 pos;
			pos.x = -x + Random.Range(-noise, noise);
			pos.z = -z + Random.Range(-noise, noise);
			pos.y = 50 + Random.Range(-y_range, y_range);


			GameObject _go = Instantiate(obj, pos, transform.rotation);

		}


	}
	
}

*/