namespace _common_tests
{
    using NUnit.Framework;
    using _common.Protocol;

    [TestFixture]
    public class LoadStatusTest
    {
        [Test]
        public void TestLoadStatusStringTranslation()
        {
            var status = new LoadStatus {LoadType = LoadStatusType.Adaptive, Limit = 4};

            string data = status.ToString();

            LoadStatus restoredStatus;
            bool success = LoadStatus.TryParseString(data, out restoredStatus);
            Assert.True(success);
            Assert.AreEqual(status.LoadType, restoredStatus.LoadType);
            Assert.AreEqual(status.Limit, restoredStatus.Limit);
            
            // test failure
            success = LoadStatus.TryParseString("dumb_string", out restoredStatus);
            Assert.False(success);
        }

    }
}
