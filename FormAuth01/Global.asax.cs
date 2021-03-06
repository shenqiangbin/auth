﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace FormAuth01
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public MvcApplication()
        {
            AuthorizeRequest += MvcApplication_AuthorizeRequest;            
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        private void MvcApplication_AuthorizeRequest(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                var identity = Context.User.Identity;
                string[] roles = new string[] { "admin" };
                //string userDate = ((FormsIdentity)identity).Ticket.UserData;
                //roles = userDate.Split(',');
                Context.User = new GenericPrincipal(identity, roles);
            }
        }
    }
}
