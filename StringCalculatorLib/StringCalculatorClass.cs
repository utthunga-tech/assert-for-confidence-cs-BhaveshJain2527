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
        #endregion

        #region Methods
        public int Add(string numbers)
        {
            if(string.IsNullOrEmpty(numbers)) return 0;
            var numberList = numbers.Split(_delimiters.ToArray(), StringSplitOptions.None).Select(int.Parse).ToList();
            bool IsNegativeExists = IsNegativeNumberExists(numberList);
            return IsNegativeExists ? 0 : numberList.Where(x => x <= maxLimit).Sum();
        }

        public bool IsNegativeNumberExists(List<int> numberList)
        {
            if (!numberList.Any(x => x < 0)) return false;
            var negativeNumbers = string.Join(",", numberList.Where(x => x < 0).Select(x => x.ToString()).ToArray());
            Console.WriteLine("Negatives number are not allowed - " +negativeNumbers);
            return true;
        }

        #endregion
    }
}
