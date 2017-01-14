namespace IdentityManagementSample.WebApiCore.Model
{
    using System;
    using System.Collections.Generic;
    using System.Security.Principal;

    public class ApplicationEntities : IDisposable//: DbContext
    {
        // Your context has been configured to use a 'ApplicationEntities' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'IdentityManagementSample.WebApiCore.Model.ApplicationEntities' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ApplicationEntities' 
        // connection string in the application configuration file.
        public ApplicationEntities()
            : base()
        {
            Users = new List<USER>();
            var identity = System.Threading.Thread.CurrentPrincipal.Identity as WindowsIdentity;

            Users.Add(new USER() { SID = identity.User.Value, ROLE = Handler.UserRole.Sachbearbeiter });
            Users.Add(new USER() { SID = identity.User.Value, ROLE = Handler.UserRole.Benuterverwalter });
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual List<USER> Users { get; set; }

        public void Dispose()
        {
        }
    }
}