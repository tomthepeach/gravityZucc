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
            body.UpdateVelocity(bodies, Time.fixedDeltaTime);
        }

        foreach (Body body in bodies)
        {
            // Debug.Log("update pos");
            body.UpdatePosition(Time.fixedDeltaTime);
        }

        List<Body> to_destroy = new List<Body>();
        int len = bodies.Count;

        for(int i=0; i<len;i++)
        {
            for (int j = i + 1; j < len; j++)
            {
                Body this_body = bodies[i];
                Body other_body = bodies[j];


                if (other_body != this_body)
                {
                    if (this_body.mass >= other_body.mass)
                    {

                        float r = Vector3.Distance(this_body.transform.position, other_body.transform.position);

                        if (r < this_body.scale/4)
                        {   
                            Vector3 avg_pos = (this_body.transform.position - other_body.transform.position) / 2;
                            this_body.transform.Translate(avg_pos);
                            float totmass = this_body.mass + other_body.mass;

                            this_body.velocity = (other_body.velocity*other_body.mass + this_body.velocity*this_body.mass)/(totmass);

                            this_body.mass = totmass;
                            this_body.scale = (float) ApproxMath.pow(totmass,0.8);
                            this_body.transform.localScale = new Vector3(this_body.scale,this_body.scale,this_body.scale);


                            //GetComponent<Renderer>().material.BaseColor = new Color(0, 255, 0);
                            
                            to_destroy.Add(other_body);
                        }
                    }
                }
            }
        }
        

        foreach (Body body in bodies){
            if (body.blackhole == 0 && body.mass >= 10){
                //replace body with blackhole body
                float scale = (float)ApproxMath.pow(body.mass,0.2)/2;

                GameObject bh = Instantiate(bhPrefab);
                bh.transform.position = body.transform.position;
                bh.GetComponent<Body>().init(body.mass, body.velocity, scale,1);
                
                to_destroy.Add(body);
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

    Debug.Log(tot_pe);
    tot_ke = 0;
    tot_pe = 0;
    }
}
