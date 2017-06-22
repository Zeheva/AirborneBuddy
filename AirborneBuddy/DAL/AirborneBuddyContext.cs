using System.Data.Entity;
using System.Security.Cryptography.X509Certificates;
using AirborneBuddy.Models;

namespace AirborneBuddy.DAL
{
    public class AirborneBuddyContext : DbContext
    {
        public AirborneBuddyContext()
        {
            //add : Base("AirborneBuddyContext") when i understand why
        }

        public DbSet<AirborneOperation> AirborneOperations { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Paratrooper> Paratroopers { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
    }
}