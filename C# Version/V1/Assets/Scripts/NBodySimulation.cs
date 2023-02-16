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
            body.UpdateVelocity(bodies, Time.fixedDeltaTime);
        }
    }
}
