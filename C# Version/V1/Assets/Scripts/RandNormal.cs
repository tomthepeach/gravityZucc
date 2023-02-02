using Random = UnityEngine.Random;
using Mathf = UnityEngine.Mathf;

public class RandomNormal
{
    public float value(float mean = 0.0f, float stdDev = 1.0f)
    {
        //Box-Muller transform
        float u1 = 1.0f - Random.value; //uniform(0,1] random doubles
        float u2 = 1.0f - Random.value;
        float randStdNormal = Mathf.Sqrt(-2.0f * Mathf.Log(u1)) * Mathf.Sin(2.0f * Mathf.PI * u2); //random normal(0,1)
        float result = mean + stdDev * randStdNormal; //random normal(mean,stdDev^2)
        return result;
    }

}
