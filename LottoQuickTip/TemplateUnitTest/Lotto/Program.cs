/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *              Musterlösung-HA
 *--------------------------------------------------------------
 * Description: Lotto QuickTipp
 *--------------------------------------------------------------
 */
using System;

namespace Lotto
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lotto-Quicktip:");
            Console.WriteLine("*****************");

            for (int i = 0; i < 10; i++)
            {
                string quickTip = Lotto.TipToString(Lotto.QuickTip(45));
                Console.WriteLine($"{i + 1, 2}. Quick-Tip: {quickTip}");
            }
        }
    }
}