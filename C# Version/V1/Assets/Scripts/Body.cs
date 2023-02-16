using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Body : MonoBehaviour
{
	public Vector3 netForce = Vector3.zero;
	public Vector3 velocity = Vector3.zero;


	public float bigG = 1.2E19f;
	public float mass;
	public float scale;

	public void init(float inpmass, Vector3 inpinitialVelocity, Vector3 inpscale)
	{
		mass = inpmass;
		velocity = inpinitialVelocity;
		scale = inpscale.magnitude;
		transform.localScale = inpscale;
		
	}
	// Use this for initialization

	// Update is called once per frame
	public void UpdateVelocity(List<Body> Bodies, float timestep)
	{
		// Debug.Log("Here");

		foreach (Body _body in Bodies.ToArray())
		{
			if (_body != this)
			{
				// distance between bodies
				float r = Vector3.Distance(transform.position, _body.transform.position);

				if (r < scale)
				{
					mass += _body.mass;
					transform.Translate((_body.transform.position - transform.position) / 2);
					// Debug.Log("Here");
					velocity += _body.velocity;
					// size 

					Destroy(_body.gameObject, 0);
					Bodies.Remove(_body);
				}
			}
		}


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

				Vector3 F = (dir * F_amp) * timestep;
				netForce += F;

			}
		}

		netForce *= bigG;
		// Debug.Log(netForce);
		// velocity += netForce * Time.fixedDeltaTime;
		velocity = Vector3.one;
		netForce = Vector3.zero;

	}

	public void UpdatePosition(float timeStep)
	{
		Debug.Log(velocity);
		transform.Translate(velocity);
	}
}