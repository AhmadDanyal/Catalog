using System;
using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

public class Item
{
    public Guid Id {get;set;}
    public string Name {get;set;}
    public string Description {get;set;}
    public Decimal Price {get;set;}
    public DateTimeOffset CreatedDate {get;set;}
}