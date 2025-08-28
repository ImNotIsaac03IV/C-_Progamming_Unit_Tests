/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung
*--------------------------------------------------------------
* Description: ChessGame
*--------------------------------------------------------------
*/

namespace Chess
{
    using System;
    using System.IO;

    public static class Chess
    {
        /// <summary>
        /// Read all chessPieces from a csv file into an array of "ChessPiece". 
        /// </summary>
        /// <param name="fileName">Csv file-name</param>
        /// <returns>The array or "ChessPiece".</returns>
        public static ChessPiece[] ReadFromCsv(string fileName)
        {
            string[] fileLines = File.ReadAllLines(fileName);
            string[][] fileContent = new string[fileLines.Length][];
            ChessPiece[] chessPieces = new ChessPiece[fileLines.Length - 1];

            for (int i = 0; i < fileLines.Length; i++)
            {
                fileContent[i] = fileLines[i].Split(';');
            }

            for (int i = 1; i < fileLines.Length; i++)
            {
                ChessPiece chessPiece = new ChessPiece();

                chessPiece.Row = GetRow(fileContent[i][0]);
                chessPiece.Col = GetCol(fileContent[i][0]);
                GetFigure(fileContent[i][1], chessPiece);
                if (fileContent[i][2] == "B")
                {
                    chessPiece.IsBlack = true;
                }
                else
                {
                    chessPiece.IsBlack = false;
                }

                chessPieces[i - 1] = chessPiece;
            }

            return chessPieces;
        }

