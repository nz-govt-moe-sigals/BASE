namespace App.Core.Shared.Tests
{
    using System.Collections.Generic;
    using Xunit;

    public class ATestClass
    {
        public ATestClass()
        {
            // Use the Constructor as the equivalent to FixtureSetup
            // This is state that is shared across all Facts:
            this._classWideState = new Stack<int>();
        }

        private Stack<int> _classWideState;

        //public void Dispose()
        //{
        //    // Use the Disposer as the equivalent to FixtureTeardown
        //    //_classWideState.Dispose();
        //}

        [Fact]
        public void ATest()
        {
            Assert.True(true);
        }
    }
}