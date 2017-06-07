using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Restaurant
{
  public class RestaurantTest : IDisposable
  {
    public RestaurantTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=restaurant_test;Integrated Security=SSPI;";
    }
    public void Dispose()
    {
      Restaurant.DeleteAll();
    }
    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      int result = Restaurant.GetAll().Count;

      Assert.Equal(0, result);
    }
    [Fact]
    public void Test_Equal_ReturnsTrueIfNamesAreTheSame()
    {
      //Arrange, Act
      Restaurant firstRestaurant = new Restaurant("Saburos", 1);
      Restaurant secondRestaurant = new Restaurant("Saburos", 1);
      //Assert
      Assert.Equal(firstRestaurant, secondRestaurant);
    }
    [Fact]
    public void Test_Save_SavesToDatabase()
    {
      //Arrange
      Restaurant testRestaurant = new Restaurant("Saburos", 1);
      //Act
      testRestaurant.Save();
      List<Restaurant> result = Restaurant.GetAll();
      List<Restaurant> testList = new List<Restaurant>{testRestaurant};
      //Assert
      Assert.Equal(testList, result);
    }
    [Fact]
    public void Test_Save_AssignsIdToObject()
    {
      //Arrange
      Restaurant testRestaurant = new Restaurant("Saburos", 1);
      //Act
      testRestaurant.Save();
      Restaurant savedRestaurant = Restaurant.GetAll()[0];
      int result = savedRestaurant.GetId();
      int testId = testRestaurant.GetId();
      //Assert
      Assert.Equal(testId, result);
    }
    [Fact]
    public void Test_Find_FindsRestaurantInDatabase()
    {
      //Arrange
      Restaurant testRestaurant = new Restaurant("Saburos", 1);
      testRestaurant.Save();
      //Act
      Restaurant foundRestaurant = Restaurant.Find(testRestaurant.GetId());
      //Assert
      Assert.Equal(testRestaurant, foundRestaurant);
    }
    [Fact]
    public void Test_ByCuisine_ReturnsTrueIfListsAreTheSame()
    {
      //Arrange
      Cuisine newCuisine = new Cuisine("Sushi");
      Restaurant firstRestaurant = new Restaurant("Sushi Sakura", 1, newCuisine.GetId());
      Restaurant secondRestaurant = new Restaurant("Saburos", 2, newCuisine.GetId());
      //Act
      newCuisine.Save();
      firstRestaurant.Save();
      secondRestaurant.Save();
      List<Restaurant> result = Restaurant.ByCuisine();
      List<Restaurant> testList = new List<Restaurant>{firstRestaurant, secondRestaurant};
      //Assert
      Assert.Equal(testList, result);
    }
  }
}
