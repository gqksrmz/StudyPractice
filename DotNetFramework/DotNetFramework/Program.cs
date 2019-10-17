using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Introduction = Wrox.ProCSharp.Basics;
namespace DotNetFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            Introduction::NamespaceExamle NSEx = new Introduction::NamespaceExamle();
            Console.WriteLine(NSEx.GetNamespace());
            Console.ReadLine();
        }
    }
}
namespace Wrox.ProCSharp.Basics
{
    class NamespaceExamle
    {
        public string GetNamespace()
        {
            return this.GetType().Namespace;
        }
    }
}