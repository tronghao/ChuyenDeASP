using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppMVCStudy.Controllers
{
    public class DamioController : Controller
    {
        //
        // GET: /Damio/
        public string Index()
        {
            return "Đây là phương thức Index, phương thức mặc định của Controller Dammio.";
        }

        // 
        // GET: /Dammio/ChaoMung/ 
        public string ChaoMung()
        {
            return "Đây là phương thức ChaoMung nằm trong Controller Dammio!";
        } 
	}
}