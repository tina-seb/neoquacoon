//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Quacoon.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SoldInventory
    {
        public int ID { get; set; }
        public long EBayItemID { get; set; }
        public string EbayTitle { get; set; }
        public Nullable<int> CardID { get; set; }
        public string ItemURL { get; set; }
        public string GalleryURL { get; set; }
        public long CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string PostalCode { get; set; }
        public string BuyerLocation { get; set; }
        public Nullable<double> SellingPrice { get; set; }
        public Nullable<double> ShippingPrice { get; set; }
        public Nullable<System.DateTime> SoldTime { get; set; }
        public Nullable<int> PlayerID { get; set; }
        public Nullable<int> PriceChange { get; set; }
    }
}
