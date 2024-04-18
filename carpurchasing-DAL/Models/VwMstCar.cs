using System;
using System.Collections.Generic;

namespace carpurchasing_DAL.Models;

public partial class VwMstCar
{
    public Guid Id { get; set; }

    public int? EngineSize { get; set; }

    public string? FuelType { get; set; }

    public int? ManufactureYear { get; set; }

    public string? ChassisCode { get; set; }

    public string? EngineCode { get; set; }

    public string? Brand { get; set; }

    public string? Type { get; set; }

    public string? Usage { get; set; }

    public string? Model { get; set; }
}
