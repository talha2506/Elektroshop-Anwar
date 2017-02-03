using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Elektroshop;

namespace UnitTestProject1 {

    [TestClass]
    
    public class UnitTest1 {
        [TestMethod, ExpectedException(typeof(ElektroshopException))]
        public void TestMethod1() {
            Produkte p = new Geraete("OnePlus", "Handy", "One", -5);
        }

        [TestMethod]
        public void TestMethod2() {
            Person k = new Kunden(100, "manuel@zatschkowitsch.at", true, "Manuel", "Zatschkowitsch", "Breitstetten");
            Assert.AreEqual("Breitstetten", k.Adresse);
        }

        [TestMethod, ExpectedException(typeof(ElektroshopException))]
        public void TestMethod3() {
            Produkte p = new Services("Reparatur", "Samsung Galaxy S5 Displayschaden", -5F);
        }
    }
}
