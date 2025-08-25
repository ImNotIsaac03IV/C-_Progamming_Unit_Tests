/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung
*--------------------------------------------------------------
* Description: Gomoku
*--------------------------------------------------------------
*/

namespace Gomoku;

using System;
using System.IO;

public static class Gomoku
{
    public const string _fileName = "game.csv";

    /// <summary>
    ///     Executes the Gomoku program
    /// </summary>s
    public static void Run()
    {
        Console.WriteLine("Gomoku");
        Console.WriteLine("=========");

        Console.Write("Insert the size of the board [15, 17, or 19]: ");

        int boardSize = GetBoardLength();
        int[,] board = CreateBoard(boardSize);

        int currentPlayer = 0;

        bool gameWon = false;

        while (!gameWon)
        {
            PrintBoard(board);
            Console.WriteLine($"Player {currentPlayer + 1}'s turn!");
            Console.Write("Press \"S\" to save, \"L\" to load or \"!\" to surrender: ");
            string input = Console.ReadLine()!;

            if (input.ToLower() == "s")
            {
                SaveGame(board, _fileName);
                Console.WriteLine("Game saved");
            }
            else if (input.ToLower() == "l")
            {
                board = LoadGame(boardSize, _fileName);
                Console.WriteLine("Game loaded.");

                currentPlayer = GetPlayerTurn(board);
            }
            else if (input == "!")
            {
                PrintBoard(board);
                gameWon = true;
                currentPlayer = 1 - currentPlayer;
            }
            else
            {
                if (PlayersInput(input, board, currentPlayer))
                {
                    string[] parts = input.Split(',');

                    int row = int.Parse(parts[0]);
                    int col = int.Parse(parts[1]);

                    if (IsWinner(board, row, col))
                    {
                        PrintBoard(board);
                        gameWon = true;
                    }
                    else
                    {
                        currentPlayer = GetPlayerTurn(board);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid move, try again");
                    Console.WriteLine("Input format: [row,column]");
                }
            }

            Console.WriteLine();

        }

        Console.WriteLine($"Winner: Player {currentPlayer + 1} wins!");
        Console.WriteLine("Game over!");
    }
    public static int GetBoardLength()
    {
        int input;

        while (!int.TryParse(Console.ReadLine()!, out input) || !(input == 15 || input == 17 || input == 19))
        {
            Console.Write("Valid board sizes: 15, 17, 19: ");
        }

        return input;
    }
    public static void PrintBoard(int[,] board)
    {
        Console.Write("   ");

        for (int i = 0; i < board.GetLength(0); i++)
        {                                          
            Console.Write($"{i,3}");           
        }                                          
                                                   
        Console.WriteLine();                       
                                                   
        for (int i = 0; i < board.GetLength(0); i++)
        { 
            Console.Write($"{i,-3}");

            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (board[i, j] == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{"X",3}");
                    Console.ResetColor();
                }
                else if (board[i, j] == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{"O",3}");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write($"{".",3}");
                }
            }

            Console.WriteLine();
        }
    }
    public static int[,] CreateBoard(int boardSize)
    {
        int[,] board = new int[boardSize, boardSize];

        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                board[i, j] = -1;
            }
        }

        return board;
    }
    public static bool PlayersInput(string input, int[,] board, int player)
    {
        string[] parts = input.Split(',');

        if (parts.Length != 2)
        {
            return false;
        }

        if (int.TryParse(parts[0], out int row) && int.TryParse(parts[1], out int col))

        if (row >= 0 && row < board.GetLength(0) && 
            col >= 0 && col < board.GetLength(1))
        {
            return SetStone(board, row, col, player);
        }

        return false;
    }
    public static int GetPlayerTurn(int[,] board)
    {
        if (GetStoneCount(board) % 2 == 0)
        {
            return 0;
        }

        return 1;
    }

    /// <summary>
    /// Set a stone on the (game-)field.
    /// Row and col must be a empty position.
    /// </summary>
    /// <param name="field">The game field</param>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <param name="player">The player (0,1= who set the stone</param>
    /// <returns>true, if the user won the game, false otherwise</returns>
    public static bool SetStone(int[,] field, int row, int col, int player)
    {
        if (field[row, col] != -1)
        {
            return false;
        }
        else
        {
            field[row, col] = player;
        }

        return true;
    }

    /// <summary>
    /// Check, if after placing a stone, the player has won the game.
    /// Do not check all fields, only the surrounding fields of the new stone.
    /// </summary>
    /// <param name="field"></param>
    /// <param name="row">Row of the new stone.</param>
    /// <param name="col">Column of the new stone</param>
    /// <returns>true if 5 in any directions</returns>
    public static bool IsWinner(int[,] field, int row, int col)
    {
        int player = field[row, col];

        if (player == -1)
        {
            return false;
        }

        int[,] directions = new int[,]
        {
            { 0, 1 },
            { 1, 0 },
            { 1, 1 },
            { 1, -1 },
        };

        int numDirections = directions.GetLength(0);

        for (int i = 0; i < numDirections; i++)
        {
            int count = 1;

            int rowStep = directions[i, 0];
            int colStep = directions[i, 1];

            int rowDirection = row + rowStep;
            int colDirection = col + colStep;

            while (rowDirection >= 0 && rowDirection < field.GetLength(0) &&
                   colDirection >= 0 && colDirection < field.GetLength(1) &&
                   field[rowDirection, colDirection] == player)
            {
                count++;
                rowDirection = rowDirection + rowStep;
                colDirection = colDirection + colStep;
            }

            rowDirection = row - rowStep;
            colDirection = col - colStep;

            while (rowDirection >= 0 && rowDirection < field.GetLength(0) &&
                   colDirection >= 0 && colDirection < field.GetLength(1) &&
                   field[rowDirection, colDirection] == player)
            {
                count++;
                rowDirection = rowDirection - rowStep;
                colDirection = colDirection - colStep;
            }

            if (count >= 5)
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Count all stones on the field, independent of the player.
    /// </summary>
    /// <param name="field"></param>
    /// <returns>Count of stones on the field</returns>
    public static int GetStoneCount(int[,] field)
    {
        int stoneCount = 0;

        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                if (field[i, j] != -1)
                {
                    stoneCount++;
                }
            }
        }

        return stoneCount;
    }

    /// <summary>
    /// Save the current game to the specified file (as excel csv).
    /// </summary>
    /// <param name="field">the definition for the current game.</param>
    /// <param name="fileName">The destination filename.</param>
    public static void SaveGame(int[,] field, string fileName)
    {
        string[] lines = new string[GetStoneCount(field) + 1];
        int idx = 0;
        int move = 1;

        lines[idx] = $"No;Row;Col;Player";

        for (int row = 0; row < field.GetLength(0); row++)
        {
            for (int col = 0; col < field.GetLength(1); col++)
            {
                if (field[row, col] != -1)
                {
                    lines[idx + 1] = $"{move};{row};{col};{field[row, col]}";
                    move++;
                    idx++;
                }
            }
        }

        File.WriteAllLines(fileName, lines);
    }

    /// <summary>
    /// Load a stored game from a file (csv format).
    /// The file must be in a correct format (no validation check)
    /// and the boardSize must match.
    /// Errors are ignored
    /// </summary>
    /// <param name="boardSize">16,17 or 19</param>
    /// <param name="fileName">Source file-name.</param>
    /// <returns></returns>
    public static int[,] LoadGame(int boardSize, string fileName)
    {
        int[,] board = CreateBoard(boardSize);

        if (!File.Exists(fileName))
        {
            return board;
        }

        string[] line = File.ReadAllLines(fileName);

        for (int i = 1; i < line.Length; i++)
        {
            string[] parts = line[i].Split(';');

            if (parts.Length == 4 && 
                int.TryParse(parts[1], out int row) && 
                int.TryParse(parts[2], out int col) && 
                int.TryParse(parts[3], out int player))
            {
                board[row, col] = player;
            }
        }

        return board;
    }
}