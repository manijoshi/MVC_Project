using Company.Project.Core.Domain.Repository;
using Company.Project.ProductDomain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Project.ProductDomain.Repository
{
    public interface IProductRepository:IRepository<Product>
    {
        Product Add(Product evt);
        Product Update(Product evt);
        void Delete(int EventId);
        IEnumerable<Product> GetAllEvents();
        IEnumerable<Product> AllEvents();
        IEnumerable<Product> MyEvents(string UserId);
        Product GetEventByEventId(int EventId);
        IEnumerable<Product> EventsInvitedTo(string InviteByEmail);
        
    }
}
