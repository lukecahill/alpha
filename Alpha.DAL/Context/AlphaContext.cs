using Alpha.DAL.Models;
using System.Data.Entity;
using System.Linq;

namespace Alpha.DAL.Context {
    public class AlphaContext : DbContext {
        public AlphaContext() : base("name=AlphaContext") {
            Database.SetInitializer<AlphaContext>(null);
            Configuration.LazyLoadingEnabled = false;

            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Games> Games { get; set; }
        public DbSet<Addons> Addons { get; set; }
        public DbSet<Accessories> Accessories { get; set; }

        /// <summary>
        /// When SaveChanges is called this overrides the method and loops though each item which was deleted. Then invokes the Delete() method which is inherited from DalBase class. Then sets the state to modified instead with the IsDeleted property set to true and the DateTime.Now set, before saving the changes. 
        /// </summary>
        public override int SaveChanges() {
            foreach(var entity in ChangeTracker.Entries().Where(e => e.State == EntityState.Deleted)) {
                // wut \(◉◡◔)/
                // Just in case we ever set objects to not be soft deleted, check if the Delete() method exists before trying to invoke it
                var deleteMethod = entity.Entity.GetType().GetMethod("Delete");

                if(deleteMethod != null) {
                    deleteMethod.Invoke(entity.Entity, null);
                    entity.State = EntityState.Modified;
                }
            }
            return base.SaveChanges();
        }
    }
}
