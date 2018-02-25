using System;

namespace TaskLockTest
{
    class Program
    {
        /// <summary>
        /// Some vague set of tests
        /// </summary>
        static void Main(string[] args)
        {
            var t = new Test();

            Console.WriteLine("(1) ----------------------------");

            for (var i = 0; i < 100; i++)
            {
                t.Do(i);
            }

            Console.ReadLine();

            Console.WriteLine("(2) ----------------------------");

            for (var i = 0; i < 100; i++)
            {
                t.Do2(i);
            }

            Console.ReadLine();

            Console.WriteLine("(3) ----------------------------");

            for (var i = 0; i < 100; i++)
            {
                t.Do3(i);
            }

            Console.ReadLine();
        }
    }
}
