/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *              Musterlösung-HA
 *--------------------------------------------------------------
 * Description: Test a SV Number
 *--------------------------------------------------------------
 */

namespace SVNummerTest
{
    public class SVNummer
    {
        public static bool IsSvNumberValid(string svNumber)
        {
            int[] svCheck = { 3, 7, 9, 0, 5, 8, 4, 2, 1, 6 };
            int validDigit = ValidSum(svCheck, svNumber);

            if (!isLength10(svNumber))
            {
                return false;
            }

            if (!IsOnlyDigits(svNumber))
            {
                return false;
            }

            if (validDigit != (svNumber[3] - '0'))
            {
                return false;
            }

            return true;
        }
        private static bool isLength10 (string input)
        {
            if(input.Length == 10)
            {
                return true;
            }

            return false;
        }
        private static bool IsOnlyDigits(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] < '0' || input[i] > '9')
                {
                    return false;
                }
            }
            return true;
        }
        private static int ValidSum(int[] svCheck, string svNumber)
        {
            if (svNumber == "")
            {
                return -1;
            }
            int sum = 0;
            for(int i = 0; i < svNumber.Length; i++)
            {
                sum += (svNumber[i] - '0') * svCheck[i];
            }
            return sum % 11;
        }
    }
}