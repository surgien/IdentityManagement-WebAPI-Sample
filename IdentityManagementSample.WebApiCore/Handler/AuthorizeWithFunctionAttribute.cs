using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace IdentityManagementSample.WebApiCore.Handler
{
    public class AuthorizeWithFunctionAttribute : AuthorizeAttribute
    {
        public AuthorizeWithFunctionAttribute(UserRole benutzerfunktion)
        {
            AllowedFunctions = new List<UserRole>() { benutzerfunktion };
        }

        public AuthorizeWithFunctionAttribute(params UserRole[] benutzerfunktion)
        {
            AllowedFunctions = benutzerfunktion;
        }

        public IEnumerable<UserRole> AllowedFunctions { get; set; }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var isAuth = base.IsAuthorized(actionContext);

            if (isAuth)
            {
                var principal = (CustomApplicationPrincipal)System.Threading.Thread.CurrentPrincipal;

                isAuth = false;

                foreach (var funktion in AllowedFunctions)
                {
                    if (principal.AssignedUserRoles.Contains(funktion))
                    {
                        isAuth = true;
                    }
                }
            }

            return isAuth;
        }
    }
}
