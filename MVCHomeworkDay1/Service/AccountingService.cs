using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCHomeworkDay1.Repositories;
using MVCHomeworkDay1.Models;
using MVCHomeworkDay1.ViewModels;

namespace MVCHomeworkDay1.Service
{
    public class AccountingService : Repository<Models.AccountBook>
    {
        private readonly IRepository<Models.AccountBook> _accountingDetailRepo;

        public AccountingService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _accountingDetailRepo = new Repository<Models.AccountBook>(unitOfWork);
        }

        public IList<ViewModels.AccountingDetailViewModels> SelectAll()
        {
            var source = _accountingDetailRepo.LookupAll();
            return source.Select(item => new AccountingDetailViewModels()
                    {
           
                        Date = item.Dateee,
                        Note = item.Remarkkk,
                        Sum = item.Amounttt,
                        Type = item.Categoryyy.ToString()
                    }).ToList();
        }

    }
}