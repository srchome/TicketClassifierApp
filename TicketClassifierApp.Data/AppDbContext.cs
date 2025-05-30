using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketClassifierApp.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TicketClassifierApp.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Ticket> Tickets { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>()
                .Property(t => t.Text)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }

}
