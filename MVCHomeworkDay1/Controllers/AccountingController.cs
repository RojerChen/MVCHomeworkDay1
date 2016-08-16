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
           var  models = _accountingService.SelectAll().
                                            OrderByDescending(x => x.Date).ToList();
           return View(models); 
        }

        [HttpPost]
        public ActionResult Create(ViewModels.AccountingDetailViewModels model)
        {
            _accountingService.Create(new Models.AccountBook()
            {
                Id = Guid.NewGuid(),
                Amounttt = (int)model.Sum,
                Categoryyy = Convert.ToInt32(model.Type),
                Dateee = model.Date,
                Remarkkk = model.Note
            });
            _accountingService.Commit();
            return RedirectToAction("index");
        }
    }
}