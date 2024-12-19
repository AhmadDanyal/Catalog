using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

public class InMemItemsRepository : IItemsRepository
{
    public readonly List<Item> items = new()
    {
        new Item {Id = Guid.NewGuid(), Name = "Potion", Price = 9, CreatedDate = DateTimeOffset.UtcNow},
        new Item {Id = Guid.NewGuid(), Name = "Sword", Price = 20, CreatedDate = DateTimeOffset.UtcNow},
        new Item {Id = Guid.NewGuid(), Name = "Bronze Shield", Price = 18, CreatedDate = DateTimeOffset.UtcNow}
    };

    public async Task<IEnumerable<Item>> GetItemsAsync()
    {
        return await Task.FromResult(items);
    }

    public async Task<Item> GetItemAsync(Guid Id)
    {
        var item = items.Where(x => x.Id == Id).SingleOrDefault();
        return await Task.FromResult(item);
    }

    public async Task CreateItemAsync(Item item)
    {
        items.Add(item);
        await Task.CompletedTask;
    }

    public async Task UpdateItemAsync(Item item)
    {
        var index = items.FindIndex(expectedItem => expectedItem.Id == item.Id);
        items[index] = item;
        await Task.CompletedTask;
    }

    public async Task DeleteItemAsync(Guid id)
    {
        var index = items.FindIndex(item => item.Id == id);
        items.Remove(items[index]);
        await Task.CompletedTask;
    }
}