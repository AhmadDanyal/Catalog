using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("items")]
public class ItemsController : ControllerBase
{
    public readonly IItemsRepository repository;
    public readonly ILogger<ItemsController> logger;

    public ItemsController(IItemsRepository repository, ILogger<ItemsController> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    [HttpGet]
    public async Task<IEnumerable<ItemDto>> GetItemsAsync()
    {
        var items = (await repository.GetItemsAsync()).Select(item => item.AsDto());

        logger.LogInformation($"{DateTime.UtcNow.ToString("hh:mm:ss")}: Retrieved {items.Count()} items");

        return items;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ItemDto>> GetItemAsync(Guid id)
    {
        var item = await repository.GetItemAsync(id);
        if (item is null)
        {
            return NotFound();
        }
        return item.AsDto();
    }

    [HttpPost]
    public async Task<ActionResult<ItemDto>> CreateItemAsync(CreateItemDto itemDto)
    {
        Item item = new()
        {
            Id = Guid.NewGuid(),
            Name = itemDto.Name,
            Description = itemDto.Description,
            Price = itemDto.Price,
            CreatedDate = DateTimeOffset.UtcNow
        };
        
        await repository.CreateItemAsync(item);
        return CreatedAtAction(nameof(GetItemAsync),new {Id = item.Id}, item.AsDto());
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateItemAsync(Guid id, UpdateItemDto itemDto)
    {
        var expectedItem = await repository.GetItemAsync(id);
        if (expectedItem is null)
        {
            return NotFound();
        }

        expectedItem.Name = itemDto.Name;
        expectedItem.Price = itemDto.Price;

        await repository.UpdateItemAsync(expectedItem);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteItemAsync(Guid id)
    {
        var item = await repository.GetItemAsync(id);
        if (item is null)
        {
            return NotFound();
        }
        await repository.DeleteItemAsync(item.Id);
        return NoContent();
    }
}