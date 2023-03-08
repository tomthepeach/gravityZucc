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


    public static float combinedSphereRadius(float r1, float r2)
    {
        float vol1 = (4.0f / 3.0f) * Mathf.PI * r1 * r1 * r1;
        float vol2 = (4.0f / 3.0f) * Mathf.PI * r2 * r2 * r2;
        return (float)pow((vol1 + vol2) * 3/(4 * Math.PI), 1.0f / 3.0f);
    }

    public static float boundedGaussian(float mean = 0.0f, float stdDev = 1.0f, float min = 0.0f, float max = 1.0f)
    {
        float result = gaussian(mean, stdDev);
        while(max < result || result < min)
        {
            result = gaussian(mean, stdDev);
        }
        return result;
    }

    public static float schwarzschildRadius(float mass)
    {
        const float scaler = 1e6f;
        return (2.0f *scaler * Constants.SOLAR_MASS * mass * Constants.BIGG /(Constants.C * Constants.C * Constants.AU));
    }

}
