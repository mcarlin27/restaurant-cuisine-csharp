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

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO contacts (address, phone, restaurant_id) OUTPUT INSERTED.id VALUES (@ContactInfoAddress, @ContactInfoPhone, @ContactRestaurantId);", conn);

      SqlParameter addressParameter = new SqlParameter();
      addressParameter.ParameterName = "@ContactInfoAddress";
      addressParameter.Value = this.GetAddress();

      SqlParameter phoneParameter = new SqlParameter();
      phoneParameter.ParameterName = "@ContactInfoPhone";
      phoneParameter.Value = this.GetPhone();

      SqlParameter restaurantIdParameter = new SqlParameter();
      restaurantIdParameter.ParameterName = "@ContactRestaurantId";
      restaurantIdParameter.Value = this.GetRestaurantId();

      cmd.Parameters.Add(addressParameter);
      cmd.Parameters.Add(phoneParameter);
      cmd.Parameters.Add(restaurantIdParameter);

      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
    }

    public void Update(string newAddress)
    { //Update method for strings
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("UPDATE contacts SET address = @NewAddress OUTPUT INSERTED.address WHERE id = @ContactId;", conn);

      SqlParameter newAddressParameter = new SqlParameter();
      newAddressParameter.ParameterName = "@NewAddress";
      newAddressParameter.Value = newAddress;
      cmd.Parameters.Add(newAddressParameter);

      SqlParameter contactIdParameter = new SqlParameter();
      contactIdParameter.ParameterName = "@ContactId";
      contactIdParameter.Value = this.GetId();
      cmd.Parameters.Add(contactIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._address = rdr.GetString(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
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

    public static ContactInfo Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM contacts WHERE id = @ContactId;", conn);
      SqlParameter contactIdParameter = new SqlParameter();
      contactIdParameter.ParameterName = "@ContactId";
      contactIdParameter.Value = id.ToString();
      cmd.Parameters.Add(contactIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundContactId = 0;
      string foundContactAddress = null;
      int foundContactPhone = 0;
      int foundRestaurantId = 0;
      while(rdr.Read())
      {
        foundContactId = rdr.GetInt32(0);
        foundContactAddress = rdr.GetString(1);
        foundContactPhone = rdr.GetInt32(2);
        foundRestaurantId = rdr.GetInt32(3);
      }
      ContactInfo foundContactInfo = new ContactInfo(foundContactAddress, foundContactPhone, foundRestaurantId,  foundContactId);

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return foundContactInfo;
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
