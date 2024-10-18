using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        Stopwatch sw = new Stopwatch();

        /*
        Console.WriteLine("inserire un numero massimo di iterazioni: ");
        long nmax= long.Parse(Console.ReadLine()!);
        */

        Process process = Process.GetCurrentProcess();
        Console.WriteLine($"Memoria utilizzata Prima: {process.PrivateMemorySize64}");

        Thread t1 = new Thread(Leibniz);
        Thread t2 = new Thread(Nilakantha);
        Thread t3 = new Thread(Arcocoseno);

        t1.Start();
        t2.Start();
        t3.Start();

        /*
        Console.WriteLine($"Pigreco: {Math.PI}");
        sw.Start();
        Console.WriteLine($"Pigreco Leibniz: {Leibniz}");
        sw.Stop();
        long leibniz = sw.ElapsedTicks/(Stopwatch.Frequency/(1000L * 1000L));

        sw = Stopwatch.StartNew();
        Console.WriteLine($"Pigreco Nilakantha: {Nilakantha}");
        sw.Stop();
        long nilakantha = sw.ElapsedTicks/(Stopwatch.Frequency/(1000L * 1000L));

        sw = Stopwatch.StartNew();
        Console.WriteLine($"Pigreco Arcocoseno: {Arcocoseno}");
        sw.Stop();
        long arcocoseno = sw.ElapsedTicks/(Stopwatch.Frequency/(1000L * 1000L));

        Console.WriteLine($"Tempo impiegato per leibniz: {leibniz}");
        Console.WriteLine($"Tempo impiegato per Nilakantha: {nilakantha}");
        Console.WriteLine($"Tempo impiegato per Arcocoseno: {arcocoseno}");
        */
    }

    public static void Leibniz()
    {
        Stopwatch sw = Stopwatch.StartNew();
        double somma = 4;
        double den = 3;
            
        for(int i = 1; i < 100000; i++)
        {
            if(i % 2 != 0)
            {
                somma -=4/den;
            }
            else 
            {
                somma += 4/den;
            }
            
            den += 2;
        }
        sw.Stop();
        long leibniz = sw.ElapsedTicks/(Stopwatch.Frequency/(1000L * 1000L));
        Console.WriteLine($"PI: {somma}");
        Console.WriteLine($"Tempo impiegato per leibniz: {leibniz}");
    }

    public static void Nilakantha()
    {
        Stopwatch sw = Stopwatch.StartNew();
        double somma = 3;
        double n = 2;

        for(int i = 1; i < 100000; i++)
        {
            if((i % 2) != 0)
            {
                somma += 4/(n*(n+1)*(n+2));
            }
            else
            {
                somma -= 4/(n*(n+1)*(n+2));
            }

            n += 2;
        }
        sw.Stop();
        long nilakantha = sw.ElapsedTicks/(Stopwatch.Frequency/(1000L * 1000L));
        Console.WriteLine($"PI: {somma}");
        Console.WriteLine($"Tempo impiegato per Nilakantha: {nilakantha}");
    }

    public static void Arcocoseno()
    {
        Stopwatch sw = Stopwatch.StartNew();
        double pi = 2*Math.Acos(0.0);
        sw.Stop();
        long arcocoseno = sw.ElapsedTicks/(Stopwatch.Frequency/(1000L * 1000L));
        Console.WriteLine($"PI: {pi}");
        Console.WriteLine($"Tempo impiegato per Arcocoseno: {arcocoseno}");
    }

}