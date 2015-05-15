using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PagedList;

using FoodStore.ViewModels;
using FoodStore.Models;

namespace FoodStore.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(string searchWord, string currentFilter, string sortOrder, int? page)
        {
            if (searchWord != null)
                page = 1;
            else
                searchWord = currentFilter;
             
            if (String.IsNullOrEmpty(sortOrder))
            {
                sortOrder = ProductRepo.PRODUCT_NAME;
            }

            ProductRepo productRepo = new ProductRepo();
            IEnumerable<ProductWithManufacturer> products =
                productRepo.GetAllProductsWithMfg(searchWord, sortOrder);

            // set ViewBag for order
            if (sortOrder == ProductRepo.PRODUCT_NAME)
            {
                ViewBag.ProductNameOrder = ProductRepo.PRODUCT_NAME_DESC;
            }
            else
            {
                ViewBag.ProductNameOrder = ProductRepo.PRODUCT_NAME;
            }

            if (sortOrder == ProductRepo.MANUFACTURER_NAME)
            {
                ViewBag.ManufacturerOrder = ProductRepo.MANUFACTURER_NAME_DESC;
            }
            else
            {
                ViewBag.ManufacturerOrder = ProductRepo.MANUFACTURER_NAME;
            }

            if (sortOrder == ProductRepo.MANUFACTURER_DISCOUNT)
            {
                ViewBag.ManufacturerDiscountOrder = ProductRepo.MANUFACTURER_DISCOUNT_DESC;
            }
            else
            {
                ViewBag.ManufacturerDiscountOrder = ProductRepo.MANUFACTURER_DISCOUNT;
            }

            // set searchword
            ViewBag.SearchWord      = searchWord;
            ViewBag.CurrentSort     = sortOrder;

            const int PAGE_SIZE = 2;
            int pageNumber = (page ?? 1);
            products = products.ToPagedList(pageNumber, PAGE_SIZE);

            return View(products);
        }
    }
}