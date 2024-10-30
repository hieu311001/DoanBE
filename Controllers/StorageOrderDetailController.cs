using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductOrder.Entities;
using ProductOrder.Services.Interfaces;

namespace ProductOrder.Controllers
{
    [ApiController]
    public class StorageOrderDetailController : BaseController<StorageOrderDetailEntity, IStorageOrderDetailService>
    {
        public StorageOrderDetailController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}
