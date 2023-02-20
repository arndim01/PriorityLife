using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PriorityLifeAPI.BusinessObject;
using PriorityLifeAPI.EF;

namespace PriorityLifeAPI
{
    public partial class PriorityLifeContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //var connection = Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-MKRCOC2;Database=PriorityLifeDataLocal;MultipleActiveResultSets=True;Integrated Security=True;");
            var config = Config.Get("ConnectionStrings:DefaultConnection");
            optionsBuilder.UseSqlServer(config);
            //Server=DESKTOP-Q6K9UMB\\SQLEXPRESS;Database=ExtractorDatabase_Debug;MultipleActiveResultSets=True;Integrated Security=True;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_AspNetRoleClaims");

                entity.ToTable("AspNetRoleClaims", "dbo");

                entity.HasIndex(e => new { e.RoleId })
                    .HasName("IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.Id);

                entity.Property(e => e.RoleId)
                    .HasMaxLength(450)
                    .IsRequired();

                entity.Property(e => e.ClaimType);

                entity.Property(e => e.ClaimValue);

                entity.HasOne(d => d.RoleIdNavigation)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_AspNetRoleClaims_AspNetRoles_RoleId");

            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_AspNetRoles");

                entity.ToTable("AspNetRoles", "dbo");

                entity.HasIndex(e => new { e.NormalizedName })
                    .HasName("RoleNameIndex");

                entity.Property(e => e.Id)
                    .HasMaxLength(450);

                entity.Property(e => e.Name)
                    .HasMaxLength(256);

                entity.Property(e => e.NormalizedName)
                    .HasMaxLength(256);

                entity.Property(e => e.ConcurrencyStamp);

            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_AspNetUserClaims");

                entity.ToTable("AspNetUserClaims", "dbo");

                entity.HasIndex(e => new { e.UserId })
                    .HasName("IX_AspNetUserClaims_UserId");

                entity.Property(e => e.Id);

                entity.Property(e => e.UserId)
                    .HasMaxLength(450)
                    .IsRequired();

                entity.Property(e => e.ClaimType);

                entity.Property(e => e.ClaimValue);

                entity.HasOne(d => d.UserIdNavigation)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_AspNetUserClaims_AspNetUsers_UserId");

            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
                    .HasName("PK_AspNetUserLogins");

                entity.ToTable("AspNetUserLogins", "dbo");

                entity.HasIndex(e => new { e.UserId })
                    .HasName("IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider)
                    .HasMaxLength(128);

                entity.Property(e => e.ProviderKey)
                    .HasMaxLength(128);

                entity.Property(e => e.ProviderDisplayName);

                entity.Property(e => e.UserId)
                    .HasMaxLength(450)
                    .IsRequired();

                entity.HasOne(d => d.UserIdNavigation)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_AspNetUserLogins_AspNetUsers_UserId");

            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_AspNetUsers");

                entity.ToTable("AspNetUsers", "dbo");

                entity.HasIndex(e => new { e.NormalizedUserName })
                    .HasName("UserNameIndex");

                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.Property(e => e.Id)
                    .HasMaxLength(450);

                entity.Property(e => e.UserName)
                    .HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName)
                    .HasMaxLength(256);

                entity.Property(e => e.Email)
                    .HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail)
                    .HasMaxLength(256);

                entity.Property(e => e.EmailConfirmed)
                    .IsRequired();

                entity.Property(e => e.PasswordHash);

                entity.Property(e => e.SecurityStamp);

                entity.Property(e => e.ConcurrencyStamp);

                entity.Property(e => e.PhoneNumber);

                entity.Property(e => e.PhoneNumberConfirmed)
                    .IsRequired();

                entity.Property(e => e.TwoFactorEnabled)
                    .IsRequired();

                entity.Property(e => e.LockoutEnd);

                entity.Property(e => e.LockoutEnabled)
                    .IsRequired();

                entity.Property(e => e.AccessFailedCount)
                    .IsRequired();

                entity.Property(e => e.FirstName);

