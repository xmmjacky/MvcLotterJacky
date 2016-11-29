using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLotterModel;
using MvcLotterModel.Page;
using MvcLotterServicesLogic;

namespace MvcLotterJacky.Controllers
{
    public class AwardsController : Controller
    {
        private readonly AwardsListLogic _awardsListLogic=new AwardsListLogic();
        private readonly object _lockobject = new object();
        //
        // GET: /Awards/
        public ActionResult Index(AwardsListEntity objEntity)
        {
            ViewBag.userInfoPar = objEntity;
            var page = _awardsListLogic.GetAwardsListpageList(objEntity);
            var pv = new PageResult<AwardsListEntity>();
            pv.PageIndex = objEntity.PageIndex;
            pv.PageSize = objEntity.PageSize;
            pv.DataList = page ?? new List<AwardsListEntity>();
            pv.Total = page != null && page.Count >= 0 ? Convert.ToInt32(page[0].Total) : 0;
            pv.RequestUrl = objEntity.RequetUrl;
            return View(pv);
        }

        public ActionResult Add()
        {
            return View();
        }


        public object InsertAwards(string Awards, int AwardsNum, string AwardsGoods)
        {
            if (string.IsNullOrEmpty(Awards))
            {
                return Json(new { status = -1, msg = "奖品等级不能为空！" });
            }
            lock (_lockobject)
            {
                var resp = _awardsListLogic.GetAwardsListByAwards(Awards);
                if (resp != null) return Json(new { status = -1, msg = "该奖品等级已经设置过！" });
                var m = new AwardsListEntity()
                {
                    Awards = Awards,
                    AwardsNum = AwardsNum,
                    UsedNum=AwardsNum,
                    AwardsGoods = AwardsGoods
                };
                var data = _awardsListLogic.InsertAwards(m);
                return data > 0 ? Json(new { status = 1, msg = "奖品设置成功" }) : Json(new { status = -1, msg = "奖品设置失败" });
            }
        }

        public object DelAwards(long id)
        {
            var data = _awardsListLogic.DelAwardsList(id);
            return data > 0 ? Json(new { status = 1, msg = "删除成功" }) : Json(new { status = -1, msg = "删除失败" });
        }
	}
}