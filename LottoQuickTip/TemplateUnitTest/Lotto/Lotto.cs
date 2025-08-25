/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *              Musterlösung-HA
 *--------------------------------------------------------------
 * Description: Lotto QuickTip
 *--------------------------------------------------------------
 */

using System;

namespace Lotto
{
    public static class Lotto
    {
        public static int[] QuickTip(int maxNo)
        {
            if (maxNo < 6)
            {
                return null;
            }

            int[] array = new int[6];

            for (int i = 0; i < array.Length; i++)
            {
                int value;
                do
                {
                    value = Random.Shared.Next(1, maxNo + 1);
                    array[i] = value;
                }
                while (Contains(array, i, value));
            }

            return SortArray(array);
        }
        public static string TipToString(int[] tip)
        {
            string output = "";

            for (int i = 0; i < tip.Length; i++)
            {
                if (i > 0)
                {
                    output += ",";
                }
                output += tip[i];
            }
            return output;
        }
        public static int[] SortArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
            return array;
        }
        public static bool Contains(int[] array, int count, int value)
        {
            for (int i = 0; i < count; i++)
            {
                if (array[i] == value)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
