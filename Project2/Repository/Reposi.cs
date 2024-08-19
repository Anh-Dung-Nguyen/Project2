using Project2.Data;
using Project2.Models;

namespace Project2.Repository
{
    public class Reposi
    {
        private readonly GdttContext _context;
        public Reposi(GdttContext context)
        {
            _context = context;
        }
        public IQueryable<Table2> GetDetailsss(string soHsgd)
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

                        let vat = (from HsgdCtu in _context.HsgdCtus
                                   where HsgdCtu.SoHsgd == soHsgd
                                   join HsgdDx in _context.HsgdDxes on HsgdCtu.PrKey equals HsgdDx.FrKey
                                   select HsgdDx.SoTienpdsc * (HsgdDx.VatSc / 100.0m)).Sum()
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
                                                        .Sum(HsgdDx => HsgdDx.SoTienpdsc + (HsgdDx.SoTienpdsc * HsgdDx.VatSc / 100.0m))).FirstOrDefault()
                        let khau_tru = (from HsgdCtu in _context.HsgdCtus
                                        where HsgdCtu.SoHsgd == soHsgd
                                        select HsgdCtu.SoTienctkh).FirstOrDefault()
                        let doi_tru = (from hsgdCtu in _context.HsgdCtus
                                       where hsgdCtu.SoHsgd == soHsgd
                                       join hsgdDx in _context.HsgdDxes on hsgdCtu.PrKey equals hsgdDx.FrKey
                                       select hsgdDx.SoTienDoitru).FirstOrDefault() ?? 0
                        let giam_gia = (total_vat * (HsgdCtu.TyleggPhutungvcx) / 100) ?? 0
                        let pvi_bao_lanh = total_vat - giam_gia - khau_tru - giam_tru_bt - doi_tru

                        select new Table2
                        {
                            TenHmuc = DmHmuc.TenHmuc,
                            GhiChutt = HsgdDx.GhiChutt,
                            GhiChudv = HsgdDx.GhiChudv,
                            SoTientt = HsgdDx.SoTientt,
                            SoTienph = HsgdDx.SoTienph,
                            SoTienson = HsgdDx.SoTienson,
                            VatSc = HsgdDx.VatSc,
                            GiamTruBt = giam_tru_bt,
                            ThuHoiTs = HsgdDx.ThuHoiTs,
                            SoTienDoitru = HsgdDx.SoTienDoitru
                        };

            return query;
        }
    }
}
