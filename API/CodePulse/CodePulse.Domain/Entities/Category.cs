using CodePulse.Domain.Entities.Base;

namespace CodePulse.Domain.Entities;

public class Category: BaseEntity
{
    public string Name { get; set; }
    
    public string UrlHandle { get; set; }
}