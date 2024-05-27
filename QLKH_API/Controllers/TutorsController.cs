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
    public class TutorsController : ApiController
    {
        private QLKHEntities db = new QLKHEntities();

        [HttpGet]
        public List<Tutor> GetTutors()
        {
            return db.Tutors.ToList();
        }

        [HttpGet]
        public Tutor FindByTutorID(int tutorID)
        {
            return db.Tutors.FirstOrDefault(x => x.tutorID == tutorID);
        }

        [HttpPost]
        public bool AddTutor(int tutorID, int accountID, string fullName, string contactNumber, int provinceID, int districtID, int communeID, string email)
        {
            Tutor tut = db.Tutors.FirstOrDefault(x => x.tutorID == tutorID);
            if (tut == null)
            {
                Tutor tut1 = new Tutor();
                tut1.tutorID = tutorID;
                tut1.accountID = accountID;
                tut1.fullName = fullName;
                tut1.contactNumber = contactNumber;
                tut1.provinceID = provinceID;
                tut1. districtID = districtID;
                tut1. communeID = communeID;
                tut1.email = email;
                tut1.createAt = DateTime.Now;
                tut1.updateAt = DateTime.Now;
                db.Tutors.Add(tut1);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpPost]
        public bool UpdateTutor(int tutorID, int accountID, string fullName, string contactNumber, int provinceID, int districtID, int communeID, string email)
        {
            Tutor tut = db.Tutors.FirstOrDefault(x => x.tutorID == tutorID);
            if (tut != null)
            {
                tut.tutorID = tutorID;
                tut.accountID = accountID;
                tut.fullName = fullName;
                tut.contactNumber = contactNumber;
                tut.provinceID = provinceID;
                tut.districtID = districtID;
                tut.communeID = communeID;
                tut.email = email;
                tut.updateAt = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpDelete]
        public bool DeleteTutor(int id)
        {
            Tutor tut = db.Tutors.FirstOrDefault(x => x.tutorID == id);

            if (tut != null)
            {
                db.Tutors.Remove(tut);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}