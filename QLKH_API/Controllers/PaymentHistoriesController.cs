using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using QLKH_API.Models;

namespace QLKH_API.Controllers
{
    public class PaymentHistoriesController : ApiController
    {
        private QLKHEntities db = new QLKHEntities();

        [HttpGet]
        public List<PaymentHistory> GetPaymentHistorys()
        {
            return db.PaymentHistorys.ToList();
        }

        [HttpGet]
        public PaymentHistory FindByPaymentHistoryID(int paymentHistoryID)
        {
            return db.PaymentHistorys.FirstOrDefault(x => x.paymentHistoryID == paymentHistoryID);
        }

        [HttpPost]
        public bool AddPaymentHistory(int paymentHistoryID, int studentID, int paymentTypeID, string paymentName, int amount)
        {
            PaymentHistory ph = db.PaymentHistorys.FirstOrDefault(x => x.paymentHistoryID == paymentHistoryID);
            if (ph == null)
            {
                PaymentHistory ph1 = new PaymentHistory();
                ph1.paymentHistoryID = paymentHistoryID;
                ph1.studentID = studentID;
                ph1.paymentTypeID = paymentTypeID;
                ph1.amount = amount;
                ph1.paymentName = paymentName;
                ph1.createAt = DateTime.Now;
                ph1.updateAt = DateTime.Now;
                db.PaymentHistorys.Add(ph1);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpPost]
        public bool UpdatePaymentHistory(int paymentHistoryID, int studentID, int paymentTypeID, string paymentName, int amount)
        {
            PaymentHistory ph = db.PaymentHistorys.FirstOrDefault(x => x.paymentHistoryID == paymentHistoryID);
            if (ph != null)
            {
                ph.paymentHistoryID = paymentHistoryID;
                ph.studentID = studentID;
                ph.paymentTypeID = paymentTypeID;
                ph.amount = amount;
                ph.paymentName = paymentName;
                ph.updateAt = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpDelete]
        public bool DeletePaymentHistory(int id)
        {
            PaymentHistory ph = db.PaymentHistorys.FirstOrDefault(x => x.paymentHistoryID == id);

            if (ph != null)
            {
                db.PaymentHistorys.Remove(ph);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}