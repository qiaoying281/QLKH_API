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
    public class QuestionsController : ApiController
    {
        private QLKHEntities db = new QLKHEntities();

        [HttpGet]
        public List<Question> GetQuestions()
        {
            return db.Questions.ToList();
        }

        [HttpGet]
        public Question FindByQuestionID(int questionID)
        {
            return db.Questions.FirstOrDefault(x => x.questionID == questionID);
        }

        [HttpPost]
        public bool AddQuestion(int questionID, int examID, string questionName)
        {
            Question que = db.Questions.FirstOrDefault(x => x.questionID == questionID);
            if (que == null)
            {
                Question que1 = new Question();
                que1.questionID = questionID;
                que1.examID = examID;
                que1.questionName = questionName;
                que1.createAt = DateTime.Now;
                que1.updateAt = DateTime.Now;
                db.Questions.Add(que1);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpPost]
        public bool UpdateQuestion(int questionID, int examID, string questionName)
        {
            Question que = db.Questions.FirstOrDefault(x => x.questionID == questionID);
            if (que != null)
            {
                que.questionID = questionID;
                que.examID = examID;
                que.questionName = questionName;
                que.updateAt = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpDelete]
        public bool DeleteQuestion(int id)
        {
            Question que = db.Questions.FirstOrDefault(x => x.questionID == id);

            if (que != null)
            {
                db.Questions.Remove(que);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}