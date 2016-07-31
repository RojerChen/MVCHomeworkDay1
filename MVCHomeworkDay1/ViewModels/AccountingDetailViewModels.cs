using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCHomeworkDay1.ViewModels
{
    public class AccountingDetailViewModels
    {
        //收入、支出
        public string Type { get; set; }

        //日期
        public DateTime Date { get; set; }

        //金額總計
        public decimal Sum { get; set; }

        //備註
        public string Note { get; set; }
    }
}