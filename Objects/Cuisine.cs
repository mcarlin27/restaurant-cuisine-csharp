using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace Restaurant
{
  public class Cuisine
  {
    private int _id;
    private string _name;

    public Cuisine(string Name, int Id = 0)
    {
      _id = Id;
      _name = Name;
    }

    public override bool Equals(System.Object otherCuisine)
    {
      if (!(otherCuisine is Cuisine))
      {
        return false;
      }
      else
      {
        Cuisine newCuisine = (Cuisine) otherCuisine;
        bool idEquality = this.GetId() == newCuisine.GetId();
        bool nameEquality = this.GetName() == newCuisine.GetName();
        return (idEquality && nameEquality);
      }
    }


    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }
    public void SetName(string newName)
    {
      _name = newName;
    }

    // public static void DeleteAll()
    //   {
    //     SqlConnection conn = DB.Connection();
    //     conn.Open();
    //     SqlCommand cmd = new SqlCommand("DELETE FROM cuisines;", conn);
    //     cmd.ExecuteNonQuery();
    //     conn.Close();
    //   }


  }
}
