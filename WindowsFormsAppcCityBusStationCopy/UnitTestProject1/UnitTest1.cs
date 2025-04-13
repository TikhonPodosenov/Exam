using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WindowsFormsAppcCityBusStation;
using System.IO;
using WindowsFormsAppcCityBusStation.Models;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private Form1 _form = new Form1();
        [TestMethod]
        public void TestExportEntityDataToFile()
        {
            Type entityType = typeof(WindowsFormsAppcCityBusStation.Models.Schedules); 
            string testFilePath = Path.Combine(Path.GetTempPath(), "test_export.txt");
            string expected = "ОК";
            string result = _form.ExportEntityDataToFile(entityType, testFilePath);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestEntityDataToFile()
        {
            string testDir = @"C:\Office\";
            string testFilePath = Path.Combine(testDir, "test_export.txt");
            Assert.IsTrue(File.Exists(testFilePath));
        }

        [TestMethod]
        public void TestGetEntityByIdIsNotNull()
        {
            Type entityType = typeof(Buses); 
            int testId = 1;

            var privateObject = new PrivateObject(_form);

            var result = privateObject.Invoke("GetEntityById", entityType, testId);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestGetEntityByIdType()
        {
            Type entityType = typeof(Buses);
            int testId = 1;

            var privateObject = new PrivateObject(_form);

            var result = privateObject.Invoke("GetEntityById", entityType, testId);

            Assert.IsInstanceOfType(result, typeof(Buses));
        }

        [TestMethod]
        public void TestCreateEntity()
        {
            Buses expectedBus = new Buses
            {
                IDBus = 1,
                BusNumber = "TEST-123",
                NumberOfSeats = 50,
                Carrier = 1,
                FireExtinguisher = true
            };
            var privateObject = new PrivateObject(_form);

            var result = privateObject.Invoke("CreateEntity") as Buses;
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedBus.IDBus, result.IDBus);
            Assert.AreEqual(expectedBus.BusNumber, result.BusNumber);
            Assert.AreEqual(expectedBus.NumberOfSeats, result.NumberOfSeats);
            Assert.AreEqual(expectedBus.Carrier, result.Carrier);
            Assert.AreEqual(expectedBus.FireExtinguisher, result.FireExtinguisher);
        }
    }
}
