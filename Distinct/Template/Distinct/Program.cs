/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: (Array-)Distinct with UnitTests
*--------------------------------------------------------------
*/

namespace Distinct
{
    using System;
    using System.Diagnostics.Metrics;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Distinct");
            Console.WriteLine("**********************");
            Console.Write("Please enter the count of numbers: ");
            int size = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[size];

            array = DistinctTools.InsertValues(size);

            Console.Write("Input: ");
            DistinctTools.Spaces("Input");
            DistinctTools.ArrayOutput(array);

            if (!DistinctTools.IsDistinct(array))
            {
                Console.Write(" => The array is NOT distinct");
            }

            Console.WriteLine();

            Console.Write($"Distinct: ");
            DistinctTools.Spaces("Distinct");
            DistinctTools.ArrayOutput(DistinctTools.Distinct(array));

            Console.WriteLine();

            Console.Write("Duplicates: ");
            DistinctTools.Spaces("Duplicates");
            DistinctTools.ArrayOutput(DistinctTools.Duplicate(array));

            Console.WriteLine();

            Console.ReadKey();
        }
    }
}