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
    public float timewarp = 1f;
    public float clusterMass = 1000.0f;
    
    void Start()
    {

        //starCount =  NumStars.numStars;
        Time.timeScale = timewarp;
        // Time.fixedDeltaTime = Time.fixedDeltaTime * Time.timeScale;

        GameObject bh = Instantiate(bhPrefab);
        bh.transform.position = Vector3.zero;
        float bhmass = clusterMass * 0.05f;   
        bh.GetComponent<Body>().init(bhmass, Vector3.zero, ApproxMath.schwarzschildRadius(bhmass), 1);
        float remainingMass = clusterMass - bhmass;

        for (int i = 0; i < starCount; i++)
        {
            float scaler = ApproxMath.beta(2f, 2f*120f/(remainingMass/starCount));
            float inpmass = scaler * 120f;
            float starRadius = 15f * scaler;

            Vector3 pos;
            pos = Random.insideUnitSphere * clusterRadius;//ApproxMath.boundedGaussian(0.0f, galaxyRadius/2.0f, 0.01f, galaxyRadius);

            Vector3 velDir = Vector3.Cross(pos, Vector3.up).normalized;
            float velMag = Mathf.Sqrt(Constants.BIGG * (clusterMass - inpmass)/ pos.magnitude) * Time.deltaTime * Constants.YEAR_S;

            GameObject star3 = Instantiate(starPrefab);
            star3.transform.position = pos;
            star3.GetComponent<Body>().init(inpmass, velMag * velDir, starRadius,0);

        }


    }
}