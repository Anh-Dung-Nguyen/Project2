using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Project2.Models;

namespace Project2.Data;

public partial class GdttContext : DbContext
{
    public GdttContext()
    {
    }

    public GdttContext(DbContextOptions<GdttContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DmGaRa> DmGaRas { get; set; }

    public virtual DbSet<DmHieuxe> DmHieuxes { get; set; }

    public virtual DbSet<DmHmuc> DmHmucs { get; set; }

    public virtual DbSet<DmLoaixe> DmLoaixes { get; set; }

    public virtual DbSet<HsgdCtu> HsgdCtus { get; set; }

    public virtual DbSet<HsgdDx> HsgdDxes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DmGaRa>(entity =>
        {
            entity.HasKey(e => e.MaGara);
            entity.ToTable("dm_ga_ra");

            entity.Property(e => e.DiaChi)
                .HasMaxLength(200)
                .HasColumnName("dia_chi");
            entity.Property(e => e.DiaChiXuong)
                .HasMaxLength(300)
                .HasDefaultValue("")
                .HasColumnName("dia_chi_xuong");
            entity.Property(e => e.DienThoaiGara)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("dien_thoai_gara");
            entity.Property(e => e.EmailGara)
                .HasMaxLength(100)
                .HasDefaultValue("")
                .HasColumnName("email_gara");
            entity.Property(e => e.GaraTthai).HasColumnName("gara_tthai");
            entity.Property(e => e.MaDonvi)
                .HasMaxLength(8)
                .HasColumnName("ma_donvi");
            entity.Property(e => e.MaGara)
                .HasMaxLength(11)
                .HasColumnName("ma_gara");
            entity.Property(e => e.MaUsercNhat)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("ma_userc_nhat");
            entity.Property(e => e.NgayCnhat)
                .HasColumnType("smalldatetime")
                .HasColumnName("ngay_cnhat");
            entity.Property(e => e.QuanHuyen)
                .HasMaxLength(100)
                .HasDefaultValue("")
                .HasColumnName("quan_huyen");
            entity.Property(e => e.TenGara)
                .HasMaxLength(150)
                .HasColumnName("ten_gara");
            entity.Property(e => e.TenTat)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("ten_tat");
            entity.Property(e => e.TenTinh)
                .HasMaxLength(100)
                .HasDefaultValue("")
                .HasColumnName("ten_tinh");
            entity.Property(e => e.TyleggPhutung)
                .HasDefaultValue(0.00m)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("tylegg_phutung");
            entity.Property(e => e.TyleggSuachua)
                .HasDefaultValue(0.00m)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("tylegg_suachua");
        });

        modelBuilder.Entity<DmHieuxe>(entity =>
        {
            entity.HasKey(e => e.PrKey).HasName("PK_dm_hangxe");

            entity.ToTable("dm_hieuxe");

            entity.Property(e => e.PrKey).HasColumnName("pr_key");
            entity.Property(e => e.HieuXe)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("hieu_xe");
        });

        modelBuilder.Entity<DmHmuc>(entity =>
        {
            entity.HasKey(e => e.MaHmuc).HasName("PK_hang_mucxe");

            entity.ToTable("dm_hmuc");

            entity.Property(e => e.MaHmuc)
                .HasMaxLength(30)
                .HasDefaultValue("")
                .HasColumnName("ma_hmuc");
            entity.Property(e => e.MaNhmuc)
                .HasMaxLength(30)
                .HasDefaultValue("")
                .HasColumnName("ma_nhmuc");
            entity.Property(e => e.MaTongthanhxe)
                .HasMaxLength(10)
                .HasDefaultValue("")
                .HasColumnName("ma_tongthanhxe");
            entity.Property(e => e.MaUser)
                .HasMaxLength(100)
                .HasDefaultValue("")
                .HasColumnName("ma_user");
            entity.Property(e => e.NgayCapnhat)
                .HasColumnType("smalldatetime")
                .HasColumnName("ngay_capnhat");
            entity.Property(e => e.SuDung)
                .HasDefaultValue(1)
                .HasColumnName("su_dung");
            entity.Property(e => e.TenHmuc)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("ten_hmuc");
        });

        modelBuilder.Entity<DmLoaixe>(entity =>
        {
            entity.HasKey(e => e.PrKey);

            entity.ToTable("dm_loaixe");

            entity.Property(e => e.PrKey).HasColumnName("pr_key");
            entity.Property(e => e.FrKey).HasColumnName("fr_key");
            entity.Property(e => e.LoaiXe)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("loai_xe");
            entity.Property(e => e.MaUser)
                .HasMaxLength(100)
                .HasDefaultValue("")
                .HasColumnName("ma_user");
            entity.Property(e => e.NgayCapnhat)
                .HasColumnType("smalldatetime")
                .HasColumnName("ngay_capnhat");
        });

        modelBuilder.Entity<HsgdCtu>(entity =>
        {
            entity.HasKey(e => e.PrKey);

            entity.ToTable("hsgd_ctu", tb =>
                {
                    tb.HasTrigger("Update_so_hsgd");
                    tb.HasTrigger("update_nhatky_danggd");
                });

            entity.HasIndex(e => e.SoDonbh, "Index_hsgd_ctu_so_donbh");

            entity.HasIndex(e => e.SoSeri, "Index_hsgd_ctu_so_seri");

            entity.HasIndex(e => e.SoHsgd, "hsgd_ct_so_hsgdIND");

            entity.HasIndex(e => e.PrKeyBt, "hsgd_ctu_pr_key_bt_IND");

            entity.Property(e => e.PrKey).HasColumnName("pr_key");
            entity.Property(e => e.BaoLanh).HasColumnName("bao_lanh");
            entity.Property(e => e.BienKsoat)
                .HasMaxLength(250)
                .HasDefaultValue("")
                .HasColumnName("bien_ksoat");
            entity.Property(e => e.Bl1)
                .HasDefaultValue(1)
                .HasColumnName("bl_1");
            entity.Property(e => e.Bl2)
                .HasDefaultValue(1)
                .HasColumnName("bl_2");
            entity.Property(e => e.Bl3)
                .HasDefaultValue(1)
                .HasColumnName("bl_3");
            entity.Property(e => e.Bl4)
                .HasDefaultValue(1)
                .HasColumnName("bl_4");
            entity.Property(e => e.Bl5)
                .HasDefaultValue(1)
                .HasColumnName("bl_5");
            entity.Property(e => e.Bl6).HasColumnName("bl_6");
            entity.Property(e => e.Bl7).HasColumnName("bl_7");
            entity.Property(e => e.Bl8).HasColumnName("bl_8");
            entity.Property(e => e.Bl9)
                .HasDefaultValue(1)
                .HasColumnName("bl_9");
            entity.Property(e => e.BlDsemail)
                .HasMaxLength(200)
                .HasDefaultValue("")
                .HasColumnName("bl_dsemail");
            entity.Property(e => e.BlDsphone)
                .HasMaxLength(200)
                .HasDefaultValue("")
                .HasColumnName("bl_dsphone");
            entity.Property(e => e.BlPdbl).HasColumnName("bl_pdbl");
            entity.Property(e => e.BlSendEmail).HasColumnName("bl_send_email");
            entity.Property(e => e.BlTailieubs)
                .HasMaxLength(300)
                .HasDefaultValue("")
                .HasColumnName("bl_tailieubs");
            entity.Property(e => e.ChuaThuphi).HasColumnName("chua_thuphi");
            entity.Property(e => e.DangKiem).HasColumnName("dang_kiem");
            entity.Property(e => e.DexuatPan)
                .HasDefaultValue("")
                .HasColumnType("ntext")
                .HasColumnName("dexuat_pan");
            entity.Property(e => e.DiaChi)
                .HasMaxLength(250)
                .HasDefaultValue("")
                .HasColumnName("dia_chi");
            entity.Property(e => e.DiaDiemgd)
                .HasMaxLength(500)
                .HasDefaultValue("")
                .HasColumnName("dia_diemgd");
            entity.Property(e => e.DiaDiemtt)
                .HasMaxLength(500)
                .HasDefaultValue("")
                .HasColumnName("dia_diemtt");
            entity.Property(e => e.DienThoai)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("dien_thoai");
            entity.Property(e => e.DienThoaiNdbh)
                .HasMaxLength(50)
                .HasColumnName("dien_thoai_ndbh");
            entity.Property(e => e.DoituongttTnds)
                .HasMaxLength(300)
                .HasDefaultValue("")
                .HasColumnName("doituongtt_tnds");
            entity.Property(e => e.DoituongttTsk)
                .HasMaxLength(300)
                .HasDefaultValue("")
                .HasColumnName("doituongtt_tsk");
            entity.Property(e => e.DonviSuachuaTsk)
                .HasMaxLength(300)
                .HasDefaultValue("")
                .HasColumnName("donvi_suachua_tsk");
            entity.Property(e => e.DvnhapPasc).HasColumnName("dvnhap_pasc");
            entity.Property(e => e.GhiChu)
                .HasMaxLength(2000)
                .HasColumnName("ghi_chu");
            entity.Property(e => e.GhiChudx)
                .HasMaxLength(2000)
                .HasDefaultValue("")
                .HasColumnName("ghi_chudx");
            entity.Property(e => e.GhiChudxTnds)
                .HasMaxLength(300)
                .HasDefaultValue("")
                .HasColumnName("ghi_chudx_tnds");
            entity.Property(e => e.GhiChudxTndstt)
                .HasMaxLength(2000)
                .HasColumnName("ghi_chudx_tndstt");
            entity.Property(e => e.GhiChudxTsk)
                .HasMaxLength(300)
                .HasDefaultValue("")
                .HasColumnName("ghi_chudx_tsk");
            entity.Property(e => e.GhiChudxTsktt)
                .HasMaxLength(2000)
                .HasColumnName("ghi_chudx_tsktt");
            entity.Property(e => e.GhiChudxtt)
                .HasMaxLength(2000)
                .HasDefaultValue("")
                .HasColumnName("ghi_chudxtt");
            entity.Property(e => e.HieuXe).HasColumnName("hieu_xe");
            entity.Property(e => e.HieuXeTnds).HasColumnName("hieu_xe_tnds");
            entity.Property(e => e.HieuXeTndsBen3)
                .HasDefaultValue(0)
                .HasColumnName("hieu_xe_tnds_ben3");
            entity.Property(e => e.HosoPhaply)
                .HasDefaultValue("")
                .HasColumnType("ntext")
                .HasColumnName("hoso_phaply");
            entity.Property(e => e.HsgdTpc).HasColumnName("hsgd_tpc");
            entity.Property(e => e.InsertMobile)
                .HasMaxLength(2)
                .HasDefaultValueSql("((0))")
                .HasColumnName("insert_mobile");
            entity.Property(e => e.LoaiXe).HasColumnName("loai_xe");
            entity.Property(e => e.LoaiXeTnds).HasColumnName("loai_xe_tnds");
            entity.Property(e => e.LoaiXeTndsBen3)
                .HasDefaultValue(0)
                .HasColumnName("loai_xe_tnds_ben3");
            entity.Property(e => e.LydoCtkh)
                .HasMaxLength(250)
                .HasDefaultValue("")
                .HasColumnName("lydo_ctkh");
            entity.Property(e => e.LydoCtkhTnds)
                .HasMaxLength(300)
                .HasDefaultValue("")
                .HasColumnName("lydo_ctkh_tnds");
            entity.Property(e => e.LydoCtkhTsk)
                .HasMaxLength(300)
                .HasDefaultValue("")
                .HasColumnName("lydo_ctkh_tsk");
            entity.Property(e => e.MaCbkt)
                .HasMaxLength(11)
                .HasDefaultValue("")
                .HasColumnName("ma_cbkt");
            entity.Property(e => e.MaCtu)
                .HasMaxLength(11)
                .HasColumnName("ma_ctu");
            entity.Property(e => e.MaDaily)
                .HasMaxLength(11)
                .HasDefaultValue("")
                .HasColumnName("ma_daily");
            entity.Property(e => e.MaDdiemTthat)
                .HasMaxLength(8)
                .HasDefaultValue("")
                .HasColumnName("ma_ddiem_tthat");
            entity.Property(e => e.MaDonbh)
                .HasMaxLength(8)
                .HasDefaultValue("")
                .HasColumnName("ma_donbh");
            entity.Property(e => e.MaDonvi)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("ma_donvi");
            entity.Property(e => e.MaDonviTt)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("ma_donvi_tt");
            entity.Property(e => e.MaDonvigd)
                .HasMaxLength(10)
                .HasDefaultValue("")
                .HasColumnName("ma_donvigd");
            entity.Property(e => e.MaDvbtHo)
                .HasMaxLength(11)
                .HasDefaultValue("")
                .HasColumnName("ma_dvbt_ho");
            entity.Property(e => e.MaDviBtHo)
                .HasMaxLength(11)
                .HasColumnName("ma_dvi_bt_ho");
            entity.Property(e => e.MaGaraTnds)
                .HasMaxLength(50)
                .HasColumnName("ma_gara_tnds");
            entity.Property(e => e.MaGaraTnds01)
                .HasMaxLength(300)
                .HasColumnName("ma_gara_tnds01");
            entity.Property(e => e.MaGaraTnds02)
                .HasMaxLength(300)
                .HasColumnName("ma_gara_tnds02");
            entity.Property(e => e.MaGaraVcx)
                .HasMaxLength(50)
                .HasColumnName("ma_gara_vcx");
            entity.Property(e => e.MaGaraVcx01)
                .HasMaxLength(300)
                .HasColumnName("ma_gara_vcx01");
            entity.Property(e => e.MaGaraVcx02)
                .HasMaxLength(300)
                .HasColumnName("ma_gara_vcx02");
            entity.Property(e => e.MaKh)
                .HasMaxLength(11)
                .HasDefaultValue("")
                .HasColumnName("ma_kh");
            entity.Property(e => e.MaKthac)
                .HasMaxLength(8)
                .HasDefaultValue("")
                .HasColumnName("ma_kthac");
            entity.Property(e => e.MaLhsbt)
                .HasMaxLength(8)
                .HasDefaultValue("")
                .HasColumnName("ma_lhsbt");
            entity.Property(e => e.MaLoaibang)
                .HasMaxLength(2)
                .HasDefaultValue("")
                .HasColumnName("ma_loaibang");
            entity.Property(e => e.MaNguyenNhanTtat)
                .HasMaxLength(10)
                .HasColumnName("ma_nguyen_nhan_ttat");
            entity.Property(e => e.MaNhloaixe)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("ma_nhloaixe");
            entity.Property(e => e.MaPkt)
                .HasMaxLength(11)
                .HasDefaultValue("")
                .HasColumnName("ma_pkt");
            entity.Property(e => e.MaSanpham)
                .HasMaxLength(150)
                .HasDefaultValue("")
                .HasColumnName("ma_sanpham");
            entity.Property(e => e.MaTte)
                .HasMaxLength(3)
                .HasDefaultValue("")
                .HasColumnName("ma_tte");
            entity.Property(e => e.MaTtrangGd)
                .HasMaxLength(8)
                .HasDefaultValue("")
                .HasColumnName("ma_ttrang_gd");
            entity.Property(e => e.MaUser).HasColumnName("ma_user");
            entity.Property(e => e.NamSinh).HasColumnName("nam_sinh");
            entity.Property(e => e.NamSx).HasColumnName("nam_sx");
            entity.Property(e => e.NamSxTnds).HasColumnName("nam_sx_tnds");
            entity.Property(e => e.NgGdichTh)
                .HasMaxLength(500)
                .HasDefaultValue("")
                .HasColumnName("ng_gdich_th");
            entity.Property(e => e.NgLienhe)
                .HasMaxLength(200)
                .HasColumnName("ng_lienhe");
            entity.Property(e => e.NgayCtu)
                .HasColumnType("smalldatetime")
                .HasColumnName("ngay_ctu");
            entity.Property(e => e.NgayCuoiLaixe)
                .HasColumnType("smalldatetime")
                .HasColumnName("ngay_cuoi_laixe");
            entity.Property(e => e.NgayCuoiLuuhanh)
                .HasColumnType("smalldatetime")
                .HasColumnName("ngay_cuoi_luuhanh");
            entity.Property(e => e.NgayCuoiSeri)
                .HasColumnType("smalldatetime")
                .HasColumnName("ngay_cuoi_seri");
            entity.Property(e => e.NgayDauLaixe)
                .HasColumnType("smalldatetime")
                .HasColumnName("ngay_dau_laixe");
            entity.Property(e => e.NgayDauLuuhanh)
                .HasColumnType("smalldatetime")
                .HasColumnName("ngay_dau_luuhanh");
            entity.Property(e => e.NgayDauSeri)
                .HasColumnType("smalldatetime")
                .HasColumnName("ngay_dau_seri");
            entity.Property(e => e.NgayDuyet)
                .HasColumnType("smalldatetime")
                .HasColumnName("ngay_duyet");
            entity.Property(e => e.NgayGdinh)
                .HasColumnType("smalldatetime")
                .HasColumnName("ngay_gdinh");
            entity.Property(e => e.NgayTbao)
                .HasColumnType("smalldatetime")
                .HasColumnName("ngay_tbao");
            entity.Property(e => e.NgayTthat)
                .HasColumnType("smalldatetime")
                .HasColumnName("ngay_tthat");
            entity.Property(e => e.NguoiGiao)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("nguoi_giao");
            entity.Property(e => e.NguoiXuly)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("nguoi_xuly");
            entity.Property(e => e.NguyenNhanTtat)
                .HasMaxLength(500)
                .HasDefaultValue("")
                .HasColumnName("nguyen_nhan_ttat");
            entity.Property(e => e.PascDsemail)
                .HasMaxLength(200)
                .HasDefaultValue("")
                .HasColumnName("pasc_dsemail");
            entity.Property(e => e.PascDsphone)
                .HasMaxLength(200)
                .HasDefaultValue("")
                .HasColumnName("pasc_dsphone");
            entity.Property(e => e.PascSendEmail).HasColumnName("pasc_send_email");
            entity.Property(e => e.PascVatTnds).HasColumnName("pasc_vat_tnds");
            entity.Property(e => e.PascVatVcx).HasColumnName("pasc_vat_vcx");
            entity.Property(e => e.PathCrm)
                .HasMaxLength(200)
                .HasColumnName("path_crm");
            entity.Property(e => e.PathTndsDt)
                .HasMaxLength(200)
                .HasDefaultValue("")
                .HasColumnName("path_tnds_dt");
            entity.Property(e => e.PathTndsKhacDt)
                .HasMaxLength(200)
                .HasDefaultValue("")
                .HasColumnName("path_tnds_khac_dt");
            entity.Property(e => e.PathVcxDt)
                .HasMaxLength(200)
                .HasDefaultValue("")
                .HasColumnName("path_vcx_dt");
            entity.Property(e => e.PrKeyBt)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("pr_key_bt");
            entity.Property(e => e.PrKeyBtHo)
                .HasMaxLength(11)
                .HasDefaultValueSql("((0))")
                .HasColumnName("pr_key_bt_ho");
            entity.Property(e => e.PrKeyGoc)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("pr_key_goc");
            entity.Property(e => e.PrKeyKbtt).HasColumnName("pr_key_kbtt");
            entity.Property(e => e.PrKeySeri)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("pr_key_seri");
            entity.Property(e => e.SaiDkdk).HasColumnName("sai_dkdk");
            entity.Property(e => e.SaiPhancap).HasColumnName("sai_phancap");
            entity.Property(e => e.SaiphamKhac).HasColumnName("saipham_khac");
            entity.Property(e => e.SoDonbh)
                .HasMaxLength(23)
                .HasDefaultValue("")
                .HasColumnName("so_donbh");
            entity.Property(e => e.SoGphepLaixe)
                .HasMaxLength(20)
                .HasDefaultValue("")
                .HasColumnName("so_gphep_laixe");
            entity.Property(e => e.SoGphepLuuhanh)
                .HasMaxLength(20)
                .HasDefaultValue("")
                .HasColumnName("so_gphep_luuhanh");
            entity.Property(e => e.SoHsgd)
                .HasMaxLength(12)
                .HasDefaultValue("")
                .HasColumnName("so_hsgd");
            entity.Property(e => e.SoLanBt)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("so_lan_bt");
            entity.Property(e => e.SoSeri)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("so_seri");
            entity.Property(e => e.SoTienGtbt).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.SoTienGtbtKhac).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.SoTienGtbtTnds)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("SoTienGtbtTNDS");
            entity.Property(e => e.SoTienThucTe)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("so_tien_thuc_te");
            entity.Property(e => e.SoTienctkh)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("so_tienctkh");
            entity.Property(e => e.SoTienctkhTnds)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("so_tienctkh_tnds");
            entity.Property(e => e.SoTienctkhTsk)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("so_tienctkh_tsk");
            entity.Property(e => e.SoTienugd)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("so_tienugd");
            entity.Property(e => e.TenKhach)
                .HasMaxLength(150)
                .HasDefaultValue("")
                .HasColumnName("ten_khach");
            entity.Property(e => e.TenLaixe)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("ten_laixe");
            entity.Property(e => e.ThieuAnh).HasColumnName("thieu_anh");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(8)
                .HasDefaultValue("")
                .HasColumnName("trang_thai");
            entity.Property(e => e.TrucloiBh).HasColumnName("trucloi_bh");
            entity.Property(e => e.TygiaHt)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("tygia_ht");
            entity.Property(e => e.TygiaTt)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("tygia_tt");
            entity.Property(e => e.TyleggPhutungtnds)
                .HasDefaultValue(0.00m)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("tylegg_phutungtnds");
            entity.Property(e => e.TyleggPhutungvcx)
                .HasDefaultValue(0.00m)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("tylegg_phutungvcx");
            entity.Property(e => e.TyleggSuachuatnds)
                .HasDefaultValue(0.00m)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("tylegg_suachuatnds");
            entity.Property(e => e.TyleggSuachuavcx)
                .HasDefaultValue(0.00m)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("tylegg_suachuavcx");
            entity.Property(e => e.Vat)
                .HasDefaultValue(1)
                .HasColumnName("vat");
            entity.Property(e => e.VatTnds)
                .HasDefaultValue(1)
                .HasColumnName("vat_tnds");
            entity.Property(e => e.VatTsk)
                .HasDefaultValue(1)
                .HasColumnName("vat_tsk");
            entity.Property(e => e.XuatXu)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("xuat_xu");
            entity.Property(e => e.XuatXuTnds)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("xuat_xu_tnds");
            entity.Property(e => e.YkienGdinh)
                .HasDefaultValue("")
                .HasColumnType("ntext")
                .HasColumnName("ykien_gdinh");
        });

        modelBuilder.Entity<HsgdDx>(entity =>
        {
            entity.HasKey(e => e.PrKey);

            entity.ToTable("hsgd_dx");

            entity.HasIndex(e => e.FrKey, "hsgd_dxFRKEYIND");

            entity.Property(e => e.PrKey).HasColumnName("pr_key");
            entity.Property(e => e.FrKey).HasColumnName("fr_key");
            entity.Property(e => e.GetDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("get_date");
            entity.Property(e => e.GhiChudv)
                .HasMaxLength(300)
                .HasDefaultValue("")
                .HasColumnName("ghi_chudv");
            entity.Property(e => e.GhiChutt)
                .HasMaxLength(300)
                .HasDefaultValue("")
                .HasColumnName("ghi_chutt");
            entity.Property(e => e.GiamTruBt).HasColumnName("giam_tru_bt");
            entity.Property(e => e.LoaiDx).HasColumnName("loai_dx");
            entity.Property(e => e.MaHmuc)
                .HasMaxLength(30)
                .HasDefaultValue("")
                .HasColumnName("ma_hmuc");
            entity.Property(e => e.NgayCapnhat)
                .HasColumnType("smalldatetime")
                .HasColumnName("ngay_capnhat");
            entity.Property(e => e.SoTienDoitru)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("so_tien_doitru");
            entity.Property(e => e.SoTienpdDoitru)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("so_tienpd_doitru");
            entity.Property(e => e.SoTienpdsc)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("so_tienpdsc");
            entity.Property(e => e.SoTienpdtt)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("so_tienpdtt");
            entity.Property(e => e.SoTienph)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("so_tienph");
            entity.Property(e => e.SoTienson)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("so_tienson");
            entity.Property(e => e.SoTientt)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("so_tientt");
            entity.Property(e => e.ThuHoiTs).HasColumnName("thu_hoi_ts");
            entity.Property(e => e.VatSc)
                .HasDefaultValue(10)
                .HasColumnName("vat_sc");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
