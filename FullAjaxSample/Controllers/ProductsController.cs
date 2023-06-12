using FullAjaxAmple.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FullAjaxSample.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetAll()
        {
            using (ProductManager manager = new ProductManager())
            {
                var list = manager.GetAll();
                return Json(list,JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            using (ProductManager manager = new ProductManager())
            {
                manager.Delete(id);
                return Json("success");
            }
        }
    }
}