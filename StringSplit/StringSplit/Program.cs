using System;

namespace StringSplit
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = "\"#419\",\"#Augy\",\"#Dedrick\",\"#636399072000000000\"";
            string[] split;

            split = line.Split(',');

            Console.WriteLine(line);

            foreach(string lines in split)
            {
                Console.WriteLine(lines);
            }
            
            Console.ReadLine();
        }
    }
}
