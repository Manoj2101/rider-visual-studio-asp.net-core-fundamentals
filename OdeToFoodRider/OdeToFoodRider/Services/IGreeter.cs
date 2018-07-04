﻿namespace OdeToFoodRider.Services
{
    public interface IGreeter
    {
        string GetMessageOfTheDay();
    }

    class Greeter : IGreeter
    {
        public string GetMessageOfTheDay()
        {
            return "Greetings from Rider!";
            
        }
    }
}