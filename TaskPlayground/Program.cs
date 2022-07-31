// See https://aka.ms/new-console-template for more information
using TaskPlayground;

Console.WriteLine("Hello, World!");

TaskPool taskPool = new TaskPool();
//taskPool.ExecSingleTask();
taskPool.ExecTplForLoop();