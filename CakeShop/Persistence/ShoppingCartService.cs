﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FavoursShop.Core.Models;

namespace FavoursShop.Persistence
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly FavourShopDbContext _context;

        public string Id { get; set; }
        public IEnumerable<ShoppingCartItem> ShoppingCartItems { get; set; }

        private ShoppingCartService(FavourShopDbContext context)
        {
            _context = context;
        }

        public static ShoppingCartService GetCart(IServiceProvider services)
        {
            var httpContext = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext;
            var context = services.GetRequiredService<FavourShopDbContext>();

            var request = httpContext.Request;
            var response = httpContext.Response;

            var cardId = request.Cookies["CartId-cookie"] ?? Guid.NewGuid().ToString();

            response.Cookies.Append("CartId-cookie", cardId, new CookieOptions
            {
                Expires = DateTime.Now.AddMonths(2)
            });

            return new ShoppingCartService(context)
            {
                Id = cardId
            };
        }

        public async Task<int> AddToCartAsync(Favour favour, int qty = 1)
        {
            return await AddOrRemoveCart(favour, qty);

        }

        public async Task<int> RemoveFromCartAsync(Favour favour)
        {
            return await AddOrRemoveCart(favour, -1);
        }

        public async Task<IEnumerable<ShoppingCartItem>> GetShoppingCartItemsAsync()
        {
            ShoppingCartItems = ShoppingCartItems ?? await _context.ShoppingCartItems
                .Where(e => e.ShoppingCartId == Id)
                .Include(e => e.Favour)
                .ToListAsync();

            return ShoppingCartItems;
        }

        public async Task ClearCartAsync()
        {
            var shoppingCartItems = _context
                .ShoppingCartItems
                .Where(s => s.ShoppingCartId == Id);

            _context.ShoppingCartItems.RemoveRange(shoppingCartItems);

            ShoppingCartItems = null; //reset
            await _context.SaveChangesAsync();
        }

        public async Task<(int ItemCount, decimal TotalAmmount)> GetCartCountAndTotalAmmountAsync()
        {
            var subTotal = ShoppingCartItems?
                .Select(c => c.Favour.Price * c.Qty) ??
                await _context.ShoppingCartItems
                .Where(c => c.ShoppingCartId == Id)
                .Select(c => c.Favour.Price * c.Qty)
                .ToListAsync();

            return (subTotal.Count(), subTotal.Sum());
        }

        private async Task<int> AddOrRemoveCart(Favour favour, int qty)
        {


            var shoppingCartItem = await _context.ShoppingCartItems
                            .SingleOrDefaultAsync(s => s.FavourId == favour.Id && s.ShoppingCartId == Id);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = Id,
                    Favour = favour,
                    Qty = 0
                };

                await _context.ShoppingCartItems.AddAsync(shoppingCartItem);
            }

            shoppingCartItem.Qty += qty;

            if (shoppingCartItem.Qty <= 0)
            {
                shoppingCartItem.Qty = 0;
                _context.ShoppingCartItems.Remove(shoppingCartItem);
            }

            await _context.SaveChangesAsync();

            ShoppingCartItems = null; // Reset

            return await Task.FromResult(shoppingCartItem.Qty);
        }

    }
}
