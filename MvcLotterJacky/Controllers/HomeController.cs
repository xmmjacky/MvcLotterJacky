using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLotterServicesLogic;

namespace MvcLotterJacky.Controllers
{
    public class HomeController : Controller
    {
        private readonly AwardsListLogic _awardsListLogic = new AwardsListLogic();
        private readonly object _lockobject = new object();
        //
        // GET: /抽奖页面
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }
	}
}