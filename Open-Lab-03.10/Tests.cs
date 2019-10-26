using System;
using System.Collections;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Open_Lab_03._10
{
    [TestFixture]
    public class Tests
    {

        private Checker checker;
        private bool shouldStop;

        private const int RandStrMinSize = 50;
        private const int RandStrMaxSize = 10000;
        private const int RandSeed = 310310310;
        private const int RandTestCasesCount = 95;

        [OneTimeSetUp]
        public void Init()
        {
            checker = new Checker();
            shouldStop = false;
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome == ResultState.Failure ||
                TestContext.CurrentContext.Result.Outcome == ResultState.Error)
                shouldStop = true;
        }

        [TestCase('a', "Xamarin Lab", 3)]
        [TestCase('A', "AppsLab 2019", 1)]
        [TestCase('o', "C# is an object oriented language", 2)]
        public void GetNumberOfCharsInStringTest(char letter, string str, int expected) =>
            Assert.That(checker.GetNumberOfCharsInString(letter, str), Is.EqualTo(expected));

        [TestCaseSource(nameof(GetRandom))]
        public void GetNumberOfCharsInStringTestRandom(char letter, string str, int expected)
        {
            if (shouldStop)
                Assert.Ignore("Previous test failed!");

            Assert.That(checker.GetNumberOfCharsInString(letter, str), Is.EqualTo(expected));
        }

        private static IEnumerable GetRandom()
        {
            var rand = new Random(RandSeed);

            for (var i = 0; i < RandTestCasesCount; i++)
            {
                var arr = new char[rand.Next(RandStrMinSize, RandStrMaxSize + 1) + 1];

                for (var j = 0; j < arr.Length; j++)
                    arr[j] = (char) rand.Next('A', 'z' + 1);

                yield return new TestCaseData(arr[^1], new string(arr[..^1]),
                    arr[..^1].Count(letter => letter == arr[^1]));
            }
        }

    }
}
