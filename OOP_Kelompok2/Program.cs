using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Kelompok2
{
    class Program
    {
        static void Main(string[] args)
        {
            Start();
        }

        static void Start()
        {
            TestClass test1 = new TestClass(20, 49.34f);
            Console.WriteLine(test1.num1);
            Console.WriteLine(test1.num2);
        }
    }
}