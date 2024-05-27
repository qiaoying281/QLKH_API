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
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace QLKH_API.Controllers
{
    public class AnswersController : ApiController
    {
        private QLKHEntities db = new QLKHEntities();

        [HttpGet]
        public List<Answer> GetAnswers()
        {
            return db.Answers.ToList();
        }

        [HttpGet]
        public Answer FindByAnswerID(int AnswerID)
        {
            return db.Answers.FirstOrDefault(x => x.answerID == AnswerID);
        }

        [HttpPost]
        public bool AddAnswer(int answerID, int questionID, bool rightAnswer, string content)
        {
            Answer ans = db.Answers.FirstOrDefault(x => x.answerID == answerID);
            if (ans == null)
            {
                Answer ans1 = new Answer();
                ans1.answerID = answerID;
                ans1.questionID = questionID;
                ans1.rightAnswer = rightAnswer;
                ans1.content = content;
                ans1.createAt = DateTime.Now;
                ans1.updateAt = DateTime.Now;
                db.Answers.Add(ans1);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpPost]
        public bool UpdateAnswer(int answerID, int questionID, bool rightAnswer, string content)
        {
            Answer ans = db.Answers.FirstOrDefault(x => x.answerID == answerID);
            if (ans != null)
            {
                ans.answerID = answerID;
                ans.questionID = questionID;
                ans.rightAnswer = rightAnswer;
                ans.content = content;
                ans.updateAt = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpDelete]
        public bool DeleteAnswer(int id)
        {
            Answer ans = db.Answers.FirstOrDefault(x => x.answerID == id);

            if (ans != null)
            {
                db.Answers.Remove(ans);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}