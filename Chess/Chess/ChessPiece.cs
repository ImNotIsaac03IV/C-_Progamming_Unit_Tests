/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: ChessGame
*--------------------------------------------------------------
*/

using System;

namespace Chess;

//1 König - King
//2 Dame - Queen
//3 Turm - Rook
//4 Läufer - Bishop
//5 Springer - Knight
//6 Bauer - Pawn

//TODO Implement ChessPiece (Datenkapsel) here
public class ChessPiece
{
    public const int King = 1;
    public const int Queen = 2;
    public const int Rook = 3;
    public const int Bishop = 4;
    public const int Knight = 5;
    public const int Pawn = 6;

    private int _row;
    private int _column;
    private int _type;
    private bool _isBlack;

    public int Row
    {
        set { _row = value; }
        get { return _row; }
    }
    public int Col
    {
        set { _column = value; }
        get { return _column; }
    }
    public int Type
    {
        set { _type = value; }
        get { return _type; }
    }
    public bool IsBlack
    {
        set { _isBlack = value; }
        get { return _isBlack; }
    }
}