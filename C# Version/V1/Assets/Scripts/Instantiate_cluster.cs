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
    public float clusterMass = 10000.0f;
    

    void Start()
    {

        //starCount =  NumStars.numStars;
        Time.timeScale = timewarp * Constants.YEAR_S;
        float totalMass = 0;
        dist = Beta(2f, 5f);
        for (int i = 0; i < starCount; i++)
        {
            float scaler = ApproxMath.boundedGaussian(0.5f);
            float inpmass = 120f * scaler;
            totalMass += inpmass;
            float starRadius = 15f * scaler;

            Vector3 pos;
            pos = Random.insideUnitSphere * galaxyRadius;//ApproxMath.boundedGaussian(0.0f, galaxyRadius/2.0f, 0.01f, galaxyRadius);

            Vector3 velDir = Vector3.Cross(pos, Vector3.up).normalized;
            float velMag = Mathf.Sqrt(Constants.BIGG * (clusterMass - inpmass)/ Dir.magnitude);

            GameObject star3 = Instantiate(starPrefab);
            star3.transform.position = pos;
            star3.GetComponent<Body>().init(inpmass, velMag * velDir, starRadius,0);

        }

        GameObject bh = Instantiate(bhPrefab);
        bh.transform.position = Vector3.zero;
        float bhmass = totalMass * 0.05f;   
        bh.GetComponent<Body>().init(bhmass, Vector3.zero, ApproxMath.schwarzschildRadius(bhmass), 1);//totalMass*0.05f
    }
}