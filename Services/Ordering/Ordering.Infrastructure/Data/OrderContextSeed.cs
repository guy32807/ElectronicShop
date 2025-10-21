using Microsoft.Extensions.Logging;
using Ordering.Core.Entities;

namespace Ordering.Infrastructure.Data
{
    public abstract class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("Seeded database with initial orders.");
            }
        }

        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>() {
                new Order() {
                    UserName = "johndoe",
                    FirstName = "John",
                    LastName = "Doe",
                    EmailAddress = "jdoe@ecommerce.net",
                    Country = "United States",
                    City = "Orlando",
                    State = "Florida",
                    ZipCode = "32839",

                    CardName = "Visa",
                    CardNumber = "4484323529842523",
                    CreatedBy = "Auguste",
                    Expiration = "10/30",
                    CVV = "432",
                    PaymentMethod = 1,
                    LastModifiedBy = "Auguste",
                    LastModifiedDate = DateTime.Now
                }
            };
        }
    }
}
