using NUnit.Framework;

namespace EndToEnd
{
    [TestFixture]
    public class SanityTests
    {
        [Test]
        public void TrueIsTrue()
        {
            Assert.That(true, Is.True);
        }
    }
}
