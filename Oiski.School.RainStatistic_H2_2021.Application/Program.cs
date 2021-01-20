using System;

namespace Oiski.School.RainStatistic_H2_2021.Application
{
    class Program
    {
        static void Main (string[] args)
        {
            RainDropContainer container = null;

            int menuIndex = 0;
            do
            {
                Console.Clear();
                switch ( menuIndex )
                {
                    case 0: //  Main Menu
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Oiski's Raindrop Calc");
                            Console.WriteLine("1) Type Values");
                            Console.WriteLine("2) Print Results");
                        } while ( !int.TryParse(Console.ReadLine(), out menuIndex) || ( menuIndex < 1 || menuIndex > 2 ) );
                        
                        break;
                    case 1: //  Type Values Menu

                        int poolSize;
                        do
                        {
                            Console.Write("The Amount of Values: ");
                        } while ( !int.TryParse(Console.ReadLine(), out poolSize) );

                        container = new RainDropContainer(poolSize);

                        for ( int i = 0; i < container.ValuePool.Length; i++ )
                        {
                            decimal value;
                            do
                            {
                                Console.Write($"Value({i + 1}): ");

                            } while ( !decimal.TryParse(Console.ReadLine(), out value) );
                            container.ValuePool[i] = value;
                        }

                        menuIndex = 0;
                        break;

                    case 2: //  Print Result Menu
                        if ( container != null )
                        {
                            Console.WriteLine("|------------------------------------|");
                            for ( int i = 0; i < container.ValuePool.Length; i++ )
                            {
                                Console.Write(string.Format("{0,20}", $"Value({i + 1}): "));
                                Console.Write(string.Format("{0,5}", $"{container.ValuePool[i]}\n"));
                            }
                            Console.WriteLine("|------------------------------------|");

                            Console.Write(string.Format("{0,20}", $"Minimum: "));
                            Console.Write(string.Format("{0,5}", $"{container.GetMinimum()}\n"));

                            Console.Write(string.Format("{0,20}", $"Maximum: "));
                            Console.Write(string.Format("{0,5}", $"{container.GetMaximum()}\n"));

                            Console.Write(string.Format("{0,20}", $"Average: "));
                            Console.Write(string.Format("{0,5}", $"{container.GetAverage()}\n"));
                            Console.WriteLine("|------------------------------------|");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("There are no values in the pool");
                            Console.ResetColor();
                        }

                        Console.Write("Press any key...");
                        Console.Read();
                        menuIndex = 0;
                        break;
                }
            } while ( true );
        }
    }
}
