using System;
using System.Linq;
using System.Collections.Generic;

namespace StringCalculatorLib
{
    public class StringCalculatorClass
    {
        #region Properties
        private List<string> _delimiters = new List<string> { ",", "\n" };
        private const int maxLimit = 1000;
        private string backslashDelimiter = "//";
        #endregion

        #region Methods
        public int Add(string numbers)
        {
            if(string.IsNullOrEmpty(numbers)) return 0;

            if (numbers.StartsWith(backslashDelimiter))
            {
                numbers = GetNumbersExcludingBackslashAndOtherDelimiters(numbers);
            }

            var numberList = numbers.Split(_delimiters.ToArray(), StringSplitOptions.None).Select(int.Parse).ToList();
            string negativeNumber = CheckForNegativeNumber(numberList);

            if(string.IsNullOrEmpty(negativeNumber))
            {
                return numberList.Where(x => x <= maxLimit).Sum();
            }
            else
            {
                ThrowException("Negatives number are not allowed - " + negativeNumber);
                return 0;
            }
        }

        private string GetNumbersExcludingBackslashAndOtherDelimiters(string numberList)
        {
            string numbers = string.Empty;

            var otherdelimiters = GetOtherDelimiters(numberList);
            _delimiters.AddRange(otherdelimiters);

            int multipleDelimiterLength = otherdelimiters.Count > 1 ? (otherdelimiters.Count * 2) : 0;

            int startIndexAfterBackslash = 3;
            int startIndexOfString = startIndexAfterBackslash + otherdelimiters.Sum(x => x.Length) + multipleDelimiterLength;

            numbers = numberList.Substring(startIndexOfString);

            return numbers;
        }

        private List<string> GetOtherDelimiters(string numbers)
        {
            int EndIndexOfBackslash = 2;
            var delimitersAfterBackslash = numbers.Substring(EndIndexOfBackslash, numbers.IndexOf('\n') - EndIndexOfBackslash);

            List<string> otherdelimiters = delimitersAfterBackslash.Split('[').Select(x => x.TrimEnd(']')).ToList();

            if (otherdelimiters.Contains(string.Empty))
            {
                otherdelimiters.Remove(string.Empty);
            }

            return otherdelimiters;
        }

        private void ThrowException(string errMessage)
        {
            throw new Exception(errMessage);
        }

        public string CheckForNegativeNumber(List<int> numberList)
        {
            if (!numberList.Any(x => x < 0)) return string.Empty;
            var negativeNumbers = string.Join(",", numberList.Where(x => x < 0).Select(x => x.ToString()).ToArray());
            return negativeNumbers;
        }

        #endregion
    }
}
