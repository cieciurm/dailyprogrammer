using System;
using System.Linq;
using NUnit.Framework;

namespace Mateusz.DailyProgrammer._258
{
    public class IrcConnectionManagerTests
    {
        const string Nick = "Mateunio997";
        const string RealName = "Mateusz Cieciura";

        readonly IrcConnectionManager _connectionManager = new IrcConnectionManager();
        readonly ArgsDto _args = new ArgsDto(Nick, Nick, RealName);

        [Test]
        public void IrcConnection_Connect_ResponseNotNull()
        {
            var response = _connectionManager.Connect(_args);

            Assert.NotNull(response);
        }

        [Test]
        public void IrcConnection_Connect_ResponseContainsMoreThanOneResult()
        {
            var response = _connectionManager.Connect(_args);

            var splitted = response.Split(new [] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            Assert.Greater(splitted.Length, 0);
        }

        [Test]
        public void IrcConnection_Connect_ResponseContainsDesiredLine()
        {
            var response = _connectionManager.Connect(_args);

            var splitted = response.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            Assert.AreEqual(1, splitted.Count(x => x.Contains(string.Format(".freenode.net 001 {0} :Welcome to the freenode Internet Relay Chat Network {0}", Nick))));
        }
    }
}
