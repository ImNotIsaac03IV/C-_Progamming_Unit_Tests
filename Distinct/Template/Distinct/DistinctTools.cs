/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 3ABIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: (Array-)Distinct with UnitTests
*--------------------------------------------------------------
*/

using System;

namespace Distinct
{
    public static class DistinctTools
    {
        public static bool IsDistinct(int[] ar)
        {
            for (int i = 0; i < ar.Length; i++)
            {
                for (int j = 1 + i; j < ar.Length; j++)
                {
                    if (ar[i] == ar[j])
                    {
                        return false;
                    }
                }
            }
            return true;
        } //Checks if an array only consists on distinct characters
        public static int[] Distinct(int[] ar)
        {
            int index = 0;
            int size = ar.Length;
            int[] modifiedArray = new int[size];

            for (int i = 0; i < size; i++)
            {
                bool isDistinct = true;

                for (int j = 0; j < index && isDistinct; j++)
                {
                    if (ar[i] == ar[j])
                    {
                        isDistinct = false;
                    }
                }
                if (isDistinct)
                {
                    modifiedArray[index] = ar[i];
                    index++;
                }
            }

            int[] result = ConcateZeros(modifiedArray, index);

            return result;
        } //Every value is displayed once
        public static int[] Duplicate(int[] ar)
        {
            if (ar.Length == 0)
            {
                return ar;
            }

            int index = 0;
            int size = ar.Length;
            int[] modifiedArray = new int[size];

            for (int i = 0; i < size; i++)
            {
                bool isSame = false;

                for (int j = 0; j < i; j++)
                {
                    if (ar[i] == ar[j])
                    {
                        isSame = true;
                    }
                }

                if (isSame)
                {
                    bool alreadyAdded = false;
                    for (int n = 0; n < index; n++)
                    {
                        if (modifiedArray[n] == ar[i])
                        {
                            alreadyAdded = true;
                        }
                    }
                    if (!alreadyAdded)
                    {
                        modifiedArray[index] = ar[i];
                        index++;
                    }
                }
            }
            int[] result = ConcateZeros(modifiedArray, index);

            return result;
        } //This method only displays values that appear more than once
        public static void Spaces(string label)
        {
            int space = 10;
            for (int i = label.Length; i < space; i++)
            {
                Console.Write(" ");
            }
        } //This method is for formatting the output
        public static int[] InsertValues(int size)
        {
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                Console.Write($"Please enter {i + 1}. numbers: ");
                int value = Convert.ToInt32(Console.ReadLine());
                array[i] = value;
            }
            return array;
        } // This method is for entering the values of my array
        public static void ArrayOutput(int[] array)
        {
            int counter = 0;
            foreach (int i in array)
            {
                if (counter > 0)
                {
                    Console.Write(", ");
                }
                Console.Write(i);
                counter++;
            }
        } //A Simple method for printing the values of an array to the console
        public static int[] ConcateZeros(int[] array, int index)
        {
            int[] outputArray = new int[index];
            for (int i = 0; i < index; i++)
            {
                outputArray[i] = array[i];
            }
            return outputArray;
        } //Removes zeros
    }
}