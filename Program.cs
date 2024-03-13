using System;
using System.Linq;

namespace Ex01_01
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter 3 positive binary numbers, each with 9 digits");
            string firstBinaryNumberFromUser = GetValidBinaryNumberFromUser();
            string secondBinaryNumberFromUser = GetValidBinaryNumberFromUser();
            string thirdBinaryNumberFromUser = GetValidBinaryNumberFromUser();
            int firstDecimal = ConvertBinaryToDecimal(firstBinaryNumberFromUser);
            int secondtDecimal = ConvertBinaryToDecimal(secondBinaryNumberFromUser);
            int thirdtDecimal = ConvertBinaryToDecimal(thirdBinaryNumberFromUser);
            MinMaxAndAscendingOrderOfDecimals(firstDecimal, secondtDecimal, thirdtDecimal);
            AverageOccurrencesOfZeroAndOneDigits(firstBinaryNumberFromUser, secondBinaryNumberFromUser, thirdBinaryNumberFromUser);
            HowManyNumbersArePowerOfTwo(firstDecimal, secondtDecimal, thirdtDecimal);
            CountInHowManyNumbersDigitsInAscendingOrder(firstDecimal, secondtDecimal, thirdtDecimal);
        }

        private static string GetValidBinaryNumberFromUser()
        {
            string inputFromUser = Console.ReadLine();
            bool isValidInput = CheckIfValidInput(inputFromUser);

            if (!isValidInput)
            {
                Console.WriteLine("Invalid number, try again!");
                inputFromUser = GetValidBinaryNumberFromUser();
            }

            return inputFromUser;
        }

        private static bool CheckIfValidInput(string i_InputStr)
        {
            bool isContainsOnlyZeroesAndOnes = i_InputStr.All(c => c == '0' || c == '1');
            bool isValidInput = isContainsOnlyZeroesAndOnes;

            if (isValidInput)
            {
                bool isPositiveNumber = !i_InputStr.All(c => c == '0');
                isValidInput = isPositiveNumber;
                if (isPositiveNumber)
                {
                    bool isContainsNineDigits = i_InputStr.Length == 9;
                    isValidInput = isContainsNineDigits;
                }
            }

            return isValidInput;
        }

        private static int ConvertBinaryToDecimal(string i_BinaryStr)
        {
            double decimalFromBinary = 0;
            int binaryStrLength = i_BinaryStr.Length;
            int indexOfDigitOneInBinaryStr = i_BinaryStr.IndexOf('1');

            while (indexOfDigitOneInBinaryStr != -1)
            {
                decimalFromBinary += Math.Pow(2, binaryStrLength - indexOfDigitOneInBinaryStr - 1);
                indexOfDigitOneInBinaryStr = i_BinaryStr.IndexOf('1', indexOfDigitOneInBinaryStr + 1);
            }

            return (int)decimalFromBinary;
        }

        private static void MinMaxAndAscendingOrderOfDecimals(int i_FirstDecimal, int i_SecondDecimal, int i_ThirdDecimal)
        {
            int min = Math.Min(Math.Min(i_FirstDecimal, i_SecondDecimal), i_ThirdDecimal);
            int max = Math.Max(Math.Max(i_FirstDecimal, i_SecondDecimal), i_ThirdDecimal);
            int middle = i_FirstDecimal + i_SecondDecimal + i_ThirdDecimal - min - max;

            Console.WriteLine(string.Format(
@"This is their ascending order:
{0}
{1}
{2}
The min decimal is {0}
The max decimal is {2}",
min, middle, max));
        }

        private static void AverageOccurrencesOfZeroAndOneDigits(string i_FirstBinaryNumber, string i_SecondBinaryNumber, string i_ThirdBinaryNumber)
        {
            int zeroDigitCounter = 0;
            int oneDigitCounter = 0;
            int numOfInputs = 3;

            zeroDigitCounter += HowManyOccurrencesDigitHasInStr(i_FirstBinaryNumber, '0');
            zeroDigitCounter += HowManyOccurrencesDigitHasInStr(i_SecondBinaryNumber, '0');
            zeroDigitCounter += HowManyOccurrencesDigitHasInStr(i_ThirdBinaryNumber, '0');
            oneDigitCounter += HowManyOccurrencesDigitHasInStr(i_FirstBinaryNumber, '1');
            oneDigitCounter += HowManyOccurrencesDigitHasInStr(i_SecondBinaryNumber, '1');
            oneDigitCounter += HowManyOccurrencesDigitHasInStr(i_ThirdBinaryNumber, '1');
            float zeroAvg = (float)zeroDigitCounter / numOfInputs;
            float oneAvg = (float)oneDigitCounter / numOfInputs;
            Console.WriteLine(string.Format(
@"The average number of occurrences of the digit 0 is {0} 
The average number of occurrences of the digit 1 is {1}",
zeroAvg, oneAvg));
        }

        private static int HowManyOccurrencesDigitHasInStr(string i_BinaryStr, char i_CharDigit)
        {
            int digitOccurrencesCounter = i_BinaryStr.Count(c => c == i_CharDigit);

            return digitOccurrencesCounter;
        }

        private static int HowManyNumbersArePowerOfTwo(int i_FirsDecimal, int i_SecondDecimal, int i_ThirdDecimal)
        {

            int powersOfTwoCounter = (CheckIfNumberIsPowerOfTwo(i_FirsDecimal) ? 1 : 0) + (CheckIfNumberIsPowerOfTwo(i_SecondDecimal) ? 1 : 0) + (CheckIfNumberIsPowerOfTwo(i_ThirdDecimal) ? 1 : 0);
            
            Console.WriteLine("{0} of the numbers you entered are powers of 2", powersOfTwoCounter);

            return powersOfTwoCounter;
        }

        private static bool CheckIfNumberIsPowerOfTwo(int i_DecimalNumber)
        {
            double powerOfNumber = Math.Log(i_DecimalNumber, 2);
            bool isPowerOfTwo = powerOfNumber == (int)powerOfNumber;

            return isPowerOfTwo;
        }

        private static void CountInHowManyNumbersDigitsInAscendingOrder(int i_FirsDecimal, int i_SecondDecimal, int i_ThirdDecimal)
        {
            int numbersInAscendingOrderCounter = (CheckIfDigitsInAscendingOrder(i_FirsDecimal) ? 1 : 0) + (CheckIfDigitsInAscendingOrder(i_SecondDecimal) ? 1 : 0) + (CheckIfDigitsInAscendingOrder(i_ThirdDecimal) ? 1 : 0);

            Console.WriteLine("In {0} of the numbers you entered, the digits makes a strictly increasing series", numbersInAscendingOrderCounter);
        }

        private static bool CheckIfDigitsInAscendingOrder(int i_DecimalNumber)
        {
            bool isDigitsInAscendingOrder = true;
            string decimalNumberStr = i_DecimalNumber.ToString();

            for (int i = 0; i < decimalNumberStr.Length - 1 && isDigitsInAscendingOrder; i++)
            {
                isDigitsInAscendingOrder = decimalNumberStr[i] < decimalNumberStr[i + 1];
            }

            return isDigitsInAscendingOrder;
        }
    }
}