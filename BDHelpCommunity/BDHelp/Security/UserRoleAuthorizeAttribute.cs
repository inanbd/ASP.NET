using System.Linq;

namespace BDHelp.Security
{
    public class UserRoleAuthorizeAttribute : System.Web.Mvc.AuthorizeAttribute
    {
        public UserRoleAuthorizeAttribute(){}

        public UserRoleAuthorizeAttribute(params UserRole[] roles)
        {
            Roles = string.Join(",", roles.Select(r => r.ToString()));
        }
    }

    public enum UserRole
    {
        Admin = 1,
        User=2
    }
}