                entity.Property(e => e.LastName);

            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name })
                    .HasName("PK_AspNetUserTokens");

                entity.ToTable("AspNetUserTokens", "dbo");

                entity.Property(e => e.UserId)
                    .HasMaxLength(450);

                entity.Property(e => e.LoginProvider)
                    .HasMaxLength(128);

                entity.Property(e => e.Name)
                    .HasMaxLength(128);

                entity.Property(e => e.Value);

                entity.HasOne(d => d.UserIdNavigation)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_AspNetUserTokens_AspNetUsers_UserId");

            });

            modelBuilder.Entity<Carriers>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__Carriers__3214EC07DD278CE6");

                entity.ToTable("Carriers", "dbo");

                entity.Property(e => e.Id);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.ShortName)
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.Username)
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.Password)
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.Active)
                    .HasDefaultValueSql("1");

                entity.Property(e => e.AddedBy)
                    .IsRequired()
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.AddedDate)
                    .HasDefaultValueSql("getutcdate");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.UpdatedDate);

            });

            modelBuilder.Entity<Commissions>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__Commissi__3214EC07142BCD2C");

                entity.ToTable("Commissions", "dbo");

                entity.Property(e => e.Id);

                entity.Property(e => e.SalespersonId)
                    .IsRequired();

                entity.Property(e => e.CarrierId)
                    .IsRequired();

                entity.Property(e => e.CommissionDate)
                    .IsRequired();

                entity.Property(e => e.CommissionStartDate);

                entity.Property(e => e.CommissionEndDate);

                entity.Property(e => e.Amount)
                    .IsRequired()
                    .HasColumnType("money");

                entity.Property(e => e.AddedBy)
                    .IsRequired()
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.AddedDate)
                    .HasDefaultValueSql("getutcdate");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.UpdatedDate);

                entity.HasOne(d => d.SalespersonIdNavigation)
                  .WithMany(p => p.Commissions)
                  .HasForeignKey(d => d.SalespersonId)
                  .OnDelete(DeleteBehavior.Restrict)
                  .HasConstraintName("FK_Commissions_Salesperson");

                entity.HasOne(d => d.CarrierIdNavigation)
                    .WithMany(p => p.Commissions)
                    .HasForeignKey(d => d.CarrierId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Commissions_Carriers");

            });

            modelBuilder.Entity<CommissionsExtracted>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__Commissi__3214EC070EBEFCF6");

                entity.ToTable("CommissionsExtracted", "dbo");

                entity.Property(e => e.Id);

                entity.Property(e => e.Carrier)
                    .IsRequired()
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.Amount)
                    .IsRequired()
                    .HasColumnType("money");

                entity.Property(e => e.Date)
                    .IsRequired();

                entity.Property(e => e.UCode)
                    .IsRequired()
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.DownloadType)
                    .IsRequired()
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.Active)
                    .HasDefaultValueSql("1");

                entity.Property(e => e.AddedBy)
                    .IsRequired()
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.AddedDate)
                    .IsRequired();

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.UpdatedDate);

            });

            modelBuilder.Entity<CommissionsFile>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__tmp_ms_x__3214EC071B38AE4E");

                entity.ToTable("CommissionsFile", "dbo");

                entity.Property(e => e.Id);

                entity.Property(e => e.CarrierId)
                    .IsRequired();

                entity.Property(e => e.ExtractedDate)
                    .HasDefaultValueSql("getutcdate");

                entity.Property(e => e.FileUrl)
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.Extension)
                    .HasMaxLength(50)
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Active)
                    .HasDefaultValueSql("1");

                entity.Property(e => e.AddedBy)
                    .IsRequired()
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.AddedDate)
                    .HasDefaultValueSql("getutcdate");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.UpdatedDate);

                entity.HasOne(d => d.CarrierIdNavigation)
                    .WithMany(p => p.CommissionsFile)
                    .HasForeignKey(d => d.CarrierId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_CarrierId");

            });

            modelBuilder.Entity<Hierarchy>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__Hierarch__3214EC07B223F8A5");

                entity.ToTable("Hierarchy", "dbo");

                entity.Property(e => e.Id);

                entity.Property(e => e.SalesPersonId)
                    .IsRequired();

                entity.Property(e => e.Upline1Id);

                entity.Property(e => e.Upline2Id);

                entity.Property(e => e.Upline3Id);

                entity.Property(e => e.Upline4Id);

                entity.Property(e => e.Upline5Id);

                entity.Property(e => e.Upline6Id);

                entity.Property(e => e.Upline7Id);

                entity.Property(e => e.Upline8Id);

                entity.Property(e => e.Upline9Id);

                entity.Property(e => e.Upline10Id);

                entity.Property(e => e.Active)
                    .HasDefaultValueSql("1");

                entity.Property(e => e.AddedBy)
                    .IsRequired()
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.AddedDate)
                    .HasDefaultValueSql("getutcdate");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.UpdatedDate);

                entity.HasOne(d => d.SalesPersonIdNavigation)
                    .WithMany(p => p.HierarchySalesPersonIdNavigation)
                    .HasForeignKey(d => d.SalesPersonId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SalespersonId");

                entity.HasOne(d => d.Upline1IdNavigation)
                    .WithMany(p => p.HierarchyUpline1IdNavigation)
                    .HasForeignKey(d => d.Upline1Id)
                    .HasConstraintName("FK_SalespersonUpline1Id");

                entity.HasOne(d => d.Upline2IdNavigation)
                    .WithMany(p => p.HierarchyUpline2IdNavigation)
                    .HasForeignKey(d => d.Upline2Id)
                    .HasConstraintName("FK_SalespersonUpline2Id");

                entity.HasOne(d => d.Upline3IdNavigation)
                    .WithMany(p => p.HierarchyUpline3IdNavigation)
                    .HasForeignKey(d => d.Upline3Id)
                    .HasConstraintName("FK_SalespersonUpline3Id");

                entity.HasOne(d => d.Upline4IdNavigation)
                    .WithMany(p => p.HierarchyUpline4IdNavigation)
                    .HasForeignKey(d => d.Upline4Id)
                    .HasConstraintName("FK_SalespersonUpline4Id");

                entity.HasOne(d => d.Upline5IdNavigation)
                    .WithMany(p => p.HierarchyUpline5IdNavigation)
                    .HasForeignKey(d => d.Upline5Id)
                    .HasConstraintName("FK_SalespersonUpline5Id");

                entity.HasOne(d => d.Upline6IdNavigation)
                    .WithMany(p => p.HierarchyUpline6IdNavigation)
                    .HasForeignKey(d => d.Upline6Id)
                    .HasConstraintName("FK_SalespersonUpline6Id");

                entity.HasOne(d => d.Upline7IdNavigation)
                    .WithMany(p => p.HierarchyUpline7IdNavigation)
                    .HasForeignKey(d => d.Upline7Id)
                    .HasConstraintName("FK_SalespersonUpline7Id");

                entity.HasOne(d => d.Upline8IdNavigation)
                    .WithMany(p => p.HierarchyUpline8IdNavigation)
                    .HasForeignKey(d => d.Upline8Id)
                    .HasConstraintName("FK_SalespersonUpline8Id");

                entity.HasOne(d => d.Upline9IdNavigation)
                    .WithMany(p => p.HierarchyUpline9IdNavigation)
                    .HasForeignKey(d => d.Upline9Id)
                    .HasConstraintName("FK_SalespersonUpline9Id");

                entity.HasOne(d => d.Upline10IdNavigation)
                    .WithMany(p => p.HierarchyUpline10IdNavigation)
                    .HasForeignKey(d => d.Upline10Id)
                    .HasConstraintName("FK_SalespersonUpline10Id");

            });

            modelBuilder.Entity<Salesperson>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__Salesper__3214EC07EA9039FD");

                entity.ToTable("Salesperson", "dbo");

                entity.Property(e => e.Id);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.Initials)
                    .IsRequired()
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.Email)
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.Phone)
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.Active)
                    .HasDefaultValueSql("1");

                entity.Property(e => e.AddedBy)
                    .IsRequired()
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.AddedDate)
                    .HasDefaultValueSql("getutcdate");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.UpdatedDate);

            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__Team__3214EC07B333D01B");

                entity.ToTable("Team", "dbo");

                entity.Property(e => e.Id);

                entity.Property(e => e.TeamManager)
                    .IsRequired();

                entity.Property(e => e.TeamName)
                    .IsRequired()
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.Active)
                    .HasDefaultValueSql("1");

                entity.Property(e => e.AddedBy)
                    .IsRequired()
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.AddedDate)
                    .HasDefaultValueSql("getutcdate");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.UpdatedDate);

                entity.HasOne(d => d.TeamManagerNavigation)
                    .WithMany(p => p.Team)
                    .HasForeignKey(d => d.TeamManager)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_TeamManagerSalespersonId");

            });

            modelBuilder.Entity<TeamDetails>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__TeamDeta__3214EC0764E6ECDC");

                entity.ToTable("TeamDetails", "dbo");

                entity.Property(e => e.Id);

                entity.Property(e => e.TeamId)
                    .IsRequired();

                entity.Property(e => e.TeamMemberId)
                    .IsRequired();

                entity.Property(e => e.Activate)
                    .HasDefaultValueSql("1");

                entity.Property(e => e.AddedBy)
                    .IsRequired()
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.AddedDate)
                    .HasDefaultValueSql("getutcdate");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.UpdatedDate);

                entity.HasOne(d => d.TeamIdNavigation)
                    .WithMany(p => p.TeamDetails)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_TeamId");

                entity.HasOne(d => d.TeamMemberIdNavigation)
                    .WithMany(p => p.TeamDetails)
                    .HasForeignKey(d => d.TeamMemberId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_TeamMemberId");

            });

        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<Carriers> Carriers { get; set; }
        public virtual DbSet<Commissions> Commissions { get; set; }
        public virtual DbSet<CommissionsExtracted> CommissionsExtracted { get; set; }
        public virtual DbSet<CommissionsFile> CommissionsFile { get; set; }
        public virtual DbSet<Hierarchy> Hierarchy { get; set; }
        public virtual DbSet<Salesperson> Salesperson { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<TeamDetails> TeamDetails { get; set; }
    }
}
