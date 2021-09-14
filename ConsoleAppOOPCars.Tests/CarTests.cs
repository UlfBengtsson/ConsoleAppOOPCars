using System;
using Xunit;
using ConsoleAppOOPCars;

namespace ConsoleAppOOPCars.Tests
{
    public class CarTests
    {
        [Fact]
        public void ColorGoodValueTest()
        {
            //Arrange
            string expectedColor = "Blue";
            Car testCar = new Car("testCar", "white");

            //Act
            testCar.Color = expectedColor;
            string result = testCar.Color;

            //Assert
            Assert.Equal(expectedColor, result);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void ColorBadValueTest(string badColor)
        {
            //Arrange
            Car testCar = new Car("testCar", "white");

            //Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => testCar.Color = badColor);

            //Assert
            Assert.Contains("Color", exception.Message);
        }

        [Fact]
        public void StartEngineFirstTimeTest()
        {
            //Arrange
            Car testCar = new Car("testCar", "white");

            //Act
            string result = testCar.StartEngine();

            //Assert
            Assert.True(testCar.EngineIsOn);
            Assert.Equal("The engine starts", result);
        }

        [Fact]
        public void StartEngineFirstTimeWithSpecialEngineTest()
        {
            //Arrange
            string engine = "V12";
            Car testCar = new Car("testCar", "white",2021, engine);

            //Act
            string result = testCar.StartEngine();

            //Assert
            Assert.True(testCar.EngineIsOn);
            Assert.Equal($"The {engine} starts", result);
        }

        [Fact]
        public void StartEngineTwiseTest()
        {
            //Arrange
            Car testCar = new Car("testCar", "white");

            //Act
            string resultOne = testCar.StartEngine();
            string resultTwo = testCar.StartEngine();

            //Assert
            Assert.True(testCar.EngineIsOn);
            Assert.Equal("The engine starts", resultOne);
            Assert.Equal("Engine is already on.", resultTwo);
        }


        [Fact]
        public void DriveEngineIsOffTest()
        {
            //Arrange
            Car testCar = new Car("testCar", "white");

            //Act
            string result = testCar.Drive();

            //Assert
            Assert.False(testCar.EngineIsOn);
            Assert.Equal("Can´t drive the car when the engine is off.", result);
        }

        [Fact]
        public void DriveEngineIsOnTest()
        {
            //Arrange
            string modelName = "testCar";
            string color = "white";
            string keyPhrazeForDrivingAway = "drives away";
            Car testCar = new Car(modelName, color);
            testCar.StartEngine();

            //Act
            string result = testCar.Drive();

            //Assert
            Assert.True(testCar.EngineIsOn);
            Assert.Contains(color, result);
            Assert.Contains(modelName, result);
            Assert.Contains(keyPhrazeForDrivingAway, result);           
        }

        [Fact]
        public void InfoHasCorrectInfoTest()
        {
            //Arrange
            string modelName = "Saab";
            string color = "white";
            int modelYear = 2010;
            string engineType = "V4";
            Car testCar = new Car(modelName, color, modelYear, engineType);

            //Act
            string result = testCar.Info();

            //Assert
            Assert.NotNull(result);
            Assert.Contains(modelName, result);
            Assert.Contains(color, result);
            Assert.Contains(modelYear.ToString(), result);
            Assert.Contains(engineType, result);
        }

    }
}
