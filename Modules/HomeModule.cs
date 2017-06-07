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



    }
  }
}
