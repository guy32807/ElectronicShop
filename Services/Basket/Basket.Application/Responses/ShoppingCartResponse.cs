namespace Basket.Application.Responses
{
    public class ShoppingCartResponse
    {
        public string Username { get; set; }
        public List<ShoppingCartItemResponse> Items { get; set; }
        private decimal _totalPrice;


        public ShoppingCartResponse(string username)
        {
            Username = username;
        }

        public decimal TotalPrice
        {
            get
            {
                foreach (var item in Items)
                {
                    _totalPrice += item.Price * item.Quantity;
                }
                return _totalPrice;
            }
        }


    }
}
