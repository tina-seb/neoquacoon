//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CardBoss.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vendor
    {
        public int ServiceVendorID { get; set; }
        public string ServiceType { get; set; }
        public string ServiceDesc { get; set; }
        public string ServiceImage { get; set; }
        public Nullable<decimal> HourlyCost { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<int> CompanyId { get; set; }
    }
}