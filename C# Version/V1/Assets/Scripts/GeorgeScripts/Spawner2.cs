using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public GameObject obj;
	public int spawnCount = 100;

	public float numRounds = 1.0f;
	public int y_range = 10;
	public int noise = 10;
	public float radius = 1.0f;
	public float speed = 1.0f;

	void Awake()
	{
		
		//Double spiral
		for (int i = 0; i < spawnCount/2; i++)
		{
			float theta = ((2 * Mathf.PI * i) / spawnCount) * numRounds;
			float r = theta * theta;
			float x = radius * r * Mathf.Cos(theta);
			float z = radius * r * Mathf.Sin(theta);

			Vector3 pos;
			pos.x = x + Random.Range(-noise, noise);
			pos.z = z + Random.Range(-noise, noise);
			pos.y = 50 + Random.Range(-y_range, y_range);

			Vector3 origin = Vector3.zero;
			Vector3 heading = origin - pos;
			float dis = heading.magnitude;
			Vector3 dir = heading / heading.magnitude;

			Vector3 vel;
			vel.x = speed * dis * dir.z;
			vel.y = 0;
			vel.z = speed * dis * -dir.x;


			GameObject _go = (GameObject)Instantiate(obj, pos, transform.rotation);
			_go.GetComponent<Rigidbody>().velocity = vel;

		}

		for (int i = 0; i < spawnCount / 2; i++)
		{
			float theta = ((2 * Mathf.PI * i) / spawnCount) * numRounds;
			float r = theta * theta;
			float x = radius * r * Mathf.Cos(theta);
			float z = radius * r * Mathf.Sin(theta);

			Vector3 pos;
			pos.x = -x + Random.Range(-noise, noise);
			pos.z = -z + Random.Range(-noise, noise);
			pos.y = 50 + Random.Range(-y_range, y_range);

			Vector3 origin = Vector3.zero;
			Vector3 heading = origin - pos;
			float dis = heading.magnitude;
			Vector3 dir = heading / heading.magnitude;

			Vector3 vel;
			vel.x = speed * dis * dir.z;
			vel.y = 0;
			vel.z = speed * dis * -dir.x;


			GameObject _go = (GameObject)Instantiate(obj, pos, transform.rotation);
			_go.GetComponent<Rigidbody>().velocity = vel;

		}


	}
	
}