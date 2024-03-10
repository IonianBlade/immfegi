using immfegi.Models;
using immfegi.Models.NewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace immfegi.Data;

public class DataContext : IdentityDbContext<ApplicationUser>
{
    static DataContext()
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public DataContext(DbContextOptions<DataContext> context) : base(context)
    {
    }

    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<ArticleForm> ArticleForms { get; set; }
    public DbSet<UserArticle> UserArticles { get; set; }
    public DbSet<SchoolArticleForm> SchoolArticleForms { get; set; }
    public DbSet<UserSchoolArticle> UserSchoolArticles { get; set; }

    // new entities
    public DbSet<Article> Articles { get; set; }
    public DbSet<ApplicationUserArticles> ApplicationUserArticlesCollection { get; set; }
    public DbSet<SchoolArticle> SchoolArticles { get; set; }
    public DbSet<ApplicationUserSchoolArticles> ApplicationUserSchoolArticlesCollection { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<ArticleForm>()
            .HasMany(a => a.UserArticles)
            .WithOne(ua => ua.ArticleForm)
            .HasForeignKey(ua => ua.ArticleFormId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<SchoolArticleForm>()
            .HasMany(a => a.UserSchoolArticles)
            .WithOne(ua => ua.SchoolArticleForm)
            .HasForeignKey(ua => ua.SchoolArticleFormId)
            .OnDelete(DeleteBehavior.Cascade);

        const string adminId = "02174cf0–9412–4cfe-afbf-59f706d72cf6";
        const string inspectorId = "02174cf0–9412–4cfe-afbf-59f706d72cf2";
        const string adminRoleId = "341743f0-asd2–42de-afbf-59kmkkmk72cf6";
        const string studentRoleId = "341743f0-asd2–42de-afbf-59kmkkmk72cf1";


        builder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Name = "Администратор",
            NormalizedName = "АДМИНИСТРАТОР",
            Id = adminRoleId,
            ConcurrencyStamp = adminRoleId
        });

        builder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Name = "Студент",
            NormalizedName = "СТУДЕНТ",
            Id = studentRoleId,
            ConcurrencyStamp = studentRoleId
        });

        var adminUser = new ApplicationUser
        {
            Id = adminId,
            UserName = "admin",
            Email = "zirinazirina2015@yandex.ru",
            NormalizedEmail = "ZIRINAZIRINA2015@YANDEX.RU",
            NormalizedUserName = "ADMIN",
        };

        var inspectorUser = new ApplicationUser()
        {
            Id = inspectorId,
            UserName = "inspektor",
            Email = "inspector@test.ru",
            NormalizedEmail = "INSPECTOR@TEST.RU",
            NormalizedUserName = "INSPECTOR",
        };

        //set user password
        var ph = new PasswordHasher<ApplicationUser>();
        adminUser.PasswordHash = ph.HashPassword(adminUser, "ZaicevaRshu");
        inspectorUser.PasswordHash = ph.HashPassword(adminUser, "InspectorRshu");

        //seed user
        builder.Entity<ApplicationUser>().HasData(adminUser);
        builder.Entity<ApplicationUser>().HasData(inspectorUser);

        //set user role to admin
        builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = adminRoleId,
            UserId = adminId
        });

        builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = adminRoleId,
            UserId = inspectorId
        });
    }
}