using Random = UnityEngine.Random;
using Mathf = UnityEngine.Mathf;
using System;

public class ApproxMath
{
    public static float gaussian(float mean = 0.0f, float stdDev = 1.0f)
    {
        //Box-Muller transform
        float u1 = 1.0f - Random.value; //uniform(0,1] random doubles
        float u2 = 1.0f - Random.value;
        float randStdNormal = Mathf.Sqrt(-2.0f * Mathf.Log(u1)) * Mathf.Sin(2.0f * Mathf.PI * u2); //random normal(0,1)
        float result = mean + stdDev * randStdNormal; //random normal(mean,stdDev^2)
        return result;
    }

    public static double pow(double a, double b) 
    {
        int tmp = (int)(BitConverter.DoubleToInt64Bits(a) >> 32);
        int tmp2 = (int)(b * (tmp - 1072632447) + 1072632447);
        return BitConverter.Int64BitsToDouble(((long)tmp2) << 32);
    }

}