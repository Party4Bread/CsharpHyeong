using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HyeongCsharp;

namespace HyeongTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Parser hp = new Parser();
            hp.혀엉코드="형";
            Assert.AreEqual(hp.명령어해석()[0],"");
        }
    }
}
