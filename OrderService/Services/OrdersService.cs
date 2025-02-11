using OrderService.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace OrderService.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IMongoCollection<Order> _orderCollection;

        public OrdersService(
         IOptions<OrderDatabaseSettings> orderDBSettings)
        {
            var mongoClient = new MongoClient(
                orderDBSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                orderDBSettings.Value.DatabaseName);

            _orderCollection = mongoDatabase.GetCollection<Order>(
                orderDBSettings.Value.BooksCollectionName);
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync() =>
            await _orderCollection.Find(_ => true).ToListAsync();

        public async Task<Order?> GetOrderByIdAsync(string id) =>
            await _orderCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task AddOrderAsync(Order order) =>
            await _orderCollection.InsertOneAsync(order);

        public async Task UpdateOrderAsync(string id, Order order) =>
            await _orderCollection.ReplaceOneAsync(x => x.Id == id, order);

        public async Task DeleteOrderAsync(string id) =>
            await _orderCollection.DeleteOneAsync(x => x.Id == id);

    }
}
