using Company.Project.ProductDomain.Domain;
using Company.Project.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Project.ProductDomain.Data.DBContext;
using Company.Project.ProductDomain.Repository;
using Microsoft.AspNetCore.Authorization;

namespace Company.Project.Web.Controllers
{
    public class EventController : Controller
    {
        private AutoMapper.IMapper mapper;
        private IProductRepository _productRepository;
        private ProductDomain.AppServices.IProductAppService _productService;

        public EventController(IProductRepository productRepository, ProductDomain.AppServices.IProductAppService productService, AutoMapper.IMapper mapper)
        {
            this.mapper = mapper;
            _productRepository = productRepository;
            _productService = productService;
        }

        [HttpGet]
        //[Authorize]
        public IActionResult CreateEvent()
        {
            if (User.IsInRole("User"))
            {
                return View();
            }
            else
            {
                return Redirect("~/home/Privacy");
            }
        }

        [HttpPost]
        //[Authorize]
        public IActionResult CreateEvent(EventViewModel model)
        {
            if (ModelState.IsValid)
            {
                Product newEvent = new Product
                {   
                    UserId = User.Identity.Name,
                    Title = model.Title,
                    Date = model.Date,
                    Location = model.Location,
                    StartTime = model.StartTime,
                    Type = model.Type,
                    Duration = model.Duration,
                    Description = model.Description,
                    OtherDetails = model.OtherDetails,
                    InviteByEmail = model.InviteByEmail
                    
                };
                _productRepository.Add(newEvent);
                return RedirectToAction("details", "event");
            }
            return View();
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            IList<EventViewModel> products = new List<EventViewModel>();

            var data = _productService.GetAllEvents();
            if (data.IsSuccess)
            {
                products = mapper.Map<IEnumerable<ProductDomain.AppServices.DTOs.ProductDTO>, List<EventViewModel>>(data.Data);
            }
            return View(products);
        }
        //[Authorize]
        public IActionResult AllEvents()
        {
            IList<EventViewModel> products = new List<EventViewModel>();

            var data = _productService.AllEvents();
            if (data.IsSuccess)
            {
                products = mapper.Map<IEnumerable<ProductDomain.AppServices.DTOs.ProductDTO>, List<EventViewModel>>(data.Data);
                
            }
            return View(products);
        }
        
        public IActionResult Details()
        {
            IList<EventViewModel> products = new List<EventViewModel>();
            var data = _productService.MyEvents(User.Identity.Name);
            foreach (var d in data.Data)
            {
                if (d.UserId == User.Identity.Name)
                {
                    ViewBag.CanEdit = User.IsInRole("Administrator") || User.Identity.Name != null;
                }
            }
            if (data.IsSuccess)
            {
                products = mapper.Map<IEnumerable<ProductDomain.AppServices.DTOs.ProductDTO>, List<EventViewModel>>(data.Data);
            }
            //var model = _productRepository.GetAllEvents();
            return View(products);
            //return View();
        }
        [AllowAnonymous]
        public IActionResult EventDetails(int Id)
        {
            EventViewModel eventViewModel = new EventViewModel();
            var data = _productService.GetEventByEventId(Id);
            if (data.IsSuccess)
            {
                eventViewModel = mapper.Map<ProductDomain.AppServices.DTOs.ProductDTO, EventViewModel>(data.Data);
            }
            return View(eventViewModel);
        }
        //[Authorize]
        public ActionResult EventsInvitedTo()
        {
            IList<EventViewModel> products = new List<EventViewModel>();
            var data = _productService.EventsInvitedTo(User.Identity.Name);
            if (data.IsSuccess)
            {
                products = mapper.Map<IEnumerable<ProductDomain.AppServices.DTOs.ProductDTO>, List<EventViewModel>>(data.Data);
            }
            return View(products);
        }
        [HttpGet]
        //[Authorize]
        public ActionResult EditEvent(int Id)
        {
            var evnt = _productService.GetEventByEventId(Id).Data;
            EventViewModel eventViewModel = new EventViewModel
            {
                Id=evnt.Id,
                UserId = evnt.UserId,
                Title = evnt.Title,
                Date = evnt.Date,
                Location = evnt.Location,
                StartTime = evnt.StartTime,
                Type = evnt.Type,
                Duration = evnt.Duration,
                Description = evnt.Description,
                OtherDetails = evnt.OtherDetails,
                InviteByEmail = evnt.InviteByEmail
            };
            ViewBag.CanEdit = (User.IsInRole("Administrator") || evnt.UserId == User.Identity.Name) && evnt.Date > DateTime.Now;
            if ((User.IsInRole("Administrator") || evnt.UserId == User.Identity.Name) && evnt.Date > DateTime.Now)
            {
                return View(eventViewModel);
            }
            else
            {
                return Redirect("~/home/Privacy");
            }
        }

        [HttpPost]
        //[Authorize]
        public IActionResult EditEvent(EventViewModel model)
        {
            if (ModelState.IsValid)
            {

                //var evnt = _productService.GetEventByEventId(model.EventId).Data;
                var evnt = _productService.GetEventByEventId(model.Id).Data;
                evnt.Title = model.Title;
                evnt.Date = model.Date;
                evnt.Location = model.Location;
                evnt.StartTime = model.StartTime;
                evnt.Type = model.Type;
                evnt.Duration = model.Duration;
                evnt.Description = model.Description;
                evnt.OtherDetails = model.OtherDetails;
                evnt.InviteByEmail = model.InviteByEmail;
                var updatedEmployee = _productService.Update(evnt);
                if (User.Identity.Name == "myadmin@bookevents.com")
                {
                    return RedirectToAction("AllEvents");
                }
                else
                {
                    return RedirectToAction("Details");
                }
            }
            return View(model);
        }
        
        public IActionResult Delete(int Id)
        {
            
            var currentEvent = _productService.AllEvents().Data.Where(e => e.Id == Id).FirstOrDefault();
            if (currentEvent == null)
            {
                return Redirect("~/home/privacy");
            }

            if (User.IsInRole("Administrator") || currentEvent.UserId == User.Identity.Name)
            {
                _productService.Delete(Id);
                
                return User.IsInRole("Administrator") ? Redirect("~/Event/AllEvents") : Redirect("~/Event/Details");
            }

            return Redirect("~/home/privacy");
           
        }
        
        
    }
}
