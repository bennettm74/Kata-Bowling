using Kata_Bowling_Core;
using System;
using System.Collections.Generic;

namespace Kata_Bowling_Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Input a line of bowling (string of characters ['1'-'9','X','/','-',' ']) -OR- \"T\" to run tests -OR- blank to quit:");
                var input = Console.ReadLine();

                if (String.IsNullOrWhiteSpace(input))
                    return;
                else if ("T" == input.Trim().ToUpper())
                    RunTests();
                else
                    OutputLine(input);
            }
        }

        struct TestCase
        {
            public string Line;
            public ushort ExpectedScore;
        }

        static void RunTests()
        {
            TestCase[] testCases = new[]
            {
                new TestCase { Line = "X X X X X X X X X X X X", ExpectedScore = 300 },
                new TestCase { Line = "9- 9- 9- 9- 9- 9- 9- 9- 9- 9-", ExpectedScore = 90 },
                new TestCase { Line = "5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/5", ExpectedScore = 150 }

            };

            foreach (var testCase in testCases)
                OutputTest(testCase);
        }

        static void OutputTest(TestCase testCase)
        {
            var score = Scorer.ScoreLine(testCase.Line);
            if (score == testCase.ExpectedScore)
                Console.WriteLine($"PASSED: Score of test line [{testCase.Line}] is {score} as expected.");
            else
                Console.WriteLine($"FAILED: Score of test line [{testCase.Line}] is {score} rather than expected {testCase.ExpectedScore}.");
        }

        static void OutputLine(string line)
        {
            Console.WriteLine($"Score of line [{line}] is {Scorer.ScoreLine(line)}");
        }
    }
}