        /// <summary>
        /// Print the field to the console.
        /// </summary>
        /// <param name="chessPieces"></param>
        public static void Print(ChessPiece[] chessPieces)
        {
            Console.Write("+");
            for (int i = 0; i < 8; i++)
            {
                Console.Write("---+");
            }

            Console.WriteLine();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    bool foundPiece = false;
                    ChessPiece? figurePosition = null;
                    for (int n = 0; n < chessPieces.Length; n++)
                    {
                        if (chessPieces[n].Row == i && chessPieces[n].Col == j && !foundPiece)
                        {
                            figurePosition = chessPieces[n];
                            foundPiece = true;
                        }
                    }
                    Console.Write("|");
                    if (figurePosition != null)
                    {
                        switch (figurePosition.Type)
                        {
                            case 1:
                                 Console.Write($"{" K",2}");
                            break;                     
                             case 2:                   
                                 Console.Write($"{" Q",2}");
                            break;                     
                             case 3:                   
                                 Console.Write($"{" R",2}");
                            break;                     
                             case 4:                   
                                 Console.Write($"{" B",2}");
                            break;                     
                             case 5:                   
                                 Console.Write($"{"KN",2}");
                            break;                     
                             case 6:                   
                                 Console.Write($"{" P",2}");
                            break;                     
                            default:
                                Console.Write("Invalid game figure");
                            break;
                        }

                        if (figurePosition.IsBlack)
                        {
                            Console.Write("B");
                        }
                        else
                        {
                            Console.Write("W");
                        }
                    }
                    else
                    {
                        Console.Write($"{"  ",3}");
                    }
                }
                Console.Write("|");
                Console.WriteLine();
                Console.Write("+");
                for (int m = 0; m < 8; m++)
                {
                    Console.Write("---+");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Create a field from a chessPiece array.
        /// </summary>
        /// <param name="chessPieces">The list of pieces.</param>
        /// <returns>valid field or null (if invalid).</returns>
        public static ChessPiece?[,]? CreateField(ChessPiece[] chessPieces)
        {
            ChessPiece[,] matrix = new ChessPiece[8, 8];

            for (int i = 0; i < chessPieces.Length; i++)
            {
                ChessPiece chessPiece = chessPieces[i];

                if (chessPiece.Row < 0 || chessPiece.Row > 7 || chessPiece.Col < 0 || chessPiece.Col > 7)
                {
                    return null;
                }

                if (matrix[chessPiece.Row, chessPiece.Col] != null)
                {
                    return null;
                }

                if (!Chess.IsValidPawnPosition(matrix, chessPiece))
                {
                    return null;
                }

                matrix[chessPiece.Row, chessPiece.Col] = chessPiece;
            }

            if (!IsValidPieceAmount(chessPieces))
            {
                return null;
            }

            return matrix;
        }
        public static bool IsValid(ChessPiece[] chessPieces)
        {
            return (CreateField(chessPieces) != null) && IsValidPieceAmount(chessPieces);
        }
        public static bool IsValidPieceAmount(ChessPiece[] chessPieces)
        {
            int whiteKings = 0, blackKings = 0;
            int whitePawns = 0, blackPawns = 0;
            int whiteQueens = 0, blackQueens = 0;
            int whiteKnight = 0, blackKnight = 0;

            for (int i = 0; i < chessPieces.Length; i++)
            {
                ChessPiece piece = chessPieces[i];
                
                switch (piece.Type)
                {
                    case ChessPiece.King:
                        if (piece.IsBlack)
                        {
                            blackKings++;
                        }
                        else
                        {
                            whiteKings++;
                        }
                    break;
                    case ChessPiece.Pawn:
                        if (piece.IsBlack)
                        {
                            blackPawns++;
                        }
                        else
                        {
                            whitePawns++;
                        }
                    break;
                    case ChessPiece.Queen:
                        if (piece.IsBlack)
                        {
                            blackQueens++;
                        }
                        else
                        {
                            whiteQueens++;
                        }
                    break;
                    case ChessPiece.Knight:
                        if (piece.IsBlack)
                        {
                            blackKnight++;
                        }
                        else
                        {
                            whiteKnight++;
                        }
                        break;
                }
            }

            if (whiteKings != 1 | blackKings != 1)
            {
                return false;
            }

            if (whitePawns > 8 || blackPawns > 8)
            {
                return false;
            }

            if (whiteQueens > 9 || blackQueens > 9)
            {
                return false;
            }

            if (whiteQueens == 9 && whitePawns > 0)
            {
                return false;
            }

            if (blackQueens == 9 && blackPawns > 0)
            {
                return false;
            }

            if (whiteKnight > 2 || blackKnight > 2)
            {
                return false;
            }

            if (!(blackPawns == 8 && blackQueens == 1))
            {
                return false;
            }

            if (!(whitePawns == 8 && whiteQueens == 1))
            {
                return false;
            }

            return true;
        }
        public static bool CanPlaceChessPiece(ChessPiece?[,] field, ChessPiece chessPiece)
        {
            if (chessPiece.Row < 0 || chessPiece.Row > 7 || chessPiece.Col < 0 || chessPiece.Col > 7)
            {
                return false;
            }

            if (field[chessPiece.Row, chessPiece.Col] != null)
            {
                return false;
            }

            if (!IsValidPawnPosition(field, chessPiece))
            {
                return false;
            }

            return true;
        }
        public static bool PlaceChessPiece(ChessPiece?[,] field, ChessPiece chessPiece)
        {
            if (CanPlaceChessPiece(field, chessPiece))
            {
                field[chessPiece.Row, chessPiece.Col] = chessPiece;
                return true;
            }

            return false;
        }
        public static bool IsValidPawnPosition(ChessPiece?[,] field, ChessPiece chessPiece)
        {
            if (chessPiece.Type != ChessPiece.Pawn)
            {
                return true;
            }

            if (!chessPiece.IsBlack && chessPiece.Row == 0)
            {
                return false;
            }

            if (chessPiece.IsBlack && chessPiece.Row == 7)
            {
                return false;
            }

            return true;
        }
        public static int GetRow(string input)
        {
            return input[1] - '1';
        }
        public static int GetCol(string input)
        {
            return input[0] - 'A';
        }
        public static void GetFigure(string figure, ChessPiece chessPiece)
        {
            switch (figure)
            {
                case "K":
                    chessPiece.Type = ChessPiece.King;
                break;
                case "Q":
                    chessPiece.Type = ChessPiece.Queen;
                break;
                case "R":
                    chessPiece.Type = ChessPiece.Rook;
                break;
                case "B":
                    chessPiece.Type = ChessPiece.Bishop;
                break;
                case "KN":
                    chessPiece.Type = ChessPiece.Knight;
                break;
                case "P":
                    chessPiece.Type = ChessPiece.Pawn;
                break;
            }
        }
    }
}