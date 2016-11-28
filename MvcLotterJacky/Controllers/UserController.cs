using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLotterModel;
using MvcLotterModel.Page;
using MvcLotterModel.ParView;
using MvcLotterServicesLogic;

namespace MvcLotterJacky.Controllers
{
    public class UserController : Controller
    {
        private readonly UserLogic _userLogic = new UserLogic();
        //
        // GET: /User/
        public ActionResult Index(User objUser)
        {
            ViewBag.userInfoPar = objUser;
            var page = _userLogic.QueueUserlistpage(objUser);
            var pv = new PageResult<User>();
            pv.PageIndex = objUser.PageIndex;
            pv.PageSize = objUser.PageSize;
            pv.DataList = page;
            pv.Total = page.Count > 0 ?  Convert.ToInt32(page[0].Total) : 0;
            pv.RequestUrl = objUser.RequetUrl;
            return View(pv);
        }

        public ActionResult Add()
        {
            return View();
        }
        //签到
        public object UserSign(long id)
        {
            var data = _userLogic.UpdateUserbyId(id);
            return data > 0 ? Json(new { status = 1, msg = "签到成功" }) : Json(new { status = -1, msg = "签到失败" });
        }
    }
}