using ProductOrder.Entities;

namespace ProductOrder.Parameters
{
    public class CreateStoreOrderParam
    {
        public StorageOrderEntity storeOrder { get; set; }

        public List<StorageOrderDetailEntity> storeOrderDetails { get; set; }
    }
}
