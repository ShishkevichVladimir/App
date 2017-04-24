using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using App.Models;

namespace App.EF
{
    public class AppEfContext : DbContext
    {
        public AppEfContext() : base("AppContext")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .HasKey(t => t.Id)
                .HasRequired(t => t.User)
                .WithMany(t => t.Messages);

            base.OnModelCreating(modelBuilder);
        }
    }
}
