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

        /// <summary>
        /// Adds the specified numbers.
        /// </summary>
        /// <param name="numbers">The numbers.</param>
        /// <returns></returns>
        public int Add(string numbers)
        {
            int result = 0;

            if(string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            var numberList = numbers.Split(_delimiters.ToArray(), StringSplitOptions.None).Select(int.Parse).ToList();

            bool IsNegativeExists = IsNegativeNumberExists(numberList);

            if (!IsNegativeExists)
            {
                result = numberList.Where(x => x <= maxLimit).Sum();
            }
            return result;
        }

        /// <summary>
        /// Determines whether [is negative number exists] [the specified number list].
        /// </summary>
        /// <param name="numberList">The number list.</param>
        /// <returns>
        ///   <c>true</c> if [is negative number exists] [the specified number list]; otherwise, <c>false</c>.
        /// </returns>
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

