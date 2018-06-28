using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class RoomTests
    {
        [TestMethod]
        public void RoomTest()
        {
            int ID = 1 ;
            Assert.IsNotNull(ID);
            string Name = "Jedynka";
            Assert.IsNotNull(Name);
            string Capacity = "2";
            Assert.IsNotNull(Capacity);
            bool Bathroom = true;
            Assert.IsTrue(Bathroom);
            bool IsAvailable = true;
            Assert.IsTrue(IsAvailable);
            decimal Price = 100;
            Assert.IsNotNull(Price);

        }
    }
}
