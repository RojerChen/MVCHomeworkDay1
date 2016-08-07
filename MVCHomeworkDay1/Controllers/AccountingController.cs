using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCHomeworkDay1.Repositories;

namespace MVCHomeworkDay1.Controllers
{
    public class AccountingController : Controller
    {
        private Service.AccountingService _accountingService;

        public AccountingController()
        {
            var unitOfWork = new EFUnitOfWork();
            _accountingService = new Service.AccountingService(unitOfWork);
        }

        // GET: Accounting
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult Detail()
        {
            IList<ViewModels.AccountingDetailViewModels> models = _accountingService.SelectAll();
           return View(models);
        }
 
    }
}