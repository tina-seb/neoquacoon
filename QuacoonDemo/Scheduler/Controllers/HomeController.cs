using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quacoon.Models;
using Quacoon.Utilities;
using Microsoft.AspNet.Identity;

namespace Quacoon.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        { 
            return View();
        }

        public ActionResult Terms()
        {
            ViewBag.Message = "Terms & Conditions";

            return View();
        }

        public ActionResult MyQuacoon()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult DemoTwo()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult Map()
        {
            ViewBag.Message = "";

            return View();
        }


        public ActionResult Scheduler()
        {
            ViewBag.Message = "";

            return View();
        }

        [HttpPost]
        public ActionResult UploadCardImage(HttpPostedFileBase uploadFile1)
        {
            try
            {
                bool uploadStatus = false;
                String fileName = String.Empty;

                var manager = new UserManager<ApplicationUser>(new Microsoft.AspNet.Identity.EntityFramework.UserStore<ApplicationUser>(new ApplicationDbContext()));
                var currentUser = manager.FindById(User.Identity.GetUserId());

                DateTime currentDate = DateTime.Now;

                //fileName = "UploadedImage" + currentDate.Day.ToString() + currentDate.Month.ToString() + currentDate.Year.ToString() + currentDate.Hour.ToString() + currentDate.Minute.ToString() + currentDate.Second.ToString() + currentDate.Millisecond.ToString();

                if (uploadFile1 != null)
                {
                    var fName = Path.GetFileName(uploadFile1.FileName);
                    uploadFile1.SaveAs(Path.Combine(@"C:\Users\tinas\Desktop\Quacoon\UploadedImages", fName));

                    Bitmap edge_detection_img = ProcessCard.ApplyEdgeDetection(Path.Combine(@"C:\Users\tinas\Desktop\Quacoon\UploadedImages", fName));
                    edge_detection_img.Save(Path.Combine(@"C:\Users\tinas\Desktop\Quacoon\UploadedImages\Edge", fName),System.Drawing.Imaging.ImageFormat.Bmp);

                    Bitmap inverted_img = ProcessCard.ApplyInvert(Path.Combine(@"C:\Users\tinas\Desktop\Quacoon\UploadedImages", fName));
                    inverted_img.Save(Path.Combine(@"C:\Users\tinas\Desktop\Quacoon\UploadedImages\Inverted", fName), System.Drawing.Imaging.ImageFormat.Bmp);

                    Bitmap stained_img = ProcessCard.ApplyStainDetection(Path.Combine(@"C:\Users\tinas\Desktop\Quacoon\UploadedImages", fName));
                    stained_img.Save(Path.Combine(@"C:\Users\tinas\Desktop\Quacoon\UploadedImages\Stain", fName), System.Drawing.Imaging.ImageFormat.Bmp);

                    Bitmap oof_img = ProcessCard.OutOfFocusDetector(Path.Combine(@"C:\Users\tinas\Desktop\Quacoon\UploadedImages", fName));
                    oof_img.Save(Path.Combine(@"C:\Users\tinas\Desktop\Quacoon\UploadedImages\OOF", fName), System.Drawing.Imaging.ImageFormat.Bmp);

                    Bitmap corner_img = ProcessCard.CornerDetector(Path.Combine(@"C:\Users\tinas\Desktop\Quacoon\UploadedImages", fName));
                    corner_img.Save(Path.Combine(@"C:\Users\tinas\Desktop\Quacoon\UploadedImages\Corner", fName), System.Drawing.Imaging.ImageFormat.Bmp);

                    //Bitmap wavelet_img = ProcessCard.ApplyWaveletTransform(Path.Combine(@"C:\Users\tinas\Desktop\Quacoon\UploadedImages", fName));
                    //wavelet_img.Save(Path.Combine(@"C:\Users\tinas\Desktop\Quacoon\UploadedImages\Wavelet", fName), System.Drawing.Imaging.ImageFormat.Bmp);

                }
                return Redirect(Url.Action("Index", "Home"));
            }
            catch(Exception ex)
            {
                return Redirect(Url.Action("Index", "Home"));
            }
        }

    }
}