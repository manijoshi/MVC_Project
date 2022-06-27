using AutoMapper;
using Company.Project.Core.AppServices;
using Company.Project.Core.ExceptionManagement;
using Company.Project.Core.ValueObjects;
using Company.Project.ProductDomain.AppServices.DTOs;
using Company.Project.ProductDomain.Domain;
using Company.Project.ProductDomain.Repository;
using Company.Project.ProductDomain.UoW;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Project.ProductDomain.AppServices
{
    public class CommentAppService : AppService, ICommentAppService
    {
        private IMapper mapper;
        
        private ICommentRepository commentRepository;
        private object prodcutDTOList;

        public CommentAppService(IProductUnitOfWork unitOfWork, ICommentRepository commentRepository, IMapper mapper, IExceptionManager exceptionManager) : base(unitOfWork, exceptionManager)
        {
            this.mapper = mapper;
            //this.unitOfWork = unitOfWork;
            //this.exceptionManager = exceptionManager;
            this.commentRepository = commentRepository;

        }
        public OperationResult<IEnumerable<CommentDTO>> Comments(int EventId)
        {
            IEnumerable<Comments> commentList = commentRepository.GetComments(EventId);
            List<CommentDTO> commentDTOList = new List<CommentDTO>();
            prodcutDTOList = mapper.Map<IEnumerable<Comments>, List<CommentDTO>>(commentList);
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<IEnumerable<CommentDTO>>(commentDTOList, true, message);
        }

        
    }
}
