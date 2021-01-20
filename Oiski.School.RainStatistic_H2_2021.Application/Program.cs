using System;

namespace Oiski.School.RainStatistic_H2_2021.Application
{
    class Program
    {
        static void Main (string[] args)
        {
            RainDropContainer calc = new RainDropContainer(5);

            decimal[] values = new decimal[2];
            for ( int i = 0; i < values.Length; i++ )
            {
                values[i] = i + 1;
            }

            calc.AddRange(6, values);

            foreach ( var item in calc.ValuePool )
            {
                Console.Write(item);
            }
        }
    }
}
