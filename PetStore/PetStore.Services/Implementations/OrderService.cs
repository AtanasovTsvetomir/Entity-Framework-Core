﻿namespace PetStore.Services.Implementations
{
    using PetStore.Data;
    using PetStore.Models;

    public class OrderService : IOrderService
    {
        private readonly PetStoreDbContext data;

        public OrderService(PetStoreDbContext data)
        {
            this.data = data;
        }

        public void CompleteOrder(int orderId)
        {
            var order = this.data
                .Orders
                .Find(orderId);

            order.Status = OrderStatus.Done;

            this.data.SaveChanges();
        }
    }
}
