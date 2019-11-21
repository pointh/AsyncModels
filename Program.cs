using System;
using System.Threading;


namespace ThreadpoolAPM
{
    /// <summary>
    /// Threadpool async programming model
    /// </summary>
    class Program
    {
        // Delegát WaitCallback je definovaný s argumentem typu object
        public static void Print(object s)
        {
            Console.WriteLine(s);
        }
        static void Main(string[] args)
        {
            WaitCallback wc = Print;

            ThreadPool.GetMaxThreads(out int nThreads, out int nCompletionPortThreads);
            Console.WriteLine($"Začátek: Maximálně {nThreads} vláken ve threadpoolu, maximálně {nCompletionPortThreads} I/O vláken v threadpoolu");

            // Skončí v náhodném pořadí
            ThreadPool.QueueUserWorkItem(wc, "1");
            ThreadPool.QueueUserWorkItem(wc, "2");
            ThreadPool.QueueUserWorkItem(wc, "3");
            ThreadPool.QueueUserWorkItem(wc, "4");
            ThreadPool.QueueUserWorkItem(wc, "5");

            Console.ReadKey();
        }
    }
}
