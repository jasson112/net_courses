﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Data;

namespace OdeToFood
{
    public class ClientRestaurantsModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        public ClientRestaurantsModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
       
    }
}