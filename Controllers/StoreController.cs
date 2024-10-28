using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductOrder.Entities;
using ProductOrder.Services.Interfaces;

namespace ProductOrder.Controllers
{
    [ApiController]
    public class StoreController : BaseController<StoreEntity, IStoreService>
    {
        public StoreController(IStoreService service) : base(service)
        {
        }
    }
}
