using System;
using System.IO;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.ComponentModel.Design.Serialization;
using System.Reflection;
using System.Diagnostics.CodeAnalysis;

namespace Percettrone
{
    internal class Program
    {
        const int domande = 5;
        const double threshold = 0.5;
        const double learning_rate = 0.1;
        static double[] pesi = new double[domande] { 0.7, 0.6, 0.5, 0.3, 0.4 };
        static double bias = 0.0;
        

        static void Main(string[] args)
        {
            Console.WriteLine("A: addestrare, P: usalo");
            string scelta = Console.ReadLine();

            if (scelta == "p")
            {
                int[] input = new int[domande];
                Console.WriteLine("Artista famoso? (1=si, 0=No):");
                input[0] = int.Parse(Console.ReadLine());
                Console.WriteLine("Bel meteo? (1=si, 0=No):");
                input[1] = int.Parse(Console.ReadLine());
                Console.WriteLine("Viene un amico? (1=si, 0=No):");
                input[2] = int.Parse(Console.ReadLine());
                Console.WriteLine("Cibo? (1=si, 0=No):");
                input[3] = int.Parse(Console.ReadLine());
                Console.WriteLine("Bere? (1=si, 0=No):");
                input[4] = int.Parse(Console.ReadLine());

                int decisione = prevedi(input);

                if (decisione == 0)
                {
                    Console.WriteLine("Non andare");
                }
                else
                {
                    Console.WriteLine("Vai");
                }
            }
            else
            {
                StreamReader sr = new StreamReader("a.txt");
                
                int carattere;

                while (carattere = sr.Read() != -1)
                {
                    int[] input = new int[domande];
                    input[0] = carattere - 48;
                    input[1] = sr.Read() - 48;
                    input[2] = sr.Read() - 48;
                    input[3] = sr.Read() - 48;
                    input[4] = sr.Read() - 48;
                    int risosta = sr.Read() - 48;

                    double somma = bias;

                    for (int j = 0; j < domande; j++)
                    {
                        somma += input[j] * pesi[j];
                    }

                    int output = attivazione(somma);
                    int error = risposta - output;

                    for (int j = 0; j < domande; j++)
                    {
                        pesi[j] += learning_rate * error * input[j];
                    }

                    bias += learning_rate * error;
                }

                Console.WriteLine("pesi nuovi: " + pesi[0] + " " + pesi[1] + " " + pesi[2] + " " + pesi[3] + " " + pesi[4]);
            }
        }

        static int attivazione(double x)
        {
            if (x > threshold)
            {
                return 1;
            }
            else return 0;
        }
        
        static int prevedi (int[] input)
        {
            double somma = bias;

            for (int i = 0; i < domande; i++)
            {
                somma += input[i] * pesi[i];
            }
            return attivazione(somma);
        }
    }
}
