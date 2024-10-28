namespace ProductOrder.Parameters
{
    public class ModelParameter<T> 
        where T : class
    {
        public T Model;
        public List<string> Columns;
    }
}
