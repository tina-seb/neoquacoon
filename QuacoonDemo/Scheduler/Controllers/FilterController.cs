using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Description;
using Quacoon.Models;
using System.Web.Mvc;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Globalization;
//using Newtonsoft.Json;

namespace Quacoon.Controllers
{
    public class FilterController : ApiController
    {
        private QuacoonEntities1 db = new QuacoonEntities1();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }

            base.Dispose(disposing);
        }

        // GET api/reco
        [ResponseType(typeof(List<CardViewModel>))]
        //public async Task<IHttpActionResult> Get()
        public List<CardViewModel> Get(string id)
        {
            string[] param = id.Split(':');

            string budget = param[0];
            string goal = param[1];

            var data = db.CurrentInventories.ToList().Where(d => d.Player != null && d.Sellingprice > 0 && d.Sellingprice <= 10 && d.Goal == goal).OrderBy(x => x.WatchCount).Take(12);

            List<CardViewModel> cvm = new List<CardViewModel>();

            if (budget == "$10-$100")
                data = db.CurrentInventories.ToList().Where(d => d.Player != null && d.Sellingprice > 10 && d.Sellingprice <= 100 && d.Goal == goal).OrderBy(x => x.WatchCount).Take(12);
            else if (budget == "$100-$1000")
                data = db.CurrentInventories.ToList().Where(d => d.Player != null && d.Sellingprice > 100 && d.Sellingprice <= 1000 && d.Goal == goal).OrderBy(x => x.WatchCount).Take(12);
            else if (budget == "$1000-$10000")
                data = db.CurrentInventories.ToList().Where(d => d.Player != null && d.Sellingprice > 1000 && d.Sellingprice <= 10000 && d.Goal == goal).OrderBy(x => x.WatchCount).Take(12);
            else if (budget == "$10000-$100000")
                data = db.CurrentInventories.ToList().Where(d => d.Player != null && d.Sellingprice > 10000 && d.Sellingprice <= 100000 && d.Goal == goal).OrderBy(x => x.WatchCount).Take(12);
            else if (budget == ">$100000")
                data = db.CurrentInventories.ToList().Where(d => d.Player != null && d.Sellingprice > 100000 && d.Goal == goal).OrderBy(x => x.WatchCount).Take(12);

            foreach (var d in data)
            {
                CardViewModel cm = new CardViewModel();

                var playerdata = db.Players.ToList().Where(p => p.Name == d.Player).FirstOrDefault();
                var playergraphdata = db.PlayerGraphs.ToList().Where(p => p.Name == d.Player).FirstOrDefault();

                if (playergraphdata != null)
                {
                    cm.One = playergraphdata.One;
                    cm.Two = playergraphdata.Two;
                    cm.Three = playergraphdata.Three;
                    cm.Four = playergraphdata.Four;
                    cm.Five = playergraphdata.Five;
                }

                cm.Title = d.Title;
                cm.ItemURL = d.ItemURL;
                cm.GalleryURL = d.GalleryURL;
                cm.Player = d.Player;

                if (d.Sellingprice != null)
                {
                    string formattedSellingPrice = String.Format("{0:C}", d.Sellingprice);
                    cm.Sellingprice = "Selling Price : " + formattedSellingPrice;
                }
                else
                {
                    cm.Sellingprice = "";
                }

                if (d.PopulationSupply != null)
                {
                    cm.PopulationSupply = "Population Supply : " + d.PopulationSupply.ToString();
                }
                else
                {
                    cm.PopulationSupply = "";
                }

                if (d.Grade != null)
                {
                    cm.Grade = "Grade : " + d.Grade;
                }
                else
                {
                    cm.Grade = "";
                }

                if (d.GradingCompany != null)
                {
                    cm.GradingCompany = "Grading Company : " + d.GradingCompany;
                }
                else
                {
                    cm.GradingCompany = "";
                }

                if (d.CardYear != null)
                {
                    cm.CardYear = "Card Year : " + d.CardYear;
                }
                else
                {
                    cm.CardYear = "";
                }

                if (d.CardManufacturer != null)
                {
                    cm.CardManufacturer = "Manufacturer : " + d.CardManufacturer;
                }
                else
                {
                    cm.CardManufacturer = "";
                }

                if (d.Era != null)
                {
                    cm.Era = "Era : " + d.Era;
                }
                else
                {
                    cm.Era = "";
                }

                if (d.Licensed != null)
                {
                    cm.Licensed = "Licensed : " + d.Licensed;
                }
                else
                {
                    cm.Licensed = "";
                }

                if (d.Feature != null)
                {
                    cm.Feature = "Feature : " + d.Feature;
                }
                else
                {
                    cm.Feature = "";
                }

                if (d.Original != null)
                {
                    cm.Original = "Original : " + d.Original;
                }
                else
                {
                    cm.Original = "";
                }

                if (d.League != null)
                {
                    cm.League = "League : " + d.League;
                }
                else
                {
                    cm.League = "";
                }

                if (d.Team != null)
                {
                    cm.Team = "Team : " + d.Team;
                }
                else
                {
                    cm.Team = "";
                }

                var stats = db.PlayerStats.Where(x => x.Name == cm.Player).Take(1);

                foreach (var s in stats)
                {
                    if (s.PlayerEfficiencyRating != null)
                    {
                        cm.PlayerEfficiencyRating = "Player Efficiency Rating : " + s.PlayerEfficiencyRating;
                    }
                    else
                    {
                        cm.PlayerEfficiencyRating = "";
                    }

                    if (s.TrueShootingPerc != null)
                    {
                        cm.TrueShootingPerc = "True Shooting Perc : " + s.TrueShootingPerc;
                    }
                    else
                    {
                        cm.TrueShootingPerc = "";
                    }

                    if (s.AssistRatio != null)
                    {
                        cm.AssistRatio = "Assist Ratio : " + s.AssistRatio;
                    }
                    else
                    {
                        cm.AssistRatio = "";
                    }

                    if (s.TurnoverRatio != null)
                    {
                        cm.TurnoverRatio = "Turnover Ratio : " + s.TurnoverRatio;
                    }
                    else
                    {
                        cm.TurnoverRatio = "";
                    }

                    if (s.ReboundRate != null)
                    {
                        cm.ReboundRate = "Rebound Ratio : " + s.ReboundRate;
                    }
                    else
                    {
                        cm.ReboundRate = "";
                    }

                    if (s.ValueAdded != null)
                    {
                        cm.ValueAdded = "ValueAdded : " + s.ValueAdded;
                    }
                    else
                    {
                        cm.ValueAdded = "";
                    }

                    if (s.EstimatedWinsAdded != null)
                    {
                        cm.EstimatedWinsAdded = "EstimatedWinsAdded : " + s.EstimatedWinsAdded;
                    }
                    else
                    {
                        cm.EstimatedWinsAdded = "";
                    }

                }

                cvm.Add(cm);

            }
            return cvm;
        }
    }
}


