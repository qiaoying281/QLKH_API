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
    public class ExamTypesController : ApiController
    {
        private QLKHEntities db = new QLKHEntities();

        [HttpGet]
        public List<ExamType> GetExamTypes()
        {
            return db.ExamTypes.ToList();
        }

        [HttpGet]
        public ExamType FindByExamTypeID(int examTypeID)
        {
            return db.ExamTypes.FirstOrDefault(x => x.examTypeID == examTypeID);
        }

        [HttpPost]
        public bool AddExamType(int examTypeID, string examTypeName)
        {
            ExamType ext = db.ExamTypes.FirstOrDefault(x => x.examTypeID == examTypeID);
            if (ext == null)
            {
                ExamType ext1 = new ExamType();
                ext1.examTypeID = examTypeID;
                ext1.examTypeName = examTypeName;
                ext1.createAt = DateTime.Now;
                ext1.updateAt = DateTime.Now;
                db.ExamTypes.Add(ext1);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpPost]
        public bool UpdateExamType(int examTypeID, string examTypeName)
        {
            ExamType ext = db.ExamTypes.FirstOrDefault(x => x.examTypeID == examTypeID);
            if (ext != null)
            {
                ext.examTypeID = examTypeID;
                ext.examTypeName = examTypeName;
                ext.updateAt = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpDelete]
        public bool DeleteExamType(int id)
        {
            ExamType ext = db.ExamTypes.FirstOrDefault(x => x.examTypeID == id);

            if (ext != null)
            {
                db.ExamTypes.Remove(ext);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}