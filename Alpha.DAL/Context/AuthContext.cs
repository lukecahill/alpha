using Microsoft.AspNet.Identity.EntityFramework;

namespace Alpha.DAL.Context {
    public class AuthContext : IdentityDbContext<IdentityUser> {
        public AuthContext() : base("AuthContext") { }
    }
}
