using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using pas_pertamina.Models;

namespace pas_pertamina.Controllers
{
    public class LaporanController : Controller
    {
        private readonly db_penjadwalan_pelabuhanContext _context;
        LaporanDataAccessLayer objLaporan = new LaporanDataAccessLayer();
        public LaporanController(db_penjadwalan_pelabuhanContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult JadwalMonitoring()
        {
            ViewData["Idkapal"] = new SelectList(_context.Pelabuhan, "Idlistpelabuhan", "Namapelabuhan");
            return View();
        }

        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }
        public async Task<IActionResult> CetakJadwalMonitoring(string idpelabuhan,string daritanggal,string hinggatanggal)
        {
            /*CetakMonitoring _cetak = new CetakMonitoring();
            _cetak.cetakMonitoring1s = objLaporan.GetMonitoringProsesJetty1(idpelabuhan,daritanggal);
            _cetak.cetakMonitoring2s = objLaporan.GetMonitoringProsesJetty2(idpelabuhan, daritanggal);
            _cetak.cetakMonitoring3s = objLaporan.GetMonitoringPlanningJetty1(idpelabuhan, daritanggal);
            _cetak.cetakMonitoring4s = objLaporan.GetMonitoringPlanningJetty2(idpelabuhan, daritanggal);
            _cetak.tgl = daritanggal;*/

            //baru bs 1 tanggal aja
            //jika lebih dari 1 tanggal maka gunakan add di _cetak
            DateTime StartDate = DateTime.Parse(daritanggal);
            DateTime EndDate = DateTime.Parse(hinggatanggal);
            List<CetakMonitoring> _cetak2 = new List<CetakMonitoring>();
            foreach(DateTime day in EachDay(StartDate, EndDate))
            {
                _cetak2.Add(new CetakMonitoring
                {
                    cetakMonitoring1s = objLaporan.GetMonitoringProsesJetty1(idpelabuhan, daritanggal),
                    cetakMonitoring2s = objLaporan.GetMonitoringProsesJetty2(idpelabuhan, daritanggal),
                    cetakMonitoring3s = objLaporan.GetMonitoringPlanningJetty1(idpelabuhan, daritanggal),
                    cetakMonitoring4s = objLaporan.GetMonitoringPlanningJetty2(idpelabuhan, daritanggal),
                    tgl = day.ToString("dd/MM/yyyy"),
                });
            }
            
            return View(_cetak2);
        }
    }
}