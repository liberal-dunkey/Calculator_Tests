using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AnalaizerClassLibrary.Tests
{
    [TestClass]
    public class AnalaizerClassTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void Format_WhenExpressionLengthIsBiggerThanMaxLength_ReturnsError()
        {
            //Arrange
            string expected = "&Error 07 — Дуже довгий вираз. Максмальная довжина — 65536 символів.";
            AnalaizerClass.expression = new string('0', 65537);
            //Actual
            string actualResult = AnalaizerClass.Format();
            //Assert
            Assert.AreEqual(expected, actualResult);
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "testData.xml", "Data", DataAccessMethod.Sequential)]
        public void FormatTest()
        {
            //Arrange
            string expected = Convert.ToString(TestContext.DataRow["expected"]);
            AnalaizerClass.expression = Convert.ToString(TestContext.DataRow["incomingData"]);
            //Actual
            string actualResult = AnalaizerClass.Format();
            //Assert
            Assert.AreEqual(expected, actualResult);
        }
    }
}