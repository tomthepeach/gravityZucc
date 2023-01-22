using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NBodySimulation : MonoBehaviour
{
    PhysicsBody[] bodies;
    // Start is called before the first frame update
    void Awake()
    {
        bodies = FindObjectsOfType<PhysicsBody>();
        Time.timeScale = 10;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < bodies.Length; i++)
        {
            bodies[i].UpdateVelocity(bodies, Time.fixedDeltaTime);
        }
        for (int i = 0; i < bodies.Length; i++)
        {
            bodies[i].UpdatePosition(Time.fixedDeltaTime);
        }
    }
}
