/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *              Musterlösung-HA
 *--------------------------------------------------------------
 * Description: Method for Union and Except between two arrays
 *--------------------------------------------------------------
 */

using System;

namespace UnionExcept
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Union");
            Console.WriteLine("===========");
            Console.WriteLine("Normalfall");
            int[] feldA = { 1, 1, 3, 5, 7, 9, 1, 3, };
            int[] feldB = { 0, 1, 2, 3 };
            SetTools.PrintMessage(feldA, feldB, "union");

            Console.WriteLine("Alle gleich");
            feldA = new [] { 1, 1, 3, 5, };
            feldB = new[] { 1, 3, 3, 5, };
            SetTools.PrintMessage(feldA, feldB, "union");

            Console.WriteLine("Keine Überschneidung");
            feldA = new[] { 1, 3, 5, 7, 9 };
            feldB = new[] { 0, 2, 4, 6, 8 };
            SetTools.PrintMessage(feldA, feldB, "union");

            Console.WriteLine("Exept");
            Console.WriteLine("===========");
            Console.WriteLine("Normalfall");
            feldA = new [] { 1, 1, 3, 5, 7, 9, 1, 3, };
            feldB = new [] { 0, 1, 2, 3 };
            SetTools.PrintMessage(feldA, feldB, "except");

            Console.WriteLine("Alle gleich");
            feldA = new[] { 1, 1, 3, 5, };
            feldB = new[] { 1, 3, 3, 5, };
            SetTools.PrintMessage(feldA, feldB, "except");

            Console.WriteLine("Keine Überschneidung");
            feldA = new[] { 1, 3, 5, 7, 9 };
            feldB = new[] { 0, 2, 4, 6, 8 };
            SetTools.PrintMessage(feldA, feldB, "except");
        }
    }
}