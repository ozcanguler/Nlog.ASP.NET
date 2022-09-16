using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using WebApplication1.Services.Data;

namespace WebApplication1.Services.Business
{
    public class SecurityService
    {     
            SecurityDAO daoService = new SecurityDAO();

            public bool Authenticate(UserModel user)
            {
                return daoService.FindByUser(user);
            }
        
    }
}