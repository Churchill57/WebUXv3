using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gold.MVC.ViewModels;

namespace Gold.MVC.Controllers
{
    public class IssueController : Controller
    {
        private readonly ApplicationDbContext _context;
        public IssueController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Issue
        public ActionResult IssueWidget()
        {
            return Content("Here's where issues would go!");
        }
    }
}