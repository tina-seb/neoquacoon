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
    
    public partial class Bio
    {
        public int BioID { get; set; }
        public string BioType { get; set; }
        public string BioDesc { get; set; }
        public Nullable<decimal> HourlyCost { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<int> CompanyId { get; set; }
    }
}
