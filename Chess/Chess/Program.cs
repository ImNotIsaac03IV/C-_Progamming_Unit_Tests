/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung
*--------------------------------------------------------------
* Description: Chess
*--------------------------------------------------------------
*/

namespace Chess
{
    using System;

    public class Program
    {
        private const int FieldSize = 10;

        static void Main(string[] args)
        {
            Console.WriteLine("Chess Validator");
            Console.WriteLine("=====================");

            string fileName = "Game.csv";

            if (args.Length >= 1)
            {
                fileName = args[0];
            }

            Console.WriteLine($"Game from: {fileName}");
            Console.WriteLine();

            var chessPieces = Chess.ReadFromCsv(fileName);

            if (Chess.IsValid(chessPieces))
            {
                Chess.Print(chessPieces);
            }
            else
            {
                Console.WriteLine("The game definition is invalid!");
            }
        }
    }
}