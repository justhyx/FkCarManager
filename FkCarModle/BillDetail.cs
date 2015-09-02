using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FkCar.Modle
{
    /// <summary>
    /// 账目明细类
    /// </summary>
    public class BillDetail
    {
        public BookkeepingMethod Bookkeeping { get; set; } //借贷类
        public int BillID { get; set; }//所属账单ID
        public string Subject { get; set; }//明目
        public int AccountId { get; set; }//所属账号
        public float Amount { get; set; } //金额
        public DateTime MarkDate { get; set; }//记账日期


    }

    public enum BookkeepingMethod
    {
        /// <summary>
        /// 记入借
        /// </summary>
        Debit = 0,
        /// <summary>
        /// 记入贷方;
        /// </summary>
        credit = 1
    }
}
