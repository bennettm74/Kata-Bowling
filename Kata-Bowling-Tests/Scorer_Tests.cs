using Kata_Bowling_Core;
using System;
using Xunit;

namespace Kata_Bowling_Tests
{
    public class Scorer_Tests
    {
        [Fact]
        public void ScoreLine_Test1_Equals300()
        {
            Assert.Equal(300, Scorer.ScoreLine("X X X X X X X X X X X X"));
        }

        [Fact]
        public void ScoreLine_Test2_Equals90()
        {
            Assert.Equal(90, Scorer.ScoreLine("9- 9- 9- 9- 9- 9- 9- 9- 9- 9-"));
        }

        [Fact]
        public void ScoreLine_Test3_Equals150()
        {
            Assert.Equal(150, Scorer.ScoreLine("5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/5"));
        }
    }
}
