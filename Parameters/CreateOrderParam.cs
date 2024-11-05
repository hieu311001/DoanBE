using ProductOrder.Entities;

namespace ProductOrder.Parameters
{
    public class CreateOrderParam
    {
        public ProductOrderEntity productOrder {  get; set; }

        public List<ProductOrderDetailEntity> productOrderDetails { get; set; }
    }
}
