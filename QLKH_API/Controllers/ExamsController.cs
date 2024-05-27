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
    public class ExamsController : ApiController
    {
        private QLKHEntities db = new QLKHEntities();

        [HttpGet]
        public List<Exam> GetExams()
        {
            return db.Exams.ToList();
        }

        [HttpGet]
        public Exam FindByExamID(int examID)
        {
            return db.Exams.FirstOrDefault(x => x.examID == examID);
        }

        [HttpPost]
        public bool AddExam(int examID, int coursePartID, int examTypeID, string examName, string desription, int workTime, DateTime dueDate, float minGrade)
        {
            Exam exm = db.Exams.FirstOrDefault(x => x.examID == examID);
            if (exm == null)
            {
                Exam exm1 = new Exam();
                exm1.examID = examID;
                exm1.coursePartID = coursePartID;
                exm1.examTypeID = examTypeID;
                exm1.examName = examName;
                exm1.description = desription;
                exm1.workTime = workTime;
                exm1.dueDate = dueDate;
                exm1.minGrade = minGrade;
                exm1.createAt = DateTime.Now;
                exm1.updateAt = DateTime.Now;
                db.Exams.Add(exm1);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpPost]
        public bool UpdateExam(int examID, int coursePartID, int examTypeID, string examName, string desription, int workTime, DateTime dueDate, float minGrade)
        {
            Exam exm = db.Exams.FirstOrDefault(x => x.examID == examID);
            if (exm != null)
            {
                exm.examID = examID;
                exm.coursePartID = coursePartID;
                exm.examTypeID = examTypeID;
                exm.examName = examName;
                exm.description = desription;
                exm.workTime = workTime;
                exm.dueDate = dueDate;
                exm.minGrade = minGrade;
                exm.updateAt = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpDelete]
        public bool DeleteExam(int id)
        {
            Exam exm = db.Exams.FirstOrDefault(x => x.examID == id);

            if (exm != null)
            {
                db.Exams.Remove(exm);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}