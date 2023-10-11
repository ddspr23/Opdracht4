using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace Opdracht4.core
{
    [Table("Attractie")]
    internal class Attractie
    {
        public readonly SemaphoreSlim Semaphore = new(1, 1);

        public Attractie(string Naam)
        {
            this.Naam = Naam;
        }

        public int AttractieID { get; set; }
        public string Naam { get; set; } = string.Empty;
        public async Task<bool> OnderhoudBezig(DatabaseContext _ctx)
        {
            return await Task.Run(() =>
            {
                if(_ctx.Onderhoud.Where(_o => _o.AttractieID == AttractieID).ToList().All(_o => _o._dtb.Eindigt()))
                {
                    return false;
                }

                return true;
            });
        }

        public async Task<bool> Vrij(DatabaseContext _ctx, DateTimeBereik _dtb)
        {
            return await Task.Run(() =>
            {
                var _rsv = _ctx.Reserveringen.Select(_t => _t).ToList();
                if(_rsv.Find(_r => _r._dtb.Overlapt(_dtb)) == default)
                {
                    return true;
                }

                return false;
            });
        }
    }
}
