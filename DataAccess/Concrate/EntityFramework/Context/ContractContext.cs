using System;
using System.Collections.Generic;
using Entities.Concrate;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrate.EntityFramework.Context;


public partial class ContractContext : DbContext
{
    public ContractContext()
    {
    }

    public ContractContext(DbContextOptions<ContractContext> options)
        : base(options)
    {
    }

    public virtual DbSet<About> Abouts { get; set; }

    public virtual DbSet<AccessLevel> AccessLevels { get; set; }

    public virtual DbSet<AmountType> AmountTypes { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CategoryType> CategoryTypes { get; set; }

    public virtual DbSet<ContactPersonsOrg> ContactPersonsOrgs { get; set; }

    public virtual DbSet<ContactPersonsSec> ContactPersonsSecs { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<ContractAttachFile> ContractAttachFiles { get; set; }

    public virtual DbSet<ContractExtensionFile> ContractExtensionFiles { get; set; }

    public virtual DbSet<ContractStatus> ContractStatuses { get; set; }

    public virtual DbSet<ContractsName> ContractsNames { get; set; }

    public virtual DbSet<DeleteLog> DeleteLogs { get; set; }

    public virtual DbSet<Extension> Extensions { get; set; }

    public virtual DbSet<Guarantee> Guarantees { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Organization> Organizations { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<SecOfficial> SecOfficials { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-CGRMPJM;Database=MuqavileDIM;User Id=sa;Password=123;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<About>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("About");

            entity.Property(e => e.AboutTheSystem).HasMaxLength(4000);
            entity.Property(e => e.SsmaTimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("SSMA_TimeStamp");
        });

        modelBuilder.Entity<AccessLevel>(entity =>
        {
            entity.HasKey(e => e.AccessLevelId).HasName("AccessLevels$PrimaryKey");

            entity.HasIndex(e => e.AccessLevelId, "AccessLevels$UseID");

            entity.Property(e => e.AccessLevelId).HasColumnName("AccessLevelID");
            entity.Property(e => e.AccessLevelName).HasMaxLength(20);
            entity.Property(e => e.Description).HasMaxLength(255);
        });

        modelBuilder.Entity<AmountType>(entity =>
        {
            entity.HasKey(e => e.AmountTypeId).HasName("AmountType$PrimaryKey");

            entity.ToTable("AmountType");

            entity.HasIndex(e => e.AmountTypeId, "AmountType$AmountTypeID");

            entity.Property(e => e.AmountTypeId).HasColumnName("AmountTypeID");
            entity.Property(e => e.AmountDescription).HasMaxLength(255);
            entity.Property(e => e.AmountSymbol).HasMaxLength(5);
            entity.Property(e => e.AmountTypeName).HasMaxLength(20);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("Categories$PrimaryKey");

            entity.HasIndex(e => e.CategoryId, "Categories$CategoryID");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryDescription).HasMaxLength(255);
            entity.Property(e => e.CategoryName).HasMaxLength(30);
        });

        modelBuilder.Entity<CategoryType>(entity =>
        {
            entity.HasKey(e => e.CategoryTypeId).HasName("CategoryTypes$PrimaryKey");

            entity.HasIndex(e => e.CategoryId, "CategoryTypes$CategoryId");

            entity.HasIndex(e => e.CategoryTypeId, "CategoryTypes$CategoryTypeID");

            entity.Property(e => e.CategoryTypeId).HasColumnName("CategoryTypeID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(30);
            entity.Property(e => e.CategoryTypeName).HasMaxLength(100);
        });

        modelBuilder.Entity<ContactPersonsOrg>(entity =>
        {
            entity.HasKey(e => e.ContactId).HasName("ContactPersonsOrg$PrimaryKey");

            entity.ToTable("ContactPersonsOrg");

            entity.HasIndex(e => e.ContactId, "ContactPersonsOrg$ContactID");

            entity.HasIndex(e => e.ContractId, "ContactPersonsOrg$ContractID");

            entity.Property(e => e.ContactId).HasColumnName("ContactID");
            entity.Property(e => e.ContractId)
                .HasDefaultValue(0)
                .HasColumnName("ContractID");
            entity.Property(e => e.EmailAddress).HasMaxLength(30);
            entity.Property(e => e.FirstName).HasMaxLength(30);
            entity.Property(e => e.JobPosition).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(30);
            entity.Property(e => e.MobilePhone1).HasMaxLength(20);
            entity.Property(e => e.MobilePhone2).HasMaxLength(20);
            entity.Property(e => e.OfficePhone).HasMaxLength(20);

            entity.HasOne(d => d.Contract).WithMany(p => p.ContactPersonsOrgs)
                .HasForeignKey(d => d.ContractId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("ContactPersonsOrg${56D9E784-C409-4DE8-A280-E853834D31A0}");
        });

        modelBuilder.Entity<ContactPersonsSec>(entity =>
        {
            entity.HasKey(e => e.SecId);

            entity.ToTable("ContactPersonsSec");

            entity.HasIndex(e => e.ContactId, "ContactPersonsSec$ContactID");

            entity.HasIndex(e => e.ContractId, "ContactPersonsSec$ContractID");

            entity.Property(e => e.SecId).HasColumnName("SecID");
            entity.Property(e => e.ContactId)
                .HasDefaultValue(0)
                .HasColumnName("ContactID");
            entity.Property(e => e.ContractId)
                .HasDefaultValue(0)
                .HasColumnName("ContractID");

            entity.HasOne(d => d.Contract).WithMany(p => p.ContactPersonsSecs)
                .HasForeignKey(d => d.ContractId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ContactPersonsSec_Contracts");
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.ContractId).HasName("Contracts$ID");

            entity.HasIndex(e => e.AmountTypeId, "Contracts$AmountTypeID");

            entity.HasIndex(e => e.CategoryId, "Contracts$CategoryID");

            entity.HasIndex(e => e.CategoryTypeId, "Contracts$CategoryTypeID");

            entity.HasIndex(e => e.ContractStatusId, "Contracts$ContractStatusID");

            entity.HasIndex(e => e.GuaranteeId, "Contracts$GuaranteeID");

            entity.HasIndex(e => e.OrganizationId, "Contracts$OrganizationID");

            entity.HasIndex(e => e.PaymentMethodId, "Contracts$PaymentMethodID");

            entity.Property(e => e.ContractId).HasColumnName("ContractID");
            entity.Property(e => e.Amount).HasColumnType("money");
            entity.Property(e => e.AmountTypeId).HasColumnName("AmountTypeID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryTypeId).HasColumnName("CategoryTypeID");
            entity.Property(e => e.ContractNumber)
                .HasMaxLength(50)
                .UseCollation("Latin1_General_100_CI_AI_SC_UTF8");
            entity.Property(e => e.ContractStatusId).HasColumnName("ContractStatusID");
            entity.Property(e => e.ContractYear).HasMaxLength(4);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.Fine).HasMaxLength(255);
            entity.Property(e => e.GuaranteeId).HasColumnName("GuaranteeID");
            entity.Property(e => e.Notes).HasMaxLength(255);
            entity.Property(e => e.OrganizationId).HasColumnName("OrganizationID");
            entity.Property(e => e.PaymentMethodId).HasColumnName("PaymentMethodID");
            entity.Property(e => e.SsmaTimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("SSMA_TimeStamp");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.Subject)
                .HasMaxLength(4000)
                .UseCollation("Latin1_General_100_CI_AI_SC_UTF8");
            entity.Property(e => e.TaxNumber)
                .HasMaxLength(50)
                .UseCollation("Latin1_General_100_CI_AI_SC_UTF8");

            entity.HasOne(d => d.AmountType).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.AmountTypeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Contracts${11B79AA4-489D-4283-9F26-59938392C9AF}");

            entity.HasOne(d => d.Category).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Contracts${3CAFF1B1-D75E-4B68-A4F1-9233F6C9EB97}");

            entity.HasOne(d => d.CategoryType).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.CategoryTypeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Contracts${D23C53AB-64FC-40A8-89E5-AA7E596F6441}");

            entity.HasOne(d => d.ContractStatus).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.ContractStatusId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Contracts${2A07B86A-F51B-4398-B8BC-02280F860325}");

            entity.HasOne(d => d.Guarantee).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.GuaranteeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Contracts${1FEF9CA0-1626-4C2A-A99D-5283D0474574}");

            entity.HasOne(d => d.Organization).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.OrganizationId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Contracts${8FA81822-F8CF-431F-B59C-C661A6C04D53}");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.PaymentMethodId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Contracts${6F3ACEBE-6FA6-482E-A823-3B7CC20DCE69}");
        });

        modelBuilder.Entity<ContractAttachFile>(entity =>
        {
            entity.HasKey(e => e.FileId).HasName("ContractsAttachFiles$PK__contract__07D884C617CC2C99");

            entity.Property(e => e.FileId).HasColumnName("FileID");
            entity.Property(e => e.ContractId).HasColumnName("ContractID");
            entity.Property(e => e.FileName).HasMaxLength(255);
            entity.Property(e => e.FileType).HasMaxLength(50);

            entity.HasOne(d => d.Contract).WithMany(p => p.ContractAttachFiles)
                .HasForeignKey(d => d.ContractId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ContractsAttachFiles_Contracts");
        });

        modelBuilder.Entity<ContractExtensionFile>(entity =>
        {
            entity.HasKey(e => e.FileId).HasName("PK_ContractExtensionFiles_1");

            entity.Property(e => e.FileId).HasColumnName("FileID");
            entity.Property(e => e.ContractId).HasColumnName("ContractID");
            entity.Property(e => e.ExtensionId).HasColumnName("ExtensionID");
            entity.Property(e => e.FileName).HasMaxLength(255);
            entity.Property(e => e.FileType).HasMaxLength(50);

            entity.HasOne(d => d.Extension).WithMany(p => p.ContractExtensionFiles)
                .HasForeignKey(d => d.ExtensionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ContractExtensionFiles_Contracts");
        });

        modelBuilder.Entity<ContractStatus>(entity =>
        {
            entity.HasKey(e => e.ContractStatusId).HasName("ContractStatus$PrimaryKey");

            entity.ToTable("ContractStatus");

            entity.HasIndex(e => e.ContractStatusId, "ContractStatus$ContractStatusID");

            entity.Property(e => e.ContractStatusId).HasColumnName("ContractStatusID");
            entity.Property(e => e.ContractStatusDescription).HasMaxLength(255);
            entity.Property(e => e.ContractStatusName).HasMaxLength(50);
        });

        modelBuilder.Entity<ContractsName>(entity =>
        {
            entity.HasKey(e => e.ContractId).HasName("ContractsName$ID");

            entity.ToTable("ContractsName");

            entity.HasIndex(e => e.AmountTypeId, "ContractsName$AmountTypeID");

            entity.HasIndex(e => e.CategoryId, "ContractsName$CategoryID");

            entity.HasIndex(e => e.CategoryTypeId, "ContractsName$CategoryTypeID");

            entity.HasIndex(e => e.ContractStatusId, "ContractsName$ContractStatusID");

            entity.HasIndex(e => e.GuaranteeId, "ContractsName$GuaranteeID");

            entity.HasIndex(e => e.OrganizationIdold, "ContractsName$OrganizationID");

            entity.HasIndex(e => e.OrganizationId, "ContractsName$OrganizationID1");

            entity.HasIndex(e => e.PaymentMethodId, "ContractsName$PaymentMethodID");

            entity.Property(e => e.ContractId).HasColumnName("ContractID");
            entity.Property(e => e.Amount).HasColumnType("money");
            entity.Property(e => e.AmountTypeId)
                .HasDefaultValue(0)
                .HasColumnName("AmountTypeID");
            entity.Property(e => e.AmountTypeName).HasMaxLength(30);
            entity.Property(e => e.Attachment)
                .HasMaxLength(8000)
                .IsUnicode(false);
            entity.Property(e => e.CategoryId)
                .HasDefaultValue(0)
                .HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(30);
            entity.Property(e => e.CategoryTypeId)
                .HasDefaultValue(0)
                .HasColumnName("CategoryTypeID");
            entity.Property(e => e.CategoryTypeName).HasMaxLength(50);
            entity.Property(e => e.ContactsDim).HasMaxLength(255);
            entity.Property(e => e.ContactsOrg).HasMaxLength(255);
            entity.Property(e => e.ContractNumber).HasMaxLength(50);
            entity.Property(e => e.ContractStatusId)
                .HasDefaultValue(0)
                .HasColumnName("ContractStatusID");
            entity.Property(e => e.ContractStatusName).HasMaxLength(50);
            entity.Property(e => e.ContractYear).HasMaxLength(4);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.Fine).HasMaxLength(255);
            entity.Property(e => e.GuaranteeId)
                .HasDefaultValue(0)
                .HasColumnName("GuaranteeID");
            entity.Property(e => e.GuaranteeName).HasMaxLength(50);
            entity.Property(e => e.Notes).HasMaxLength(255);
            entity.Property(e => e.OrganizationId)
                .HasDefaultValue(0)
                .HasColumnName("OrganizationID");
            entity.Property(e => e.OrganizationIdold)
                .HasDefaultValue(0)
                .HasColumnName("OrganizationIDold");
            entity.Property(e => e.OrganizationName).HasMaxLength(255);
            entity.Property(e => e.PaymentMethodId)
                .HasDefaultValue(0)
                .HasColumnName("PaymentMethodID");
            entity.Property(e => e.PaymentMethodName).HasMaxLength(30);
            entity.Property(e => e.SsmaTimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("SSMA_TimeStamp");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.Subject).HasMaxLength(4000);
            entity.Property(e => e.TaxNumber).HasMaxLength(30);
        });

        modelBuilder.Entity<DeleteLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__DeleteLo__5E5499A85B98119B");

            entity.ToTable("DeleteLog");

            entity.Property(e => e.LogId).HasColumnName("LogID");
            entity.Property(e => e.DeleteTime).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(50);
            entity.Property(e => e.RecordId).HasColumnName("RecordID");
            entity.Property(e => e.TableName).HasMaxLength(50);
        });

        modelBuilder.Entity<Extension>(entity =>
        {
            entity.HasKey(e => e.ExtensionId).HasName("Extensions$PrimaryKey");

            entity.HasIndex(e => e.ExtensionId, "Extensions$ContactID");

            entity.HasIndex(e => e.ContractId, "Extensions$ContractID");

            entity.Property(e => e.ExtensionId).HasColumnName("ExtensionID");
            entity.Property(e => e.ContractId)
                .HasDefaultValue(0)
                .HasColumnName("ContractID");
            entity.Property(e => e.CurrentEndDate).HasColumnType("datetime");
            entity.Property(e => e.ExtensionReason).HasMaxLength(255);
            entity.Property(e => e.LinkDelete)
                .HasMaxLength(10)
                .HasDefaultValue("Sil")
                .IsFixedLength();
            entity.Property(e => e.LinkFiles)
                .HasMaxLength(10)
                .HasDefaultValue("Fayl")
                .IsFixedLength();
            entity.Property(e => e.NewEndDate).HasColumnType("datetime");

            entity.HasOne(d => d.Contract).WithMany(p => p.Extensions)
                .HasForeignKey(d => d.ContractId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Extensions${A7B5C3E5-F93E-40D4-B8E8-75C300BE0218}");
        });

        modelBuilder.Entity<Guarantee>(entity =>
        {
            entity.HasKey(e => e.GuaranteeId).HasName("Guarantees$PrimaryKey");

            entity.HasIndex(e => e.GuaranteeId, "Guarantees$GuaranteeID");

            entity.Property(e => e.GuaranteeId).HasColumnName("GuaranteeID");
            entity.Property(e => e.GuaranteeDescription).HasMaxLength(255);
            entity.Property(e => e.GuaranteeName).HasMaxLength(30);
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.InvoiceId).HasName("Invoices$PrimaryKey");

            entity.HasIndex(e => e.ContractId, "Invoices$ContractID");

            entity.HasIndex(e => e.InvoiceId, "Invoices$InvoiceID");

            entity.HasIndex(e => e.AmountTypeId, "Invoices$InvoicesAmountTypeID");

            entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");
            entity.Property(e => e.AmountTypeId).HasColumnName("AmountTypeID");
            entity.Property(e => e.ContractId).HasColumnName("ContractID");
            entity.Property(e => e.InvoiceAmount).HasColumnType("money");
            entity.Property(e => e.InvoiceDate).HasColumnType("datetime");
            entity.Property(e => e.InvoiceNo).HasMaxLength(20);
            entity.Property(e => e.InvoiceSerialNo).HasMaxLength(20);
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");

            entity.HasOne(d => d.AmountType).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.AmountTypeId)
                .HasConstraintName("FK_Invoices_AmountType");

            entity.HasOne(d => d.Contract).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.ContractId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Invoices${25672F5E-2B98-4165-883E-DFFEA5E578C2}");
        });

        modelBuilder.Entity<Organization>(entity =>
        {
            entity.HasKey(e => e.OrganizationId).HasName("Organizations$PrimaryKey");

            entity.HasIndex(e => e.OrganizationName, "Organizations$OrganizationName").IsUnique();

            entity.HasIndex(e => e.OrganizationId, "Organizations$id");

            entity.Property(e => e.OrganizationId).HasColumnName("OrganizationID");
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.ContractYear).HasMaxLength(4);
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .HasDefaultValue("Az?rbaycan");
            entity.Property(e => e.OrganizationName).HasMaxLength(255);
            entity.Property(e => e.StreetAptNo).HasMaxLength(50);
            entity.Property(e => e.TaxNumber).HasMaxLength(50);
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.HasKey(e => e.PaymentMethodId).HasName("PaymentMethod$PrimaryKey");

            entity.ToTable("PaymentMethod");

            entity.HasIndex(e => e.PaymentMethodId, "PaymentMethod$PaymentMethodID");

            entity.Property(e => e.PaymentMethodId).HasColumnName("PaymentMethodID");
            entity.Property(e => e.PaymentMethodDescription).HasMaxLength(255);
            entity.Property(e => e.PaymentMethodName).HasMaxLength(30);
        });

        modelBuilder.Entity<SecOfficial>(entity =>
        {
            entity.HasKey(e => e.ContactId).HasName("SecOfficials$PrimaryKey");

            entity.HasIndex(e => e.ContactId, "SecOfficials$id");

            entity.Property(e => e.ContactId).HasColumnName("ContactID");
            entity.Property(e => e.EmailAddress).HasMaxLength(30);
            entity.Property(e => e.FirstName).HasMaxLength(30);
            entity.Property(e => e.JobPosition).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(30);
            entity.Property(e => e.MobilePhone1).HasMaxLength(20);
            entity.Property(e => e.MobilePhone2).HasMaxLength(20);
            entity.Property(e => e.OfficePhone).HasMaxLength(20);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("Users$PrimaryKey");

            entity.HasIndex(e => e.AccessLevelId, "Users$AccessLevelID");
            entity.HasIndex(e => e.UserId, "Users$UserID");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.AccessLevelId).HasColumnName("AccessLevelID");
            entity.Property(e => e.BackupFilePath).HasMaxLength(30);
            entity.Property(e => e.DataBaseName)
                .HasMaxLength(30)
                .IsFixedLength();
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.ServerName)
                .HasMaxLength(30)
                .IsFixedLength();
            entity.Property(e => e.UserName).HasMaxLength(20);

            entity.HasOne(u => u.AccessLevel)
                  .WithMany()
                  .HasForeignKey(u => u.AccessLevelId)
                  .OnDelete(DeleteBehavior.SetNull);
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
