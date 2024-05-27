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
    public class SubmissionsController : ApiController
    {
        private QLKHEntities db = new QLKHEntities();

        [HttpGet]
        public List<Submission> GetSubmissions()
        {
            return db.Submissions.ToList();
        }

        [HttpGet]
        public Submission FindBySubmissionID(int submissionID)
        {
            return db.Submissions.FirstOrDefault(x => x.submissionID == submissionID);
        }

        [HttpPost]
        public bool AddSubmission(int submissionID, int examID, int studentID, DateTime submissionDate, int examTimes, int grade)
        {
            Submission sub = db.Submissions.FirstOrDefault(x => x.submissionID == submissionID);
            if (sub == null)
            {
                Submission sub1 = new Submission();
                sub1.submissionID = submissionID;
                sub1.examID = examID;
                sub1.studentID = studentID;
                sub1.submissionDate = submissionDate;
                sub1.examTimes = examTimes;
                sub1.grade = grade;
                sub1.createAt = DateTime.Now;
                sub1.updateAt = DateTime.Now;
                db.Submissions.Add(sub1);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpPost]
        public bool UpdateSubmission(int submissionID, int examID, int studentID, DateTime submissionDate, int examTimes, int grade)
        {
            Submission sub = db.Submissions.FirstOrDefault(x => x.submissionID == submissionID);
            if (sub != null)
            {
                sub.submissionID = submissionID;
                sub.examID = examID;
                sub.studentID = studentID;
                sub.submissionDate = submissionDate;
                sub.examTimes = examTimes;
                sub.grade = grade;
                sub.updateAt = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpDelete]
        public bool DeleteSubmission(int id)
        {
            Submission sub = db.Submissions.FirstOrDefault(x => x.submissionID == id);

            if (sub != null)
            {
                db.Submissions.Remove(sub);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}