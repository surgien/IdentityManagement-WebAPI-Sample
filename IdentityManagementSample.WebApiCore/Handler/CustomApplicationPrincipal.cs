using System.Collections.Generic;
using System.Security.Principal;

namespace IdentityManagementSample.WebApiCore.Handler
{
    public class CustomApplicationPrincipal : WindowsPrincipal
    {
        private List<UserRole> _assignedBenutzerfunktion;

        public CustomApplicationPrincipal(WindowsIdentity identity, List<UserRole> dbUserRollen) : base(identity)
        {
            _assignedBenutzerfunktion = dbUserRollen;
        }

        public List<UserRole> AssignedUserRoles
        {
            get { return _assignedBenutzerfunktion; }
        }
    }
}