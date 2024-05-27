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
    public class PaymentTypesController : ApiController
    {
        private QLKHEntities db = new QLKHEntities();

        [HttpGet]
        public List<PaymentType> GetPaymentTypes()
        {
            return db.PaymentTypes.ToList();
        }

        [HttpGet]
        public PaymentType FindByPaymentTypeID(int paymentTypeID)
        {
            return db.PaymentTypes.FirstOrDefault(x => x.paymentTypeID == paymentTypeID);
        }

        [HttpPost]
        public bool AddPaymentType(int paymentTypeID, string paymentTypeName)
        {
            PaymentType pt = db.PaymentTypes.FirstOrDefault(x => x.paymentTypeID == paymentTypeID);
            if (pt == null)
            {
                PaymentType pt1 = new PaymentType();
                pt1.paymentTypeID = paymentTypeID;
                pt1.paymentTypeName = paymentTypeName;
                pt1.creatAt = DateTime.Now;
                pt1.updatedAt = DateTime.Now;
                db.PaymentTypes.Add(pt1);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpPost]
        public bool UpdatePaymentType(int paymentTypeID, string paymentTypeName)
        {
            PaymentType pt = db.PaymentTypes.FirstOrDefault(x => x.paymentTypeID == paymentTypeID);
            if (pt != null)
            {
                pt.paymentTypeID = paymentTypeID;
                pt.paymentTypeName = paymentTypeName;
                pt.updatedAt = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpDelete]
        public bool DeletePaymentType(int id)
        {
            PaymentType pt = db.PaymentTypes.FirstOrDefault(x => x.paymentTypeID == id);

            if (pt != null)
            {
                db.PaymentTypes.Remove(pt);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}