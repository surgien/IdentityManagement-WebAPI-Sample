using IdentityManagementSample.WebApiCore.Model;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace IdentityManagementSample.WebApiCore.Handler
{
    public class AuthenticationHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var notAuthenticatedReply = request.CreateErrorResponse(HttpStatusCode.Unauthorized, "User is not authenticated.");
            var owinUser = request.GetOwinContext().Authentication.User;

            if (owinUser == null)
                return Task.FromResult(notAuthenticatedReply);

            var owinIdentity = (System.Security.Principal.WindowsIdentity)owinUser.Identity;
            var identity = new WindowsIdentity(owinIdentity.Token);
            CustomApplicationPrincipal user = default(CustomApplicationPrincipal);
            var sid = identity.User.Value;
            
            using (ApplicationEntities oc = new ApplicationEntities())
            {
                var dbUserRollen = (from usr in oc.Users
                                    where usr.SID == sid
                                    select usr.ROLE).ToList();

                if (dbUserRollen.Count == 0)
                {
                    return Task.FromResult(notAuthenticatedReply);
                }
                else
                {
                    user = new CustomApplicationPrincipal(identity, dbUserRollen);
                }
            }

            if (!user.Identity.IsAuthenticated || owinUser == null)
            {
                return Task.FromResult(notAuthenticatedReply);
            }

            SetPrincipal(user);

            return base.SendAsync(request, cancellationToken);
        }

        private void SetPrincipal(CustomApplicationPrincipal user)
        {
            Thread.CurrentPrincipal = user;
        }
    }
}
