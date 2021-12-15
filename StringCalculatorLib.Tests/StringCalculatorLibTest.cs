using System;
using Xunit;
using StringCalculatorLib;

namespace StringCalculatorLib.Tests
{
    public class StringCalculatorLibTest
    {
        private StringCalculatorClass _codeUnderTest;

        public StringCalculatorLibTest()
        {
            _codeUnderTest = new StringCalculatorClass();
        }

        [Fact]
        public void GivenEmptyStringWhenInvokeAddThenZeroIsExpected()
        {
            string inputParameter = "";
            Assert.Equal(0, _codeUnderTest.Add(inputParameter));
        }

        [Fact]
        public void GivenSingleStringWhenInvokeAddThenSameStringIsExpected()
        {
            string inputParameter = "1";
            Assert.Equal(1, _codeUnderTest.Add(inputParameter));
        }

        [Fact]
        public void GivenStringSeperatedByCommasWhenInvokeAddThenSumOfNumberIsExpected_Case1()
        {
            string inputParameter = "1,2";
            Assert.Equal(3, _codeUnderTest.Add(inputParameter));
        }

        [Fact]
        public void GivenStringSeperatedByCommasWhenInvokeAddThenSumOfNumberIsExpected_Case2()
        {
            string inputParameter = "1,2,3,4";
            Assert.Equal(10, _codeUnderTest.Add(inputParameter));
        }

        [Fact]
        public void GivenStringSeperatedByNewLineWhenInvokeAddThenSumOfNumberIsExpected_Case1()
        {
            string inputParameter = "1\n2,3";
            Assert.Equal(6, _codeUnderTest.Add(inputParameter));
        }

        [Fact]
        public void GivenStringSeperatedByNewLineWhenInvokeAddThenSumOfNumberIsExpected_Case2()
        {
            string inputParameter = "1\n2,3\n4\n3";
            Assert.Equal(13, _codeUnderTest.Add(inputParameter));
        }

        [Fact]
        public void GivenStringWithNegativeNumberWhenInvokeAddThenThrowsException_Case1()
        {
            string inputParameter = "1\n2,-3\n4\n3";
            Assert.Throws<System.Exception>(() => _codeUnderTest.Add(inputParameter));
        }

        [Fact]
        public void GivenStringWithNegativeNumberWhenInvokeAddThenThrowsException_Case2()
        {
            string inputParameter = "1\n2,-3\n-4\n-3";
            Assert.Throws<System.Exception>(() => _codeUnderTest.Add(inputParameter));
        }

        [Fact]
        public void GivenStringWithBiggerThen1000NumberWhenInvokeAddThenBiggerNumberShouldBeIgnored()
        {
            string inputParameter = "1,1002,1";
            Assert.Equal(2, _codeUnderTest.Add(inputParameter));
        }

        [Fact]
        public void GivenStringWithBackSlashWhenInvokeAddThenSumOfNumberIsExpectedExcludingBackslash()
        {
            string inputParameter = "//;\n1;2";
            Assert.Equal(3, _codeUnderTest.Add(inputParameter));
        }
        
        [Fact]
        public void GivenStringWithMultiDelimeterWhenInvokeAddThenSumOfNumberIsExpected_Case1()
        {
            string inputParameter = "//[*][%]\n1*2%3";
            Assert.Equal(6, _codeUnderTest.Add(inputParameter));
        }

        [Fact]
        public void GivenStringWithMultiDelimeterWhenInvokeAddThenSumOfNumberIsExpected_Case2()
        {
            string inputParameter = "//[][%%]\n1,2%%3";
            Assert.Equal(6, _codeUnderTest.Add(inputParameter));
        }
    }
}
