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
    public class StudentsController : ApiController
    {
        private QLKHEntities db = new QLKHEntities();

        [HttpGet]
        public List<Student> GetStudents()
        {
            return db.Students.ToList();
        }

        [HttpGet]
        public Student FindByStudentID(int studentID)
        {
            return db.Students.FirstOrDefault(x => x.studentID == studentID);
        }

        [HttpPost]
        public bool AddStudent(int studentID, int accountID, string fullName, string contactNumber, int provinceID, int districtID, int communeID, string email, int totalMoney)
        {
            Student stu = db.Students.FirstOrDefault(x => x.studentID == studentID);
            if (stu == null)
            {
                Student stu1 = new Student();
                stu1.studentID = studentID;
                stu1.accountID = accountID;
                stu1.fullName = fullName;
                stu1.contactNumber = contactNumber;
                stu1.provinceID = provinceID;
                stu1. districtID = districtID;
                stu1.communeID = communeID;
                stu1.email = email;
                stu1.totalMoney = totalMoney;
                stu1.createAt = DateTime.Now;
                stu1.updateAt = DateTime.Now;
                db.Students.Add(stu1);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpPost]
        public bool UpdateStudent(int studentID, int accountID, string fullName, string contactNumber, int provinceID, int districtID, int communeID, string email, int totalMoney)
        {
            Student stu = db.Students.FirstOrDefault(x => x.studentID == studentID);
            if (stu != null)
            {
                stu.studentID = studentID;
                stu.accountID = accountID;
                stu.fullName = fullName;
                stu.contactNumber = contactNumber;
                stu.provinceID = provinceID;
                stu.districtID = districtID;
                stu.communeID = communeID;
                stu.email = email;
                stu.totalMoney = totalMoney;
                stu.updateAt = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpDelete]
        public bool DeleteStudent(int id)
        {
            Student stu = db.Students.FirstOrDefault(x => x.studentID == id);

            if (stu != null)
            {
                db.Students.Remove(stu);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}