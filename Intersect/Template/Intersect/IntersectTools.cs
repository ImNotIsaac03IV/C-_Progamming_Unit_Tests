/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Method for intersection between two arrays  
*--------------------------------------------------------------
*/

namespace Intersect
{
    public class IntersectTools
    {
        public static int[] Intersect(int[] feldA, int[] feldB)
        {
            int size;
            int index = 0;
            if (feldA.Length < feldB.Length)
            {
                size = feldB.Length;
            }
            else
            {
                size = feldA.Length;
            }
            int[] thirdArray = new int[size];
            for (int i = 0; i < feldA.Length; i++)
            {
                bool isSame = false;
                for (int j = 0; j < feldB.Length; j++)
                {
                    if (feldA[i] == feldB[j])
                    {
                        isSame = true;
                    }
                }
                if (isSame)
                {
                    bool alreadyAdded = false;

                    for (int n = 0; n < index; n++)
                    {
                        if (thirdArray[n] == feldA[i])
                        {
                            alreadyAdded = true;
                        }
                    }
                    if (!alreadyAdded)
                    {
                        thirdArray[index] = feldA[i];
                        index++;
                    }
                }
            }
            int[] result = new int[index];
            for (int i = 0; i < index; i++)
            {
                result[i] = thirdArray[i];
            }
            return result;
        }
    }
}