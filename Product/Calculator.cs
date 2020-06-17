using System;

namespace Product
{
    public class Calculator
    {
        private const string DELIMETER_LINE_INDICATOR = "//";
        private static string _delimeter = ",";

        public static int Add(string numbers)
        {
            if (HasDelimeterLine(numbers))
            {
                ParseDelimeter(numbers);
                numbers = GetNumbers(numbers);
            }

            if (IsEmptyString(numbers))
                return HandleEmptyString();

            if (HasMultipleNumbers(numbers))
            {
                return HandleMultipleNumbers(numbers);
            }


            return HandleOneNumber(numbers);

        }

        private static void ParseDelimeter(string numbers)
        {
            _delimeter = numbers.Substring(2, 1);
        }

        private static string GetNumbers(string numbers)
        {
            string[] numParts = numbers.Split(char.Parse("\n"));
            numbers = numParts[1];
            return numbers;
        }

        private static bool HasDelimeterLine(string numbers)
        {
            return numbers.StartsWith(DELIMETER_LINE_INDICATOR);
        }

        private static int HandleMultipleNumbers(string numbers)
        {
            string[] nums = numbers.Split(_delimeter.ToCharArray());
            int total = 0;

            foreach (string num in nums)
            {
                
                total += HandleOneNumber(num);
            }
            return total;
           
        }

        private static bool HasMultipleNumbers(string numbers)
        {
            return numbers.Contains(_delimeter);
        }

        private static int HandleOneNumber(string numbers)
        {
            return int.Parse(numbers);
        }

        private static int HandleEmptyString()
        {
            return 0;
        }

        private static bool IsEmptyString(string numbers)
        {
            return numbers.Length == 0;
        }
    }
}
