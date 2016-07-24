using System;
using System.Collections.Generic;
using System.Linq;
using Bookstore.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Bookstore.Web.Migrations
{
    using System.Data.Entity.Migrations;

    using DbContext;

    public class BookstoreDbMigrationConfiguration
        : DbMigrationsConfiguration<BookstoreDbContext>
    {
        public BookstoreDbMigrationConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(BookstoreDbContext context)
        {
            if (!context.Users.Any())
            {
                this.CreateUsers(context);
                this.CreateBooks(context);
            }   
        }

        private void CreateUsers(BookstoreDbContext context)
        {
            var usernames = new []
            {
                "katherina", "m.deneva", "nikola", "georgi", "denislav", "iliana",
            };

            var users = new List<User>();
            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);
            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 2,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            foreach (var username in usernames)
            {
                var user = new User
                {
                    UserName = username,
                    Email = username + "@gmail.com",
                };

                var password = "123456";
                var userCreateResult = userManager.Create(user, password);
                if (userCreateResult.Succeeded)
                {
                    users.Add(user);
                }
                else
                {
                    throw new Exception(string.Join("; ", userCreateResult.Errors));
                }
            }
        }

        private void CreateBooks(BookstoreDbContext conntext)
        {
            var toKillAMockingbirdBook = new Book
            {
                Title = "To Kill a Mockingbird",
                Summary = "The unforgettable novel of a childhood in a sleepy Southern town and" +
                          "the crisis of conscience that rocked it, To Kill A Mockingbird became" +
                          "both an instant bestseller and a critical success when it was first" +
                          "published in 1960. It went on to win the Pulitzer Prize in 1961 and" +
                          "was later made into an Academy Award-winning film, also a classic." +
                          "Compassionate, dramatic, and deeply moving, To Kill A Mockingbird" +
                          "takes readers to the roots of human behavior - to innocence and" +
                          "experience, kindness and cruelty, love and hatred, humor and pathos. " +
                          "Now with over 18 million copies in print and translated into forty" +
                          "languages, this regional story by a young Alabama woman claims" +
                          "universal appeal.Harper Lee always considered her book to be a simple" +
                          "love story.Today it is regarded as a masterpiece of American literature.",
                Author = "Harper Lee"
            };

            conntext.Books.Add(toKillAMockingbirdBook);
            conntext.SaveChanges();

            var theSecondHalfBook = new Book()
            {
                Title = "The Second Half",
                Summary =
                    "Mona and Ken Sorenson are approaching the best years of their lives. Mona's greatest concern is that Ken will learn of the surprise party she's planning for his retirement from his job as Dean of Students at Stone University. They've already been making plans to travel, spend limitless hours in the garden, and Ken is looking forward to working on his woodworking and fishing with his grandchildren. It's what they deserve after years of careful planning.",
                Author = "Lauraine Snelling",
            };

            conntext.Books.Add(theSecondHalfBook);
            conntext.SaveChanges();
        }
    }
}