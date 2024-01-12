﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using immfegi.Data;

#nullable disable

namespace immfegi.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("immfegi.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "531d0a42-d6df-4269-b7b3-d313e7e4477a",
                            Email = "zirinazirina2015@yandex.ru",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ZIRINAZIRINA2015@YANDEX.RU",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEKRpYwiFxSWZ2zI06C6g8q91yA2UB/bOqSM+ZavaJaBbcG48j0AVK2ZUpdTp7FaV3A==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "436911f1-fb1f-4ec4-8e00-f2033b4c73d9",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = "02174cf0–9412–4cfe-afbf-59f706d72cf2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "578e71a9-7773-4b3d-b5fa-57f6c7b320e2",
                            Email = "inspector@test.ru",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "INSPECTOR@TEST.RU",
                            NormalizedUserName = "INSPECTOR",
                            PasswordHash = "AQAAAAEAACcQAAAAEPHJFVSx9knaSqjWWKoWrjYCJVbg+ch2bQv/ffJhI6O9XbuqUrdCBrBQ7+1uWsAqcw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "babf6ffa-85aa-4406-96ac-c81d862f0f8f",
                            TwoFactorEnabled = false,
                            UserName = "inspektor"
                        });
                });

            modelBuilder.Entity("immfegi.Models.ArticleForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ArticleFormStatus")
                        .HasColumnType("integer");

                    b.Property<string>("ArticleNameOnEnglish")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ArticleNameOnRussian")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ArticlePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Course")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullEducationInstitutionName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Group")
                        .HasColumnType("text");

                    b.Property<int>("IntendedParticipation")
                        .HasColumnType("integer");

                    b.Property<string>("ScientificDirectorEmail")
                        .HasColumnType("text");

                    b.Property<string>("ScientificDirectorFullEducationInstitutionName")
                        .HasColumnType("text");

                    b.Property<string>("ScientificDirectorName")
                        .HasColumnType("text");

                    b.Property<string>("ScientificDirectorPatronymic")
                        .HasColumnType("text");

                    b.Property<string>("ScientificDirectorPhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("ScientificDirectorPost")
                        .HasColumnType("text");

                    b.Property<string>("ScientificDirectorSurname")
                        .HasColumnType("text");

                    b.Property<string>("ScientificDirectorTitle")
                        .HasColumnType("text");

                    b.Property<string>("ScientificTitle")
                        .HasColumnType("text");

                    b.Property<string>("Section")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SpeakerEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SpeakerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SpeakerPatronymic")
                        .HasColumnType("text");

                    b.Property<string>("SpeakerPhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SpeakerPost")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SpeakerRole")
                        .HasColumnType("integer");

                    b.Property<string>("SpeakerSurname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UploadDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("ArticleForms");
                });

            modelBuilder.Entity("immfegi.Models.SchoolArticleForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AbbreviatedEducationInstitutionName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ArticleActivities")
                        .HasColumnType("integer");

                    b.Property<int>("ArticleFormStatus")
                        .HasColumnType("integer");

                    b.Property<string>("ArticleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ArticlePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullEducationInstitutionName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MunicipalDistrict")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SchoolBoyClass")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SchoolBoyEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SchoolBoyName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SchoolBoyPatronymic")
                        .HasColumnType("text");

                    b.Property<string>("SchoolBoyPhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SchoolBoySurname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ScientificDirectorEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ScientificDirectorName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ScientificDirectorPatronymic")
                        .HasColumnType("text");

                    b.Property<string>("ScientificDirectorPhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("ScientificDirectorPost")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ScientificDirectorSurname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ScientificDirectorTitle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Section")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UploadDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UrbanDistrict")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SchoolArticleForms");
                });

            modelBuilder.Entity("immfegi.Models.UserArticle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ArticleFormId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("ArticleFormId");

                    b.ToTable("UserArticles");
                });

            modelBuilder.Entity("immfegi.Models.UserSchoolArticle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SchoolArticleFormId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("SchoolArticleFormId");

                    b.ToTable("UserSchoolArticles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                            ConcurrencyStamp = "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                            Name = "Администратор",
                            NormalizedName = "АДМИНИСТРАТОР"
                        },
                        new
                        {
                            Id = "341743f0-asd2–42de-afbf-59kmkkmk72cf1",
                            ConcurrencyStamp = "341743f0-asd2–42de-afbf-59kmkkmk72cf1",
                            Name = "Студент",
                            NormalizedName = "СТУДЕНТ"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                            RoleId = "341743f0-asd2–42de-afbf-59kmkkmk72cf6"
                        },
                        new
                        {
                            UserId = "02174cf0–9412–4cfe-afbf-59f706d72cf2",
                            RoleId = "341743f0-asd2–42de-afbf-59kmkkmk72cf6"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("immfegi.Models.UserArticle", b =>
                {
                    b.HasOne("immfegi.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("UserArticles")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("immfegi.Models.ArticleForm", "ArticleForm")
                        .WithMany("UserArticles")
                        .HasForeignKey("ArticleFormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("ArticleForm");
                });

            modelBuilder.Entity("immfegi.Models.UserSchoolArticle", b =>
                {
                    b.HasOne("immfegi.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("immfegi.Models.SchoolArticleForm", "SchoolArticleForm")
                        .WithMany("UserSchoolArticles")
                        .HasForeignKey("SchoolArticleFormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("SchoolArticleForm");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("immfegi.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("immfegi.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("immfegi.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("immfegi.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("immfegi.Models.ApplicationUser", b =>
                {
                    b.Navigation("UserArticles");
                });

            modelBuilder.Entity("immfegi.Models.ArticleForm", b =>
                {
                    b.Navigation("UserArticles");
                });

            modelBuilder.Entity("immfegi.Models.SchoolArticleForm", b =>
                {
                    b.Navigation("UserSchoolArticles");
                });
#pragma warning restore 612, 618
        }
    }
}
