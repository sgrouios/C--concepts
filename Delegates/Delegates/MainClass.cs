using System;

namespace Delegates
{
    class MainClass
    {
        static void Main(string[] args)
        {
            Numbers set1 = new Numbers(3, 5);

            Calculate calc = new Calculate(Multiply);
            calc += Add;

            Func<int, int, int> calcFunc = new Func<int, int, int>(Multiply);
            calcFunc += Add;

            CalculateSet calcSet = new CalculateSet(Multiply);
            calcSet += Add;

            Func<Numbers, Numbers> calcSetFunc = new Func<Numbers, Numbers>(Multiply);
            calcSetFunc += Add;

            PerformCalculations(3, 5, calc);

            PerformSetCalculations(3, 5, calcSetFunc);

            Console.ReadKey();
            /*Console.WriteLine();
            int num1 = 3, num2 = 5;
            calc(3, 5);
            Console.WriteLine(num1);

            Console.WriteLine();
            calcSet(set1);
            Console.WriteLine(set1.num1);
            Console.Read();*/

        }

        public delegate int Calculate(int num1, int num2);
        
        public delegate Numbers CalculateSet(Numbers set);

        public static int Multiply(int num1, int num2)
        {
            Console.WriteLine("Multiply");
            num1 = num1 * num2;
            return num1;
        }

        public static int Add(int num1, int num2)
        {
            Console.WriteLine("Add");
            num1 = num1 + num2;
            return num1;
        }

        public static Numbers Multiply(Numbers set)
        {
            Console.WriteLine("Multiply set");
            set.num1 = set.num1 * set.num2;
            return set;
        }

        public static Numbers Add(Numbers set)
        {
            Console.WriteLine("Add set");
            set.num1 = set.num1 + set.num2;
            return set;
        }

        public static void PerformCalculations(int num1, int num2, Calculate calc)
        {
            Console.WriteLine(calc(num1, num2));
        }

        public static void PerformSetCalculations(int num1, int num2, Func<Numbers, Numbers> calc)
        {
            Console.WriteLine(calc(new Numbers(num1, num2)).num1);
        }

    }

    class Numbers
    {
        public int num1;
        public int num2;

        public Numbers(int num1, int num2)
        {
            this.num1 = num1;
            this.num2 = num2;
        }
    }
}
