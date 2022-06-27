using Company.Project.Core.Data.DataAccess;
using Company.Project.ProductDomain.Data.DBContext;
using Company.Project.ProductDomain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Company.Project.ProductDomain.Repository
{
    
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ProductDomainDbContext context;
        public ProductRepository(ProductDomainDbContext context) : base(context)
        {
            this.context = context;
        }

        public Product Add(Product evt)
        {
            context.Products.Add(evt);
            context.SaveChanges();
            foreach (var entity in context.ChangeTracker.Entries())
            {
                entity.State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            }
            
            return evt;
        }
        public IEnumerable<Product> GetAllEvents()
        {  
            return context.Products.OrderBy(e => e.Date).Where(e=>e.Type=="Public").ToList();
        }
        public Product Update(Product eventChanges)
        {
            var entity = context.Products.Where(x => x.Id == eventChanges.Id).FirstOrDefault();
            if (entity != null)
            {
                entity.Title = eventChanges.Title;
                entity.Date = eventChanges.Date;
                entity.Location = eventChanges.Location;
                entity.StartTime = eventChanges.StartTime;
                entity.Type = eventChanges.Type;
                entity.Duration = eventChanges.Duration;
                entity.Description = eventChanges.Description;
                entity.OtherDetails = eventChanges.OtherDetails;
                entity.InviteByEmail = eventChanges.InviteByEmail;
                context.Products.Update(entity);
                context.SaveChanges();
            }
            return entity;
        }
        public IEnumerable<Product> MyEvents(string UserId)
        {
            IList<Product> evts = context.Products.OrderBy(e=>e.Date).Where(e => e.UserId == UserId).ToList();
            return evts;
            //return context.Products.AsEnumerable();
        }

        public Product GetEventByEventId(int Id)
        {
            return context.Products.FirstOrDefault(e => e.Id == Id);
        }
        public IEnumerable<Product> EventsInvitedTo(string UserId)
        {
            var evts = AllEvents();
            IList<Product> list = new List<Product>();
            foreach (var e in evts)
            {
                if (e.InviteByEmail != null)
                {
                    var emails = e.InviteByEmail.Replace(" ", string.Empty).Split(',').ToList();
                    if (emails.Contains(UserId))
                    {
                        list.Add(e);
                    }
                }
            }
            return list;
        }

        public IEnumerable<Product> AllEvents()
        {
            return context.Products.OrderBy(e => e.Date).ToList();
        }
        public void Delete(int Id)
        {
            var entity = context.Products.Find(Id);
            if (entity != null)
            {
                context.Products.Remove(entity);
                context.SaveChanges();
            }

        }
        
        
    }
}
