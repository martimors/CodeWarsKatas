using System;
using Xunit;
using Skyscrapers4by4;

namespace Skyscrapers4by4Tests
{

    public class SkyscrapersTests
    {
        [Fact]
        public void SolveSkyscrapers1()
        {
            var clues = new[]{ 2, 2, 1, 3,
                           2, 2, 3, 1,
                           1, 2, 2, 3,
                           3, 2, 1, 3};

            var expected = new[]{ new []{1, 3, 4, 2},
                               new []{4, 2, 1, 3},
                               new []{3, 4, 2, 1},
                               new []{2, 1, 3, 4 }};

            var actual = Program.Skyscrapers.SolvePuzzle(clues);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SolveSkyscrapers2()
        {
            var clues = new[]{ 0, 0, 1, 2,
                                       0, 2, 0, 0,
                                       0, 3, 0, 0,
                                       0, 1, 0, 0};

            var expected = new[]{ new []{2, 1, 4, 3},
                               new []{3, 4, 1, 2},
                               new []{4, 2, 3, 1},
                               new []{1, 3, 2, 4}};

            var actual = Program.Skyscrapers.SolvePuzzle(clues);
            Assert.Equal(expected, actual);
        }
    }

}
