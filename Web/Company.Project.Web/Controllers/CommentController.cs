using Company.Project.ProductDomain.Domain;
using Company.Project.ProductDomain.Repository;
using Company.Project.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.Web.Controllers
{
    public class CommentController:Controller
    {
        private AutoMapper.IMapper mapper;
        private ICommentRepository _commentRepository;
        private ProductDomain.AppServices.ICommentAppService _commentService;

        public CommentController(ICommentRepository commentRepository, AutoMapper.IMapper mapper, ProductDomain.AppServices.ICommentAppService commentService)
        {
            this.mapper = mapper;
            _commentRepository = commentRepository;
            _commentService = commentService;
            
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Comments(int Id)
        {
            //IList<CommentViewModel> products = new List<CommentViewModel>();
            var comments = _commentRepository.GetComments(Id);
            
            return View(comments);
        }
        
        public ActionResult AddComments(CommentViewModel commentViewModel)
        {
            commentViewModel.Date = DateTime.Now;
            if (ModelState.IsValid)
            {
                
                Comments cmmt = new Comments
                {
                    Date = commentViewModel.Date,
                    EventId = commentViewModel.EventId,
                    CommentAdded = commentViewModel.CommentAdded,
                    UserId = User.Identity.Name
                    
                };
                _commentRepository.AddComments(cmmt);
                _commentRepository.Notify(cmmt,commentViewModel.EventId);
                return RedirectToAction("details", "event");
            }
            return View();
        }

     } 
}
