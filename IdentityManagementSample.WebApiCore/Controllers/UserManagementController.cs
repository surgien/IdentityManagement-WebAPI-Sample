﻿using IdentityManagementSample.WebApiCore.Handler;
using System.Web.Http;

namespace IdentityManagementSample.WebApiCore.Controllers
{
    [RoutePrefix("user")]
    [AuthorizeWithFunction(UserRole.Benuterverwalter)]
    {
        [Route("all")]
        public IHttpActionResult GetAllUser()
        {
            return Ok("ok!");
        }
    }
}