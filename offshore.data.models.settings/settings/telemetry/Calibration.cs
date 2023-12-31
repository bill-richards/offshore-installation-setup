﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace offshore.data.models.settings;

public class Calibration : NamedOffshoreDataModel
{
    [Required] public User? CalibratedBy { get; set; }
    [Required] public uint DataPosition { get; set; }
    [Required] public DateTime Date { get; set; } = DateTime.Now;
    [Required] public uint Raw { get; set; }
    [Required] public uint Zero { get; set; }
    [Required] public double Value { get; set; }
    [Required] public double Data { get; set; }

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<Calibration>(modelBuilder);
        modelBuilder.Entity<Calibration>(e =>
        {
            e.HasOne(p => p.CalibratedBy);
        });
    }
}