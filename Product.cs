//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FoodStore
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public Product()
        {
            this.ProductInvoiceWithQuantities = new HashSet<ProductInvoiceWithQuantity>();
            this.Invoices = new HashSet<Invoice>();
            this.PurchaseOrders = new HashSet<PurchaseOrder>();
        }
    
        public int productID { get; set; }
        public string name { get; set; }
        public string mfg { get; set; }
        public string vendor { get; set; }
        public Nullable<decimal> price { get; set; }
    
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<ProductInvoiceWithQuantity> ProductInvoiceWithQuantities { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
