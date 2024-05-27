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
    public class EnrollmentsController : ApiController
    {
        private QLKHEntities db = new QLKHEntities();

        [HttpGet]
        public List<Enrollment> GetEnrollments()
        {
            return db.Enrollments.ToList();
        }

        [HttpGet]
        public Enrollment FindByEnrollmentID(int enrollmentID)
        {
            return db.Enrollments.FirstOrDefault(x => x.enrollmentID == enrollmentID);
        }

        [HttpPost]
        public bool AddEnrollment(int enrollmentID, int studentID, int courseID, int tutorID, DateTime enrollmentDate, int statusTypeID)
        {
            Enrollment enr = db.Enrollments.FirstOrDefault(x => x.enrollmentID == enrollmentID);
            if (enr == null)
            {
                Enrollment enr1 = new Enrollment();
                enr1.enrollmentID = enrollmentID;
                enr1.studentID = studentID;
                enr1.courseID = courseID;
                enr1.tutorID = tutorID;
                enr1.statusTypeID = statusTypeID;
                enr1.enrollmentDate = enrollmentDate;
                enr1.createAt = DateTime.Now;
                enr1.updateAt = DateTime.Now;
                db.Enrollments.Add(enr1);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpPost]
        public bool UpdateEnrollment(int enrollmentID, int studentID, int courseID, int tutorID, DateTime enrollmentDate, int statusTypeID)
        {
            Enrollment enr = db.Enrollments.FirstOrDefault(x => x.enrollmentID == enrollmentID);
            if (enr != null)
            {
                enr.enrollmentID = enrollmentID;
                enr.studentID = studentID;
                enr.courseID = courseID;
                enr.tutorID = tutorID;
                enr.statusTypeID = statusTypeID;
                enr.enrollmentDate = enrollmentDate;
                enr.updateAt = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpDelete]
        public bool DeleteEnrollment(int id)
        {
            Enrollment enr = db.Enrollments.FirstOrDefault(x => x.enrollmentID == id);

            if (enr != null)
            {
                db.Enrollments.Remove(enr);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}