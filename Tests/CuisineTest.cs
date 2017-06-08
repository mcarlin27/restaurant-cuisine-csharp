using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Restaurant
{
  [Collection("Restaurant")]
  public class CuisineTest : IDisposable
  {
    public CuisineTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=restaurant_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_CuisineTestEmptyAtFirst()
      {
        //Arrange, Act
        int result = Cuisine.GetAll().Count;
        //Assert
        Assert.Equal(0, result);
      }
    [Fact]
    public void Test_Equal_ReturnsTrueForSameName()
    {
      //Arrange, Act
      Cuisine firstCuisine = new Cuisine("Japanese");
      Cuisine secondCuisine = new Cuisine("Japanese");

      //Assert
      Assert.Equal(firstCuisine, secondCuisine);
    }
    [Fact]
    public void Test_Save_SavesCuisineToDatabase()
    {
      //Arrange
      Cuisine testCuisine = new Cuisine("Japanese");
      testCuisine.Save();

      //Act
      List<Cuisine> result = Cuisine.GetAll();
      List<Cuisine> testList = new List<Cuisine>{testCuisine};

      //Assert
      Assert.Equal(testList, result);
    }
    [Fact]
    public void Test_Save_AssignsIdToCuisineObject()
    {
      //Arrange
      Cuisine testCuisine = new Cuisine("Japanese");
      testCuisine.Save();

      //Act
      Cuisine savedCuisine = Cuisine.GetAll()[0];

      int result = savedCuisine.GetId();
      int testId = testCuisine.GetId();

      //Assert
      Assert.Equal(testId, result);
    }
    [Fact]
    public void Test_Find_FindsCuisineInDatabase()
    {
      //Arrange
      Cuisine testCuisine = new Cuisine("Japanese");
      testCuisine.Save();

      //Act
      Cuisine foundCuisine = Cuisine.Find(testCuisine.GetId());

      //Assert
      Assert.Equal(testCuisine, foundCuisine);
    }
    public void Dispose()
    {
      // Restaurant.DeleteAll();
      Cuisine.DeleteAll();
    }
    // [Fact]
    // public void Test_Update_ReturnsTrueIfCuisinesAreTheSame()
    // {
    //   //Arrange
    //   Cuisine testCuisine = new Cuisine("Japanese", 2);
    //   testCuisine.Save();
    //   Cuisine controlCuisine = new Cuisine("Mexican", 2);
    //   controlCuisine.Save();
    //
    //   //Act
    //   testCuisine.Update("Mexican");
    //
    //   //Assert
    //   Assert.Equal(controlCuisine, testCuisine);
    // }

  }
}
