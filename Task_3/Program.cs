using System;
using System.Threading;

namespace Task_3
{
    internal class Program
    {
        delegate double ArrayHandler(int[] array);

        delegate int OutOnly();

        public static void Main(string[] args)
        {
            OutOnly random = () => new Random().Next();
            
            ArrayHandler average = delegate(int[] array)
            {
                int result = 0;
                foreach (int i in array) result += i;

                return result / (double) array.Length;
            };

            int[] randoms = new int[20];
            for (int i = 0; i < randoms.Length; i++)
            {
                randoms[i] = random();
                Console.WriteLine(randoms[i]);
                Thread.Sleep(100); //для генарції РІЗНИХ випадкових чисел
            }

            Console.WriteLine(average(randoms));
        }
    }
}