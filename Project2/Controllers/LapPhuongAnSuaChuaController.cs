using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project2.Data;
using Project2.Models;
using Project2.Repository;
using Project2.Service;

namespace Project2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LapPhuongAnSuaChuaController : ControllerBase
    {
        private readonly GdttContext _context;
        private readonly Repo _repo;
        private readonly Repos _repos;
        private readonly Reposi _reposi;

        public LapPhuongAnSuaChuaController(GdttContext context, Repo repo, Repos repos, Reposi reposi)
        {
            _context = context;
            _repo = repo;
            _repos = repos;
            _reposi = reposi;
        }

        // GET: api/DmGaRas
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<DmGaRa>>> GetDmGaRas()
        //{
        //    return await _context.DmGaRas.ToListAsync();
        //}

        // GET: api/DmGaRas/5
        //[HttpGet("gara/{id}")]
        //public async Task<ActionResult<DmGaRa>> GetDmGaRa(string id)
        //{
        //    var dmGaRa = await _context.DmGaRas.FindAsync(id);

        //    if (dmGaRa == null)
        //    {
        //        return NotFound();
        //    }

        //    return dmGaRa;
        //}

        // GET: api/DmHieuxe
        //[HttpGet("hieuxe/{id}")]
        //public async Task<ActionResult<DmHieuxe>> GetDmHieuXe(int id)
        //{
        //    var dmHieuxe = await _context.DmHieuxes.FindAsync(id);

        //    if (dmHieuxe == null)
        //    {
        //        return NotFound();
        //    }

        //    return dmHieuxe;
        //}

        // GET: api/DmHmuc
        //[HttpGet("hangmuc/{id}")]
        //public async Task<ActionResult<DmHmuc>> GetDmHangMuc(string id)
        //{
        //    var dmHangmuc = await _context.DmHmucs.FindAsync(id);

        //    if (dmHangmuc == null)
        //    {
        //        return NotFound();
        //    }

        //    return dmHangmuc;
        //}

        // GET: api/DmLoaixe
        //[HttpGet("loaixe/{id}")]
        //public async Task<ActionResult<DmLoaixe>> GetDmLoaiXe(string id)
        //{
        //    var dmLoaixe = await _context.DmLoaixes.FindAsync(id);

        //    if (dmLoaixe == null)
        //    {
        //        return NotFound();
        //    }

        //    return dmLoaixe;
        //}

        // GET: api/HsgdCtu
        [HttpGet("HsgdCtu/{soHsgd}")]
        public IActionResult GetHsgdCtu(string soHsgd)
        {
            var a = Uri.UnescapeDataString(soHsgd);
            var b = _repo.GetDetails(a);
            
            if (a == null)
            {
                return NotFound();
            }

            return Ok(b);
        }

        [HttpGet("HsgdCtus/{soHsgd}")]
        public IActionResult GetHsgdCtus(string soHsgd)
        {
            var a = Uri.UnescapeDataString(soHsgd);
            var b = _repos.GetDetailss(a);

            if (a == null)
            {
                return NotFound();
            }

            return Ok(b);
        }

        [HttpGet("HsgdCtuss/{soHsgd}")]
        public IActionResult GetHsgdCtuss(string soHsgd)
        {
            var a = Uri.UnescapeDataString(soHsgd);
            var b = _reposi.GetDetailsss(a);

            if (a == null)
            {
                return NotFound();
            }

            return Ok(b);
        }

        // GET: api/HsgdDx
        //[HttpGet("HsgdDx/{id}")]
        //public async Task<ActionResult<HsgdDx>> GetHsgdDx(string id)
        //{
        //    var HsgdDx = await _context.HsgdDxes.FindAsync(id);

        //    if (HsgdDx == null)
        //    {
        //        return NotFound();
        //    }

        //    return HsgdDx;
        //}


        // PUT: api/DmGaRas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutDmGaRa(string id, DmGaRa dmGaRa)
        //{
        //    if (id != dmGaRa.MaGara)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(dmGaRa).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DmGaRaExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/DmGaRas
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<DmGaRa>> PostDmGaRa(DmGaRa dmGaRa)
        //{
        //    _context.DmGaRas.Add(dmGaRa);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (DmGaRaExists(dmGaRa.MaGara))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetDmGaRa", new { id = dmGaRa.MaGara }, dmGaRa);
        //}

        //// DELETE: api/DmGaRas/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteDmGaRa(string id)
        //{
        //    var dmGaRa = await _context.DmGaRas.FindAsync(id);
        //    if (dmGaRa == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.DmGaRas.Remove(dmGaRa);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool DmGaRaExists(string id)
        //{
        //    return _context.DmGaRas.Any(e => e.MaGara == id);
        //}
    }
}
