﻿using CodePulse.Domain.Entities.Base;

namespace CodePulse.Domain.Entities;

public class BlogPost : BaseEntity
{
    public string Title { get; set; }
    public string ShortDescription { get; set; }
    public string Content { get; set; }
    public string FeatureImageUrl { get; set; }
    public string UrlHandle { get; set; }
    public bool IsVisible { get; set; }
    public string Author  { get; set; }
    
}