using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


class MyClass
{
    public int count = 0;//<=====

    private object thisLock = new object();


    public void Increase()
    {
        lock (thisLock) // Monitor.Enter(thisLock)
        {
            Console.WriteLine($"Before  ThreadID:{Thread.CurrentThread.GetHashCode()}  count:{count}");
            Thread.Sleep(500);//0.5s
            count = count + 1;
            Thread.Sleep(500);//0.5s
            Console.WriteLine($"After ThreadID:{Thread.CurrentThread.GetHashCode()}  count:{count}");
        }
        // Monitor.Exit(thisLock)
    }
}

class Program
{
    static void Main(string[] args)
    {
        MyClass obj = new MyClass();
        //Thread t1 = new Thread(new ThreadStart(obj.Increase));
        //Thread t2 = new Thread(new ThreadStart(obj.Increase));
        //Thread t3 = new Thread(new ThreadStart(obj.Increase));
        //t1.Start();
        //t2.Start();
        //t3.Start();

        //t1.Join();
        //t2.Join();
        //t3.Join();
        Parallel.For(0, 10, index =>
        {
            obj.Increase();
        });
        Console.WriteLine(obj.count);
    }
}