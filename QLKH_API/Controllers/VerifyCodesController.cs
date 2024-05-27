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
    public class VerifyCodesController : ApiController
    {
        private QLKHEntities db = new QLKHEntities();

        [HttpGet]
        public List<VerifyCode> GetVerifyCodes()
        {
            return db.VerifyCodes.ToList();
        }

        [HttpGet]
        public VerifyCode FindByVerifyCodeID(int verifyCodeID)
        {
            return db.VerifyCodes.FirstOrDefault(x => x.verifyCodeID == verifyCodeID);
        }

        [HttpPost]
        public bool AddVerifyCode(int verifyCodeID, string email, string code, DateTime expiredTime)
        {
            VerifyCode ver = db.VerifyCodes.FirstOrDefault(x => x.verifyCodeID == verifyCodeID);
            if (ver == null)
            {
                VerifyCode ver1 = new VerifyCode();
                ver1.verifyCodeID = verifyCodeID;
                ver1.email = email;
                ver1.code = code;
                ver1.expiredTime = expiredTime;
                db.VerifyCodes.Add(ver1);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpPost]
        public bool UpdateVerifyCode(int verifyCodeID, string email, string code, DateTime expiredTime)
        {
            VerifyCode ver = db.VerifyCodes.FirstOrDefault(x => x.verifyCodeID == verifyCodeID);
            if (ver != null)
            {
                ver.verifyCodeID = verifyCodeID;
                ver.email = email;
                ver.code = code;
                ver.expiredTime = expiredTime;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpDelete]
        public bool DeleteVerifyCode(int id)
        {
            VerifyCode ver = db.VerifyCodes.FirstOrDefault(x => x.verifyCodeID == id);

            if (ver != null)
            {
                db.VerifyCodes.Remove(ver);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}