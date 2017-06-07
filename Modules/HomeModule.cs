using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace Restaurant
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
      return View["index.cshtml"];
    };
    Get["/restaurants"] = _ => {
      List<Restaurant> allRestaurants = Restaurant.GetAll();
      return View["restaurants.cshtml", allRestaurants];
    };
    Get["/cuisines"] = _ => {
      List<Cuisine> allCuisines = Cuisine.GetAll();
      return View["cuisines.cshtml", allCuisines];
    };
    Get["/cuisines/new"] = _ => {
      return View["cuisines_form.cshtml"];
    };
    Post["/cuisines/new"] = _ => {
      Cuisine newCuisine = new Cuisine(Request.Form["cuisine-name"]);
      newCuisine.Save();
      return View["success.cshtml"];
    };
    Get["/restaurants/new"] = _ => {
      List<Cuisine> AllCuisines = Cuisine.GetAll();
      return View["restaurants_form.cshtml", AllCuisines];
    };
    Post["/restaurants/new"] = _ => {
      Restaurant newRestaurant = new Restaurant(Request.Form["restaurant-description"], Request.Form["cuisine-id"]);
      newRestaurant.Save();
      return View["success.cshtml"];
    };



    }
  }
}
