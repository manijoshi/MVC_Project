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
using System.Linq;
using System.Text;

namespace Company.Project.ProductDomain.AppServices
{
    public class ProductAppService : AppService, IProductAppService
    {
        private IMapper mapper;
        //private IApplicationUnitOfWork unitOfWork;
        //private IExceptionManager exceptionManager;
        private IProductRepository productRepository;


        public ProductAppService(IProductUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper, IExceptionManager exceptionManager) : base(unitOfWork, exceptionManager)
        {
            this.mapper = mapper;
            //this.unitOfWork = unitOfWork;
            //this.exceptionManager = exceptionManager;
            this.productRepository = productRepository;

        }

        public OperationResult<ProductDTO> Create(ProductDTO item)
        {
            Product product = mapper.Map<ProductDTO, Product>(item);
            productRepository.Add(product);
            
            OperationResult result;
            result = new OperationResult(true, new Message("", ""));
            
            return new OperationResult<ProductDTO>(item, result.IsSuccess, result.MainMessage, result.AssociatedMessages.ToList<Message>());
        }

        /// <summary>
        /// Get all Products
        /// </summary>
        /// <returns></returns>
        public OperationResult<IEnumerable<ProductDTO>> GetAllProducts()
        {
            IEnumerable<Product> productList = productRepository.Get(x => x.IsActive).ToList<Product>();
            List<ProductDTO> prodcutDTOList = new List<ProductDTO>();
            prodcutDTOList = mapper.Map<IEnumerable<Product>, List<ProductDTO>>(productList);
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<IEnumerable<ProductDTO>>(prodcutDTOList, true, message);
        }


        public OperationResult<IEnumerable<ProductDTO>> GetAllEvents()
        {
            IEnumerable<Product> productList = productRepository.GetAllEvents();
            List<ProductDTO> prodcutDTOList = new List<ProductDTO>();
            prodcutDTOList = mapper.Map<IEnumerable<Product>, List<ProductDTO>>(productList);
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<IEnumerable<ProductDTO>>(prodcutDTOList, true, message);
        }
        public OperationResult<IEnumerable<ProductDTO>> AllEvents()
        {
            IEnumerable<Product> productList = productRepository.AllEvents();
            List<ProductDTO> prodcutDTOList = new List<ProductDTO>();
            prodcutDTOList = mapper.Map<IEnumerable<Product>, List<ProductDTO>>(productList);
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<IEnumerable<ProductDTO>>(prodcutDTOList, true, message);
        }
        public OperationResult<IEnumerable<ProductDTO>> MyEvents(string UserId)
        {
            IEnumerable<Product> productList = productRepository.MyEvents(UserId);
            List<ProductDTO> prodcutDTOList = new List<ProductDTO>();
            prodcutDTOList = mapper.Map<IEnumerable<Product>, List<ProductDTO>>(productList);
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<IEnumerable<ProductDTO>>(prodcutDTOList, true, message);
        }

        public OperationResult<ProductDTO> GetEventByEventId(int Id)
        {
            Product product = productRepository.GetEventByEventId(Id);
            ProductDTO productDTO = new ProductDTO();
            productDTO = mapper.Map<Product,ProductDTO> (product);
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<ProductDTO>(productDTO, true, message);
        }
        public OperationResult<IEnumerable<ProductDTO>> EventsInvitedTo(string UserId)
        {
            IEnumerable<Product> productList = productRepository.EventsInvitedTo(UserId);
            List<ProductDTO> prodcutDTOList = new List<ProductDTO>();
            prodcutDTOList = mapper.Map<IEnumerable<Product>, List<ProductDTO>>(productList);
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<IEnumerable<ProductDTO>>(prodcutDTOList, true, message);
        }

        public OperationResult<ProductDTO> Update(ProductDTO item)
        {
            Product product = mapper.Map<ProductDTO, Product>(item);
            productRepository.Update(product);
            //product.IsActive = true;
            //product.CreatedOnDate = DateTimeOffset.Now;
            OperationResult result;
            result = new OperationResult(true,new Message("",""));
            

            //6. Prepare the response
            return new OperationResult<ProductDTO>(item, result.IsSuccess, result.MainMessage, result.AssociatedMessages.ToList<Message>());
        }


        public void Delete(int Id)
        {
            Product product = productRepository.GetEventByEventId(Id);
            productRepository.Delete(product.Id);
        }
    }
}
