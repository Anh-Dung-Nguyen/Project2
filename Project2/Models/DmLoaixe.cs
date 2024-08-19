using System;
using System.Collections.Generic;

namespace Project2.Models;

public partial class DmLoaixe
{
    public int PrKey { get; set; }

    public int FrKey { get; set; }

    public string LoaiXe { get; set; } = null!;

    public DateTime? NgayCapnhat { get; set; }

    public string MaUser { get; set; } = null!;
}
