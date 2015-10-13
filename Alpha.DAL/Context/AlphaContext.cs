using Alpha.DAL.Models;
using System.Data.Entity;

namespace Alpha.DAL.Context {
    public class AlphaContext : DbContext {
        public AlphaContext() : base("name=AlphaContext") {
            Database.SetInitializer<AlphaContext>(null);
            //Configuration.LazyLoadingEnabled = false;

            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Games> Games { get; set; }
        public DbSet<Addons> Addons { get; set; }
        public DbSet<Accessories> Accessories { get; set; }
    }
}
