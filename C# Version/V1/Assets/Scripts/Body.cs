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

	private Vector3 position;

	private Material starMat;


	public void init(float inpmass, Vector3 inpinitialVelocity, float inpRadius, int bh)
	{
		blackhole = bh;
		mass = inpmass;
		velocity = inpinitialVelocity;
		radius = inpRadius;
		transform.localScale = Vector3.one * inpRadius * 2;
		position = transform.position;

		double bv = ColourTools.bvFromMass((double)inpmass);
		// Debug.Log(bv);
		starMat = GetComponent<Renderer>().material;
        Colour starCol = ColourTools.colourFromBV(bv);
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
				float r = Vector3.Distance(this.position, _body.position);
				// part of grav formula
				Vector3 F = -(mass * _body.mass) * (this.position - _body.position) / (r * r * r);
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
	// public void UpdateLuminosity(){ 

	// 	if (this.blackhole == 0){ // blackholes dont have shader, horrible doing this check every update though
	// 		float baseLumin = 1000f;  // this should be a functino of the star's mass. and should be a public varible tht is updated on collision rather than calc-ed at every update
	// 		float lumin = starMat.GetFloat("_Luminosity"); // this should be publiv var too

	// 		if ( lumin > baseLumin){ //reduce by an exponetial amount
	// 			lumin /= 2;
	// 			starMat.SetFloat("_Luminosity", lumin);
	// 		}

	// 	}

	// }

	
}