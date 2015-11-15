using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;
using Microsoft.Owin;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Alpha.DAL.Models {
    public class AuthContext : IdentityDbContext<IdentityUser> {
        public AuthContext() : base("AuthContext") {

        }
    }
}
