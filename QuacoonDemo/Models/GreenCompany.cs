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
    
    public partial class GreenCompany
    {
        public int GreenCompanyID { get; set; }
        public int CompanyID { get; set; }
        public int TotalScore { get; set; }
        public int CertificationScore { get; set; }
        public int GreenProductScore { get; set; }
        public int PensionFundInvestmentScore { get; set; }
        public int RenewableElectricitySource { get; set; }
        public int GreenFleetScore { get; set; }
        public int EnergyAuditScore { get; set; }
        public int FoodWastageScore { get; set; }
        public System.DateTime UpdateDate { get; set; }
    }
}