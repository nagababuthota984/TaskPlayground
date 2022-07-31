using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPlayground
{
    public class TaskPool
    {
        public async void ExecSingleTask()
        {
            Verbose(nameof(ExecSingleTask));
            await Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                    Console.WriteLine($"hey {i}");
            });
        }

        public async void  ExecTplForLoop()
        {
            Verbose(nameof(ExecTplForLoop));
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for(int i=0;i<100;i++)
            {
                Console.WriteLine($"hey {i}");
            }
            stopwatch.Stop();
            Console.WriteLine($"Standard for loop elapsed time - {stopwatch.Elapsed.TotalSeconds}");

            stopwatch.Reset();
            
            stopwatch.Start();
            Parallel.For(0,100,i =>
            {
                Console.WriteLine($"hey {i}");
            });
            stopwatch.Stop();
            Console.WriteLine($"Parallel for loop elapsed time - {stopwatch.Elapsed.TotalSeconds}");
            stopwatch.Reset();
        }

        public async void ExecParallelInvoke()
        {
            Verbose(nameof(ExecParallelInvoke));
            Parallel.Invoke(
                () =>
                {
                    Console.WriteLine("First task");
                },
                () =>
                {
                    Console.WriteLine("Second task");
                }
                );
        }

        public void Verbose(string methodName)
        {
            Console.WriteLine($"Enterring into Method  [{methodName}]");
            Console.WriteLine("\nMethod Result\n");
        }
    }
}
