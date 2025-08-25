/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *              Musterlösung-HA
 *--------------------------------------------------------------
 * Description: Test a SV Number
 *--------------------------------------------------------------
 */

using System;

namespace SVNummerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Check a SV Number");
            Console.WriteLine("*********************");

            Console.Write("Please enter a SV Number: ");
            string input = Console.ReadLine();

            while (!ValidateInput(input))
            {
                if (SVNummer.IsSvNumberValid(input))
                {
                    Console.WriteLine($"The SV Number \"{input}\" is valid");
                }
                else
                {
                    Console.WriteLine($"The SV Number \"{input}\" is invalid");
                }

                Console.Write("Please enter a SV Number: ");
                input = Console.ReadLine();
            }
        }
        static bool ValidateInput(string input)
        {
            return String.IsNullOrEmpty(input);
        }
    }
}