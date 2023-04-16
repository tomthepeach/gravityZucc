using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using Mathf = UnityEngine.Mathf;

public class Instantiate_cluster : MonoBehaviour
{
    public GameObject starPrefab;
    public GameObject bhPrefab;
    public Material skybox1;
    public Material skybox2;

    void Awake()
    {
        int starCount =  MenuSettings.numStars;
        float clusterRadius = MenuSettings.clusterRadius;
        float clusterMass = MenuSettings.clusterMass;
        float bhMass = MenuSettings.BHMass;
        if (MenuSettings.skybox == 0)
        {
            RenderSettings.skybox = skybox1;
        }
        else
        {
            RenderSettings.skybox = skybox2;
        }

        GameObject bh = Instantiate(bhPrefab);
        bh.transform.position = Vector3.zero; 
        bh.GetComponent<Body>().init(bhMass, Vector3.zero, ApproxMath.schwarzschildRadius(bhMass), 1);
        float massCheck = 0f;

        for (int i = 0; i < starCount; i++)
        {
            float scaler = ApproxMath.beta(2f, 2f*120f/(clusterMass/starCount));
            float inpmass = 0.1f + scaler * 120f;
            float starRadius = 15f * scaler;
            massCheck += inpmass;

            Vector3 pos;
            pos = Random.insideUnitSphere * clusterRadius;//ApproxMath.boundedGaussian(0.0f, galaxyRadius/2.0f, 0.01f, galaxyRadius);

            Vector3 velDir = Vector3.Cross(pos, Vector3.up).normalized;
            float correctedMass = (clusterMass)*(pos.magnitude/clusterRadius);
            float velMag = ApproxMath.orbitalVelocity(correctedMass, pos.magnitude);
            // float velMag = 0f;


            GameObject star = Instantiate(starPrefab);
            star.transform.position = pos;
            Body star_bod = star.GetComponent<Body>();
            star_bod.init(inpmass, velMag * velDir, starRadius,0);
            star_bod.starMat.SetFloat("_Luminosity", ApproxMath.massLuminosity(inpmass));
        }
        Debug.Log("Mass check: " + massCheck);
    }
}