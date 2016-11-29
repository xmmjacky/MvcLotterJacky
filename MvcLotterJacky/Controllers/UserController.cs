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
        private readonly object _lockobject = new object();
        //
        // GET: /User/
        public ActionResult Index(User objUser)
        { 
            ViewBag.userInfoPar = objUser;
            var page = _userLogic.QueueUserlistpage(objUser);
            var pv = new PageResult<User>();
            pv.PageIndex = objUser.PageIndex;
            pv.PageSize = objUser.PageSize;
            pv.DataList = page ?? new List<User>(); ;
            pv.Total = page != null && page.Count >= 0 ? Convert.ToInt32(page[0].Total) : 0;
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
        /// <summary>
        /// 新增员工资料
        /// </summary>
        /// <param name="userNo"></param>
        /// <param name="userName"></param>
        /// <param name="phone"></param>
        /// <param name="department"></param>
        /// <returns></returns>
        public object InsertUser(string userNo, string userName, string phone, string department)
        {
            if (string.IsNullOrEmpty(userNo))
            {
                return Json(new {status = -1, msg = "员工编号不能为空"});
            }
            
            lock (_lockobject)
            {

                var resp = _userLogic.QueueUserlist(userNo);
                if (resp != null) return Json(new { status = -1, msg = "该员工已经存在！" }); 
                var m = new User()
                {
                    UserNo = userNo,
                    UserName = userName,
                    phone = phone,
                    Department = department,
                    Islottery = false,
                    IsSign = false
                };
                var data = _userLogic.Inseruser(m);
                return data > 0 ? Json(new { status = 1, msg = "新增员工成功" }) : Json(new { status = -1, msg = "新增员工失败" });
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public object DelAwards(long id)
        {
            var data = _userLogic.DeleteUserById(id);
            return data > 0 ? Json(new { status = 1, msg = "删除成功" }) : Json(new { status = -1, msg = "删除失败" });
        }
    }
}