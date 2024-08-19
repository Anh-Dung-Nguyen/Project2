using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project2.Models;

public partial class DmGaRa
{
    [Key]
    public string MaGara { get; set; } = null!;

    public string TenGara { get; set; } = null!;

    public string TenTat { get; set; } = null!;

    public string MaDonvi { get; set; } = null!;

    public string DiaChi { get; set; } = null!;

    public string DiaChiXuong { get; set; } = null!;

    public bool GaraTthai { get; set; }

    public string TenTinh { get; set; } = null!;

    public string QuanHuyen { get; set; } = null!;

    public decimal? TyleggPhutung { get; set; }

    public decimal? TyleggSuachua { get; set; }

    public DateTime? NgayCnhat { get; set; }

    public string MaUsercNhat { get; set; } = null!;

    public string EmailGara { get; set; } = null!;

    public string DienThoaiGara { get; set; } = null!;
}
