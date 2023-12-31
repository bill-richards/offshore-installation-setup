﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

public class MeasurementUnit : NamedOffshoreDataModel
{

    [Required]
    public string Label { get; set; } = "";
    [Required]
    public double Factor { get; set; }

    [NotMapped] public string MeasurementTypeRef { get; set; } = "";

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<MeasurementUnit>(modelBuilder);
        modelBuilder.Entity<MeasurementUnit>(e =>
        {
            //e.HasOne(e => e.MeasurementType);
        });
    }
}
