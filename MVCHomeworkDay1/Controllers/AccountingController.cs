using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCHomeworkDay1.Controllers
{
    public class AccountingController : Controller
    {
        private Service.AccountingService _accountingService;

        public AccountingController()
        {
            _accountingService = new Service.AccountingService();
        }

        // GET: Accounting
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult Detail()
        {
            IList<ViewModels.AccountingDetailViewModels> models = _accountingService.GetAccountingDetail(5);
           return View(models);
        }
 
    }
}