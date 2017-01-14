using IdentityManagementSample.WebApiCore.Handler;

namespace IdentityManagementSample.WebApiCore.Model
{
    public class USER
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public string SID { get; internal set; }
        internal UserRole ROLE { get; set; }
    }
}
