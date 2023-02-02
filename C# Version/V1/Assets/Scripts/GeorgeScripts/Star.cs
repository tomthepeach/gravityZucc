using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    //Star
    public float radius;
    public float bigG = 1.2E19f;
    public float mass;

    // State
    public Vector3 position;
    public Vector3 velocity;


    // To update:
    Vector3 acceleration;
    Vector3 avgForce;

    // Cached
    Material material;
    Transform cachedTransform;


    void Awake()
    {
        material = transform.GetComponentInChildren<MeshRenderer>().material;
        cachedTransform = transform;
        mass = Random.Range(1, 1700);
    }

    public void Initialize()
    {
        position = cachedTransform.position;
        velocity = Vector3.zero;

    }

    void Update()
    {
       cachedTransform = transform;
        
    }

    public void UpdatePosition(float timeStep)
    {
        cachedTransform.position += (this.velocity * timeStep);
        position = cachedTransform.position;
    }
    

    public void UpdateVelocity(Star[] Stars, float timestep)
    {
        foreach (var star in Stars)
        {
            if (star != this)
            {
                Vector3 direction = star.position - position;
                float radius = direction.magnitude;
                Vector3 force = (bigG * mass * star.mass * direction.normalized) / (radius * radius);
                velocity += force * timestep;
            }
        }

    }


}