using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCHomeworkDay1.Controllers
{
    public class AccountingController : Controller
    {
        // GET: Accounting
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult Detail()
        {
           IList<ViewModels.AccountingDetailViewModels> models = new List<ViewModels.AccountingDetailViewModels>();
           models.Add(new ViewModels.AccountingDetailViewModels(){
               Type = "收入" ,
               Date = DateTime.Now,
               Sum = 10,
               Note = String.Empty
           });

           models.Add(new ViewModels.AccountingDetailViewModels()
           {
               Type = "支出",
               Date = DateTime.Now.AddDays(-1),
               Sum = 20,
               Note = String.Empty
           });

           models.Add(new ViewModels.AccountingDetailViewModels()
           {
               Type = "支出",
               Date = DateTime.Now.AddDays(-2),
               Sum = 30,
               Note = String.Empty
           });

           return View(models);
        }
    }
}