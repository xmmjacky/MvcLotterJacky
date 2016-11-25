using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLotterJacky.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            //分页代码
            //ViewBag.BusType = objEntity.BusType;
            //ViewBag.CommentType = objEntity.CommentType;
            //ViewBag.LikeDegree = objEntity.LikeDegree;
            //ViewBag.tags = objEntity.tag;
            //var result = _orderCommentLogic.GetCommentTagsPageList(objEntity);
            //var list = new List<CommentTagsEntity>(result);
            //var res = new PageResult<CommentTagsEntity>
            //{
            //    Code = 0,
            //    DataList = list,
            //    Total = list.Count > 0 ? list[0].Total : 0,
            //    PageSize = objEntity.PageSize,
            //    PageIndex = objEntity.PageIndex,
            //    RequestUrl = objEntity.RequetUrl

            //};
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }
	}
}