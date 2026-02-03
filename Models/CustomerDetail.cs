using System;
using System.Collections.Generic;

namespace ImgInsert.Models;

public partial class CustomerDetail
{
    public int Id { get; set; }

    public string? CustomerName { get; set; }

    public string? Email { get; set; }

    public string? Mobile { get; set; }

    public string? City { get; set; }
}
