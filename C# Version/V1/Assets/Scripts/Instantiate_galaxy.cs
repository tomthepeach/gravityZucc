using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Instantiate_galaxy : MonoBehaviour
{
    public GameObject starPrefab;
    public GameObject bhPrefab;

    public int starCount = 1000;
    public float numRounds = 1.0f;
    public int y_range = 10;
    public int galaxyNoise = 10;
    public float stdDev = 3f;
    public float galaxyRadius = 10f;
    public float speed = 1f;
    public float velocityCap = 500f;
    public float velocityScaler = 1f;

    // Start is called before the first frame update
    // void Start()
    // {
    //     for (int i = 0; i < starCount/4; i++)
    //     {
    //         float scaler = Random.value;
    //         float inpmass = 1 + scaler * 1700;

    //         Vector3 starRadius = Vector3.one + Vector3.one*17*scaler;

    //         float theta = ((2 * 2 * Mathf.PI * i) / starCount) * numRounds;
    //         float r = theta * theta;
    //         float x = galaxyRadius * r * Mathf.Cos(theta);
    //         float z = galaxyRadius * r * Mathf.Sin(theta);
    //         Vector3 pos;

    //         pos.x = x + Random.Range(-galaxyNoise, galaxyNoise);
    //         pos.z = z + Random.Range(-galaxyNoise, galaxyNoise);
    //         pos.y = Random.Range(-y_range, y_range);

    //         GameObject star1 = Instantiate(starPrefab);
    //         star1.transform.position = pos;
    //         star1.GetComponent<Body>().init(inpmass, Vector3.zero, starRadius);

    //         pos.x = -x + Random.Range(-galaxyNoise, galaxyNoise);
    //         pos.z = -z + Random.Range(-galaxyNoise, galaxyNoise);
    //         pos.y = Random.Range(-y_range, y_range);

    //         GameObject star2 = Instantiate(starPrefab);
    //         star2.transform.position = pos;
    //         star2.GetComponent<Body>().init(inpmass, Vector3.zero, starRadius);
            

    //         pos.x = galaxyRadius * ApproxMath.gaussian(transform.position.x, stdDev);
    //         pos.z = galaxyRadius * ApproxMath.gaussian(transform.position.z, stdDev);
    //         pos.y = Random.Range(-y_range, y_range); //Flat top once again.

    //         GameObject star3 = Instantiate(starPrefab);
    //         star3.transform.position = pos;
    //         star3.GetComponent<Body>().init(inpmass, Vector3.zero, starRadius);


    //         pos.x = galaxyRadius * ApproxMath.gaussian(transform.position.x, stdDev);
    //         pos.z = galaxyRadius * ApproxMath.gaussian(transform.position.z, stdDev);
    //         pos.y = Random.Range(-y_range, y_range); //Flat top once again.

    //         GameObject star4 = Instantiate(starPrefab);
    //         star4.transform.position = pos;
    //         star4.GetComponent<Body>().init(inpmass, Vector3.zero, starRadius);

    //     }   
    // }

    void Start()
    {


        
        float totalMass = 0;
        for (int i = 0; i < starCount; i++)
        {
            float scaler = ApproxMath.rayleigh(0.5f);
            float inpmass = 120f * scaler;
            totalMass += inpmass;
            float starRadius = 15f * scaler;

            Vector3 pos;
            pos = Random.insideUnitSphere * ApproxMath.boundedGaussian(0.0f, galaxyRadius/2.0f, 0.01f, galaxyRadius);

            Vector3 origin = Vector3.zero;
            Vector3 Dir = pos - origin;

            Vector3 velDir = Vector3.Cross(Dir, Vector3.up).normalized;
            float velMag = speed / (float)ApproxMath.pow(Dir.magnitude, velocityScaler);
            if (velMag > velocityCap)
            {
                velMag = velocityCap;
            }

            GameObject star3 = Instantiate(starPrefab);
            star3.transform.position = pos;
            star3.GetComponent<Body>().init(inpmass, velMag * velDir, starRadius,0);

        }

        GameObject bh = Instantiate(bhPrefab);
        bh.transform.position = Vector3.zero;
        bh.GetComponent<Body>().init(totalMass*0.05f, Vector3.zero, 0.8f, 1);
    }
}