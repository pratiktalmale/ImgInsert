using System;
using System.Collections.Generic;

namespace ImgInsert.Models;

public partial class ProDuct
{
    public int ProductId { get; set; }

    public string? Productname { get; set; }

    public double? Rate { get; set; }

    public int? Stock { get; set; }

    public string? Images { get; set; }
}
