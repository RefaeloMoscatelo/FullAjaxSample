using FullAjaxAmple.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FullAjaxSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ProductManager manager = new ProductManager();
            // ככה מביא 10 ראשונים מהליסט שחזר
            //  var list = manager.Filter(x => x.ID >= 2 && x.DisplayName.StartsWith("a")).Take(10);

            // ככה מביא 10 ראשונים מהדטה בייס

            //   var list = manager.Filter(x => x.ID >= 2 && x.DisplayName.StartsWith("a")).Take(10).ToList();

            //select count(*) from table where ID>2 and DisplayName like 'a%'
            //sent to db
            // כאן זה מייתר לנו את המנג'רים כי אינסרט אפדייט דליט הכל אפשר דרך כאן כי הוא מתרגם לאסקיואל
            // var list = manager.Filter(x => x.ID >= 2 && x.DisplayName.StartsWith("a")).Count();

            var list = manager.GetAll();
           // int num = manager.getAll();
            return View(list);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}