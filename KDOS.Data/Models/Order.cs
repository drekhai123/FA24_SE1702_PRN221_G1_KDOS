﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace KDOS.Data.Models;

public partial class Order
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int? PriceId { get; set; }

    public DateOnly OrderDate { get; set; }

    public string OriginalLocation { get; set; }

    public string Destination { get; set; }

    public string ShippingMethod { get; set; }

    public decimal? TotalCost { get; set; }

    public string Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Customer Customer { get; set; }

    public virtual ICollection<CustomsDeclaration> CustomsDeclarations { get; set; } = new List<CustomsDeclaration>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Packing> Packings { get; set; } = new List<Packing>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual PriceList Price { get; set; }

    public virtual ICollection<Transport> Transports { get; set; } = new List<Transport>();
}