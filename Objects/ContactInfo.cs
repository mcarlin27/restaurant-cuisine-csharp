using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace Restaurant
{
  public class ContactInfo
  {
    private int _id;
    private string _address;
    private int _phone;
    private int _restaurantId;

    public ContactInfo(string Address, int Phone, int RestaurantId, int Id = 0)
    {
      _id = Id;
      _address = Address;
      _phone = Phone;
      _restaurantId = RestaurantId;
    }
    public int GetId()
    {
      return _id;
    }
    public string GetAddress()
    {
      return _address;
    }
    public int GetPhone()
    {
      return _phone;
    }
    public int GetRestaurantId()
    {
      return _restaurantId;
    }

    public override bool Equals(System.Object otherContactInfo)
    {
      if (!(otherContactInfo is ContactInfo))
      {
        return false;
      }
      else{
        ContactInfo newContactInfo = (ContactInfo) otherContactInfo;
        bool idEquality = (this.GetId() == newContactInfo.GetId());
        bool addressEquality = (this.GetAddress() == newContactInfo.GetAddress());
        bool phoneEquality = (this.GetPhone() == newContactInfo.GetPhone());
        bool restaurantEquality = this.GetRestaurantId() == newContactInfo.GetRestaurantId();
        return (idEquality && addressEquality && phoneEquality && restaurantEquality);
      }
    }

    public static List<ContactInfo> GetAll()
    {
      List<ContactInfo> allContacts = new List<ContactInfo> {};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM contacts;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int contactId = rdr.GetInt32(0);
        string contactAddress = rdr.GetString(1);
        int contactPhone = rdr.GetInt32(2);
        int contactRestaurantId = rdr.GetInt32(3);
        ContactInfo newContactInfo = new ContactInfo(contactAddress, contactPhone, contactRestaurantId, contactId);
        allContacts.Add(newContactInfo);
      }

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return allContacts;
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM contacts;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }

  }

}
