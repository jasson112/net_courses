﻿using PieShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Pie> piesOfTheWeek { get; set; }
    }
}
