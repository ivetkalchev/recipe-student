using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class DatabaseConnectionTests
    {
        [TestMethod]
        public void CheckConnection()
        {
            var expected = true;
            var isConnected = DAOs.DatabaseConnection.CheckConnection();

            Assert.AreEqual(expected, isConnected);
        }
    }
}
