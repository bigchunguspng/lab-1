using System;

namespace Task_1
{
    internal class Program
    {
        delegate double ThreeIntegers(int a, int b, int c);

        public static void Main(string[] args)
        {
            ThreeIntegers average = delegate(int i, int i1, int i2)
            {
                return (i + i1 + i2) / 3d;
            };
            
            Console.WriteLine(average(-3, 3, 2));
        }
    }
}