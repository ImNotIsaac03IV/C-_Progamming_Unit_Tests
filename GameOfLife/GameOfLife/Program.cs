using System;

namespace GameOfLife
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Game of Life");
            Console.WriteLine("============");
            Console.WriteLine("Bei einer negativen Größe wird eine zufällige Welt mit der positiven Größe erstellt.");
            Console.Write("Größe des Spielfelds: [-100..100]: ");

            bool[,] gameOfLife = GameOfLife.CreateWorld(GameOfLife.ReadUserInput());

            gameOfLife = GameOfLife.FillWorld(gameOfLife);

            GameOfLife.PrintWorld(gameOfLife);

            Console.WriteLine();

            Console.WriteLine("Ausgangswelt: ");

            GameOfLife.GenerateWorld(gameOfLife);

            Console.WriteLine(); 

            Console.WriteLine("Start mit Eingabetaste...");

            Console.WriteLine();
            
            while (GameOfLife.ValidateInput())
            {
                gameOfLife = GameOfLife.CalculateNextGeneration(gameOfLife);

                GameOfLife.GenerateWorld(gameOfLife);

                Console.WriteLine();

                Console.Write("Eingabetaste für nächste Runde oder x für Ende: ");

                Console.WriteLine();
            }
        }
    }
}