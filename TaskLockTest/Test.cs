using Ratcow.Threading;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskLockTest
{
    internal class Test
    {
        AsyncLockObject locker = new AsyncLockObject();

        AsyncLock locker2 = new AsyncLock();

        public void Do(int i)
        {
            Task.Factory.StartNew(async () => 
            {
                var r = await AsyncMonitor.TryEnter(locker, 20);
                Console.WriteLine($"before {i} {r}");
                if (r)
                {
                    Console.WriteLine($"locked {i}");

                    try
                    {
                        Thread.Sleep(100);
                    }
                    finally
                    {
                        AsyncMonitor.Exit(locker);
                    }
                }
                else
                {
                    Console.WriteLine($"not locked {i}");
                }

            });
        }

        public void Do2(int i)
        {
            Task.Factory.StartNew(async () =>
            {
                var r = await AsyncMonitor.TryEnter(locker2, 20);
                Console.WriteLine($"before {i} {r}");
                if (r)
                {
                    Console.WriteLine($"locked {i}");

                    try
                    {
                        Thread.Sleep(100);
                    }
                    finally
                    {
                        AsyncMonitor.Exit(locker2);
                    }
                }
                else
                {
                    Console.WriteLine($"not locked {i}");
                }

            });
        }

        public void Do3(int i)
        {
            Task.Factory.StartNew(async () =>
            {
                var r = await locker2.Lock(20);
                Console.WriteLine($"before {i} {r}");
                if (r)
                {
                    Console.WriteLine($"locked {i}");

                    try
                    {
                        Thread.Sleep(100);
                    }
                    finally
                    {
                        locker2.Unlock();
                    }
                }
                else
                {
                    Console.WriteLine($"not locked {i}");
                }

            });
        }
    }
}
