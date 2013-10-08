using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheExtension;

namespace TheExtensionTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ToDateTest()
        {
            var dateStr = "2013-04-24";
            Assert.IsNotNull(dateStr.ToDate());
            
        }

        [TestMethod]
        public void ToDirectoryInfoTest()
        {
            var path = @"c:\testttts";
            var result = path.OpenAsDirectory(true);
            Assert.IsTrue(result.Exists);
        }

        [TestMethod]
        public void ToFileInfoTest()
        {
            var pathStr = "c:/test.txt";
            Assert.IsTrue(pathStr.OpenAsFile(true).Exists);
        }

        [TestMethod]
        public void ToIEnumerableTest()
        {
            var str = "abc def bbb  ccc";
            var result = str.ToIEnumerable();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DownloadTest()
        {
            "http://baidu.com/robots.txt".Donwload("c:\\ttttttttttttt".OpenAsDirectory(true));
            "http://localhost/welcome.png".Donwload("c:\\ttttttt".OpenAsDirectory(true));
            "http://wanmotor.com/images/logo.png".Donwload("c:\\ttttttt".OpenAsDirectory(true));
            "https://www.google.com.hk/images/nav_logo123.png".Donwload("c:\\ttttttt".OpenAsDirectory(true));
        }

        [TestMethod]
        public void StringLeftStripTest()
        {
            var result = "1234567".Left(2);
            Assert.IsTrue(result == "12");
        }

        [TestMethod]
        public void StringRightStripTest()
        {
            var result = "1234567".Right(3);
            Assert.IsTrue(result == "567");
        }
    }
}
