using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POPSAPI.Model
{
    public class POPSContext:DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<PoMaster> PoMasters { get; set; }
        public DbSet<PoDetail> PoDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .HasKey(itm => itm.ItemCode)
                .HasName("Itm_Primary_key");
            modelBuilder.Entity<Supplier>()
                .HasKey(suppl => suppl.SupplierNumber)
                .HasName("suppl_primary_key");
            modelBuilder.Entity<PoMaster>()
                        .HasKey(pom => pom.PoNumber)
                        .HasName("pom_primary_key");
            modelBuilder.Entity<PoMaster>()
                        .HasOne<Supplier>()
                        .WithMany()
                        .HasForeignKey(pom => pom.SUPLNO);

            modelBuilder.Entity<PoDetail>()
                        .HasKey(pod =>
                        new { pod.PuchaseOrderNumber, pod.ItemNumber })
                        .HasName("pod_primary_key");
            modelBuilder.Entity<PoDetail>()
                        .HasOne(pod => pod.PurchaseOrderMaster)
                        .WithMany(pom => pom.Details);
            modelBuilder.Entity<PoDetail>()
                        .HasOne<Item>()
                        .WithMany()
                        .HasForeignKey(pod => pod.ItemNumber);



        }
    }
}
