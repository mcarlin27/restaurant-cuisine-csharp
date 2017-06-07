using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Restaurant
{
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

    public void Dispose()
    {
      // Restaurant.DeleteAll();
      Cuisine.DeleteAll();
    }

  }
}
