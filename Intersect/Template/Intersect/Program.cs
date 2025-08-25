/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Method for intersection between two arrays  
*--------------------------------------------------------------
*/

using System;

namespace Intersect
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbersA = { 1, 3, 5, 7, 9 };
            int[] numbersB = { 0, 1, 2, 3 };
            Console.WriteLine(numbersA.Length);
            int[] thirdArray = IntersectTools.Intersect(numbersA, numbersB);

            Console.WriteLine("Ziffern Und");
            Console.WriteLine("===========");

            Console.Write("Feld A: ");
            foreach (int i in numbersA)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine();

            Console.Write("Feld B: ");
            foreach (int i in numbersB)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine();
            Console.WriteLine($"Ergebnis enthält {thirdArray.Length} Ziffern");
            Console.Write("Ziffern in Feld A und Feld B: ");
            foreach (int i in thirdArray)
            {
                Console.Write($"{i} ");
            }

            Console.ReadKey();
        }
    }
}