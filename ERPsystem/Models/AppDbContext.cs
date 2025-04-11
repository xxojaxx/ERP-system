using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reactive;
using System;
using Tmds.DBus.Protocol;
using System.Collections.Generic;
using ERPsystem.Models.TableDefinitions;


namespace ERPsystem.Models
{
    class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<TableDefinitions.Address> Addresses { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<SupplyItem> SupplyItems { get; set; }
        public DbSet<Bom> Boms { get; set; }
        public DbSet<BomItem> BomItems { get; set; }
        public DbSet<TableDefinitions.Unit> Units { get; set; }
        public DbSet<TableDefinitions.Type> Types { get; set; }
        public DbSet<Currency> Currencies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql("Host=localhost;Database=ERP DB;Username=postgres;Password=password")
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Mapping for User Table

            modelBuilder.Entity<User>()
                .ToTable("Users")
                .HasKey(u => u.UserId);
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                 .OnDelete(DeleteBehavior.Restrict);

            // Mapping for Role Table
            modelBuilder.Entity<Role>()
                .ToTable("Roles")
                .HasKey(r => r.RoleId);

            // Mapping for Address Table
            modelBuilder.Entity<TableDefinitions.Address>()
                .ToTable("Address")
                .HasKey(a => a.AddressId);

            // Mapping for Client Table
            modelBuilder.Entity<Client>()
                .ToTable("Clients")
                .HasKey(c => c.ClientId);
            modelBuilder.Entity<Client>()
                .HasOne(c => c.Address)
                .WithMany(a => a.Clients)
                .HasForeignKey(c => c.AddressId)
                .OnDelete(DeleteBehavior.Restrict);

            // Mapping for Supplier Table
            modelBuilder.Entity<Supplier>()
                .ToTable("Suppliers")
                .HasKey(s => s.SupplierId);
            modelBuilder.Entity<Supplier>()
                .HasOne(s => s.Address)
                .WithMany(a => a.Suppliers)
                .HasForeignKey(s => s.AddressId)
                .OnDelete(DeleteBehavior.Restrict);

            // Mapping for Item Table
            modelBuilder.Entity<Item>()
                .ToTable("Items")
                .HasKey(i => i.ItemId);
            modelBuilder.Entity<Item>()
                .HasOne(i => i.Unit)
                .WithMany(u => u.Items)
                .HasForeignKey(i => i.UmId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Item>()
                .HasOne(i => i.Type)
                .WithMany(t => t.Items)
                .HasForeignKey(i => i.ItemType)
                .OnDelete(DeleteBehavior.Restrict);

            //Mapping for Inventory Table
            modelBuilder.Entity<Inventory>()
                .ToTable("Inventory")
                .HasKey(inv => inv.InventoryId);
            modelBuilder.Entity<Inventory>()
                .HasOne(inv => inv.Item)
                .WithMany(i => i.Inventory)
                .HasForeignKey(inv => inv.ItemId)
                .OnDelete(DeleteBehavior.Restrict);

            // Mapping for Order Table
            modelBuilder.Entity<Order>()
               .ToTable("Order")
               .HasKey(o => o.OrderId);
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Client)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.ClientId);
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Currency)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CurrencyId);
            modelBuilder.Entity<Order>()
                .Property(o => o.Date)
                .HasConversion(
                    v => v,
                    v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

            // Mapping for OrderItem Table
            modelBuilder.Entity<OrderItem>()
                .ToTable("OrderItem")
                .HasKey(oi => new { oi.OrderId, oi.ItemId });
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId);
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Item)
                .WithMany(i => i.OrderItems)
                .HasForeignKey(oi => oi.ItemId);

            // Mapping for Supply Table
            modelBuilder.Entity<Supply>()
                .ToTable("Supply")
                .HasKey(s => s.SupplyId);
            modelBuilder.Entity<Supply>()
               .HasOne(s => s.Supplier)
               .WithMany(su => su.Supplies)
               .HasForeignKey(s => s.SupplierId);
            modelBuilder.Entity<Supply>()
                .HasOne(s => s.Currency)
                .WithMany(c => c.Supplies)
                .HasForeignKey(s => s.CurrencyId);
            modelBuilder.Entity<Supply>()
                .Property(s => s.Date)
                .HasConversion(
                    v => v,
                    v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

            // Mapping for SupplyItem Table
            modelBuilder.Entity<SupplyItem>()
               .ToTable("SupplyItem")
               .HasKey(si => new { si.SupplyId, si.ItemId });
            modelBuilder.Entity<SupplyItem>()
                .HasOne(si => si.Supply)
                .WithMany(s => s.SupplyItems)
                .HasForeignKey(si => si.SupplyId);
            modelBuilder.Entity<SupplyItem>()
                .HasOne(si => si.Item)
                .WithMany(i => i.SupplyItems)
                .HasForeignKey(si => si.ItemId);

            // Mapping for Bom Table
            modelBuilder.Entity<Bom>()
                .ToTable("Bom")
                .HasKey(b => b.BomId);

            // Mapping for BomItem Table
            modelBuilder.Entity<BomItem>()
               .ToTable("BomItem")
               .HasKey(bi => new { bi.BomId, bi.ItemId });
            modelBuilder.Entity<BomItem>()
                .HasOne(bi => bi.Bom)
                .WithMany(b => b.BomItems)
                .HasForeignKey(bi => bi.BomId);
            modelBuilder.Entity<BomItem>()
                .HasOne(bi => bi.Item)
                .WithMany(i => i.BomItems)
                .HasForeignKey(bi => bi.ItemId);

            // Mapping for Unit Table
            modelBuilder.Entity<TableDefinitions.Unit>()
                .ToTable("Unit")
                .HasKey(u => u.UmId);

            // Mapping for Type Table
            modelBuilder.Entity<TableDefinitions.Type>()
                .ToTable("Type")
                .HasKey(t => t.ItemType);

            // Mapping for Currency Table
            modelBuilder.Entity<Currency>()
                .ToTable("Currency")
                .HasKey(c => c.CurrencyId);
        }
    }
}
