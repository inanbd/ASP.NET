using System.Security.Principal;

namespace BDHelp.Security
{
    public static class SecurityExtentions
    {
        public static CustomPrincipal ToCustomPrincipal(this IPrincipal principal)
        {
            return (CustomPrincipal) principal;
        }
    }
}