using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiplicationMatrix
{
    class Arrays
    {
        Mutex Mutex { get; set; } = new Mutex();
        public bool Array1Full { get; set; } = false;
        public bool Array2Full { get; set; } = false;
        public int counFullPart { get; set; } = 0;
        public int[,] Matrix1 { get; set; } = new int[100, 100];
        public int[,] Matrix2 { get; set; } = new int[100, 100];
        public int[,] ResultMatrix { get; set; } = new int[100, 100];

        public Arrays()
        {
            FillArrays();
        }
        public async void FillArrays()
        {
            Array1Full = await FillArray(Matrix1);
            Array2Full = await FillArray(Matrix2);
        }
        public async Task<bool> FillArray(int[,] array)
        {
            Random random = new Random();
            return await Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    for (int j = 0; j < 100; j++)
                    {
                        array[i, j] = random.Next(1, 10);
                        Console.WriteLine($"fill {i} - {j}");
                    }
                }
                return true;
            });
        }
        public void Multiplication(int[,] a, int[,] b, int[,] c)
        {
            Parallel.Invoke(
                ()=> MultiplicationParallel(0, 25),
                ()=>MultiplicationParallel(25, 50),
                () => MultiplicationParallel(50, 75),
                () => MultiplicationParallel(75, 100)
                );
            void MultiplicationParallel(int minIndex,int maxIndex)
            {
                for (int i = minIndex; i < maxIndex; i++)
                {
                    for (int j = 0; j < 100; j++)
                    {
                        c[i, j] = a[i, j] * b[i, j];
                        Console.WriteLine($"{a[i, j]} * {b[i, j]} = {c[i, j]}");
                    }
                }
                Mutex.WaitOne();
                counFullPart++;
                Mutex.ReleaseMutex();
            }
        }
    }    
}
