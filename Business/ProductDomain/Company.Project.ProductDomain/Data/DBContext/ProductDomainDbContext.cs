using Company.Project.Core.ExceptionManagement.CustomException;
using Company.Project.ProductDomain.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace Company.Project.ProductDomain.Data.DBContext
{
    public class ProductDomainDbContext : IdentityDbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public ProductDomainDbContext(DbContextOptions options) : base(options)
        {
        }
        public ProductDomainDbContext()
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
        //protected override void OnModelCreating(ModelBuilder modelBuilder) 
        //{ modelBuilder.Entity<Product>()
        //        .HasOne(e => e.Owner)
        //        .WithOne(e => e.OwnedBlog)
        //        .OnDelete(DeleteBehavior.ClientCascade); 
        //}
    }
}
