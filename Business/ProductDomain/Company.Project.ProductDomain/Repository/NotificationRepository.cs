using Company.Project.Core.Data.DataAccess;
using Company.Project.ProductDomain.Data.DBContext;
using Company.Project.ProductDomain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Company.Project.ProductDomain.Repository
{
    public class NotificationRepository: Repository<Notification>, INotificationRepository
    {
        private readonly ProductDomainDbContext context;
        public NotificationRepository(ProductDomainDbContext context) : base(context)
        {
            this.context = context;
        }
        public IEnumerable<Notification> GetAllNotifications(string UserId)
        {
            IEnumerable<Notification> objList = context.Notifications.Where(x => x.Receiver == UserId);
            
            return objList;
        }
    }
}
