using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductOrder.Entities;
using ProductOrder.Services.Interfaces;

namespace ProductOrder.Controllers
{
    [ApiController]
    public class StorageOrderController : BaseController<StorageOrderEntity, IStorageOrderService>
    {
        public StorageOrderController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}
