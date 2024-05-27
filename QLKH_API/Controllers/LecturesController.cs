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
    public class LecturesController : ApiController
    {
        private QLKHEntities db = new QLKHEntities();

        [HttpGet]
        public List<Lecture> GetLectures()
        {
            return db.Lectures.ToList();
        }

        [HttpGet]
        public Lecture FindByLectureID(int lectureID)
        {
            return db.Lectures.FirstOrDefault(x => x.lectureID == lectureID);
        }

        [HttpPost]
        public bool AddLecture(int lectureID, int coursePartID, string lectureTitle, string lectureLink, int duration, bool isWatched, bool isWatching, bool isAvailable, int index)
        {
            Lecture lec = db.Lectures.FirstOrDefault(x => x.lectureID == lectureID);
            if (lec == null)
            {
                Lecture lec1 = new Lecture();
                lec1.lectureID = lectureID;
                lec1.coursePartID = coursePartID;
                lec1.lectureLink = lectureLink;
                lec1.lectureTitle = lectureTitle;
                lec1.duration = duration;
                lec1.isWatched = isWatched;
                lec1.isAvailable = isAvailable;
                lec1.index = index;
                lec1 .isWatching = isWatching;
                lec1.createAt = DateTime.Now;
                lec1.updateAt = DateTime.Now;
                db.Lectures.Add(lec1);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpPost]
        public bool UpdateLecture(int lectureID, int coursePartID, string lectureTitle, string lectureLink, int duration, bool isWatched, bool isWatching, bool isAvailable, int index)
        {
            Lecture lec = db.Lectures.FirstOrDefault(x => x.lectureID == lectureID);
            if (lec != null)
            {
                lec.lectureID = lectureID;
                lec.coursePartID = coursePartID;
                lec.lectureLink = lectureLink;
                lec.lectureTitle = lectureTitle;
                lec.duration = duration;
                lec.isWatched = isWatched;
                lec.isAvailable = isAvailable;
                lec.index = index;
                lec.isWatching = isWatching;
                lec.updateAt = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpDelete]
        public bool DeleteLecture(int id)
        {
            Lecture lec = db.Lectures.FirstOrDefault(x => x.lectureID == id);

            if (lec != null)
            {
                db.Lectures.Remove(lec);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}