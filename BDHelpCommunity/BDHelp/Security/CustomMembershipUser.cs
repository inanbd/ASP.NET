using FInal_Project.Models;
using System;

using System.Web.Security;


namespace BDHelp.Security
{
    public class CustomMembershipUser : MembershipUser
    {
        #region Properties

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserLoginName { get; set; }

        public int UserRoleId { get; set; }

        public string UserRoleName { get; set; }

        #endregion

        public CustomMembershipUser(UserModel user)
            : base("CustomMembershipProvider",  user.UserName, user.UserId, string.Empty, string.Empty, string.Empty, true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now)
        {
            UserLoginName = user.UserName;
            FirstName = user.FirstName;
            LastName = user.LastName;
            UserRoleName = user.UserType;
            UserRoleId = user.UserId;           
        }
    }
}