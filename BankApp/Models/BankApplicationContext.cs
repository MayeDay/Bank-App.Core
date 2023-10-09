using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Models;

public partial class BankApplicationContext : DbContext
{
    public BankApplicationContext()
    {
    }

    public BankApplicationContext(DbContextOptions<BankApplicationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AccountStatusType> AccountStatusTypes { get; set; }

    public virtual DbSet<AccountType> AccountTypes { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerAccount> CustomerAccounts { get; set; }

    public virtual DbSet<LoginAccount> LoginAccounts { get; set; }

    public virtual DbSet<TransactionHistory> TransactionHistories { get; set; }

    public virtual DbSet<TransactionType> TransactionTypes { get; set; }

    public virtual DbSet<UserLogin> UserLogins { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-IBGUT0C\\ORIGINAL; Database=BankApplication;User Id=JamesMaye;Password=J@m3sM@y3; Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Account__3214EC07BFDBBE79");

            entity.ToTable("Account");

            entity.Property(e => e.AccountNumber)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AvailableBalance).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CurrentBalance).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.AccountStatusType).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.AccountStatusTypeId)
                .HasConstraintName("FK__Account__Account__412EB0B6");

            entity.HasOne(d => d.AccountType).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.AccountTypeId)
                .HasConstraintName("FK__Account__Account__403A8C7D");
        });

        modelBuilder.Entity<AccountStatusType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AccountS__3214EC07DE8B303B");

            entity.ToTable("AccountStatusType");

            entity.Property(e => e.AccountStatusDescription)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AccountType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AccountT__3214EC072C3DCD1D");

            entity.ToTable("AccountType");

            entity.Property(e => e.AccountTypeDescription)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC079FDB6FAF");

            entity.ToTable("Customer");

            entity.Property(e => e.Address1)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Address2)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.HomePhone)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Middle_Name");
            entity.Property(e => e.MobilePhone)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ProfileImg)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Profile_Img");
            entity.Property(e => e.Ssn)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("SSN");
            entity.Property(e => e.State)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Suffix)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ZipCode)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.UserLogin).WithMany(p => p.Customers)
                .HasForeignKey(d => d.UserLoginId)
                .HasConstraintName("FK__Customer__UserLo__398D8EEE");
        });

        modelBuilder.Entity<CustomerAccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC07D83A739D");

            entity.ToTable("CustomerAccount");

            entity.HasOne(d => d.Account).WithMany(p => p.CustomerAccounts)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__CustomerA__Accou__440B1D61");

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerAccounts)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__CustomerA__Custo__44FF419A");
        });

        modelBuilder.Entity<LoginAccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LoginAcc__3214EC07B74D6085");

            entity.ToTable("LoginAccount");

            entity.HasOne(d => d.Account).WithMany(p => p.LoginAccounts)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__LoginAcco__Accou__5070F446");

            entity.HasOne(d => d.UserLogin).WithMany(p => p.LoginAccounts)
                .HasForeignKey(d => d.UserLoginId)
                .HasConstraintName("FK__LoginAcco__UserL__4F7CD00D");
        });

        modelBuilder.Entity<TransactionHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Transact__3214EC0765DF341A");

            entity.ToTable("TransactionHistory");

            entity.Property(e => e.NewBalance).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TransactionAmount).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Account).WithMany(p => p.TransactionHistories)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__Transacti__Accou__4AB81AF0");

            entity.HasOne(d => d.Customer).WithMany(p => p.TransactionHistories)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Transacti__Custo__4BAC3F29");

            entity.HasOne(d => d.TransactionType).WithMany(p => p.TransactionHistories)
                .HasForeignKey(d => d.TransactionTypeId)
                .HasConstraintName("FK__Transacti__Trans__49C3F6B7");

            entity.HasOne(d => d.UserLogin).WithMany(p => p.TransactionHistories)
                .HasForeignKey(d => d.UserLoginId)
                .HasConstraintName("FK__Transacti__UserL__4CA06362");
        });

        modelBuilder.Entity<TransactionType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Transact__3214EC0749943290");

            entity.ToTable("TransactionType");

            entity.Property(e => e.TransactionTypeDescription)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TransactionTypeName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserLogin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserLogi__3214EC0790E21248");

            entity.ToTable("UserLogin");

            entity.Property(e => e.Password)
                .HasMaxLength(64)
                .IsFixedLength();
            entity.Property(e => e.UserLogin1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("UserLogin");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
