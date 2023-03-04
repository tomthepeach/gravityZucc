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

	public int blackhole = 0; // 1 for bh. 0 for star


	float bigG = 40f;
	public float mass = 1;

	public float radius = 1;

	public void init(float inpmass, Vector3 inpinitialVelocity, float inpRadius, int bh)
	{
		blackhole = bh;
		mass = inpmass;
		velocity = inpinitialVelocity;
		radius = inpRadius;
		transform.localScale = Vector3.one * inpRadius * 2;
		
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