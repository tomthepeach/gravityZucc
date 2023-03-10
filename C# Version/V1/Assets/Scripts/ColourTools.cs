using Colour = UnityEngine.Color;


public class ColourTools
{
    public static double bvFromMass(double mass)
    {
        // min = 0.1, max = 120
        // BV <-0.4,+2.0> [-] <- M <0.1,120> [M_sun]

        double bv;
        if (mass < 0.1) mass = 0.1;
        if (mass > 120) mass = 120;
        // map mass to bv linearly
        bv = 2.0 - (2.0 + 0.4) * (mass - 0.1) / (120 - 0.1);

        return bv;
    }

    public static Colour colourFromBV(double bv)
    {
        if (bv < -0.40) bv = -0.40;
        if (bv > 2.00) bv = 2.00;

        double r = 0.0;
        double g = 0.0;
        double b = 0.0;

        if (-0.40 <= bv && bv < 0.00)
        {
            double t = (bv + 0.40) / (0.00 + 0.40);
            r = 0.61 + (0.11 * t) + (0.1 * t * t);
        }
        else if (0.00 <= bv && bv < 0.40)
        {
            double t = (bv - 0.00) / (0.40 - 0.00);
            r = 0.83 + (0.17 * t);
        }
        else if (0.40 <= bv && bv < 2.10)
        {
            double t = (bv - 0.40) / (2.10 - 0.40);
            r = 1.00;
        }

        if (-0.40 <= bv && bv < 0.00)
        {
            double t = (bv + 0.40) / (0.00 + 0.40);
            g = 0.70 + (0.07 * t) + (0.1 * t * t);
        }
        else if (0.00 <= bv && bv < 0.40)
        {
            double t = (bv - 0.00) / (0.40 - 0.00);
            g = 0.87 + (0.11 * t);
        }
        else if (0.40 <= bv && bv < 1.60)
        {
            double t = (bv - 0.40) / (1.60 - 0.40);
            g = 0.98 - (0.16 * t);
        }
        else if (1.60 <= bv && bv < 2.00)
        {
            double t = (bv - 1.60) / (2.00 - 1.60);
            g = 0.82 - (0.5 * t * t);
        }

        if (-0.40 <= bv && bv < 0.40)
        {
            double t = (bv + 0.40) / (0.40 + 0.40);
            b = 1.00;
        }
        else if (0.40 <= bv && bv < 1.50)
        {
            double t = (bv - 0.40) / (1.50 - 0.40);
            b = 1.00 - (0.47 * t) + (0.1 * t * t);
        }
        else if (1.50 <= bv && bv < 1.94)
        {
            double t = (bv - 1.50) / (1.94 - 1.50);
            b = 0.63 - (0.6 * t * t);
        }
        return new Colour((float)r,(float)g,(float)b,1.0f);
    }
}
