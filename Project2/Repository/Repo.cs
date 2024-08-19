﻿using Microsoft.EntityFrameworkCore;
using Project2.Data;
using Project2.Models;
using static Azure.Core.HttpHeader;

namespace Project2.Repository
{
    public class Repo
    {
        private readonly GdttContext _context;
        public Repo(GdttContext context)
        {
            _context = context;
        }
        public List3 GetDetails(string soHsgd)
        {
            var query = from HsgdCtu in _context.HsgdCtus
                        join DmHieuxe in _context.DmHieuxes on HsgdCtu.HieuXe equals DmHieuxe.PrKey
                        join DmLoaixe in _context.DmLoaixes on HsgdCtu.LoaiXe equals DmLoaixe.PrKey

                        join GaRaVcx in _context.DmGaRas on HsgdCtu.MaGaraVcx equals GaRaVcx.MaGara into gr1
                        from GaRaVcx in gr1.DefaultIfEmpty()
                        join GaRaVcx01 in _context.DmGaRas on HsgdCtu.MaGaraVcx01 equals GaRaVcx01.MaGara into gr2
                        from GaRaVcx01 in gr2.DefaultIfEmpty()
                        join GaRaVcx02 in _context.DmGaRas on HsgdCtu.MaGaraVcx01 equals GaRaVcx02.MaGara into gr3
                        from GaRaVcx02 in gr3.DefaultIfEmpty()

                        join HsgdDx in _context.HsgdDxes on HsgdCtu.PrKey equals HsgdDx.FrKey into gr4
                        from HsgdDx in gr4.DefaultIfEmpty()

                        join DmHmuc in _context.DmHmucs on HsgdDx.MaHmuc equals DmHmuc.MaHmuc into gr5
                        from DmHmuc in gr5.DefaultIfEmpty()

                        where HsgdCtu.SoHsgd == soHsgd

                        let tong_tt = (from HsgdCtu in _context.HsgdCtus
                                       where HsgdCtu.SoHsgd == soHsgd
                                       let prKey = HsgdCtu.PrKey
                                       select _context.HsgdDxes
                                                      .Where(HsgdDx => HsgdDx.FrKey == prKey)
                                                      .Sum(HsgdDx => HsgdDx.SoTientt)).FirstOrDefault()
                        let tong_ph = (from HsgdCtu in _context.HsgdCtus
                                       where HsgdCtu.SoHsgd == soHsgd
                                       let prKey = HsgdCtu.PrKey
                                       select _context.HsgdDxes
                                                      .Where(HsgdDx => HsgdDx.FrKey == prKey)
                                                      .Sum(HsgdDx => HsgdDx.SoTienph)).FirstOrDefault()
                        let tong_son = (from HsgdCtu in _context.HsgdCtus
                                       where HsgdCtu.SoHsgd == soHsgd
                                       let prKey = HsgdCtu.PrKey
                                       select _context.HsgdDxes
                                                      .Where(HsgdDx => HsgdDx.FrKey == prKey)
                                                      .Sum(HsgdDx => HsgdDx.SoTienson)).FirstOrDefault()

                        let vat = (from HsgdCtu in _context.HsgdCtus
                                   where HsgdCtu.SoHsgd == soHsgd
                                   join HsgdDx in _context.HsgdDxes on HsgdCtu.PrKey equals HsgdDx.FrKey
                                   select HsgdDx.SoTienpdsc * (HsgdDx.VatSc/100.0m)).Sum()
                        let giam_tru_bt = (from hsgdCtu in _context.HsgdCtus
                                           where hsgdCtu.SoHsgd == soHsgd
                                           join hsgdDx in _context.HsgdDxes on hsgdCtu.PrKey equals hsgdDx.FrKey
                                           select hsgdDx.SoTienpdsc * (hsgdDx.GiamTruBt / 100.0m)).FirstOrDefault()
                        let so_de_xuat = (from HsgdCtu in _context.HsgdCtus
                                          where HsgdCtu.SoHsgd == soHsgd
                                          let prKey = HsgdCtu.PrKey
                                          select _context.HsgdDxes.Count(HsgdDx => HsgdDx.FrKey == prKey)).FirstOrDefault()
                        let khong_vat = (from HsgdCtu in _context.HsgdCtus
                                         where HsgdCtu.SoHsgd == soHsgd
                                         let prKey = HsgdCtu.PrKey
                                         select _context.HsgdDxes
                                                        .Where(HsgdDx => HsgdDx.FrKey == prKey)
                                                        .Sum(HsgdDx => HsgdDx.SoTienpdsc)).FirstOrDefault()
                        let total_vat = (from HsgdCtu in _context.HsgdCtus
                                         where HsgdCtu.SoHsgd == soHsgd
                                         let prKey = HsgdCtu.PrKey
                                         select _context.HsgdDxes
                                                        .Where(HsgdDx => HsgdDx.FrKey == prKey)
                                                        .Sum(HsgdDx => HsgdDx.SoTienpdsc + (HsgdDx.SoTienpdsc * HsgdDx.VatSc/100.0m))).FirstOrDefault()
                        let khau_tru = (from HsgdCtu in _context.HsgdCtus
                                        where HsgdCtu.SoHsgd == soHsgd
                                        select HsgdCtu.SoTienctkh).FirstOrDefault()
                        let doi_tru = (from hsgdCtu in _context.HsgdCtus
                                       where hsgdCtu.SoHsgd == soHsgd
                                       join hsgdDx in _context.HsgdDxes on hsgdCtu.PrKey equals hsgdDx.FrKey
                                       select hsgdDx.SoTienDoitru).FirstOrDefault() ?? 0
                        let giam_gia = (total_vat * (HsgdCtu.TyleggPhutungvcx) / 100) ?? 0
                        let pvi_bao_lanh = total_vat - giam_gia - khau_tru - giam_tru_bt - doi_tru

                        select new Result
                        {
                            SoHsgd = HsgdCtu.SoHsgd,
                            XuatXu = HsgdCtu.XuatXu,
                            NamSx = HsgdCtu.NamSx,
                            Vat = HsgdCtu.Vat,
                            TyleggPhutungvcx = HsgdCtu.TyleggPhutungvcx,
                            TyleggSuachuavcx = HsgdCtu.TyleggSuachuavcx,
                            PascVatVcx = HsgdCtu.PascVatVcx,
                            SoTienctkh = HsgdCtu.SoTienctkh,
                            LydoCtkh = HsgdCtu.LydoCtkh,
                            HieuXe = DmHieuxe.HieuXe,
                            LoaiXe = DmLoaixe.LoaiXe,
                            TenGaraVcx = GaRaVcx.TenGara,
                            TenGaraVcx01 = GaRaVcx01.TenGara,
                            TenGaraVcx02 = GaRaVcx02.TenGara,
                            TenHmuc = DmHmuc.TenHmuc,
                            SoTientt = HsgdDx.SoTientt,
                            SoTienph = HsgdDx.SoTienph,
                            SoTienson = HsgdDx.SoTienson,
                            VatSc = HsgdDx.VatSc,
                            GIAM_TRU_BT = giam_tru_bt,
                            ThuHoiTs = HsgdDx.ThuHoiTs,
                            SoTienDoitru = HsgdDx.SoTienDoitru,
                            Tong_tt = tong_tt,
                            Tong_ph = tong_ph,
                            Tong_son = tong_son,
                            GhiChudv = HsgdDx.GhiChudv,
                            GhiChutt = HsgdDx.GhiChutt,
                            CO_VAT = vat,
                            SO_DE_XUAT = so_de_xuat,
                            KHONG_VAT = khong_vat,
                            TOTAL_VAT = total_vat,
                            KHAU_TRU = khau_tru,
                            DOI_TRU = doi_tru,
                            GIAM_GIA = giam_gia,
                            PVI_BAO_LANH = pvi_bao_lanh
                        };

            var chung = query.Select(x => new List1
            {
                SoHsgd = x.SoHsgd,
                XuatXu = x.XuatXu,
                NamSx = x.NamSx,
                Vat = x.Vat,
                TyleggPhutungvcx = x.TyleggPhutungvcx,
                TyleggSuachuavcx = x.TyleggSuachuavcx,
                PascVatVcx = x.PascVatVcx,
                SoTienctkh = x.SoTienctkh,
                LydoCtkh = x.LydoCtkh,
                HieuXe = x.HieuXe,
                LoaiXe = x.LoaiXe,
                TenGaraVcx = x.TenGaraVcx,
                TenGaraVcx01 = x.TenGaraVcx01,
                TenGaraVcx02 = x.TenGaraVcx02,
                Tong_tt = x.Tong_tt,
                Tong_ph = x.Tong_ph,
                Tong_son = x.Tong_son,
                CO_VAT = x.CO_VAT,
                SO_DE_XUAT = x.SO_DE_XUAT,
                KHONG_VAT = x.KHONG_VAT,
                TOTAL_VAT = x.TOTAL_VAT,
                KHAU_TRU = x.KHAU_TRU,
                DOI_TRU = x.DOI_TRU,
                GIAM_GIA = x.GIAM_GIA,
                PVI_BAO_LANH = x.PVI_BAO_LANH
            }).FirstOrDefault();

            var khong_chung = query.Select(x => new List2
            {
                TenHmuc = x.TenHmuc,
                SoTientt = x.SoTientt,
                SoTienph = x.SoTienph,
                SoTienson = x.SoTienson,
                VatSc = x.VatSc,
                GiamTruBt = x.GiamTruBt,
                ThuHoiTs = x.ThuHoiTs,
                SoTienDoitru = x.SoTienDoitru,
                GhiChudv = x.GhiChudv,
                GhiChutt = x.GhiChutt
            }).ToList();

            var gop = new List3();
            gop.List1 = chung;
            gop.List2 = new List<List2>();
            gop.List2 = khong_chung;

            return gop;
        }
    }
}