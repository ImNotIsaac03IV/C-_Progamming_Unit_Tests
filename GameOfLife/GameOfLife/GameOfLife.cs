/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: GameOfLife
* see: https://de.wikipedia.org/wiki/Conways_Spiel_des_Lebens
*--------------------------------------------------------------
*/

using System;

namespace GameOfLife
{
    public class GameOfLife
    {
        public static bool[,] CreateWorld(int size)
        {
            /*The 2D array uses the size input as columns and rows
            and generates a world filled with 0s*/
            bool[,] world = new bool[size, size];

            return world;
        }
        public static bool[,] FillWorld(bool[,] world)
        {
            //The matrix (world) is then looped through.
            /* world.GetLength(0) access the rows of my matrix
             Example: int[,] matrix = new int[5, 10]. It access the 5, so the 0th index of the 2D array*/
            for (int i = 0; i < world.GetLength(0); i++)
            {
                /* world.GetLength(1) access the rows of my matrix
                Example: int[,] matrix = new int[5, 10]. It acesses the 10, so the 1st index of the 2D array*/
                for (int j = 0; j < world.GetLength(1); j++)
                {
                    //This part generates a random value of 1s and 0s, filling the world with 1s and 0s
                    int value = Random.Shared.Next(0, 2);

                    world[i, j] = value == 1 ? true : false;
                }
            }
            return world;
        }
        public static int ReadUserInput()
        {
            //The methods validates the input of the user
            int input;
            //It'll repeat the while loop, everytime the input is not a number or is higher than 100 and lower than -100
            while (!int.TryParse(Console.ReadLine(), out input) || !(input < 100 && input > -100))
            {
                Console.Write("Enter a valid number: ");
            }
            /*If the input is valid, the program proceeds and moves here.
             It checks whether the input is negative, if it is, it generates a random world
            with the positive value of the negative input and returns it*/
            if (input < 0 && input > -100)
            {
                return input * -1;
            }
            //if the input is positive, the method simply returns it
            return input;
        }
        public static void PrintWorld(bool[,] gameOfLife)
        {
            //This method displays a matrix, with values 1s and 0s
            for (int i = 0; i < gameOfLife.GetLength(0); i++)
            {
                Console.Write($"{i + 1} Rows: ");
                for (int j = 0; j < gameOfLife.GetLength(1); j++)
                {
                    if (gameOfLife[i, j])
                    {
                        Console.Write(1);
                    }
                    else
                    {
                        Console.Write(0);
                    }
                }
                Console.WriteLine();
            }
        }
        public static void GenerateWorld(bool[,] gameOfLife)
        {
            /* This methods dispays the dead and living organism.
             My variable, which contains 0s and 1s is passed in.
            I loop through my variable with my for loops and print a "*",
            if the current value is 1, and " " space, if the current value is 0.
             */
            for (int i = 0; i < gameOfLife.GetLength(0); i++)
            {
                for (int j = 0; j < gameOfLife.GetLength(1); j++)
                {
                    if (gameOfLife[i, j])
                    {
                        Console.Write("x");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
        public static bool[,] CalculateNextGeneration(bool[,] gameOfLife)
        {
            /*In this method, I calculate the next living and dead organism and display them
            I create a new world and make the size of it the same as the size of my current matrix.*/
            bool[,] nextGeneration = new bool[gameOfLife.GetLength(0), gameOfLife.GetLength(1)];
            
            for (int i = 0; i < nextGeneration.GetLength(0); i++)
            {
                for (int j = 0; j < nextGeneration.GetLength(1); j++)
                {
                    bool isAlive = gameOfLife[i, j];
                    /*I loop through my matrix and count the amount of cells that surround one cell
                     and implement conways game of life*/
                    int liveNeighbours = CountNeighbours(gameOfLife, i, j);
                    //If a cell is alive and has less than 2 neighbours, it dies (underpopulation)
                    //If a cell is aliveand has more than 3 neighbours, it dies (overpopulation)
                    if (isAlive && (liveNeighbours < 2 || liveNeighbours > 3))
                    {
                        nextGeneration[i, j] = false;
                    }
                    //If a cell is alive and has exactly 2 or 3 neighbours, it stays alive
                    else if (isAlive && (liveNeighbours == 2 || liveNeighbours == 3))
                    {
                        nextGeneration[i, j] = true;
                    }
                    //If a cell is dead and has 3 neighbours, it gets revived
                    else if (!isAlive && liveNeighbours == 3)
                    {
                        nextGeneration[i, j] = true;
                    }
                    //Every other cell dies
                    else
                    {
                        nextGeneration[i, j] = false;
                    }
                }
            }

            return nextGeneration;
        }
        public static int CountNeighbours(bool[,] world, int targetRow, int targetCol)
        {
            //This method counts the amount of living neighbours in order to create the next generation
            int livingNeighbour = 0;
            //This projets the row of my matrix
            int rows = world.GetLength(0);
            //This projets the columns of my matrix
            int cols = world.GetLength(1);
            //I loop from -1 to =1 in order to check for neighbours left of my cell
            for (int x = -1; x <= 1; x++)
            {
                //I loop from -1 to =1 in order to check for neighbours above my cell
                for (int y = -1; y <= 1; y++)
                {
                    //If x and y are both 0, I skip the cell that I'm checking the neighbours of
                    if (x != 0 || y != 0)
                    {
                        /*If im on my first cell [0,0] and want to check it neighbours.
                        Assuming I start with the cell on the left of my current cell. I check x = -1 for it.
                        It'll go out of bound, so in order to wrap around it, I'll count the current cell, 
                        in this case 0, and the axis -1, with the amount of columns that I have 3, that will be 0 + (-1) + 3, that's 2,
                        so the position becomes the 2 of the column*/
                        int wrappedRow = (targetRow + x + rows) % rows;
                        int wrappedCol = (targetCol + y + cols) % cols;
                        //If the cell is alive, I increase the 
                        if (world[wrappedRow, wrappedCol])
                        {
                            livingNeighbour++;
                        }
                    }
                }
            }
            return livingNeighbour;
        }
        public static bool ValidateInput()
        {
            string input = Console.ReadLine();

            if (input.ToLower() == "x")
            {
                return false;
            }
            return true;
        }
    }
}