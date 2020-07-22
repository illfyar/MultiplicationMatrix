using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiplicationMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Arrays arrays = new Arrays();
            int i = 0;
            while (!(arrays.Array1Full && arrays.Array2Full))
            {
                Thread.Sleep(10);
                Console.WriteLine("//////////////////////////" + i++);
            }
            Console.WriteLine("Массивы - множители  заполенны, " +
                "нажмите любу. клавишу для выполнения произведения");
            Console.ReadKey();
            i = 0;
            arrays.Multiplication(arrays.Matrix1, arrays.Matrix2,arrays.ResultMatrix);
            while (arrays.counFullPart < 4)
            {
                Thread.Sleep(10);
                Console.WriteLine("//////////////////////////" + i++);
            }
            Console.WriteLine("Умножение произведено");
            Console.ReadKey();
        }
    }
}
