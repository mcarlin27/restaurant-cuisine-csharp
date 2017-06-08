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
    [Fact]
    public void Test_Update_ReturnsTrueIfContactInfosAreTheSame()
    {
      //Arrange
      Restaurant newRestaurant = new Restaurant("Saburos", "a sushi place", 2, 1);
      newRestaurant.Save();
      ContactInfo firstContactInfo = new ContactInfo("123 First st. Portland, OR", 2128675309, newRestaurant.GetId());
      firstContactInfo.Save();
      ContactInfo secondContactInfo = new ContactInfo("906 President st. Brooklyn, NY", 2128675309, newRestaurant.GetId(), firstContactInfo.GetId());
      //Act
      secondContactInfo.Update("123 First st. Portland, OR");
      //Assert
      Assert.Equal(firstContactInfo, secondContactInfo);
    }
    [Fact]
    public void Test_Delete_ReturnsTrueIfListsAreTheSame()
    {
      //Arrange
      ContactInfo firstContactInfo = new ContactInfo("123 First st. Portland, OR", 1234567890, 2);
      firstContactInfo.Save();

      ContactInfo secondContactInfo = new ContactInfo("906 President st. Brooklyn, NY", 2128675309, 2);
      secondContactInfo.Save();

      ContactInfo thirdContactInfo = new ContactInfo("316 10th st. Brooklyn, NY", 2024567890, 2);
      thirdContactInfo.Save();

      List<ContactInfo> expectedList = new List<ContactInfo>{firstContactInfo, secondContactInfo};

      //Act
      thirdContactInfo.Delete();
      List<ContactInfo> contactList = ContactInfo.GetAll();

      //Assert
      Assert.Equal(contactList, expectedList);

    }


    public void Dispose()
    {
      ContactInfo.DeleteAll();
    }
  }
}
