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
    
    public partial class Player
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> PER { get; set; }
        public string FutureExpectationDesc { get; set; }
        public Nullable<int> FutureExpectationRating { get; set; }
        public Nullable<decimal> FiveYearMarketValue { get; set; }
        public string PersonalAttributesDesc { get; set; }
        public Nullable<int> PersonalAttributesRating { get; set; }
        public string Tweets { get; set; }
        public Nullable<int> TwitterSentimentScore { get; set; }
        public Nullable<int> RecentInjuryHistory { get; set; }
        public string TeamName { get; set; }
        public Nullable<int> TeamRank { get; set; }
        public Nullable<int> HallofFame { get; set; }
        public Nullable<int> Retirement { get; set; }
        public Nullable<int> League { get; set; }
        public Nullable<int> Legend { get; set; }
    }
}
