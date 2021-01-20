using System;

namespace Oiski.School.RainStatistic_H2_2021.Application
{
    class Program
    {
        static void Main (string[] args)
        {
            RainDropContainer calc = new RainDropContainer(5);

            for ( int i = 0; i < calc.ValuePool.Length; i++ )
            {
                calc.ValuePool[i] = i + 1;
                Console.Write(calc.ValuePool[i]);
            }

            Console.WriteLine();
            Console.WriteLine(calc.GetMaximum());
        }
    }
}
