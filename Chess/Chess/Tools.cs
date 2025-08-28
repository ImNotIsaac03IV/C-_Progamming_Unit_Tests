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

public static class Tools
{
    public static bool Contains(int[] ar, int value)
    {
        foreach (var v in ar)
        {
            if (v == value)
            {
                return true;
            }
        }

        return false;
    }

    public static int ReadNumber(string message)
    {
        int  number;
        bool isOk;
        do
        {
            Console.Write(message);
            isOk = int.TryParse(Console.ReadLine(), out number);
        } while (!isOk);

        return number;
    }

    public static bool TryParse(string input, out int value, int max, int min)
    {
        input = input.Trim(' ');
        return int.TryParse(input, out value) && value >= min && value <= max;
    }

    public static bool InRange(int value, int max, int min)
    {
        return value >= min && value <= max;
    }
}