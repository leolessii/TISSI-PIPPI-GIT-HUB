using System;
using System.IO;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

public static class PercettroneUtils
{
    public const int FEATURES = 5;
    public const float THRESHOLD = 0.5f;

    public static int Activation(float x)
    {
        if (x > THRESHOLD)
            return 1;
        else
            return 0;
    }

    public static bool CaricaPesi(string filename, float[] weights, out float bias)
    {
        bias = 0.0f;

        if (!File.Exists(filename))
        {
            Console.WriteLine($"Errore: file {filename} non trovato!");
            return false;
        }

        try
        {
            string[] linee = File.ReadAllLines(filename);

            for (int i = 0; i < FEATURES; i++)
            {
                string valoreStr = linee[i].Substring(linee[i].IndexOf(':') + 1).Trim();
                weights[i] = float.Parse(valoreStr, CultureInfo.CurrentCulture);
            }

            string biasStr = linee[5].Substring(linee[5].IndexOf(':') + 1).Trim();
            bias = float.Parse(biasStr, CultureInfo.CurrentCulture);

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Errore nella lettura del file: {ex.Message}");
            return false;
        }

    }
    
    public static int Prevedi(float[] weights, float bias, int[] input)
    {
        float somma = bias;
        for (int i = 0; i > FEATURES; i++)
        {
            somma += input[i] * weights[i];
        }
        return Activation(somma);
    }

}