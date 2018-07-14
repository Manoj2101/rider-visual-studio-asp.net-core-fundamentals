using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OdeToFoodRider.Models;
using OdeToFoodRider.Services;
using OdeToFoodRider.ViewModels;

namespace OdeToFoodRider.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // VSRD: This time, "Initialize field from constructor" does exactly what we want.
        IRestaurantData _restaurantData;
        IGreeter _greeter;

        public HomeController(IRestaurantData restaurantData, IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }


        [AllowAnonymous]
        public IActionResult Index()
        {
            // VSRD: "Use object initialization" available in both IDEs but in Visual Studio, it's only available on the constructor call, not on further variable usages. 
            var model = new HomeIndexViewModel();
            model.Restaurants = _restaurantData.GetAll();
            model.CurrentMessage = _greeter.GetMessageOfTheDay();
            
            return View(model);
        }

        public IActionResult Details(int id)
        {
            // VSRD: Rider's completion misfires here, too: the opening parentheses completes the existing GetAll() method, too
            var model = _restaurantData.Get(id); // VSRD: In Rider, a "Check variable for null" CA is available, along with a quick path to null check pattern settings 
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestaurantEditModel model)
        {
            if (ModelState.IsValid)
            {
                var newRestaurant = new Restaurant();
                newRestaurant.Name = model.Name;
                newRestaurant.Cuisine = model.Cuisine;

                newRestaurant = _restaurantData.Add(newRestaurant);

                return RedirectToAction("Details", new {id = newRestaurant.Id});
            }

            return View();
        }
    }
}