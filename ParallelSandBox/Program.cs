using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace ParallelSandBox
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Thread thread1 = new Thread (new ThreadStart (FirstThread));
           Thread thread2 = new Thread(new ThreadStart(SecondThread));
           Thread thread3 = new Thread(new ThreadStart(ThirdThread));
            thread1.Start();
            thread2.Start();
            thread3.Start();
            Console.WriteLine("Главный поток молчит");
            Console.WriteLine("Завершение главного потока");
            Console.ReadLine();
        }
        static void FirstThread()
        {
            for (int i = 0; i < 200; i++)
            {
                Console.WriteLine("Первый поток");
            }
        }
        static void SecondThread()
        {
            for (int i = 0; i < 200; i++)
            {
                Console.WriteLine("Второй поток");
            }
        }
        static void ThirdThread()
        {
            for (int i = 0; i < 200; i++)
            {
                Console.WriteLine("Третий поток");
            }
        }
    }
}
