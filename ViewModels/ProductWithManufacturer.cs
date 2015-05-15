using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodStore.ViewModels
{
    public class ProductWithManufacturer
    {
            public int      ProductID   { get; set; }
            public string   Name        { get; set; }
            public string   Mfg         { get; set; }
            public string   Vendor      { get; set; }
            public decimal  Price       { get; set; }
            public decimal  MfgDiscount { get; set; }
    }
}