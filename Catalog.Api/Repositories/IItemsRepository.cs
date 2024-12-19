using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IItemsRepository
{
    Task<IEnumerable<Item>> GetItemsAsync();
    Task<Item> GetItemAsync(Guid Id);
    Task CreateItemAsync(Item item);
    Task UpdateItemAsync(Item item);
    Task DeleteItemAsync(Guid id);
}