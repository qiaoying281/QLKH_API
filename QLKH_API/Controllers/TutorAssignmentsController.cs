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
    public class TutorAssignmentsController : ApiController
    {
        private QLKHEntities db = new QLKHEntities();

        [HttpGet]
        public List<TutorAssignment> GetTutorAssignments()
        {
            return db.TutorAssignments.ToList();
        }

        [HttpGet]
        public TutorAssignment FindByTutorAssignmentID(int tutorAssignmentID)
        {
            return db.TutorAssignments.FirstOrDefault(x => x.tutorAssignmentID == tutorAssignmentID);
        }

        [HttpPost]
        public bool AddTutorAssignment(int tutorAssignmentID, int tutorID, int courseID, int numberOfStudent, DateTime assignmentDate)
        {
            TutorAssignment ta = db.TutorAssignments.FirstOrDefault(x => x.tutorAssignmentID == tutorAssignmentID);
            if (ta == null)
            {
                TutorAssignment ta1 = new TutorAssignment();
                ta1.tutorAssignmentID = tutorAssignmentID;
                ta1.tutorID = tutorID;
                ta1.courseID = courseID;
                ta1.numberOfStudent = numberOfStudent;
                ta1.assignmentDate = assignmentDate;
                ta1.createAt = DateTime.Now;
                ta1.updateAt = DateTime.Now;
                db.TutorAssignments.Add(ta1);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpPost]
        public bool UpdateTutorAssignment(int tutorAssignmentID, int tutorID, int courseID, int numberOfStudent, DateTime assignmentDate)
        {
            TutorAssignment ta = db.TutorAssignments.FirstOrDefault(x => x.tutorAssignmentID == tutorAssignmentID);
            if (ta != null)
            {
                ta.tutorAssignmentID = tutorAssignmentID;
                ta.tutorID = tutorID;
                ta.courseID = courseID;
                ta.numberOfStudent = numberOfStudent;
                ta.assignmentDate = assignmentDate;
                ta.updateAt = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpDelete]
        public bool DeleteTutorAssignment(int id)
        {
            TutorAssignment ta = db.TutorAssignments.FirstOrDefault(x => x.tutorAssignmentID == id);

            if (ta != null)
            {
                db.TutorAssignments.Remove(ta);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}