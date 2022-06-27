using Company.Project.Core.Domain.Repository;
using Company.Project.ProductDomain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Project.ProductDomain.Repository
{
    public interface ICommentRepository : IRepository<Comments>
    {
        IEnumerable<Comments> GetComments(int EventId);
        void AddComments(Comments comment);
        Notification Notify(Comments comment, int EventId);
    }
}
