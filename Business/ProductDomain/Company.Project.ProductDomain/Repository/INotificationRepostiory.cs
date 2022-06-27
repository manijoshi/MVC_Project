using Company.Project.Core.Domain.Repository;
using Company.Project.ProductDomain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Project.ProductDomain.Repository
{
    public interface INotificationRepository : IRepository<Notification>
    {
        IEnumerable<Notification> GetAllNotifications(string UserId);
    }
}
