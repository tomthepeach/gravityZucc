using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Body : MonoBehaviour
{
	public Vector3 netForce = Vector3.zero;
	public Vector3 velocity = Vector3.zero;


	private const float GRAVITY_CONST = 1f;
	public float mass = 1f;
	public static float scale = 1f;

	public Vector3 scale3D = Vector3.one * scale;

	public static List<Body> Bodies;


	// Use this for initialization
	void Start()
	{
		if (Bodies == null)
			Bodies = new List<Body>();

		Bodies.Add(this);
		
	}

	// Update is called once per frame
	void FixedUpdate()
	{


		foreach (Body _body in Bodies.ToArray())
		{
			if (_body == this)
				continue;

			// distance between bodies
			float r = Vector3.Distance(transform.position, _body.transform.position);

			if (r < scale)
			{
				mass += _body.mass;
				transform.Translate((_body.transform.position - transform.position) / 2);
				Debug.Log("Here");
				velocity += _body.velocity;
				// size 

				Destroy(_body.gameObject, 0);
				Bodies.Remove(_body);

			}
		}



		foreach (Body _body in Bodies)
		{
			if (_body == this)
				continue;

			// distance between bodies
			float r = Vector3.Distance(transform.position, _body.transform.position);


			// part of grav formula
			float F_amp = (mass * _body.mass) / Mathf.Pow(r, 2);
			
			// dir 
			Vector3 dir = Vector3.Normalize(_body.transform.position - transform.position);

			Vector3 F = (dir * F_amp) * Time.fixedDeltaTime;
			netForce += F;

		}


		netForce *= GRAVITY_CONST;

		velocity += netForce * Time.fixedDeltaTime;

		transform.Translate(velocity);
		netForce = Vector3.zero;
	}
}