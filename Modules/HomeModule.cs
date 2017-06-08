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
      }; //homepage

      Get["/cuisines"] = _ => {
        List<Cuisine> allCuisines = Cuisine.GetAll();
        return View["cuisines.cshtml", allCuisines];
      }; //list of all cuisines

      Get["/restaurants"] = _ => {
        List<Restaurant> allRestaurants = Restaurant.GetAll();
        return View["restaurants.cshtml", allRestaurants];
      }; //list of all restaurants

      Get["/cuisines/new"] = _ => {
        return View["cuisines_form.cshtml"];
      }; //navigates to form to add new cuisine

      Post["/cuisines/new"] = _ => {
        Cuisine newCuisine = new Cuisine(Request.Form["cuisine-name"]);
        newCuisine.Save();
        List<Cuisine> allCuisines = Cuisine.GetAll();
        return View["cuisines.cshtml", allCuisines];
      }; //posts from form adding new cuisine, returns list of all cuisines

      Get["/restaurants/new"] = _ => {
        List<Cuisine> AllCuisines = Cuisine.GetAll();
        return View["restaurant_form.cshtml", AllCuisines];
      }; //navigates to form to add new restaurant

      Post["/restaurants/new"] = _ => {
        Restaurant newRestaurant = new Restaurant(Request.Form["restaurant-name"], Request.Form["restaurant-description"], Request.Form["cuisine-id"]);
        newRestaurant.Save();
        List<Restaurant> allRestaurants = Restaurant.GetAll();
        return View["restaurants.cshtml", allRestaurants];
      }; //posts from form adding new restaurant, returns list of all restaurants

      Post["/cuisines/clear"] = _ => {
        Cuisine.DeleteAll();
        return View["cuisines.cshtml"];
      }; //deletes all cuisines

      Post["/restaurants/clear"] = _ => {
        Restaurant.DeleteAll();
        return View["restaurants.cshtml"];
      }; //deletes all restaurants

      Get["/cuisines/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var SelectedCuisine = Cuisine.Find(parameters.id);
        var CuisineRestaurants = SelectedCuisine.GetRestaurants();
        model.Add("cuisine", SelectedCuisine);
        model.Add("restaurants", CuisineRestaurants);
        return View["cuisine.cshtml", model];
      }; //retrieves individual cuisine pages

      Get["/cuisine/edit/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>{};
        Cuisine SelectedCuisine = Cuisine.Find(parameters.id);
        string cuisineEdit = Request.Query["cuisine-edit"];
        model.Add("form-type", cuisineEdit);
        model.Add("cuisine", SelectedCuisine);
        return View["edit.cshtml", model];
      }; //edit individual cuisine

      Patch["/cuisine/edit/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Cuisine SelectedCuisine = Cuisine.Find(parameters.id);
        SelectedCuisine.Update(Request.Form["cuisine-name"]);
        var CuisineRestaurants = SelectedCuisine.GetRestaurants();
        model.Add("cuisine", SelectedCuisine);
        model.Add("restaurants", CuisineRestaurants);
        return View["cuisine.cshtml", model];
      }; //returns edited cuisine page

      Get["cuisine/delete/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>{};
        Cuisine SelectedCuisine = Cuisine.Find(parameters.id);
        string cuisineDelete = Request.Query["cuisine-delete"];
        model.Add("form-type", cuisineDelete);
        model.Add("cuisine", SelectedCuisine);
        return View["delete.cshtml", model];
      }; //delete individual cuisine

      Delete["cuisine/delete/{id}"] = parameters => {
        Cuisine SelectedCuisine = Cuisine.Find(parameters.id);
        SelectedCuisine.Delete();
        List<Cuisine> allCuisines = Cuisine.GetAll();
        return View["cuisines.cshtml", allCuisines];
      }; //returns confirmation of deleted cuisine

      Get["/restaurants/{id}"] = parameters => {
        var SelectedRestaurant = Restaurant.Find(parameters.id);
        return View["restaurant.cshtml", SelectedRestaurant];
      }; //retrieves individual restaurant pages

      Get["/restaurant/edit/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>{};
        Restaurant SelectedRestaurant = Restaurant.Find(parameters.id);
        string restaurantEdit = Request.Query["restaurant-edit"];
        model.Add("form-type", restaurantEdit);
        model.Add("restaurant", SelectedRestaurant);
        return View["edit.cshtml", model];
      }; //edit individual restaurants

      Patch["/restaurant/edit/{id}"] = parameters => {
        Restaurant SelectedRestaurant = Restaurant.Find(parameters.id);
        SelectedRestaurant.Update(Request.Form["restaurant-name"], Request.Form["restaurant-description"]);
        return View["restaurant.cshtml", SelectedRestaurant];
      }; //returns edited restaurant page

      Get["restaurant/delete/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>{};
        Restaurant SelectedRestaurant = Restaurant.Find(parameters.id);
        string restaurantDelete = Request.Query["restaurant-delete"];
        model.Add("form-type", restaurantDelete);
        model.Add("restaurant", SelectedRestaurant);
        return View["delete.cshtml", model];
      }; //delete individual restaurant

      Delete["restaurant/delete/{id}"] = parameters => {
        Restaurant SelectedRestaurant = Restaurant.Find(parameters.id);
        SelectedRestaurant.Delete();
        List<Restaurant> allRestaurants = Restaurant.GetAll();
        return View["restaurants.cshtml", allRestaurants];
      }; //returns list of all restaurants
    }
  }
}
