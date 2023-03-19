using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Colour = UnityEngine.Color;



public class Body : MonoBehaviour
{
	public Vector3 netForce = Vector3.zero;
	public Vector3 velocity = Vector3.zero;

	public int blackhole = 0; // Blackhole = 1 : Star = 0

	public float mass = 1;

	public float radius = 1;

	public void init(float inpmass, Vector3 inpinitialVelocity, float inpRadius, int bh)
	{
		blackhole = bh;
		mass = inpmass;
		velocity = inpinitialVelocity;
		radius = inpRadius;
		transform.localScale = Vector3.one * inpRadius * 2;

		double bv = ColourTools.bvFromMass((double)inpmass);
		// Debug.Log(bv);

        Colour starCol = ColourTools.colourFromBV(bv);
		Material starMat = GetComponent<Renderer>().material;
		starMat.EnableKeyword("_EMISSION");
		starMat.SetColor("_EmissionColor", starCol);


		
	}

	public void UpdateVelocity(List<Body> Bodies)
	{
        netForce = Vector3.zero;

		for (int i=0; i< Bodies.Count; i++)
		{
			Body _body = Bodies[i];

			if (_body != this)
			{
				// distance between bodies
				float r = Vector3.Distance(transform.position, _body.transform.position);

				// part of grav formula
				float F_amp = (mass * _body.mass) / (r * r);
				
				// dir 
				Vector3 dir = Vector3.Normalize(_body.transform.position - transform.position);

				Vector3 F = (dir * F_amp);
				netForce += F;
			}
		}
		
		netForce *= (Constants.BIGG);

        velocity += netForce/mass * Time.fixedDeltaTime;
             
	}

	public void UpdatePosition()
	{
		// Debug.Log(velocity);
		transform.Translate(velocity * Time.fixedDeltaTime);
	}


	// //Put this into update 
	// public void ControlLuminosity(){ 
	// 	Material starMat = GetComponent<Renderer>().material;
	// 	float threshold = 1000f;

	// 	while (starMat._Luminosity > threshold){
	// 		InvokeRepeating("reduceLumin",2);
	// 	}

	// }


}