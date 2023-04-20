using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is the class used to store the constants between scenes.
public class MenuSettings : MonoBehaviour
{
    public static int numStars = 60;
    public static float timeWarp = 20f;
    public static float shootSpeed = 100;
    public static float shootMass = 10f;
    public static int type = 0;
    public static float BHMass = 1000f;
    public static float clusterMass = 1000f;
    public static float clusterRadius = 2000f;

    public static int skybox = 1;

    public static double e = 2.71828;
    public static float MassSliderExpo(float x){
        return (float) ApproxMath.pow(e,((double)x/13.4f));
    }

}
