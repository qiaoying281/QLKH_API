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
    public class FeesController : ApiController
    {
        private QLKHEntities db = new QLKHEntities();

        [HttpGet]
        public List<Fee> GetFees()
        {
            return db.Fees.ToList();
        }

        [HttpGet]
        public Fee FindByFeeID(int feeID)
        {
            return db.Fees.FirstOrDefault(x => x.feeID == feeID);
        }

        [HttpPost]
        public bool AddFee(int feeID, int studentID, int courseID, int cost, string status, bool isChecked)
        {
            Fee fee = db.Fees.FirstOrDefault(x => x.feeID == feeID);
            if (fee == null)
            {
                Fee fee1 = new Fee();
                fee1.feeID = feeID;
                fee1.studentID = studentID;
                fee1.courseID = courseID;
                fee1.cost = cost;
                fee1.status = status;
                fee1.isChecked = isChecked;
                fee1.createAt = DateTime.Now;
                fee1.updateAt = DateTime.Now;
                db.Fees.Add(fee1);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpPost]
        public bool UpdateFee(int feeID, int studentID, int courseID, int cost, string status, bool isChecked)
        {
            Fee fee = db.Fees.FirstOrDefault(x => x.feeID == feeID);
            if (fee != null)
            {
                fee.feeID = feeID;
                fee.studentID = studentID;
                fee.courseID = courseID;
                fee.cost = cost;
                fee.status = status;
                fee.isChecked = isChecked;
                fee.updateAt = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpDelete]
        public bool DeleteFee(int id)
        {
            Fee fee = db.Fees.FirstOrDefault(x => x.feeID == id);

            if (fee != null)
            {
                db.Fees.Remove(fee);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}