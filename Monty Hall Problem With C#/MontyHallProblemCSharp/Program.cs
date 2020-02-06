using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontyHallProblemCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Control montyGame = new Control();
            Console.WriteLine(montyGame.Play());
            Console.Read();
        }
    }
}
