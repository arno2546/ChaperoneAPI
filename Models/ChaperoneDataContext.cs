using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Chaperone_API.Models
{
    public class ChaperoneDataContext:DbContext
    {
        public ChaperoneDataContext()
        {
            Database.SetInitializer<ChaperoneDataContext>(new DropCreateDatabaseIfModelChanges<ChaperoneDataContext>());
        }
        virtual public DbSet<User> Users { get; set; }
        virtual public DbSet<Request> Requests { get; set; }
        virtual public DbSet<Review> Reviews { get; set; }
        virtual public DbSet<Message> Messages { get; set; }
        virtual public DbSet<Visit> Visits { get; set; }
    }
}