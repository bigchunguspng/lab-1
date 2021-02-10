using System;
using System.Globalization;

namespace Task_2
{
    internal class Program
    {
        private delegate double Operation(double a, double b);

        private static readonly Operation Add = (a, b) => a + b;
        private static readonly Operation Sub = (a, b) => a - b;
        private static readonly Operation Mul = (a, b) => a * b;
        private static readonly Operation Div = (a, b) => b == 0 ? double.PositiveInfinity : a / b;

        private static double _num1 = 0, _num2;
        private static readonly char[] Operations = {'+', '-', '*', '/'};

        public static void Main(string[] args)
        {
            Say("Введіть вираз типу n + m");
            while (true)
            {
                string expression = Console.ReadLine();
                Operate(expression);
            }
        }

        private static void Operate(string expression)
        {
            expression = expression.Replace('.', ',').Replace(" ", "").Replace('\\', '/');
            if (expression.IndexOfAny(Operations) < 0) //якщо вираз не містить операцій
            {
                Say("Не знайдено операцій, спробуйте поставити +, -, * або / між числами");
                return;
            }

            string[] expr = expression.Split(Operations);
            _num1 = String.IsNullOrEmpty(expr[0]) ? _num1 : double.Parse(expr[0]);
            _num2 = double.Parse(expr[1]);
            byte operation = (byte) new string(Operations).IndexOf(expression[expression.IndexOfAny(Operations)]);

            double result = 0;
            switch (operation)
            {
                case 0:
                    result = Add(_num1, _num2);
                    break;
                case 1:
                    result = Sub(_num1, _num2);
                    break;
                case 2:
                    result = Mul(_num1, _num2);
                    break;
                case 3:
                    result = Div(_num1, _num2);
                    break;
            }

            _num1 = result;
            Say(_num1.ToString(CultureInfo.CurrentCulture));
        }

        private static void Say(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message.Replace('і', 'i'));
            Console.ResetColor();
        }
    }
}