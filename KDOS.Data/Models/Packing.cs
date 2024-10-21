﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace KDOS.Data.Models;

public partial class Packing
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int PackerId { get; set; }

    public DateOnly PackingDate { get; set; }

    public decimal? OxygenLevel { get; set; }

    public decimal? WaterTemperature { get; set; }

    public string PackingNotes { get; set; }

    public string Status { get; set; }

    public virtual Order Order { get; set; }

    public virtual Staff Packer { get; set; }
}