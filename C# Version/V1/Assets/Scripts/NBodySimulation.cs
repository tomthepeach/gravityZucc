using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NBodySimulation : MonoBehaviour
{

    // public List<float> kes;
    // public List<float> pes;
    // public List<float> totes;

    float tot_ke;
    float tot_pe;

    public GameObject bhPrefab;
    
    List<Body> bodies;
    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Body[] bodyarr = FindObjectsOfType<Body>();
        bodies = new List<Body>(bodyarr);


        foreach (Body body in bodies)
        {
            // Debug.Log("update vel");
            tot_ke += body.ke;
            tot_pe += body.pe;
            body.UpdateVelocity(bodies);
        }


        foreach (Body body in bodies)
        {
            // Debug.Log("update pos");
            body.UpdatePosition();
        }


        List<Body> to_destroy = new List<Body>();
        int len = bodies.Count;
        float avgRadius = 0;

        for(int i=0; i<len;i++)
        {
            for (int j = i + 1; j < len; j++)
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
                        if (this_body.blackhole == other_body.blackhole){
                            Combine(this_body, other_body);
                            this_body.radius = ApproxMath.combinedSphereRadius(this_body.radius, other_body.radius);
                            this_body.transform.localScale = Vector3.one * this_body.radius * 2;
                            to_destroy.Add(other_body);

                            
                        }
                        else // IF bodya.bh != bodyb.bh
                        {
                            switch (this_body.blackhole){
                                
                                case 0: Combine(other_body, this_body);
                                    to_destroy.Add(this_body);
                                    other_body.radius = ApproxMath.schwarzschildRadius(other_body.mass);
                                    other_body.transform.localScale = Vector3.one * other_body.radius * 2;
                                    break;

                                case 1: Combine(this_body, other_body);
                                    to_destroy.Add(other_body);
                                    this_body.radius = ApproxMath.schwarzschildRadius(this_body.mass);
                                    this_body.transform.localScale = Vector3.one * this_body.radius * 2;
                                    break;
                                    
                            }
                        }
                    }
                }
            }
        }

        foreach (Body _body in to_destroy)
        {
            bodies.Remove(_body);
            Destroy(_body.gameObject, 0);
        }


    // kes.Add(tot_ke);
    // pes.Add(tot_pe);
    // totes.Add(tot_ke + tot_pe);
    avgRadius /= len;
    // Debug.Log(avgRadius);
    // Debug.Log(tot_pe);
    tot_ke = 0;
    tot_pe = 0;

    }



    void Combine(Body this_body, Body other_body){

        float distance = Vector3.Distance(this_body.transform.position, other_body.transform.position);
        Vector3 dir = (other_body.transform.position - this_body.transform.position).normalized;
        float totmass = this_body.mass + other_body.mass;
        this_body.transform.Translate(dir * distance*this_body.mass/(totmass));
        this_body.velocity = (other_body.velocity*other_body.mass + this_body.velocity*this_body.mass)/(totmass);
        this_body.mass = totmass;

        //GetComponent<Renderer>().material.BaseColor = new Color(0, 255, 0);
       
    }





}
