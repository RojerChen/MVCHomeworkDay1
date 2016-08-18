using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCHomeworkDay1.ViewModels
{
    public class AccountingDetailViewModels
    {
        [DisplayName("支出與支出")]
        [Required]
        public string Type { get; set; }

        [DisplayName("日期")]
        [Required(ErrorMessage = "「日期」不得大於今天")]
        public DateTime Date { get; set; }

        [DisplayName("金額總計")]
        [Required(ErrorMessage="「金額」只能輸入正整數")]
        public decimal Sum { get; set; }

        [DisplayName("備註")]
        [StringLength(100),Required(ErrorMessage="最多輸入100個字元")]        
        public string Note { get; set; }
    }

    public enum AccountType
    {
        [Description("收入")]
        income = 0 ,

        [Description("支出")]
        outcount = 1
    }
}