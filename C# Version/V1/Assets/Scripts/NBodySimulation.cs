using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NBodySimulation : MonoBehaviour
{

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
                    // distance between bodies
                    float r = Vector3.Distance(this_body.transform.position, other_body.transform.position);

                    if (r < this_body.scale)
                    {
                        other_body.mass += this_body.mass;
                        other_body.transform.Translate((this_body.transform.position - other_body.transform.position) / 2);
                        this_body.velocity += other_body.velocity;
                        to_destroy.Add(this_body);

                    }
                }
            }
        }

        foreach (Body _body in to_destroy)
        {
            bodies.Remove(_body);
            Destroy(_body.gameObject, 0);
        }

    }
}
