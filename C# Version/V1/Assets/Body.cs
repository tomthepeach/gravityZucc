using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public Rigidbody rb;

    void FixedUpdate ()
    {
        Body[] Bodies = FindObjectsOfType<Body>();
        foreach (Body otherBody in Bodies)
        {
            if (otherBody != this)
            {
                caclulateGravForce(otherBody);
            }
        }
    }
    void caclulateGravForce(Body otherBody)
    {
        // Calculate gravity
        Vector3 direction = rb.position - otherBody.rb.position;
        float distance = direction.magnitude;
        Vector3 force = direction.normalized * rb.mass * otherBody.rb.mass / (Mathf.Pow(distance, 2));

        otherBody.rb.AddForce(force);
    }
}
