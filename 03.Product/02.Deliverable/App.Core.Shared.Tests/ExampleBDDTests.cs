﻿namespace App.Core.Shared.Tests
{
    using Xbehave;
    using Xunit;

    public class ExampleBDDTests
    {
        [Scenario(DisplayName = "S 0: Addition")]
        [Example(1, 2, 3)]
        [Example(2, 3, 5)]
        public void S_0_1_Addition(int x, int y, int expectedAnswer)
        {
            var answer = 0;
            "Given the number {0}" // or in C# 6 or later, $"Given the number {x}"
                .f(() => { });
            "And the number {1}"
                .f(() => { });
            "When I add the numbers together"
                .f(() => answer = x + y);
            "Then the answer is {2}"
                .f(() => Assert.Equal(expectedAnswer, answer));
        }
    }
}