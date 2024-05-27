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
    public class DecentralizationsController : ApiController
    {
        private QLKHEntities db = new QLKHEntities();

        [HttpGet]
        public List<Decentralization> GetDecentralizations()
        {
            return db.Decentralizations.ToList();
        }

        [HttpGet]
        public Decentralization FindByDecentralizationID(int decentralizationID)
        {
            return db.Decentralizations.FirstOrDefault(x => x.decentralizationID == decentralizationID);
        }

        [HttpPost]
        public bool AddDecentralization(int decentralizationID, string authorityName)
        {
            Decentralization dec = db.Decentralizations.FirstOrDefault(x => x.decentralizationID == decentralizationID);
            if (dec == null)
            {
                Decentralization dec1 = new Decentralization();
                dec1.decentralizationID = decentralizationID;
                dec1.authorityName = authorityName;
                dec1.createAt = DateTime.Now;
                dec1.updateAt = DateTime.Now;
                db.Decentralizations.Add(dec1);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpPost]
        public bool UpdateDecentralization(int decentralizationID, string authorityName)
        {
            Decentralization dec = db.Decentralizations.FirstOrDefault(x => x.decentralizationID == decentralizationID);
            if (dec != null)
            {
                dec.decentralizationID = decentralizationID;
                dec.authorityName = authorityName;
                dec.updateAt = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpDelete]
        public bool DeleteDecentralization(int id)
        {
            Decentralization dec = db.Decentralizations.FirstOrDefault(x => x.decentralizationID == id);

            if (dec != null)
            {
                db.Decentralizations.Remove(dec);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}