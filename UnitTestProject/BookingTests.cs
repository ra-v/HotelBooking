using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class BookingTests
    {
        [TestMethod]
        public void BookingTest()
        {

        int ID = 1;
        Assert.IsNotNull(ID);
        decimal Advance = 50;
        Assert.IsNotNull(Advance);
        string StartDate = "11.01.2018";
        Assert.IsNotNull(StartDate);
        string EndDate = "16.01.2018";
        Assert.IsNotNull(EndDate);
        int SelectedRoomId = 1;
        Assert.IsNotNull(SelectedRoomId);
        }
    }
}
