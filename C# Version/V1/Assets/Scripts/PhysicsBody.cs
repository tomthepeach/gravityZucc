using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class PhysicsBody : MonoBehaviour 
{

    public float bigG = 1.2E19f;
    Rigidbody _rb;
    public float mass;
    public Vector3 initialVelocity;
    public Vector3 currentVelocity;
    public float radius;

    public void Init(float inpmass, Vector3 inpinitialVelocity, float inpradius)
    {
        mass = inpmass;
        initialVelocity = inpinitialVelocity;
        radius = inpradius;
    }

    void Start ()
    {
        _rb = GetComponent<Rigidbody> ();
        _rb.mass = mass;
        currentVelocity = initialVelocity;
    }

    public void UpdateVelocity(PhysicsBody[] Bodies, float timestep)
    {
        foreach (var otherbody in Bodies)
        {
            if (otherbody != this)
            {
                Vector3 direction = otherbody._rb.position - _rb.position;
                float radius = direction.magnitude;
                Vector3 acceleration = ( bigG  * otherbody._rb.mass * direction.normalized) / (radius*radius);
                currentVelocity += acceleration * timestep;
            }   
        }
    }

    public void UpdatePosition (float timeStep) 
    {
        _rb.MovePosition (_rb.position + currentVelocity * timeStep);
    }


    // void OnValidate () {
    //     mass = surfaceGravity * radius * radius / Universe.gravitationalConstant;
    //     meshHolder = transform.GetChild (0);
    //     meshHolder.localScale = Vector3.one * radius;
    //     gameObject.name = bodyName;
    // }

    public Rigidbody Rigidbody {
        get {
            return _rb;
        }
    }

    public Vector3 Position {
        get {
            return _rb.position;
        }
    }

}
