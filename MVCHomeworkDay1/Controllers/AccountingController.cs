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
            IList<ViewModels.AccountingDetailViewModels> models = GetAccountingDetail();
           return View(models);
        }

        public IList<ViewModels.AccountingDetailViewModels> GetAccountingDetail()
        {
            IList<ViewModels.AccountingDetailViewModels> accountingDateViewModelList = new List<ViewModels.AccountingDetailViewModels>();

            using (var db = new Models.SkillTreeHomeworkEntities())
            {
                var list = db.AccountBook.Take(5).ToList();
                foreach (var item in list)
                {
                    accountingDateViewModelList.Add(
                        new ViewModels.AccountingDetailViewModels()
                        {
                            Date = item.Dateee,
                            Note = item.Remarkkk,
                            Sum = item.Amounttt,
                            Type = item.Categoryyy.ToString()
                        });
                }

            }
            return accountingDateViewModelList;
        }
 
    }
}