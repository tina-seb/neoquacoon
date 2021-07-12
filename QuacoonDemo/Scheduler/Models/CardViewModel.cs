namespace Quacoon.Models
{
    using System;
    using System.Collections.Generic;

    public class CardViewModel
    {
        public string Title { get; set; }
        public long EBayItemID { get; set; }
        public string ItemURL { get; set; }
        public string GalleryURL { get; set; }
        public string Sellingprice { get; set; }
        public string PopulationSupply { get; set; }
        public string Grade { get; set; }
        public string GradingCompany { get; set; }
        public string CardYear { get; set; }
        public string CardManufacturer { get; set; }
        public string Era { get; set; }
        public string Feature { get; set; }
        public string Licensed { get; set; }
        public string Original { get; set; }
        public string League { get; set; }
        public string Player { get; set; }
        public string Team { get; set; }

        //Player Info

        public string PlayerEfficiencyRating { get; set; }
        public string TrueShootingPerc { get; set; }
        public string AssistRatio { get; set; }
        public string TurnoverRatio { get; set; }
        public string ReboundRate { get; set; }
        public string ValueAdded { get; set; }
        public string EstimatedWinsAdded { get; set; }

        public string FutureExpectationDesc { get; set; }

        //PlayerGraphInfo

        public Nullable<decimal> Zero { get; set; }
        public Nullable<decimal> One { get; set; }
        public Nullable<decimal> Two { get; set; }
        public Nullable<decimal> Three { get; set; }
        public Nullable<decimal> Four { get; set; }
        public Nullable<decimal> Five { get; set; }

    }
}
