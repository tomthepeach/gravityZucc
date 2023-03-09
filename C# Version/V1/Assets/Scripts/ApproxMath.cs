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
        return (float)pow((vol1 + vol2) * 3/(4 * Mathf.PI), 1.0f / 3.0f);
    }

    public static float beta(float a, float b) 
    {
        // a, b greater-than 0
        float alpha = a + b;
        float beta = 0.0f;
        float u1, u2, w, v = 0.0f;

        if (Mathf.Min(a, b) <= 1.0f) beta = Mathf.Max(1 / a, 1 / b);
        else beta = Mathf.Sqrt((alpha - 2.0f) / (2 * a * b - alpha));

        float gamma = a + 1 / beta;

        while (true)
        {
            u1 = Random.value;
            u2 = Random.value;
            v = beta * Mathf.Log(u1 / (1 - u1));
            w = a * Mathf.Exp(v);

            float tmp = Mathf.Log(alpha / (b + w));

            if (alpha * tmp + (gamma * v) - 1.3862944 >= Mathf.Log(u1 * u1 * u2)) break;
        }

        float x = w / (b + w);
        return x;
    } 

    public static float schwarzschildRadius(float mass)
    {
        const double c = 299792458.0;
        const double smass = 1.989e30;
        const double G = 6.67e-11;
        return (float)(2.0d*smass*(double)mass*G/(c*c));
    }

}