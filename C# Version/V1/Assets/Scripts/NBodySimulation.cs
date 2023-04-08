using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Colour = UnityEngine.Color;


public class NBodySimulation : MonoBehaviour
{
    public GameObject bhPrefab;
    public bool collectData = true;

    List<Body> bodies;
     
    DataController DC = new DataController();

    void Start()
    {   
        Time.timeScale = MenuSettings.timeWarp;
        Time.fixedDeltaTime = Time.fixedDeltaTime * Time.timeScale;

        Debug.Log("Time Scale: " + Time.timeScale);
        Debug.Log("Fixed Delta Time: " + Time.fixedDeltaTime);
        if  (collectData)
        {
            InvokeRepeating("logData", 0.0f, 1.0f);
        }
    }


    void FixedUpdate()
    {
        Body[] bodyarr = FindObjectsOfType<Body>();
        bodies = new List<Body>(bodyarr);
        int bodiesLen = bodies.Count;

        for (int i=0; i < bodiesLen; i++)
        {
            bodies[i].UpdateVelocity(bodies);
        }

        for (int i=0; i < bodiesLen; i++)
        {
            bodies[i].UpdatePosition();
            // bodies[i].UpdateLuminosity(); ??
        }

        List<Body> toDestroy = new List<Body>();
        float avgRadius = 0;
 
        for(int i=0; i<bodiesLen;i++)
        {
            for (int j = i + 1; j < bodiesLen; j++)
            {
                Body this_body = bodies[i];
                Body other_body = bodies[j];


                if (other_body != this_body)
                {

                    float r = Vector3.Distance(this_body.transform.position, other_body.transform.position);
                    avgRadius += r;


                    if (r < this_body.radius || r < other_body.radius)
                    {   

                        // For two bh and two stars
                        if (this_body.blackhole == other_body.blackhole)
                        {
                            Combine(this_body, other_body);
                            this_body.radius = ApproxMath.combinedSphereRadius(this_body.radius, other_body.radius);
                            this_body.transform.localScale = Vector3.one * this_body.radius * 2;
                            toDestroy.Add(other_body);


                            if (this_body.blackhole == 0)
                            {
                                double bv = ColourTools.bvFromMass((double)this_body.mass);
                                Colour starCol = ColourTools.colourFromBV(bv);
                                Material starMat = this_body.GetComponent<Renderer>().material;
                                starMat.EnableKeyword("_EMISSION");
                                starMat.SetColor("_EmissionColor", starCol);
                                starMat.SetFloat("_Luminosity", 1000000f);

                                float baseLumin = ApproxMath.massLuminosity(this_body.mass);  // this should depend on the star's mass. and should be a public varible tht is updated on collision rather than calc-ed at every update
                                StartCoroutine(UpdateLuminosity(this_body, baseLumin));
                            }
                        }

                        else // IF bodya.bh != bodyb.bh
                        {
                            if(other_body.blackhole == 1)
                            {
                                Combine(other_body, this_body);
                                toDestroy.Add(this_body);
                                other_body.radius = ApproxMath.schwarzschildRadius(other_body.mass);
                                other_body.transform.localScale = Vector3.one * other_body.radius * 2;
                            }

                            else
                            {
                                Combine(this_body, other_body);
                                toDestroy.Add(other_body);
                                this_body.radius = ApproxMath.schwarzschildRadius(this_body.mass);
                                this_body.transform.localScale = Vector3.one * this_body.radius * 2;

                            }
                        }
                    }
                }
            }
        }

        for (int i=0; i < toDestroy.Count; i++)
        {
            Body _body = toDestroy[i];
            bodies.Remove(_body);
            Destroy(_body.gameObject, 0);
        }

    }

    void Combine(Body this_body, Body other_body){

        float totmass = this_body.mass + other_body.mass;

        this_body.transform.position = (this_body.mass * this_body.position + other_body.mass * other_body.position)/totmass;

        this_body.velocity = (other_body.velocity*other_body.mass + this_body.velocity*this_body.mass)/(totmass);
        this_body.mass = totmass;
    }

    void logData()
    {
        DC.LogData(Time.time,bodies);
    }

    void OnApplicationQuit()
    {
        if (collectData)
        {
            DC.SaveData();
        }
    }

	IEnumerator UpdateLuminosity(Body star, float baseLumin)
    {
        float lumin = star.starMat.GetFloat("_Luminosity"); // this should be publiv var too
        while (lumin > baseLumin)
        { 
            lumin = lumin/2;
            Debug.Log(lumin);
            star.starMat.SetFloat("_Luminosity", lumin);
            yield return null;
        }
    }
}
