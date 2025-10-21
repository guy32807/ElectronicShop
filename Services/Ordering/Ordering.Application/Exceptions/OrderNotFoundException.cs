namespace Ordering.Application.Exceptions
{
    public class OrderNotFoundException : ApplicationException
    {
        public OrderNotFoundException(string name, int key)
            : base($"Order \"{name}\" with Id ({key}) was not found.")
        {
        }
    }
}
