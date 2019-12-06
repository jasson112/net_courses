﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly ILogger<ListModel> logger;

        public IEnumerable<Restaurant> Restaurants { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IRestaurantData restaurantData, ILogger<ListModel> logger) {
            this.restaurantData = restaurantData;
            this.logger = logger;
        }

        public void OnGet()
        {
            Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
            logger.LogError("On ListModel");
        }
    }
}