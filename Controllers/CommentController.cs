using CommentProject.Logics;
using CommentProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommentProject.Controllers
{
    public class CommentController : Controller
    {
        CommentBL c = new CommentBL();
        // GET: Comment
        public ActionResult Index()
        {
            CommentObj o = new CommentObj();
            o.Data = c.GetItems();
            
            return View(o);
        }

        public void Remove(int ID)
        {
            c.DeleteItem(ID);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult SaveComment(CommentObj o)
        {
            Comment nc = new Comment();
            nc.CommentData = o.NewComment;
            nc.TimeStamp = DateTime.Now.ToString("g");
            nc.Name = "Lam Nguyen";
            
            c.AddItem(nc);
            return Json("1");
        }
    }
}