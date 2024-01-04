using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InventorySystemProject.Models
{
    public partial class CIIT_CRMDBContext : DbContext
    {
        public CIIT_CRMDBContext()
        {
        }

        public CIIT_CRMDBContext(DbContextOptions<CIIT_CRMDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblOrder> TblOrders { get; set; } = null!;
        public virtual DbSet<TblOrederProduct> TblOrederProducts { get; set; } = null!;
        public virtual DbSet<TblProduct> TblProducts { get; set; } = null!;
        public virtual DbSet<TblReceiveOrder> TblReceiveOrders { get; set; } = null!;
        public virtual DbSet<TblReceiveOrderProduct> TblReceiveOrderProducts { get; set; } = null!;
        public virtual DbSet<TblSubCategory> TblSubCategories { get; set; } = null!;
        public virtual DbSet<TblUnit> TblUnits { get; set; } = null!;
        public virtual DbSet<TblVendor> TblVendors { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=A2NWPLSK14SQL-v04.shr.prod.iad2.secureserver.net;Database=CIIT_CRMDB;User=ciituser;Password=ciit@2020;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ciituser");

            modelBuilder.Entity<TblOrder>(entity =>
            {
                entity.HasKey(e => e.OrederId)
                    .HasName("PK__tblOrder__1352DEC9FD3DBEA6");

                entity.ToTable("tblOrders", "inventory");

                entity.HasIndex(e => e.OrderDate, "UQ__tblOrder__60337E3C5FABDD20")
                    .IsUnique();

                entity.Property(e => e.OrederId).HasColumnName("Oreder_id");

                entity.Property(e => e.Flag).HasColumnName("flag");

                entity.Property(e => e.OrderDate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Order_date");

                entity.Property(e => e.VendorId).HasColumnName("Vendor_id");

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.TblOrders)
                    .HasForeignKey(d => d.VendorId)
                    .HasConstraintName("FK__tblOrders__Vendo__0E0EFF63");
            });

            modelBuilder.Entity<TblOrederProduct>(entity =>
            {
                entity.HasKey(e => e.OrderProductId)
                    .HasName("PK__tblOrede__E6A3CE3EE4C41645");

                entity.ToTable("tblOreder_Products", "inventory");

                entity.Property(e => e.OrderProductId).HasColumnName("OrderProduct_id");

                entity.Property(e => e.Flag).HasColumnName("flag");

                entity.Property(e => e.OrederId).HasColumnName("Oreder_id");

                entity.Property(e => e.ProductId).HasColumnName("Product_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.UnitId).HasColumnName("Unit_id");

                entity.HasOne(d => d.Oreder)
                    .WithMany(p => p.TblOrederProducts)
                    .HasForeignKey(d => d.OrederId)
                    .HasConstraintName("FK__tblOreder__Orede__11DF9047");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TblOrederProducts)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__tblOreder__Produ__12D3B480");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.TblOrederProducts)
                    .HasForeignKey(d => d.UnitId)
                    .HasConstraintName("FK__tblOreder__Unit___13C7D8B9");
            });

            modelBuilder.Entity<TblProduct>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__tblProdu__47027DF5FB7F87FF");

                entity.ToTable("tblProducts", "inventory");

                entity.HasIndex(e => e.ProductName, "UQ__tblProdu__2B5A6A5FE9569C5F")
                    .IsUnique();

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Flag).HasColumnName("flag");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("product_name");

                entity.Property(e => e.SubCategoryId).HasColumnName("subCategory_id");

                entity.Property(e => e.Tax).HasColumnName("tax");

                entity.HasOne(d => d.SubCategory)
                    .WithMany(p => p.TblProducts)
                    .HasForeignKey(d => d.SubCategoryId)
                    .HasConstraintName("FK__tblProduc__subCa__01A9287E");
            });

            modelBuilder.Entity<TblReceiveOrder>(entity =>
            {
                entity.HasKey(e => e.ReceiveOrderId)
                    .HasName("PK__tblRecei__184DD0F342A0B51D");

                entity.ToTable("tblReceiveOrder", "inventory");

                entity.Property(e => e.ReceiveOrderId).HasColumnName("ReceiveOrder_id");

                entity.Property(e => e.Flag).HasColumnName("flag");

                entity.Property(e => e.OrederId).HasColumnName("Oreder_id");

                entity.Property(e => e.ReceiveDate)
                    .HasColumnType("date")
                    .HasColumnName("Receive_Date");

                entity.HasOne(d => d.Oreder)
                    .WithMany(p => p.TblReceiveOrders)
                    .HasForeignKey(d => d.OrederId)
                    .HasConstraintName("FK__tblReceiv__Orede__1798699D");
            });

            modelBuilder.Entity<TblReceiveOrderProduct>(entity =>
            {
                entity.HasKey(e => e.ReceiveOrderProductId)
                    .HasName("PK__tblRecei__B1FF454E70F78E91");

                entity.ToTable("tblReceiveOrder_Products", "inventory");

                entity.Property(e => e.ReceiveOrderProductId).HasColumnName("ReceiveOrderProduct_id");

                entity.Property(e => e.ExpiryDate)
                    .HasColumnType("date")
                    .HasColumnName("Expiry_date");

                entity.Property(e => e.Flag).HasColumnName("flag");

                entity.Property(e => e.ProductId).HasColumnName("Product_id");

                entity.Property(e => e.PurchaseRate).HasColumnName("Purchase_rate");

                entity.Property(e => e.ReceiveOrderId).HasColumnName("ReceiveOrder_id");

                entity.Property(e => e.UnitId).HasColumnName("Unit_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TblReceiveOrderProducts)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__tblReceiv__Produ__1C5D1EBA");

                entity.HasOne(d => d.ReceiveOrder)
                    .WithMany(p => p.TblReceiveOrderProducts)
                    .HasForeignKey(d => d.ReceiveOrderId)
                    .HasConstraintName("FK__tblReceiv__Recei__1B68FA81");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.TblReceiveOrderProducts)
                    .HasForeignKey(d => d.UnitId)
                    .HasConstraintName("FK__tblReceiv__Unit___1D5142F3");
            });

            modelBuilder.Entity<TblSubCategory>(entity =>
            {
                entity.HasKey(e => e.SubCategoryId)
                    .HasName("PK__tblSubCa__B7113748AD10FA75");

                entity.ToTable("tblSubCategories", "inventory");

                entity.HasIndex(e => e.SubcategoryName, "UQ__tblSubCa__5B737073D4A7D2A3")
                    .IsUnique();

                entity.Property(e => e.SubCategoryId).HasColumnName("subCategory_id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Flag).HasColumnName("flag");

                entity.Property(e => e.SubcategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("subcategory_name");
            });

            modelBuilder.Entity<TblUnit>(entity =>
            {
                entity.HasKey(e => e.UnitId)
                    .HasName("PK__tblUnits__2754675043FFB841");

                entity.ToTable("tblUnits", "inventory");

                entity.Property(e => e.UnitId).HasColumnName("Unit_id");

                entity.Property(e => e.Flag).HasColumnName("flag");

                entity.Property(e => e.UnitName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Unit_name");
            });

            modelBuilder.Entity<TblVendor>(entity =>
            {
                entity.HasKey(e => e.VendorId)
                    .HasName("PK__tblVendo__0F7D2B78F8B017E3");

                entity.ToTable("tblVendors", "inventory");

                entity.HasIndex(e => e.VendorName, "UQ__tblVendo__6107BA7149F84E13")
                    .IsUnique();

                entity.Property(e => e.VendorId).HasColumnName("vendor_id");

                entity.Property(e => e.ContactNumber).HasColumnName("contact_number");

                entity.Property(e => e.ContactPerson)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("contact_person");

                entity.Property(e => e.Flag).HasColumnName("flag");

                entity.Property(e => e.SubCategoryId).HasColumnName("subCategory_id");

                entity.Property(e => e.VendorName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("vendor_name");

                entity.HasOne(d => d.SubCategory)
                    .WithMany(p => p.TblVendors)
                    .HasForeignKey(d => d.SubCategoryId)
                    .HasConstraintName("FK__tblVendor__subCa__066DDD9B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
