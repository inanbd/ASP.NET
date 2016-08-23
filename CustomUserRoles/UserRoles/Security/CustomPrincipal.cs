using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using UserRoles.Models;

namespace UserRoles.Security
{
    public class CustomPrincipal : IPrincipal
    {
        private Account account;
        private AccountModel am = new AccountModel();

        public CustomPrincipal(Account account)
        {
            this.account = account;
            this.Identity = new GenericIdentity(account.Username);

        }
        
        public IIdentity Identity
        {
            get;set;
        }

        public bool IsInRole(string role)
        {
            var roles = role.Split(new char[] { ',' });
            return roles.Any(r => this.account.Roles.Contains(r));
        }
    }
}