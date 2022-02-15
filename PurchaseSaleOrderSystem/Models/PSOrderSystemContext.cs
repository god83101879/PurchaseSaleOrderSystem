using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace PurchaseSaleOrderSystem.Models
{
    public partial class PSOrderSystemContext : DbContext
    {
        public PSOrderSystemContext()
            : base("name=PSOrderSystemContext")
        {
        }

        public virtual DbSet<Money> Moneys { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Money>()
                .Property(e => e.money_totalmoney)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.PurchaseOrders)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.purchaseorder_producid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.PurchaseOrders)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.purchaseorder_userid)
                .WillCascadeOnDelete(false);
        }
    }
}
