namespace Project2.Models
{
    public class Table1
    {
        public string SoHsgd { get; set; }
        public string XuatXu { get; set; }
        public int NamSx { get; set; }
        public decimal Vat { get; set; }
        public decimal? TyleggPhutungvcx { get; set; }
        public decimal? TyleggSuachuavcx { get; set; }
        public decimal PascVatVcx { get; set; }
        public decimal SoTienctkh { get; set; }
        public string LydoCtkh { get; set; }
        public string HieuXe { get; set; }
        public string LoaiXe { get; set; }
        public string TenGaraVcx { get; set; }
        public string TenGaraVcx01 { get; set; }
        public string TenGaraVcx02 { get; set; }
        public decimal Tong_tt { get; set; }
        public decimal Tong_ph { get; set; }
        public decimal Tong_son { get; set; }
        public decimal CO_VAT { get; set; }
        public decimal GIAM_TRU_BT { get; set; }
        public int SO_DE_XUAT { get; set; }
        public decimal KHONG_VAT { get; set; }
        public decimal TOTAL_VAT { get; set; }
        public decimal KHAU_TRU { get; set; }
        public decimal? DOI_TRU { get; set; }
        public decimal GIAM_GIA { get; set; }
        public decimal? PVI_BAO_LANH { get; set; }
    }

    public class Table2
    {
        public string TenHmuc { get; set; }
        public string GhiChutt { get; set; }
        public string GhiChudv { get; set; }
        public decimal SoTientt { get; set; }
        public decimal SoTienph { get; set; }
        public decimal SoTienson { get; set; }
        public decimal VatSc { get; set; }
        public decimal GiamTruBt { get; set; }
        public bool ThuHoiTs { get; set; }
        public decimal? SoTienDoitru { get; set; }
    }
}
