﻿// <auto-generated />
using System;
using App.Infra.Data.Repos.Ef.CW18.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App.Infra.Data.Repos.Ef.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AppDomainCore.CW18.Cards.Entities.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("Balance")
                        .HasColumnType("real");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<DateTime?>("CodeDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("HolderName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("WrongPasswordTries")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("AppDomainCore.CW18.Transactions.Entities.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<int>("DestinationCardId")
                        .HasColumnType("int");

                    b.Property<int>("SourceCardId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isSuccessful")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("DestinationCardId");

                    b.HasIndex("SourceCardId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("AppDomainCore.CW18.Users.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AppDomainCore.CW18.Cards.Entities.Card", b =>
                {
                    b.HasOne("AppDomainCore.CW18.Users.Entities.User", "User")
                        .WithMany("Cards")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AppDomainCore.CW18.Transactions.Entities.Transaction", b =>
                {
                    b.HasOne("AppDomainCore.CW18.Cards.Entities.Card", "DestinationCard")
                        .WithMany("TransactionsAsDestination")
                        .HasForeignKey("DestinationCardId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AppDomainCore.CW18.Cards.Entities.Card", "SourceCard")
                        .WithMany("TransactionsAsSource")
                        .HasForeignKey("SourceCardId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("DestinationCard");

                    b.Navigation("SourceCard");
                });

            modelBuilder.Entity("AppDomainCore.CW18.Cards.Entities.Card", b =>
                {
                    b.Navigation("TransactionsAsDestination");

                    b.Navigation("TransactionsAsSource");
                });

            modelBuilder.Entity("AppDomainCore.CW18.Users.Entities.User", b =>
                {
                    b.Navigation("Cards");
                });
#pragma warning restore 612, 618
        }
    }
}
