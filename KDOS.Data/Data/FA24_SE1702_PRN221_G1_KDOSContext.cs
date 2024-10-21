﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using KDOS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace KDOS.Data.Data;

public partial class FA24_SE1702_PRN221_G1_KDOSContext : DbContext
{
    public FA24_SE1702_PRN221_G1_KDOSContext()
    {
    }

    public FA24_SE1702_PRN221_G1_KDOSContext(DbContextOptions<FA24_SE1702_PRN221_G1_KDOSContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomsDeclaration> CustomsDeclarations { get; set; }

    public virtual DbSet<FishHealth> FishHealths { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Packing> Packings { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PriceList> PriceLists { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<Transport> Transports { get; set; }
    public static string GetConnectionString(string connectionStringName)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        string connectionString = config.GetConnectionString(connectionStringName);
        return connectionString;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(GetConnectionString("DefaultConnection")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("Data Source=NITRO5-DANG\\SQL_SERVER;Initial Catalog=FA24_SE1702_PRN221_G1_KDOS;User ID=sa;Password=12345");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3213E83F209AB907");

            entity.ToTable("Category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryName)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("category_name");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3213E83F7CAC397D");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.CustomerName)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("customer_name");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("phone_number");
        });

        modelBuilder.Entity<CustomsDeclaration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CustomsD__3213E83F6990C083");

            entity.ToTable("CustomsDeclaration");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CustomsAgent)
                .HasMaxLength(255)
                .HasColumnName("customs_agent");
            entity.Property(e => e.CustomsFee)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("customs_fee");
            entity.Property(e => e.ImportPermit)
                .HasMaxLength(50)
                .HasColumnName("import_permit");
            entity.Property(e => e.InspectionDate).HasColumnName("inspection_date");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.QuarantineRequired).HasColumnName("quarantine_required");
            entity.Property(e => e.Receiver)
                .HasMaxLength(255)
                .HasColumnName("receiver");
            entity.Property(e => e.ReceiverCustomerId).HasColumnName("receiver_customer_id");
            entity.Property(e => e.Sender)
                .HasMaxLength(255)
                .HasColumnName("sender");
            entity.Property(e => e.SenderCustomerId).HasColumnName("sender_customer_id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.Transportation)
                .HasMaxLength(50)
                .HasColumnName("transportation");

            entity.HasOne(d => d.Order).WithMany(p => p.CustomsDeclarations)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomsDeclaration_Orders");

            entity.HasOne(d => d.ReceiverCustomer).WithMany(p => p.CustomsDeclarationReceiverCustomers)
                .HasForeignKey(d => d.ReceiverCustomerId)
                .HasConstraintName("fk_receiver_customer");

            entity.HasOne(d => d.SenderCustomer).WithMany(p => p.CustomsDeclarationSenderCustomers)
                .HasForeignKey(d => d.SenderCustomerId)
                .HasConstraintName("fk_sender_customer");
        });

        modelBuilder.Entity<FishHealth>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FishHeal__3213E83FFECE0A87");

            entity.ToTable("FishHealth");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AmmoniaLevel)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("ammonia_level");
            entity.Property(e => e.HealthCheckDate).HasColumnName("health_check_date");
            entity.Property(e => e.HealthStatus)
                .HasMaxLength(50)
                .HasColumnName("health_status");
            entity.Property(e => e.Notes)
                .HasMaxLength(255)
                .HasColumnName("notes");
            entity.Property(e => e.OrderDetailsId).HasColumnName("orderDetails_id");
            entity.Property(e => e.OxygenLevel)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("oxygen_level");
            entity.Property(e => e.PHLevel)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("pH_level");
            entity.Property(e => e.Temperature)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("temperature");

            entity.HasOne(d => d.OrderDetails).WithMany(p => p.FishHealths)
                .HasForeignKey(d => d.OrderDetailsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FishHealth_OrderDetails");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Notifica__3213E83FF0E9DF15");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EntityId).HasColumnName("entity_id");
            entity.Property(e => e.EntityType)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("entity_type");
            entity.Property(e => e.Message)
                .HasMaxLength(255)
                .HasColumnName("message");
            entity.Property(e => e.NotificationDate).HasColumnName("notification_date");
            entity.Property(e => e.NotificationType)
                .HasMaxLength(50)
                .HasColumnName("notification_type");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3213E83FE3B6D2CE");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.Destination)
                .HasMaxLength(255)
                .HasColumnName("destination");
            entity.Property(e => e.OrderDate).HasColumnName("order_date");
            entity.Property(e => e.OriginalLocation)
                .HasMaxLength(255)
                .HasColumnName("original_location");
            entity.Property(e => e.PriceId).HasColumnName("price_id");
            entity.Property(e => e.ShippingMethod)
                .HasMaxLength(50)
                .HasColumnName("shipping_method");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.TotalCost)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total_cost");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Customers");

            entity.HasOne(d => d.Price).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PriceId)
                .HasConstraintName("FK_Orders_PriceList");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailsId).HasName("PK__OrderDet__DA8FD2B09E7F4C75");

            entity.Property(e => e.OrderDetailsId).HasColumnName("orderDetails_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.HealthStatus)
                .HasMaxLength(50)
                .HasColumnName("health_status");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.Quantity)
                .HasDefaultValue(1)
                .HasColumnName("quantity");
            entity.Property(e => e.Size)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("size");
            entity.Property(e => e.Weight)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("weight");

            entity.HasOne(d => d.Category).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetails_Category");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetails_Orders");
        });

        modelBuilder.Entity<Packing>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Packing__3213E83F5C29C7BF");

            entity.ToTable("Packing");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.OxygenLevel)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("oxygen_level");
            entity.Property(e => e.PackerId).HasColumnName("packer_id");
            entity.Property(e => e.PackingDate).HasColumnName("packing_date");
            entity.Property(e => e.PackingNotes)
                .HasMaxLength(255)
                .HasColumnName("packing_notes");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.WaterTemperature)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("water_temperature");

            entity.HasOne(d => d.Order).WithMany(p => p.Packings)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Packing_Orders");

            entity.HasOne(d => d.Packer).WithMany(p => p.Packings)
                .HasForeignKey(d => d.PackerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Packing_Staff");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Payment__3213E83FEA780B89");

            entity.ToTable("Payment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AmountPaid)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount_paid");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.Notes)
                .HasMaxLength(255)
                .HasColumnName("notes");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.PaymentDate).HasColumnName("payment_date");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(50)
                .HasColumnName("payment_method");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.TransactionId)
                .HasMaxLength(255)
                .HasColumnName("transaction_id");

            entity.HasOne(d => d.Customer).WithMany(p => p.Payments)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payment_Customers");

            entity.HasOne(d => d.Order).WithMany(p => p.Payments)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payment_Orders");
        });

        modelBuilder.Entity<PriceList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PriceLis__3213E83F6F147010");

            entity.ToTable("PriceList");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BasePrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("base_price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.ShippingMethod)
                .HasMaxLength(50)
                .HasColumnName("shipping_method");
            entity.Property(e => e.WeightMaxRange)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("weight_max_range");
            entity.Property(e => e.WeightMinRange)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("weight_min_range");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Staff__3213E83F654AB348");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("phone_number");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasColumnName("role");
            entity.Property(e => e.StaffName)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("staff_name");
        });

        modelBuilder.Entity<Transport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Transpor__3213E83F0DECBCF7");

            entity.ToTable("Transport");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CurrentStatus)
                .HasMaxLength(50)
                .HasColumnName("current_status");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .HasColumnName("location");
            entity.Property(e => e.OrderId).HasColumnName("order_id");

            entity.HasOne(d => d.Order).WithMany(p => p.Transports)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transport_Orders");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}