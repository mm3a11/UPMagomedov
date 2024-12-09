using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq; // Для использования ElementAt

namespace TestProject1
{
    [TestClass]
    public sealed class Test1
    {
        // Тест на создание объекта Sensor и проверку свойств
        [TestMethod]
        public void TestCreateSensor()
        {
            // Arrange
            var sensor = new Sensor
            {
                SensorId = 1,
                SensorType = "Temperature",
                Location = "Room 101",
                InstallationDate = new DateOnly(2023, 12, 9),
                CalibrationDate = new DateOnly(2024, 1, 1),
                Status = "Active"
            };

            // Assert
            Assert.IsNotNull(sensor);
            Assert.AreEqual(1, sensor.SensorId);
            Assert.AreEqual("Temperature", sensor.SensorType);
            Assert.AreEqual("Room 101", sensor.Location);
            Assert.AreEqual(new DateOnly(2023, 12, 9), sensor.InstallationDate);
            Assert.AreEqual(new DateOnly(2024, 1, 1), sensor.CalibrationDate);
            Assert.AreEqual("Active", sensor.Status);
        }

        // Тест на добавление Measurement в коллекцию Measurements
        [TestMethod]
        public void TestAddMeasurementToSensor()
        {
            // Arrange
            var sensor = new Sensor
            {
                SensorId = 1,
                SensorType = "Temperature",
                Location = "Room 101",
                Status = "Active"
            };

            var measurement = new Measurement
            {
                MeasurementId = 1,
                Value = 25.5,
                Timestamp = new DateOnly(2024, 12, 9)
            };

            // Act
            sensor.Measurements.Add(measurement);

            // Assert
            Assert.AreEqual(1, sensor.Measurements.Count);
            Assert.AreEqual(25.5, sensor.Measurements.ElementAt(0).Value); // Используем ElementAt
        }

        // Тест на правильность ассоциации объекта User с Sensor
        [TestMethod]
        public void TestAssociateUserWithSensor()
        {
            // Arrange
            var user = new User
            {
                UserId = 1,
                Username = "testuser"
            };

            var sensor = new Sensor
            {
                SensorId = 1,
                SensorType = "Humidity",
                Location = "Room 102",
                Status = "Inactive",
                User = user
            };

            // Assert
            Assert.IsNotNull(sensor.User);
            Assert.AreEqual(1, sensor.User.UserId);
            Assert.AreEqual("testuser", sensor.User.Username);
        }

        // Тест на установку CalibrationDate
        [TestMethod]
        public void TestSetCalibrationDate()
        {
            // Arrange
            var sensor = new Sensor
            {
                SensorId = 1,
                SensorType = "Temperature",
                Location = "Room 101",
                Status = "Active"
            };

            var calibrationDate = new DateOnly(2024, 1, 10);
            sensor.CalibrationDate = calibrationDate;

            // Assert
            Assert.AreEqual(calibrationDate, sensor.CalibrationDate);
        }

        // Тест на добавление PollutionDatum в коллекцию PollutionData
        [TestMethod]
        public void TestAddPollutionDataToSensor()
        {
            // Arrange
            var sensor = new Sensor
            {
                SensorId = 1,
                SensorType = "Air Quality",
                Location = "Outside",
                Status = "Active"
            };

            var pollutionDatum = new PollutionDatum
            {
                PollutionId = 1,
                PollutionType = "PM2.5",
                Value = 35.6,
                MeasurementDate = new DateOnly(2024, 12, 9)
            };// Act
            sensor.PollutionData.Add(pollutionDatum);

            // Assert
            Assert.AreEqual(1, sensor.PollutionData.Count);
            Assert.AreEqual(35.6, sensor.PollutionData.ElementAt(0).Value); // Используем ElementAt
        }
    }

    // Модели для использования в тестах (замените на реальные)
    public class Sensor
    {
        public int SensorId { get; set; }
        public string SensorType { get; set; } = null!;
        public string Location { get; set; } = null!;
        public DateOnly? InstallationDate { get; set; }
        public DateOnly? CalibrationDate { get; set; }
        public string Status { get; set; } = null!;
        public int? StandardId { get; set; }
        public int? UserId { get; set; }
        public virtual ICollection<Measurement> Measurements { get; set; } = new List<Measurement>();
        public virtual ICollection<PollutionDatum> PollutionData { get; set; } = new List<PollutionDatum>();
        public virtual Standard? Standard { get; set; }
        public virtual User? User { get; set; }
    }

    public class Measurement
    {
        public int MeasurementId { get; set; }
        public double Value { get; set; }
        public DateOnly Timestamp { get; set; }
    }

    public class PollutionDatum
    {
        public int PollutionId { get; set; }
        public string PollutionType { get; set; } = null!;
        public double Value { get; set; }
        public DateOnly MeasurementDate { get; set; }
    }

    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
    }

    public class Standard
    {
        public int StandardId { get; set; }
        public string StandardName { get; set; } = null!;
    }
}