using Xunit;

namespace CTFLibrary.Utils.Test
{
    public class SwapTest
    {
        [Fact]
        public void Test()
        {
            int a = 1, b = 2;
            Util.Swap(ref a, ref b);
            Assert.Equal(2, a);
            Assert.Equal(1, b);
        }
    }
}
