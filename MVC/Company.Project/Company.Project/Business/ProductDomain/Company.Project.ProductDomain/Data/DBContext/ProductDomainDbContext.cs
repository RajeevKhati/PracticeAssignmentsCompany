using Company.Project.Core.ExceptionManagement.CustomException;
using Company.Project.ProductDomain.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Company.Project.ProductDomain.Data.DBContext
{
    public class ProductDomainDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Event> Events { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<EventAndPerson> EventsAndPeople { get; set; }


        public ProductDomainDbContext(DbContextOptions options) : base(options)
        {
        }

        public override int SaveChanges()
        {
            string errorMessage = string.Empty;
            var entities = (from entry in ChangeTracker.Entries()
                            where entry.State == EntityState.Modified || entry.State == EntityState.Added
                            select entry.Entity);

            var validationResults = new List<ValidationResult>();
            List<ValidationException> validationExceptionList = new List<ValidationException>();
            foreach (var entity in entities)
            {
                if (!Validator.TryValidateObject(entity, new ValidationContext(entity), validationResults, true))
                {
                    foreach (var result in validationResults)
                    {
                        if (result != ValidationResult.Success)
                        {
                            validationExceptionList.Add(new ValidationException(result.ErrorMessage));
                        }
                    }

                    throw new ValidationExceptions(validationExceptionList);
                }
            }

            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventAndPerson>()
             .HasKey(e => new { e.PersonID, e.EventID });

            var people = new[]
            {
                new Person { Id = 1, FullName = "adarsh singhai", Email = "adarsh@gmail.com" },
                new Person { Id = 2,FullName = "raj chakra", Email = "raj@gmail.com" },
                new Person {Id = 3, FullName = "sanket jain", Email = "sanket@yahoo.com" },
                new Person {Id = 4, FullName = "himanshu jain", Email = "himanshu@yahoo.com" },
                new Person {Id = 5, FullName = "deepanshu jain", Email = "deepanshu@gmail.com" },
                new Person {Id = 6, FullName = "dheeraj jain", Email = "dheeraj@zoho.com" }
            };

            var events = new[]
            {
                new Event
                {
                    Id=1,
                    UserID=1,
                    TitleOfBook = "positivity",
                    Date = new DateTime(2021, 11, 25),
                    Location = "mahim"
                },
                new Event
                {
                    Id=2,
                    UserID=1,
                    TitleOfBook = "war",
                    Date = new DateTime(2021 , 12 , 22),
                    Location = "bandra"
                },
                new Event
                {
                    Id=3,
                    UserID=5,
                    TitleOfBook = "21 days",
                    Date = new DateTime(2021 , 7 , 19),
                    Location = "dadar"
                },
                new Event
                {
                    Id=4,
                    UserID=5,
                    TitleOfBook = "rudest book ever",
                    Date = new DateTime(2020 , 5 , 14),
                    Location = "vasai"
                },
                new Event
                {
                    Id=5,
                    UserID=6,
                    TitleOfBook = "rag to rich",
                    Date = new DateTime(2021 , 2 , 10),
                    Location = "vile parle"
                },
                new Event
                {
                    Id=6,
                    UserID=3,
                    TitleOfBook = "rich dad poor dad",
                    Date = new DateTime(2021 , 10 , 30),
                    Location = "naigaon"
                }
            };

            var eventsAndPeople = new[]
            {
                new EventAndPerson { PersonID=1, EventID=2},
                new EventAndPerson {PersonID=2, EventID=3}
            };

            modelBuilder.Entity<Person>().HasData(people);
            modelBuilder.Entity<Event>().HasData(events);
            modelBuilder.Entity<EventAndPerson>().HasData(eventsAndPeople);



        }
    }
}
