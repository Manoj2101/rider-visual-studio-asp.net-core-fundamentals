using System.Collections.Generic;
using OdeToFoodRider.Models;

namespace OdeToFoodRider.Services
{
    public interface IRestaurantData
    {
        // VSRD: Complete Statement at GetAll{caret} generates both the parentheses and the semicolon
        IEnumerable<Restaurant> GetAll();
    }
}