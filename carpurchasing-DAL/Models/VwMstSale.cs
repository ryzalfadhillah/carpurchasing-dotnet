using System;
using System.Collections.Generic;

namespace carpurchasing_DAL.Models;

public partial class VwMstSale
{
    public string? Name { get; set; }

    public int? JumlahPenjualan { get; set; }

    public decimal? Komisi { get; set; }

    public string? Username { get; set; }

    public string? Status { get; set; }
}
