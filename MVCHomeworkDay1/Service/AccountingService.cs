using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MVCHomeworkDay1.Service
{
    public class AccountingService
    {

        private readonly Models.SkillTreeHomeworkEntities _db;

        public AccountingService()
        {
            _db = new Models.SkillTreeHomeworkEntities();
        }

        public IList<ViewModels.AccountingDetailViewModels> GetAccountingDetail(int count)
        {
            IList<ViewModels.AccountingDetailViewModels> accountingDateViewModelList = new List<ViewModels.AccountingDetailViewModels>();

   
            var list = _db.AccountBook.Take(count).ToList();

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
            return accountingDateViewModelList;

        }
    }
}