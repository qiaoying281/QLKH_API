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
    public class CoursController : ApiController
    {
        private QLKHEntities db = new QLKHEntities();

        [HttpGet]
        public List<Cours> GetCours()
        {
            return db.Courses.ToList();
        }

        [HttpGet]
        public Cours FindByCourseID(int courseID)
        {
            return db.Courses.FirstOrDefault(x => x.courseID == courseID);
        }

        [HttpPost]
        public bool AddCourse(int courseID, string courseName, string courseDescription, int tutorID, int cost)
        {
            Cours cou = db.Courses.FirstOrDefault(x => x.courseID == courseID);
            if (cou == null)
            {
                Cours cou1 = new Cours();
                cou1.courseID = courseID;
                cou1.courseName = courseName;
                cou1.courseDescription = courseDescription;
                cou1.tutorID = tutorID;
                cou1.cost = cost;
                cou1.createAt = DateTime.Now;
                cou1.updateAt = DateTime.Now;
                db.Courses.Add(cou1);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpPost]
        public bool UpdateCourse(int courseID, string courseName, string courseDescription, int tutorID, int cost)
        {
            Cours cou = db.Courses.FirstOrDefault(x => x.courseID == courseID);
            if (cou != null)
            {
                cou.courseID = courseID;
                cou.courseName = courseName;
                cou.courseDescription = courseDescription;
                cou.tutorID = tutorID;
                cou.cost = cost;
                cou.updateAt = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpDelete]
        public bool DeleteCourse(int id)
        {
            Cours cou = db.Courses.FirstOrDefault(x => x.courseID == id);

            if (cou != null)
            {
                db.Courses.Remove(cou);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}