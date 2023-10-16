﻿using Microsoft.EntityFrameworkCore;

namespace offshore.data.models.settings;

public class Translation : OffshoreDataModel
{
    public virtual SupportedLanguage? Language { get; set; }
    public virtual Translatable? Translatable { get; set; }

    public string? Value { get; set; }

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Translation>(e =>
        {
            e.Property<uint>("Id");
            e.HasIndex("Id");
            e.Property(p => p.Value).IsRequired();
            e.HasOne(p => p.Language);
            e.HasOne(p => p.Translatable); 
        });
    }
}