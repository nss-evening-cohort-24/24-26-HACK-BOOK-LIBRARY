﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace _24HackBookLibrary.Migrations
{
    [DbContext(typeof(_24HackBookLibraryDbContext))]
    [Migration("20240423032601_Update1")]
    partial class Update1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("_24HackBookLibrary.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 1,
                            Name = "Anne Frank"
                        },
                        new
                        {
                            Id = 2,
                            BookId = 2,
                            Name = "Madeline L'Engle"
                        },
                        new
                        {
                            Id = 3,
                            BookId = 3,
                            Name = "Jack Weatherford"
                        },
                        new
                        {
                            Id = 4,
                            BookId = 4,
                            Name = "Steven Erikson"
                        },
                        new
                        {
                            Id = 5,
                            BookId = 5,
                            Name = "Dan Brown"
                        },
                        new
                        {
                            Id = 6,
                            BookId = 6,
                            Name = "Douglas Adams"
                        },
                        new
                        {
                            Id = 7,
                            BookId = 7,
                            Name = "Suzanne Collins"
                        });
                });

            modelBuilder.Entity("_24HackBookLibrary.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<string>("BookCover")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("GenreId")
                        .HasColumnType("integer");

                    b.Property<int>("PublishYear")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            BookCover = "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1560816565l/48855.jpg",
                            GenreId = 1,
                            PublishYear = 1947,
                            Title = "The Diary of a Young Girl"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 2,
                            BookCover = "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1507963312l/33574273._SX318_.jpg",
                            GenreId = 2,
                            PublishYear = 1962,
                            Title = "A Wrinkle in Time"
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 3,
                            BookCover = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1530716694i/40718726.jpg",
                            GenreId = 3,
                            PublishYear = 2004,
                            Title = "Genghis Khan and the Making of the Modern World"
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 4,
                            BookCover = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1548497031i/55399.jpg",
                            GenreId = 4,
                            PublishYear = 1999,
                            Title = "Gardens of the Moon"
                        },
                        new
                        {
                            Id = 5,
                            AuthorId = 5,
                            BookCover = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1696691404i/960.jpg",
                            GenreId = 5,
                            PublishYear = 2000,
                            Title = "Angels and Demons"
                        },
                        new
                        {
                            Id = 6,
                            AuthorId = 6,
                            BookCover = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1531891848i/11.jpg",
                            GenreId = 6,
                            PublishYear = 1979,
                            Title = "The Hitchhiker's Guide to the Galaxy"
                        },
                        new
                        {
                            Id = 7,
                            AuthorId = 7,
                            BookCover = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1586722975i/2767052.jpg",
                            GenreId = 7,
                            PublishYear = 2008,
                            Title = "The Hunger Games"
                        });
                });

            modelBuilder.Entity("_24HackBookLibrary.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("integer");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 1,
                            Content = "A very important historical work.",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            BookId = 2,
                            Content = "Wild and imaginative!",
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            BookId = 3,
                            Content = "A bit biased but otherwise worth reading.",
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            BookId = 4,
                            Content = "I get the feeling the entire Malazan series will benefit from a reread.",
                            UserId = 4
                        },
                        new
                        {
                            Id = 5,
                            BookId = 5,
                            Content = "The battle between Science and religion is a fascinating topic to read.",
                            UserId = 5
                        },
                        new
                        {
                            Id = 6,
                            BookId = 6,
                            Content = "What a mezmerizingly weird little book.",
                            UserId = 6
                        },
                        new
                        {
                            Id = 7,
                            BookId = 7,
                            Content = "I just accidentally reread this book in one sitting...",
                            UserId = 7
                        });
                });

            modelBuilder.Entity("_24HackBookLibrary.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GenreName = "Biography"
                        },
                        new
                        {
                            Id = 2,
                            GenreName = "Children's"
                        },
                        new
                        {
                            Id = 3,
                            GenreName = "History"
                        },
                        new
                        {
                            Id = 4,
                            GenreName = "Fantasy"
                        },
                        new
                        {
                            Id = 5,
                            GenreName = "Mystery"
                        },
                        new
                        {
                            Id = 6,
                            GenreName = "Science-Fiction"
                        },
                        new
                        {
                            Id = 7,
                            GenreName = "Young Adult"
                        });
                });

            modelBuilder.Entity("_24HackBookLibrary.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Uid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Bio = "Test",
                            Email = "GregMarkus1992@gmail.com",
                            Uid = "",
                            UserName = "GMarkus"
                        },
                        new
                        {
                            Id = 2,
                            Bio = "Test",
                            Email = "nathopp@gmail.com",
                            Uid = "",
                            UserName = "NWelton"
                        },
                        new
                        {
                            Id = 3,
                            Bio = "Test",
                            Email = "HSmith@email.com",
                            Uid = "",
                            UserName = "HSmith"
                        },
                        new
                        {
                            Id = 4,
                            Bio = "Test",
                            Email = "mrthincrisp@gmail.com",
                            Uid = "",
                            UserName = "DSwann"
                        },
                        new
                        {
                            Id = 5,
                            Bio = "Test",
                            Email = "B33blebroxx@gmail.com",
                            Uid = "",
                            UserName = "BSchnurb"
                        });
                });

            modelBuilder.Entity("BookUser", b =>
                {
                    b.Property<int>("BooksId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("BooksId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("BookUser");
                });

            modelBuilder.Entity("_24HackBookLibrary.Models.Book", b =>
                {
                    b.HasOne("_24HackBookLibrary.Models.Author", null)
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_24HackBookLibrary.Models.Comment", b =>
                {
                    b.HasOne("_24HackBookLibrary.Models.Book", null)
                        .WithMany("Comments")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookUser", b =>
                {
                    b.HasOne("_24HackBookLibrary.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_24HackBookLibrary.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_24HackBookLibrary.Models.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("_24HackBookLibrary.Models.Book", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
