using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    [SerializeField] GameObject bhPrefab, shootPoint, starPrefab;

    public void Shoot()
    {
        //Need to add randomised masses and sizes here
        if (SceneConstants.type == 1){
            float bhMass = SceneConstants.shootMass;
            GameObject bh = Instantiate(bhPrefab);
            bh.transform.position = shootPoint.transform.position;
            bh.GetComponent<Body>().init(bhMass, shootPoint.transform.forward * SceneConstants.shootSpeed, ApproxMath.schwarzschildRadius(bhMass), 1);

        }
        if (SceneConstants.type == 0){

            float scaler = ApproxMath.beta(2f, 2f*120f/100);
            float inpmass = SceneConstants.shootMass;
            float starRadius = inpmass/6f;

            GameObject star = Instantiate(starPrefab);
            star.transform.position = shootPoint.transform.position;
            star.GetComponent<Body>().init(inpmass, shootPoint.transform.forward * SceneConstants.shootSpeed, starRadius,0);
        }
    }
}
