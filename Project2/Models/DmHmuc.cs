using System;
using System.Collections.Generic;

namespace Project2.Models;

public partial class DmHmuc
{
    public string MaHmuc { get; set; } = null!;

    public string MaTongthanhxe { get; set; } = null!;

    public string MaNhmuc { get; set; } = null!;

    public string TenHmuc { get; set; } = null!;

    public int SuDung { get; set; }

    public DateTime? NgayCapnhat { get; set; }

    public string MaUser { get; set; } = null!;
}
