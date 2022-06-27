using Company.Project.Core.AppServices;
using Company.Project.Core.ValueObjects;
using Company.Project.ProductDomain.AppServices.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Project.ProductDomain.AppServices
{
    public interface IProductAppService : IAppService
    {
        OperationResult<ProductDTO> Create(ProductDTO item);
        OperationResult<IEnumerable<ProductDTO>> GetAllEvents();
        OperationResult<IEnumerable<ProductDTO>> AllEvents();
        OperationResult<IEnumerable<ProductDTO>> MyEvents(string UserId);
        OperationResult<ProductDTO> GetEventByEventId(int Id);
        OperationResult<IEnumerable<ProductDTO>> EventsInvitedTo(string InviteByEmail);
        OperationResult<ProductDTO> Update(ProductDTO item);
        void Delete(int Id);
        //OperationResult<IEnumerable<ProductDTO>> InsertProduct();

    }
}
