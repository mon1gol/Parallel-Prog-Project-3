using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectTwo.Core.Components;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GenerateHash_ShouldReturnHashOfSpecifiedLength()
        {
            var hashGenerator = new HashGenerator();
            int expectedLength = 64; // Длина хэша SHA256 в шестнадцатеричном формате

            string result = hashGenerator.generateHash(expectedLength);

            Assert.AreEqual(result.Length, expectedLength);
        }

        [TestMethod]
        public void GenerateHash_ShouldReturnHashOfDifferentLengths()
        {
            var hashGenerator = new HashGenerator();
            int[] lengths = { 16, 32, 48, 64, 128 };

            foreach (var length in lengths)
            {
                string result = hashGenerator.generateHash(length);

                Assert.AreEqual(result.Length, length);
            }
        }

        [TestMethod]
        public void HashChecking_ShouldReturnTrueForMatchingHash()
        {
            var mainer = new Mainer();
            string maybeStr = "abc123";
            string targetHash = "abc123";

            bool result = mainer.hashChecking(maybeStr, targetHash);

            Assert.IsTrue(result);
        }


        [TestMethod]
        public void HashChecking_ShouldReturnFalseForNonMatchingHash()
        {
            var mainer = new Mainer();
            string maybeStr = "abc124";
            string targetHash = "abc123";

            bool result = mainer.hashChecking(maybeStr, targetHash);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GenerateMaybeHashString_ShouldReturnCorrectString()
        {
            var mainer = new Mainer();
            int index = 0; // Первый индекс
            int N = 3; // Длина строки
            string hashSymbols = "abc";

            string result = mainer.generateMaybeHashString(index, N, hashSymbols);

            Assert.AreEqual(result, "aaa");
        }
    }
}
