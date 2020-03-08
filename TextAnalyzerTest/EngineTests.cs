using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading;
using TextAnalyzer;

namespace TextAnalyzerTest
{
    [TestClass]
    public class EngineTests
    {
        [TestMethod]
        public void Input3TripletsOutput3InRightOrder()
        {
            var eng = new Engine();
            CancellationTokenSource cts = new CancellationTokenSource();
            var expected = new List<string> { "efg", "bcd", "abc" };
            var actual = eng.GetTriplets(@"Resources\3_Triplets.txt", cts.Token);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Input15TripletsOutput10InRightOrder()
        {
            var eng = new Engine();
            CancellationTokenSource cts = new CancellationTokenSource();
            var expected = new List<string> { 
                "abc","xyz","the","you","qwe","out","lie","app","jkl","mno" };

            var actual = eng.GetTriplets(@"Resources\15_Triplets.txt", cts.Token);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Input0TripletsOutputEmpty()
        {
            var eng = new Engine();
            CancellationTokenSource cts = new CancellationTokenSource();
            var expected = new List<string>();
            var actual = eng.GetTriplets(@"Resources\0_Triplets.txt", cts.Token);
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
