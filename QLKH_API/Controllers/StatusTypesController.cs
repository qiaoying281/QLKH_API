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
    public class StatusTypesController : ApiController
    {
        private QLKHEntities db = new QLKHEntities();

        [HttpGet]
        public List<StatusType> GetStatusTypes()
        {
            return db.StatusTypes.ToList();
        }

        [HttpGet]
        public StatusType FindByStatusTypeID(int statusTypeID)
        {
            return db.StatusTypes.FirstOrDefault(x => x.statusTypeID == statusTypeID);
        }

        [HttpPost]
        public bool AddStatusType(int statusTypeID, string statusName)
        {
            StatusType st = db.StatusTypes.FirstOrDefault(x => x.statusTypeID == statusTypeID);
            if (st == null)
            {
                StatusType st1 = new StatusType();
                st1.statusTypeID = statusTypeID;
                st1.statusName = statusName;
                st1.createAt = DateTime.Now;
                st1.updateAt = DateTime.Now;
                db.StatusTypes.Add(st1);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpPost]
        public bool UpdateStatusType(int statusTypeID, string statusName)
        {
            StatusType st = db.StatusTypes.FirstOrDefault(x => x.statusTypeID == statusTypeID);
            if (st != null)
            {
                st.statusTypeID = statusTypeID;
                st.statusName = statusName;
                st.updateAt = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpDelete]
        public bool DeleteStatusType(int id)
        {
            StatusType st = db.StatusTypes.FirstOrDefault(x => x.statusTypeID == id);

            if (st != null)
            {
                db.StatusTypes.Remove(st);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}