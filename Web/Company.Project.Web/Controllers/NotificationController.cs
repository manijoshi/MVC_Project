using Company.Project.ProductDomain.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.Web.Controllers
{
    public class NotificationController : Controller
    {
        private readonly INotificationRepository _notificationRepository;
        public NotificationController(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }
        public IActionResult ViewNotifications()
        {
            var UserId = User.Identity.Name;
            var list = _notificationRepository.GetAllNotifications(UserId);
            return View(list);
        }
    }
}
