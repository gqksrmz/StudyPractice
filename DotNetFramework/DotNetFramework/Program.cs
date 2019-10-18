using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DotNetFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
        }
    }

    public abstract class Calc<T>
    {
        public abstract T Add(T x, T y);
        public abstract T Sub(T x, T y);
    }
    public class IntCalc : Calc<int>
    {
        public override int Add(int x, int y)
        {
            return x + y;
        }
        public override int Sub(int x, int y)
        {
            return x - y;
        }
    }

}
