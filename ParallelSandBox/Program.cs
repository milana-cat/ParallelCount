using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics;


namespace ParallelSandBox
{

    internal class Program
    {
        private static long sum = 0;
        private static  object lockObject = new object();

        static void Main(string[] args)
        {
            int N = 1;
            while (N != 0)
            {
                sum = 0;
                lockObject = new object();
                Console.Write("Введите число N: ");
                N = int.Parse(Console.ReadLine());
                Console.Write("Введите количество потоков: ");
                int numberOfThreads = int.Parse(Console.ReadLine());


                Thread[] threads = new Thread[numberOfThreads];
                int range = N / numberOfThreads;
                Stopwatch sw = new Stopwatch();
                sw.Start();
                for (int i = 0; i < numberOfThreads; i++)
                {
                    int start = i * range + 1;
                    int end = (i == numberOfThreads - 1) ? N : (i + 1) * range;

                    threads[i] = new Thread(() => SumRange(start, end));
                    threads[i].Start();
                }

                // Ожидание завершения всех потоков
                for (int i = 0; i < numberOfThreads; i++)
                {
                    threads[i].Join();
                }
                sw.Stop();
                long ticksForBuilder = sw.ElapsedMilliseconds;
                Console.WriteLine("Производительность = " + ticksForBuilder);
                sw.Reset();
                Console.WriteLine($"Сумма всех чисел от 1 до {N} равна {sum}");
                Console.ReadKey();
            }
        }

        static void SumRange(int start, int end)
        {
            long localSum = 0;

            for (int i = start; i <= end; i++)
            {
                localSum += i;
            }

            // Блокировка для безопасного доступа к переменной sum
            lock (lockObject)
            {
                sum += localSum;
            }
        }

    }
}
