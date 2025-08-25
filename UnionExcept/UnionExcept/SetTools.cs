/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *              Musterlösung-HA
 *--------------------------------------------------------------
 * Description: Method for Union and Except between two arrays
 *--------------------------------------------------------------
 */

using System;

namespace UnionExcept
{
    public class SetTools
    {
        public static int[] Union(int[] firstArray, int[] secondArray)
        {
            int size = firstArray.Length + secondArray.Length;
            int[] modifiedArray = new int[size];
            int i;
            for (i = 0; i < size - secondArray.Length; i++)
            {
                modifiedArray[i] = firstArray[i];
            }
            int j = 0;
            for (; i < size; i++)
            {
                modifiedArray[i] = secondArray[j];
                j++;
            }
            return RemoveDuplicate(modifiedArray);
        }
        private static int[] RemoveDuplicate(int[] array)
        {
            int size = array.Length;
            int[] modifiedArray = new int[size];
            int index = 0;

            for (int i = 0; i < size; i++)
            {
                bool isSame = false;
                for (int j = 0; j < index; j++)
                {
                    if (array[i] == array[j])
                    {
                        isSame = true;
                    }
                }
                if (!isSame)
                {
                    bool alreadyAdded = false;

                    for (int n = 0; n < index; n++)
                    {
                        if (modifiedArray[n] == array[i])
                        {
                            alreadyAdded = true;
                        }
                    }
                    if (!alreadyAdded)
                    {
                        modifiedArray[index] = array[i];
                        index++;
                    }
                }
            }
            return ConcateZero(index, modifiedArray);
        }
        public static int[] Except(int[] firstArray, int[] secondArray)
        {
            int size = firstArray.Length + secondArray.Length;
            int[] modifiedArray = new int[size];
            int index = 0;

            for (int i = 0; i < firstArray.Length; i++)
            {
                bool isFirst = true;
                for (int j = 0; j < secondArray.Length; j++)
                {
                    if (firstArray[i] == secondArray[j])
                    {
                        isFirst = false;
                    }
                }
                if (isFirst)
                {
                    modifiedArray[index] = firstArray[i];
                    index++;
                }
            }
            int[] outputArray = RemoveDuplicate(modifiedArray);
            int[] result = ConcateZero(index,  outputArray);
            return result;
        }
        private static int[] ConcateZero(int size, int[] array)
        {
            int[] outputArray = new int[size];
            for (int i = 0; i < size; i++)
            {
                outputArray[i] = array[i];
            }
            return outputArray;
        }
        public static void PrintMessage(int[] firstArray, int[] secondArray, string methodName)
        {
            if (methodName.ToLower() == "union")
            {
                int[] array = Union(firstArray, secondArray);
                Console.Write("Feld A: ");
                foreach (int i in firstArray)
                {
                    Console.Write($"{i} ");
                }
                Console.WriteLine();
                Console.Write("Feld B: ");
                foreach (int j in secondArray)
                {
                    Console.Write($"{j} ");
                }
                Console.WriteLine();
                Console.Write($"Ziffern in Feld A und Feld B: ");

                foreach (int i in array)
                {
                    Console.Write($"{i} ");
                }
                Console.WriteLine();
                Console.WriteLine("===========");
            }
            if (methodName.ToLower() == "except")
            {
                int[] array = Except(firstArray, secondArray);
                Console.Write("Feld A: ");
                foreach (int i in firstArray)
                {
                    Console.Write($"{i} ");
                }
                Console.WriteLine();
                Console.Write("Feld B: ");
                foreach (int j in secondArray)
                {
                    Console.Write($"{j} ");
                }
                Console.WriteLine();
                Console.Write($"Ziffern in Feld A und Feld B: ");

                foreach (int i in array)
                {
                    Console.Write($"{i} ");
                }
                Console.WriteLine();
                Console.WriteLine("===========");
            }
        }
    }
}