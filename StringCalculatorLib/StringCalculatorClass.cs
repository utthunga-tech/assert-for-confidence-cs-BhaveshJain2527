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
