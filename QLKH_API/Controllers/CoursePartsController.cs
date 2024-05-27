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
    public class CoursePartPartsController : ApiController
    {
        private QLKHEntities db = new QLKHEntities();

        [HttpGet]
        public List<CoursePart> GetCours()
        {
            return db.CourseParts.ToList();
        }

        [HttpGet]
        public CoursePart FindByCoursePartID(int coursePartID)
        {
            return db.CourseParts.FirstOrDefault(x => x.coursePartID == coursePartID);
        }

        [HttpPost]
        public bool AddCoursePart(int coursePartID, int courseID, string partTitle, int amount, int duration, int index)
        {
            CoursePart cp = db.CourseParts.FirstOrDefault(x => x.coursePartID == coursePartID);
            if (cp == null)
            {
                CoursePart cp1 = new CoursePart();
                cp1.coursePartID = coursePartID;
                cp1.courseID = courseID;
                cp1.partTitle = partTitle;
                cp1.amout = amount;
                cp1.duration = duration;
                cp1.index = index;
                cp1.createAt = DateTime.Now;
                cp1.updateAt = DateTime.Now;
                db.CourseParts.Add(cp1);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpPost]
        public bool UpdateCoursePart(int coursePartID, int courseID, string partTitle, int amount, int duration, int index)
        {
            CoursePart cp = db.CourseParts.FirstOrDefault(x => x.coursePartID == coursePartID);
            if (cp != null)
            {
                cp.coursePartID = coursePartID;
                cp.courseID = courseID;
                cp.partTitle = partTitle;
                cp.amout = amount;
                cp.duration = duration;
                cp.index = index;
                cp.updateAt = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpDelete]
        public bool DeleteCoursePart(int id)
        {
            CoursePart cp = db.CourseParts.FirstOrDefault(x => x.coursePartID == id);

            if (cp != null)
            {
                db.CourseParts.Remove(cp);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}