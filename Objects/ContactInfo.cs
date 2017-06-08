// using System.Collections.Generic;
// using System.Data.SqlClient;
// using System;
//
// namespace Restaurant
// {
//   public class ContactInfo
//   {
//     private int _id;
//     private string _address;
//     private int _phone;
//     private int _restaurantId;
//
//     public ContactInfo(string Address, int Phone, int RestaurantId, int Id = 0)
//     {
//       _id = Id;
//       _address = Address;
//       _phone = Phone;
//       _restaurantId = RestaurantId;
//     }
//     public int GetId()
//     {
//       return _id;
//     }
//     public int GetAddress()
//     {
//       return _address;
//     }
//     public int GetPhone()
//     {
//       return _phone;
//     }
//     public int GetRestaurantId()
//     {
//       return _restaurantId;
//     }
//
//     public override bool Equals(System.Object otherContactInfo)
//     {
//       if (!(otherContactInfo is ContactInfo))
//       {
//         return false;
//       }
//       else{
//         ContactInfo newContactInfo = (ContactInfo) otherContactInfo;
//         bool idEquality = (this.GetId() == newContactInfo.GetId());
//         bool addressEquality = (this.GetAddress() == newRestaurant.GetAddress());
//         bool phoneEquality = (this.GetPhone() == newRestaurant.GetPhone());
//         bool restaurantEquality = this.GetRestaurantId() == newRestaurant.GetRestaurantId();
//         return (idEquality && addressEquality && phoneEquality && restaurantEquality);
//       }
//     }
//
//     public static void DeleteAll()
//     {
//       SqlConnection conn = DB.Connection();
//       conn.Open();
//       SqlCommand cmd = new SqlCommand("DELETE FROM contacts;", conn);
//       cmd.ExecuteNonQuery();
//       conn.Close();
//     }
//
//   }
//
// }
