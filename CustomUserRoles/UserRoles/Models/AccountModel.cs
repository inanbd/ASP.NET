using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserRoles.Models
{
    public class AccountModel
    {
        private List<Account> listAccounts = new List<Account>();


        public AccountModel()
        {
            listAccounts.Add(new Account {
                Username ="admin",
                Password ="admin",
                Roles =new string[] {"admin"}
                });
            listAccounts.Add(new Account
            {
                Username = "employee",
                Password = "employee",
                Roles = new string[] {"employee" }
            });
            listAccounts.Add(new Account
            {
                Username = "super",
                Password = "super",
                Roles = new string[] { "super" }
            });

        }

        public Account find(string username)
        {
            return listAccounts.Where(acc => acc.Username.Equals(username)).FirstOrDefault();
        }
        public Account login(string username , string password)
        {
            return listAccounts.Where(acc => acc.Username.Equals(username) && acc.Password.Equals(password)).FirstOrDefault();
        }
    }
}