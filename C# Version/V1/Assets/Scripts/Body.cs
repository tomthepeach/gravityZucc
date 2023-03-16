using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Colour = UnityEngine.Color;



public class Body : MonoBehaviour
{
	public Vector3 netForce = Vector3.zero;
	public Vector3 velocity = Vector3.zero;

	public int blackhole = 0; // 1 for bh. 0 for star

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

	// Update is called once per frame
	public void UpdateVelocity(List<Body> Bodies)
	{
        netForce = Vector3.zero;

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
		
		
		netForce *= (Constants.BIGG);

        velocity += netForce/mass * Time.fixedDeltaTime;
             
	}

	public void UpdatePosition()
	{
		// Debug.Log(velocity);
		transform.Translate(velocity * Time.fixedDeltaTime);
	}

}