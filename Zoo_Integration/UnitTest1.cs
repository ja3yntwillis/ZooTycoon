using NSubstitute;
using System;
using NUnit.Framework;
using System.Collections.Generic;
//using solution_repo.zoo;
using System.Collections.Generic;
using Assert = Xunit.Assert;
using FluentAssertions;
using solution_repo.Animals.Elephant;
using solution_repo.Animals.Tiger;
using solution_repo.Animals.Lion;
using solution_repo.Ibase;
using solution_repo.zoo;


namespace Zoo_Integration
{
    public class MyZooIntegrationTests
    {
        [Fact]
        public void MyZooTycoon_ReturnsCorrectDictionary_AllMock()
        {
            // Arrange
            //var eleObj = new ElephantCage();
            var eleObj = Substitute.For<IZoo>();
            var lionCage = Substitute.For<IZoo>();
            var tigerCage = Substitute.For<IZoo>();
            List<string> foodList;
            eleObj.getAnimal("elephant").Returns("Mocked Elephant");
            eleObj.getCage("elephant").Returns("Mocked Elephant Cage");
            eleObj.getFood().Returns(foodList = new List<string> { "Mocked Elephant Food", "Mocked Elephant Food2" });

            lionCage.getAnimal("lion").Returns("Mocked Lion");
            tigerCage.getAnimal("tiger").Returns("Mocked Tiger");
            lionCage.getCage("lion").Returns("Mocked Lion Cage");
            tigerCage.getCage("tiger").Returns("Mocked Tiger Cage");
            lionCage.getFood().Returns(new List<string> { "Mocked Lion Food", "Mocked Lion Food2" });
            tigerCage.getFood().Returns(new List<string> { "Mocked Tiger Food", "Mocked Tiger Food2", "Mocked Tiger Food3" });


            var myZoo = new MyZoo(eleObj, lionCage, tigerCage);
            var feedAnimal = new FeedAnimals(tigerCage, lionCage, eleObj);

            // Act
            Dictionary<string, string> result = myZoo.MyZooTycoon();

            // Assert
            Assert.Equal(result.Count, 9);
            //Assert.True(result.ContainsKey("Animal1"));
            Assert.Equal("Mocked Elephant", result["Animal1"]);
            //Assert.True(result.ContainsKey("Animal2"));
            Assert.Equal("Mocked Lion", result["Animal2"]);
            Assert.Equal("Mocked Tiger", result["Animal3"]);
            //Assert.Equal(new List<string> { "Mocked Elephant Food", "Mocked Elephant Food2" }, foodList);
            Assert.Equal("Mocked Elephant Food", result["FoodForAnimal1"]);
        }
        [Fact]
        public void MyZooTycoon_ReturnsCorrectDictionary_ElephantReal()
        {
            //Arrange
            var eleObj = new ElephantCage();
            var lionObj = Substitute.For<IZoo>();
            var tigerObj = Substitute.For<IZoo>();
            eleObj.getAnimal("elephant");
            eleObj.getCage("elephant");
            eleObj.getFood();
            lionObj.getAnimal("lion").Returns("Mocked lion and its cub");
            lionObj.getCage("lion").Returns("Mocked lion");
            lionObj.getFood().Returns(new List<string> { "lionFood", "lionFood2" });
            tigerObj.getAnimal("tiger").Returns("Mocked tiger and its cub");
            tigerObj.getCage("tiger").Returns("Mocked Tiger");
            tigerObj.getFood().Returns(new List<string> { "tigerFood", "tigerFood2", "tigerFood3" });


            var myZoo = new MyZoo(eleObj, lionObj, tigerObj);
            //Act
            Dictionary<string, string> result = myZoo.MyZooTycoon();
            //Assert
            Assert.Equal(result.Count, 9);
            Assert.Equal("elephant and it's Cub", result["Animal1"]);
            Assert.Equal("elephant", result["CageForAnimal1"]);
            Assert.Equal("Vegetables", result["FoodForAnimal1"]);
            Assert.Equal("Mocked lion and its cub", result["Animal2"]);
            Assert.Equal("Mocked lion", result["CageForAnimal2"]);
            Assert.Equal("lionFood2", result["FoodForAnimal2"]);
            Assert.Equal("Mocked tiger and its cub", result["Animal3"]);
            Assert.Equal("Mocked Tiger", result["CageForAnimal3"]);
            Assert.Equal("tigerFood3", result["FoodForAnimal3"]);
        }
        [Fact]
        public void MyZooTycoon_ReturnsCorrectElephantFood()
        {
            //Arrange
            var eleObjReal = new ElephantCage();
            var food = eleObjReal.getFood();
            var lionObj = Substitute.For<IZoo>();
            var tigerObj = Substitute.For<IZoo>();
            var eleObj = Substitute.For<IZoo>();
            eleObj.getCage("elephant").Returns("Mocked Elephant");
            eleObj.getAnimal("elephant").Returns("Mocked elephant and its cub");
            eleObj.getFood().Returns(new List<string> { "food", "food1" });
            lionObj.getAnimal("lion").Returns("Mocked lion and its cub");
            lionObj.getCage("lion").Returns("Mocked lion");
            lionObj.getFood().Returns(new List<string> { "lionFood", "lionFood2" });
            tigerObj.getAnimal("tiger").Returns("Mocked tiger and its cub");
            tigerObj.getCage("tiger").Returns("Mocked Tiger");
            tigerObj.getFood().Returns(new List<string> { "tigerFood", "tigerFood2", "tigerFood3" });

            var myZoo = new MyZoo(eleObj, lionObj, tigerObj);

            //Act
            Dictionary<string, string> result = myZoo.MyZooTycoon();

            //Assert
            Assert.Equal(result.Count, 9);
            Assert.Contains((string)food[0], "Vegetables");
            Assert.Contains((string)food[1], "Leaves");
        }
        [Fact]
        public void MyZooTycoon_ReturnsCorrectElephantFood1()
        {
            //Arrange
            var eleObjReal = new ElephantCage();
            var eleObj = Substitute.For<IZoo>();
            //Act
            eleObj.getCage("elephant").Returns("Mocked Elephant");
            eleObj.getAnimal("elephant").Returns("Mocked elephant and its cub");
            //eleObj.getFood().Returns(new List<string> { "food", "food1" });
            var food = eleObjReal.getFood();
            //Assert
            Assert.Equal(food.Count, 2);
            Assert.Contains((string)food[0], "Vegetables");
            Assert.Contains((string)food[1], "Leaves");
        }
        [Fact]
        public void MyZooTycoon_ReturnsCorrectTigerFood()
        {
            //Arrange
            var tigerObjectReal = new TigerCage();
            var tigerObject = Substitute.For<IZoo>();
            tigerObject.getAnimal("tiger").Returns("Mocked Tiger");
            tigerObject.getCage("tiger").Returns("Mocked Tiger cage");
            //Act
            List<string> tigerFood = tigerObjectReal.getFood();
            //Assert
            Assert.Equal(tigerFood.Count, 3);
            Assert.Contains((string)tigerFood[0], "Horse Meat");
            Assert.Contains((string)tigerFood[1], "Lamb Meat");
            Assert.Contains((string)tigerFood[2], "rabbit Meat");
        }
        [Fact]
        public void MyZooTycoon_ReturnsCorrectLionName()
        {
            //Arrange
            var lionObjectReal = new LionCage();
            var lionObject = Substitute.For<IZoo>();
            // lionObject.getAnimal("tiger").Returns("Mocked Tiger");
            lionObject.getCage("tiger").Returns("Mocked Tiger cage");
            lionObject.getFood().Returns(new List<string> { "MockedLionFood", "MockedLioFood1" });
            //Act
            var lionName = lionObjectReal.getAnimal("lion");
            //Assert
            Assert.Equal("lion and it's Cub", lionName);
        }
        [Fact]
        public void FeedAllAnimals_RealPositive()
        {
            // Arrange
            ElephantCage eleObj = new ElephantCage();
            List<string> animalName = new List<string>();
            animalName.Add(eleObj.getAnimal("elephant"));
            animalName.Add(eleObj.getAnimal("rabbit"));
            animalName.Add(eleObj.getAnimal("deer"));
            animalName.Add(eleObj.getAnimal("zebra"));

            var tigerObj = new TigerCage();
            var lionObj = new LionCage();
            
            var feedAnimal = new FeedAnimals(tigerObj, lionObj, eleObj);
            //Act
            List<string> cageListForThreeAnimals = feedAnimal.cageAllAnimals("elephant", "rabbit", "deer");
            var zebraCage = eleObj.getCage("zebra");
            var food = eleObj.getFood();

            // Assert
            Assert.Equal(new List<string> { "elephant and it's Cub", "rabbit and it's Cub", "deer and it's Cub", "zebra and it's Cub" }, animalName);
            Assert.Equal(new List<string> { "elephant", "rabbit", "deer" }, cageListForThreeAnimals);
            Assert.StrictEqual("zebra", zebraCage);
            Assert.Equal(new List<string>{ "Vegetables", "Leaves"}, food);
        }
    }
}