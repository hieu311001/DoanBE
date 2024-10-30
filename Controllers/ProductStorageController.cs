using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductOrder.Entities;
using ProductOrder.Services.Interfaces;

namespace ProductOrder.Controllers
{
    [ApiController]
    public class ProductStorageController : BaseController<ProductStorageEntity, IProductStorageService>
    {
        public ProductStorageController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}
