﻿using System;
using System.Collections.Generic;

namespace carpurchasing_DAL.Models;

public partial class MstCustomer
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string? Gender { get; set; }

    public string? Occupancy { get; set; }

    public decimal? Salary { get; set; }

    public DateTime? DtAdded { get; set; }

    public DateTime? DtUpdated { get; set; }

    public Guid? IdUserAdded { get; set; }

    public Guid? IdUserUpdated { get; set; }

    public virtual ICollection<TrnCarPurchase> TrnCarPurchases { get; set; } = new List<TrnCarPurchase>();
}
