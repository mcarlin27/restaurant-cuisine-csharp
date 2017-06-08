using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Restaurant
{
  [Collection("Restaurant")]
  public class ContactInfoTest : IDisposable
  {
    public ContactInfoTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=restaurant_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      int result = ContactInfo.GetAll().Count;

      Assert.Equal(0, result);
    }
    public void Dispose()
    {
      ContactInfo.DeleteAll();
    }
  }
}
