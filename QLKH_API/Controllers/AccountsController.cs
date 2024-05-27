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
    public class AccountsController : ApiController
    {
        private QLKHEntities db = new QLKHEntities();

        [HttpGet]
        public List<Account> GetAccounts()
        {
            return db.Accounts.ToList();
        }
        
        [HttpGet]
        public Account FindByAccountID(int accountID)
        {
            return db.Accounts.FirstOrDefault(x => x.accountID == accountID);
        }

        [HttpPost]
        public bool AddAccount(int accountID, string email, string avatar, string password, string status, int decentralizationID)
        {
            Account acc = db.Accounts.FirstOrDefault(x => x.accountID == accountID);
            if (acc == null)
            {
                Account acc1 = new Account();
                acc1.accountID = accountID;
                acc1.email = email;
                acc1.avatar = avatar;
                acc1.password = password;
                acc1.status = status;
                acc1.decentralizationId = decentralizationID;
                acc1.createAt = DateTime.Now;
                acc1.updateAt = DateTime.Now;
                db.Accounts.Add(acc1);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        
        [HttpPost]
        public bool UpdateAccount(int accountID, string email, string avatar, string password, string status, int decentralizationID)
        {
            Account acc = db.Accounts.FirstOrDefault(x => x.accountID == accountID);
            if (acc != null)
            {
                acc.accountID = accountID;
                acc.email = email;
                acc.avatar = avatar;
                acc.password = password;
                acc.status = status;
                acc.decentralizationId = decentralizationID;
                acc.updateAt = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        
        [HttpDelete]
        public bool DeleteAccount(int id)
        {
            Account acc = db.Accounts.FirstOrDefault(x => x.accountID == id);
            
            if (acc != null)
            {
                db.Accounts.Remove(acc);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}