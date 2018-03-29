using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.Services.Data
{
    public class PaymentDBContext:DbContext
    {
        public PaymentDBContext(DbContextOptions<PaymentDBContext> options) : base(options)
        {
        }

        public DbSet<Models.Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Payment>().ToTable("Payment");
        }
    }
}
