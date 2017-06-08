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
    [Fact]
    public void Test_Equal_ReturnsTrueIfAddressesAreTheSame()
    {
      //Arrange, Act
      ContactInfo firstContactInfo = new ContactInfo("906 President st. Brooklyn, NY", 2128675309, 1);
      ContactInfo secondContactInfo = new ContactInfo("906 President st. Brooklyn, NY", 2128675309, 1);
      //Assert
      Assert.Equal(firstContactInfo, secondContactInfo);
    }
    [Fact]
    public void Test_Save_SavesToDatabase()
    {
      //Arrange
      ContactInfo testContactInfo = new ContactInfo("906 President st. Brooklyn, NY", 2128675309, 1);
      //Act
      testContactInfo.Save();
      List<ContactInfo> result = ContactInfo.GetAll();
      List<ContactInfo> testList = new List<ContactInfo>{testContactInfo};
      //Assert
      Assert.Equal(testList, result);
    }
    public void Dispose()
    {
      ContactInfo.DeleteAll();
    }
    [Fact]
    public void Test_Save_AssignsIdToObject()
    {
      //Arrange
      ContactInfo testContactInfo = new ContactInfo("906 President st. Brooklyn, NY", 2128675309, 1);
      //Act
      testContactInfo.Save();
      ContactInfo savedContactInfo = ContactInfo.GetAll()[0];
      int result = savedContactInfo.GetId();
      int testId = testContactInfo.GetId();
      //Assert
      Assert.Equal(testId, result);
    }
    [Fact]
    public void Test_Find_FindsContactInfoInDatabase()
    {
      //Arrange
      ContactInfo testContactInfo = new ContactInfo("906 President st. Brooklyn, NY", 2128675309, 1);
      testContactInfo.Save();
      //Act
      ContactInfo foundContactInfo = ContactInfo.Find(testContactInfo.GetId());
      //Assert
      Assert.Equal(testContactInfo, foundContactInfo);
    }



  }
}
