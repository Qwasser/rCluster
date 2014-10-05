
using System;

namespace _common_tests.ProtocolTest
{
    using NUnit.Framework;
    using _common.Protocol;

    [TestFixture]
    class RequestSenderHandlerTests
    {
        [Test]
        public void ErrorTest()
        {
            const string testString = "->hello!";

            var receiver = new ConsoleRequestSender();
            var sender = new ClusterRequestSender(receiver);

            sender.SendError(testString);

            Assert.AreEqual(MessageType.Error.ToString() + testString, receiver.GetLastMessage());

        }

        [Test]
        public void SuccessTest()
        {
            const string testString = "->hello!";

            var receiver = new ConsoleRequestSender();
            var sender = new ClusterRequestSender(receiver);

            sender.SendSuccess(testString);

            Assert.AreEqual(MessageType.Success.ToString() + testString, receiver.GetLastMessage());

        }

        [Test]
        public void SpawnStopWorkersTest()
        {
            const int count = 100;

            var receiver = new ConsoleRequestSender();
            var sender = new ClusterRequestSender(receiver);

            sender.SendSpawnWorkers(count);
            Assert.AreEqual(MessageType.SpawnWorkers.ToString() + count, receiver.GetLastMessage());

            sender.SendStopWorkers(count);
            Assert.AreEqual(MessageType.StopWorkers.ToString() + count, receiver.GetLastMessage());

            sender.SendSpawnAllWorkers();
            Assert.AreEqual(MessageType.SpawnAllWorkers.ToString(), receiver.GetLastMessage());

            sender.SendStopAllWorkers();
            Assert.AreEqual(MessageType.StopAllWorkers.ToString(), receiver.GetLastMessage());

        }

        [Theory]
        public void ParameterlessMessageTest(MessageType t)
        {
            var receiver = new ConsoleRequestSender();
            var sender = new ClusterRequestSender(receiver);

            bool pass = false;
            switch(t)
            {
                case MessageType.Error:
                    sender.SendError(String.Empty);
                    break;
                case MessageType.Success:
                    sender.SendSuccess(String.Empty);
                    break;
                case MessageType.SpawnWorkers:
                    pass = true;
                    break;
                case MessageType.SpawnAllWorkers:
                    sender.SendSpawnAllWorkers();
                    break;
                case MessageType.StopWorkers:
                    pass = true;
                    break;
                case MessageType.StopAllWorkers:
                    sender.SendStopAllWorkers();
                    break;
                case MessageType.WorkersMemory:
                    sender.SendWorkersMemory();
                    break;
                case MessageType.WorkersLoad:
                    sender.SendWorkersLoad();
                    break;
                case MessageType.WorkersCount:
                    sender.SendWorkersCount();
                    break;
                case MessageType.RedisIp:
                    sender.SendRedisIp(String.Empty);
                    break;
                case MessageType.TotalLoad:
                    sender.SendTotalLoad();
                    break;
                case MessageType.TotalMemory:
                    sender.SendTotalMemory();
                    break;
                case MessageType.LoadStatus:
                    sender.SendLoadStatus();
                    break;
                case MessageType.SetLoadStatus:
                    pass = true;
                    break;
                case MessageType.CurrentWorkerLimit:
                    sender.SendCurrentWorkerLimit();
                    break;
                case MessageType.MaximumWorkerLimit:
                    sender.SendMaximumWorkerLimit();
                    break;
                case MessageType.LibrariesList:
                    sender.SendLibrariesList();
                    break;
                case MessageType.HasLibrary:
                    sender.SendHasLibrary(String.Empty);
                    break;
                case MessageType.InstallLibrary:
                    sender.SendInstallLibrary(String.Empty);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("t");
            }
            if (!pass)
            {
                Assert.AreEqual(t.ToString(), receiver.GetLastMessage());
            }
        }

        [Test]

        public void RedisIpTest()
        {
            const string testString = "->hello!";

            var receiver = new ConsoleRequestSender();
            var sender = new ClusterRequestSender(receiver);

            sender.SendRedisIp(testString);

            Assert.AreEqual(MessageType.RedisIp.ToString() + testString, receiver.GetLastMessage());
        }
    }
}
