using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateTest
{
    //定义委托，它定义了可以代表的方法的类型
    //将方法作为方法的参数，将方法动态的赋给参数
    //减少在程序中使用大量if-else，使程序有更好的可拓展性
    public delegate void GreetingDelegate(string name);
    class Program
    {
        private static void EnglishGreeting(string name)
        {
            Console.WriteLine("Morning, " + name);
        }
        private static void ChineseGreeting(string name)
        {
            Console.WriteLine("早上好, " + name);
        }
        //接受一个GreetingDelegate类型的方法做参数
        private static void GreetPeople(string name,GreetingDelegate MakeGreeting)
        {
            MakeGreeting(name);
        }
        static void Main(string[] args)
        {
            /*
            GreetPeople("Danny", EnglishGreeting);
            GreetPeople("赵四", ChineseGreeting);
            Console.ReadKey();
            */

            /*
            string name1, name2;
            name1 = "Danny";
            name2 = "赵四";
            GreetPeople(name1, EnglishGreeting);
            GreetPeople(name2, ChineseGreeting);
            Console.ReadKey();
            */

            /*
            GreetingDelegate delegate1, delegate2;
            delegate1 = EnglishGreeting;
            delegate2 = ChineseGreeting;
            GreetPeople("Danny", delegate1);
            GreetPeople("赵四", delegate2);
            Console.ReadKey();
            */

            /* 将多个方法绑定到同一个委托
            GreetingDelegate delegate1;
            delegate1 = EnglishGreeting;    //先给委托类型的变量赋值
            delegate1 += ChineseGreeting;   //给此委托变量再绑定一个方法

            //先后调用EnglishGreeting与ChineseGreeting方法
            GreetPeople("Danny", delegate1);
            Console.ReadKey();
            */

            /* 也可以绕过GreetPeople方法，通过委托直接调用EnglishGreeting与ChineseGreeting方法
            GreetingDelegate delegate1;
            delegate1 = EnglishGreeting;
            delegate1 += ChineseGreeting;
            delegate1("Danny");
            Console.ReadKey();
            */

            GreetingDelegate delegate1 = new GreetingDelegate(EnglishGreeting);
            delegate1 += ChineseGreeting;

            //先后调用EnglishGreeting与ChineseGreeting方法
            GreetPeople("Danny", delegate1);
            Console.WriteLine();

            //取消对EnglishGreeting方法的绑定
            delegate1 -= EnglishGreeting;
            GreetPeople("赵四", delegate1);
            Console.ReadKey();
        }
    }
}
