using Company.Project.Core.Data.DataAccess;
using Company.Project.ProductDomain.Data.DBContext;
using Company.Project.ProductDomain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Company.Project.ProductDomain.Repository
{
    public class CommentRepository : Repository<Comments>,ICommentRepository
    {
        private readonly ProductDomainDbContext context;
        public CommentRepository(ProductDomainDbContext context) : base(context)
        {
            this.context = context;
        }
        public int Count => throw new NotImplementedException();

        public IEnumerable<Comments> GetComments(int Id)
        {
            IEnumerable<Comments> comments = null;
            var query = from c in context.Comments
                        where c.EventId == Id
                        select c;
            if (query != null)
            {
                comments = query.ToList();
                
            }
            return comments;
        }

        public void AddComments(Comments comment)
        {
            context.Comments.Add(comment);
            context.SaveChanges();
        }

        public IQueryable<Comments> All()
        {
            throw new NotImplementedException();
        }

        public bool Contains(Expression<Func<Comments, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Create(Comments entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Comments entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Expression<Func<Comments, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Comments> Filter(Expression<Func<Comments, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Comments> Filter(Expression<Func<Comments, bool>> filter, out int total, int index = 0, int size = 50)
        {
            throw new NotImplementedException();
        }

        public Comments Find(Expression<Func<Comments, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Comments> Get(Expression<Func<Comments, bool>> filter = null, Func<IQueryable<Comments>, IOrderedQueryable<Comments>> orderBy = null)
        {
            throw new NotImplementedException();
        }

        public Comments GetById(object id)
        {
            throw new NotImplementedException();
        }

        public Notification Notify(Comments comment, int EventId)
        {
            var evt = context.Products.Find(EventId);
            Notification notification = new Notification
            {
                Sender = comment.UserId,
                Receiver = evt.UserId,
                EventId = EventId,
                EventTitle = evt.Title,
                Date = comment.Date,
                
                
            };
            context.Notifications.Add(notification);
            context.SaveChanges();
            return notification;
        }
    
    }
}
