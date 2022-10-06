﻿using eGames.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eGames.Data.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly AppDbContext _context;

        public OrdersService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole)
        {
            // get all orders across the app
            var orders = await _context.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Game).Include(n => n.User).ToListAsync();

            // check for roles

            if (userRole != "Admin")
            {
                orders = orders.Where(n => n.UserId == userId).ToList();
            }

            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAddress,
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            // then store all the shopping cart items to the database

            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                   GameId = item.Game.Id,
                    OrderId = order.Id,
                    Price = item.Game.Price
                };
                await _context.OrderItems.AddAsync(orderItem);

            }
            await _context.SaveChangesAsync();
        }
    }
}
