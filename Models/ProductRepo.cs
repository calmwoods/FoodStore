using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using FoodStore.ViewModels;

namespace FoodStore.Models
{
    public class ProductRepo
    {
        public const string PRODUCT_NAME                = "ProductName";
        public const string PRODUCT_NAME_DESC           = "ProductName_Desc";

        public const string MANUFACTURER_NAME           = "ManufacturerName";
        public const string MANUFACTURER_NAME_DESC      = "ManufacturerName_Desc";

        public const string MANUFACTURER_DISCOUNT       = "ManufacturerDiscount";
        public const string MANUFACTURER_DISCOUNT_DESC  = "ManufacturerDiscount_Desc";

        IEnumerable<ProductWithManufacturer> FilterProducts(
            IEnumerable<ProductWithManufacturer> products, string searchWord)
        {
            if (!String.IsNullOrEmpty(searchWord))
            {
                products = products.Where(
                    r => r.Name.ToUpper().Contains(searchWord.ToUpper())
                    || r.Mfg.ToUpper().Contains(searchWord.ToUpper()));
            }
            return products;
        }

        IEnumerable<ProductWithManufacturer> SortProducts(
            IEnumerable<ProductWithManufacturer> products, string sortOrder)
        {
            switch (sortOrder)
            {
                case PRODUCT_NAME :
                    products = products.OrderBy(r => r.Name);
                    break; 
                case PRODUCT_NAME_DESC:
                    products = products.OrderByDescending(r => r.Name);
                    break;
                case MANUFACTURER_NAME:
                    products = products.OrderBy(r => r.Mfg);
                    break;
                case MANUFACTURER_NAME_DESC:
                    products = products.OrderByDescending(r => r.Mfg);
                    break;
                case MANUFACTURER_DISCOUNT:
                    products = products.OrderBy(r => r.MfgDiscount);
                    break;
                case MANUFACTURER_DISCOUNT_DESC:
                    products = products.OrderByDescending(r => r.MfgDiscount);
                    break;
                default:
                    products = products.OrderBy(r => r.Name);
                    break;
            }
            return products;
        }

        public IEnumerable<ProductWithManufacturer> GetAllProductsWithMfg(
                                                        string searchWord, string sortOrder)
        {
            FoodStoreEntities db = new FoodStoreEntities();

            IEnumerable<ProductWithManufacturer> products = 
                            from p in db.Products
                            from m in db.Manufacturers
                            where p.mfg == m.mfg
                            select new ProductWithManufacturer
                            {
                                ProductID = p.productID,
                                Name = p.name,
                                Mfg = p.mfg,
                                Vendor = p.vendor,
                                Price = (decimal)p.price,
                                MfgDiscount = (decimal)m.mfgDiscount
                            };

            products = FilterProducts(products, searchWord);
            products = SortProducts(products, sortOrder);

            return products.ToList();
        }
    }
}