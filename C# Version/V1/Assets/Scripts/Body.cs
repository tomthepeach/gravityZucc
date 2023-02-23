using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Body : MonoBehaviour
{
	public Vector3 netForce = Vector3.zero;
	public Vector3 velocity = Vector3.zero;


	public float bigG = 1;//6.67E-11f;
	public float mass = 1;
	public float scale = 1;

	public void init(float inpmass, Vector3 inpinitialVelocity, Vector3 inpscale)
	{

		/*
		mass = inpmass;
		velocity = inpinitialVelocity;
		scale = inpscale.magnitude;
		transform.localScale = inpscale;
		*/
	}
	// Use this for initialization

	// Update is called once per frame
	public void UpdateVelocity(List<Body> Bodies, float timestep)
	{

		foreach (Body _body in Bodies)
		{
			if (_body != this)
			{
				// distance between bodies
				float r = Vector3.Distance(transform.position, _body.transform.position);

				// part of grav formula
				float F_amp = (mass * _body.mass) / Mathf.Pow(r, 2);
				
				// dir 
				Vector3 dir = Vector3.Normalize(_body.transform.position - transform.position);

				Vector3 F = (dir * F_amp);
				netForce += F;

			}
		}

		netForce *= bigG;
	
        velocity += netForce * Time.fixedDeltaTime;
                               
        netForce = Vector3.zero;
	
	}

	public void UpdatePosition(float timeStep)
	{
		// Debug.Log(velocity);
		transform.Translate(velocity*timeStep);
	}
}