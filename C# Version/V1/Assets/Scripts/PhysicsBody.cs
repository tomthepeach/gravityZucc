using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class PhysicsBody : MonoBehaviour 
{

    public float radius;
    public float bigG = 1.2E19f;

    public Vector3 currentVelocity { get; private set; }

    public Vector3 velocity { get; private set; }
    Rigidbody _rb;

    void Start ()
    {
        _rb = GetComponent<Rigidbody> ();
        // _rb.velocity = new Vector3 (Random.Range (-100, 100), Random.Range (-100, 100), Random.Range (-100, 100));
        _rb.mass = Random.Range (1, 1700);
    }

    public void UpdateVelocity(PhysicsBody[] Bodies, float timestep)
    {
        foreach (var otherbody in Bodies)
        {
            if (otherbody != this)
            {
                Vector3 direction = otherbody._rb.position - _rb.position;
                float radius = direction.magnitude;
                Vector3 force = ( bigG * _rb.mass * otherbody._rb.mass * direction.normalized) / (radius*radius);
                _rb.velocity += force * timestep;
            }   
        }
    }

    public void UpdatePosition (float timeStep) 
    {
        _rb.MovePosition (_rb.position + _rb.velocity * timeStep);
    }

    public Rigidbody Rigidbody {
        get {
            return _rb;
        }
    }

    public Vector3 Position {get {return _rb.position;}}
}
