using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using Mathf = UnityEngine.Mathf;

public class Instantiate_cluster : MonoBehaviour
{
    public GameObject starPrefab;
    public GameObject bhPrefab;

    public int starCount = 100;
    public float clusterRadius = 1000f;
    public float clusterMass = 1000.0f;
    public float bhMass = 100.0f;
    
    void Start()
    {

        //starCount =  NumStars.numStars;

        GameObject bh = Instantiate(bhPrefab);
        bh.transform.position = Vector3.zero; 
        bh.GetComponent<Body>().init(bhMass, Vector3.zero, ApproxMath.schwarzschildRadius(bhMass), 1);

        for (int i = 0; i < starCount; i++)
        {
            float scaler = ApproxMath.beta(2f, 2f*120f/(clusterMass/starCount));
            float inpmass = 0.1f + scaler * 120f;
            float starRadius = 15f * scaler;

            Vector3 pos;
            pos = Random.insideUnitSphere * clusterRadius;//ApproxMath.boundedGaussian(0.0f, galaxyRadius/2.0f, 0.01f, galaxyRadius);

            Vector3 velDir = Vector3.Cross(pos, Vector3.up).normalized;
            float velMag = ApproxMath.orbitalVelocity(clusterMass, pos.magnitude);
            // float velMag = 0f;


            GameObject star3 = Instantiate(starPrefab);
            star3.transform.position = pos;
            star3.GetComponent<Body>().init(inpmass, velMag * velDir, starRadius,0);

        }
    }
}