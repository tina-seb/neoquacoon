using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using CardBoss.Models;
using Microsoft.AspNet.Identity;

namespace CardBoss.Controllers
{

    [Authorize]
    public class HomeController : Controller 
    {
        private static CardBossEntities1 db = new CardBossEntities1();
        public ActionResult Index()
        { 
            return View();
        }
        public ActionResult UploadProof()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadProof(HttpPostedFileBase postedFile)
        {
            try
            {
                var manager = new UserManager<ApplicationUser>(new Microsoft.AspNet.Identity.EntityFramework.UserStore<ApplicationUser>(new ApplicationDbContext()));
                String userid = User.Identity.GetUserId();
                var currentUser = manager.FindById(User.Identity.GetUserId());

                DateTime currentDate = DateTime.Now;

                string inputPath = Server.MapPath("~/Profiles/");
                if (!Directory.Exists(inputPath))
                {
                    Directory.CreateDirectory(inputPath);
                }

               /* if (postedFile != null)
                {
                    var fName = Path.GetFileName(postedFile.FileName);
                    fName = DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + fName;
                    String originalcardpath = Path.Combine(inputPath, fName);
                    postedFile.SaveAs(originalcardpath);

                    SaveAWS(inputPath, fName, "quacoo/profilepics");

                    String awsinputdir = "https://quacoo.s3.us-east-2.amazonaws.com/profilepics/";

                    SaveInput(Path.Combine(awsinputdir, fName), userid);
                }
                else
                {
                    return Redirect(Url.Action("Index", "Home"));
                } */

                return Redirect(Url.Action("Index", "Home"));
            }
            catch (Exception ex)
            {
                return Redirect(Url.Action("Index", "Home"));
            }
        }

       
    }
}