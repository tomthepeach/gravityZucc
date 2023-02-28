using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Body : MonoBehaviour
{
	public Vector3 netForce = Vector3.zero;
	public Vector3 velocity = Vector3.zero;
	float scalar_vel;
	public float ke;
	public float pe;


	public float bigG = 1;//6.67E-11f;
	public float mass = 1;
	public float scale = 1;

	public void init(float inpmass, Vector3 inpinitialVelocity, Vector3 inpscale)
	{
		
		mass = 1;//inpmass;
		velocity = inpinitialVelocity;
		scale = 1;//inpscale.magnitude;
		transform.localScale = Vector3.one;//inpscale;
		
	}

	// Update is called once per frame
	public void UpdateVelocity(List<Body> Bodies, float timestep)
	{
		Vector3 peV = Vector3.zero;
		float scalar_vel = velocity.magnitude;
		ke = scalar_vel * scalar_vel * 0.5f * mass;

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
				peV += F * r;
			}
		}
		
		peV *= bigG;

		pe = -peV.magnitude;

		netForce *= bigG;

        velocity += netForce/mass * Time.fixedDeltaTime;
             
        netForce = Vector3.zero;
	}

	public void UpdatePosition(float timeStep)
	{
		// Debug.Log(velocity);
		transform.Translate(velocity*timeStep);
	}


	public void CheckBlachole(){
		if (mass > 150){

		}
	}
}