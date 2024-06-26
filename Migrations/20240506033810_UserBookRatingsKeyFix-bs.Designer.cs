﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace _24HackBookLibrary.Migrations
{
    [DbContext(typeof(_24HackBookLibraryDbContext))]
    [Migration("20240506033810_UserBookRatingsKeyFix-bs")]
    partial class UserBookRatingsKeyFixbs
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

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

            modelBuilder.Entity("_24HackBookLibrary.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Anne Frank"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Madeline L'Engle"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Jack Weatherford"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Steven Erikson"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Dan Brown"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Douglas Adams"
                        },
                        new
                        {
                            Id = 7,
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
                        .HasColumnType("text");

                    b.Property<int>("GenreId")
                        .HasColumnType("integer");

                    b.Property<int>("PublishYear")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("GenreId");

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
                        .HasColumnType("text");

                    b.Property<DateTime?>("DatePosted")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 1,
                            Content = "A very important historical work.",
                            DatePosted = new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc),
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            BookId = 2,
                            Content = "Wild and imaginative!",
                            DatePosted = new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc),
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            BookId = 3,
                            Content = "A bit biased but otherwise worth reading.",
                            DatePosted = new DateTime(2024, 1, 22, 0, 0, 0, 0, DateTimeKind.Utc),
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            BookId = 4,
                            Content = "I get the feeling the entire Malazan series will benefit from a reread.",
                            DatePosted = new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            UserId = 4
                        },
                        new
                        {
                            Id = 5,
                            BookId = 5,
                            Content = "The battle between Science and religion is a fascinating topic to read.",
                            DatePosted = new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Utc),
                            UserId = 5
                        });
                });

            modelBuilder.Entity("_24HackBookLibrary.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("GenreName")
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
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean");

                    b.Property<string>("Uid")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Bio = "Test",
                            Email = "GregMarkus1992@gmail.com",
                            IsAdmin = true,
                            Uid = "DJNoS94RYXSgpS0jTW7RSVlWyCG3",
                            UserName = "GMarkus"
                        },
                        new
                        {
                            Id = 2,
                            Bio = "Test",
                            Email = "nathopp@gmail.com",
                            IsAdmin = true,
                            Uid = "pVt45Of2j2ThgpcIPKruq1pKn4A2",
                            UserName = "NWelton"
                        },
                        new
                        {
                            Id = 3,
                            Bio = "Test",
                            Email = "HSmith@email.com",
                            IsAdmin = true,
                            Uid = "udUYrA1rU1huTDv7dIsRYDcdLwl2",
                            UserName = "HSmith"
                        },
                        new
                        {
                            Id = 4,
                            Bio = "Test",
                            Email = "mrthincrisp@gmail.com",
                            IsAdmin = true,
                            Uid = "vaO8Bo1J2SVL7O2grpe1r0Lef9R2",
                            UserName = "DSwann"
                        },
                        new
                        {
                            Id = 5,
                            Bio = "Test",
                            Email = "B33blebroxx@gmail.com",
                            IsAdmin = true,
                            Uid = "qNfn30qHHwUki1tCyhS58puS8Ov1",
                            UserName = "BSchnurb"
                        });
                });

            modelBuilder.Entity("_24HackBookLibrary.Models.UserBookRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("integer");

                    b.Property<double>("Score")
                        .HasColumnType("double precision");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("UserBookRatings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 2,
                            Score = 5.0,
                            UserId = 4
                        },
                        new
                        {
                            Id = 2,
                            BookId = 6,
                            Score = 5.0,
                            UserId = 18
                        },
                        new
                        {
                            Id = 3,
                            BookId = 4,
                            Score = 5.0,
                            UserId = 18
                        },
                        new
                        {
                            Id = 4,
                            BookId = 3,
                            Score = 3.0,
                            UserId = 1
                        },
                        new
                        {
                            Id = 5,
                            BookId = 1,
                            Score = 4.0,
                            UserId = 2
                        });
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

            modelBuilder.Entity("_24HackBookLibrary.Models.Book", b =>
                {
                    b.HasOne("_24HackBookLibrary.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_24HackBookLibrary.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("_24HackBookLibrary.Models.Comment", b =>
                {
                    b.HasOne("_24HackBookLibrary.Models.Book", null)
                        .WithMany("Comments")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_24HackBookLibrary.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("_24HackBookLibrary.Models.UserBookRating", b =>
                {
                    b.HasOne("_24HackBookLibrary.Models.Book", "Book")
                        .WithMany("UserBookRatings")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_24HackBookLibrary.Models.User", "User")
                        .WithMany("UserBookRatings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("_24HackBookLibrary.Models.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("_24HackBookLibrary.Models.Book", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("UserBookRatings");
                });

            modelBuilder.Entity("_24HackBookLibrary.Models.User", b =>
                {
                    b.Navigation("UserBookRatings");
                });
#pragma warning restore 612, 618
        }
    }
}
