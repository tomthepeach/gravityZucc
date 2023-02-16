using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NBodySimulation : MonoBehaviour
{
    
    List<Body> bodies;
    // Start is called before the first frame update
    void Awake()
    {
        Body[] bodyarr = FindObjectsOfType<Body>();
        bodies = new List<Body>(bodyarr);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (Body body in bodies)
        {
            body.UpdateVelocity(bodies, Time.fixedDeltaTime);
        }

        foreach (Body body in bodies)
        {
            body.UpdateVelocity(bodies, Time.fixedDeltaTime);
        }
    }
}
