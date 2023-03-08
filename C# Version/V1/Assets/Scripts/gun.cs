using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    [SerializeField] GameObject blackholePrefab, shootPoint;

    public void Shoot()
    {
        GameObject bh = Instantiate(blackholePrefab); //, shootPoint.transform.position);
        bh.transform.position = shootPoint.transform.position;
        bh.GetComponent<Body>().init(1000f, shootPoint.transform.forward * 25, 10f,0);
        
    }
}
