////.Net 6

using System.Threading;

MyClass MyClass = new MyClass();

MyClass.SomeMethod(ItPrints);
Thread.Sleep(30);
MyClass.SomeMethod(ItPrintsOverLoad);
Thread.Sleep(120);
MyClass.SomeMethod(ItPrints);
Thread.Sleep(100);
MyClass.SomeMethod(ItPrintsOverLoad);
Thread.Sleep(200);
MyClass.SomeMethod(ItPrints);

void ItPrints(int i)
{
    Console.WriteLine("I: "+i);
}
void ItPrintsOverLoad(int i, int j)
{
    Console.WriteLine("I: " + i+ " J: " + j);
}


/*
 1. As long as MyClass object is their, it will keep all it's states
 */

public class MyClass
{
    int i = 0;
    int j = 0;
    public delegate void CallBack(int i);
    public delegate void CallBackOverLoad(int i,int j);

    public MyClass()
    {
        RunTheThread();
    }
    public void RunTheThread()
    {
        Task.Run(() =>
        {
            //DO Something in thread

            for (;; i++)
            {
                Thread.Sleep(10);
            }
        });
    }
    
    
    public void SomeMethod(CallBack obj)
    {
        //for(int i = 0; i < 1000; i++)
        //{
            //Thread.Sleep(10);
            //Console.WriteLine(i);
            obj(i);
        //}
        //i++;
    }
    public void SomeMethod(CallBackOverLoad obj)
    {
        obj(i,j);
        //i++;
        j++;
    }
}
