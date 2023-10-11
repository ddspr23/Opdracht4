using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht4.core
{
    class DemografischRapport : Rapport
    {
        private DatabaseContext context;
        public DemografischRapport(DatabaseContext context) => this.context = context;
        public override string Naam() => "Demografie";
        public override async Task<string> Genereer()
        {
            string ret = "Dit is een demografisch rapport: \n";
            ret += $"Er zijn in totaal {await AantalGebruikers()} gebruikers van dit platform (dat zijn gasten en medewerkers)\n";
            var dateTime = new DateTime(2000, 1, 1);
            ret += $"Er zijn {await AantalSinds(dateTime)} bezoekers sinds {dateTime}\n";
            if (await AlleGastenHebbenReservering())
                ret += "Alle gasten hebben een reservering\n";
            else
                ret += "Niet alle gasten hebben een reservering\n";
            ret += $"Het percentage bejaarden is {await PercentageBejaarden()}\n";

            ret += $"De oudste gast heeft een leeftijd van {await HoogsteLeeftijd()} \n";

            ret += "De verdeling van de gasten per dag is als volgt: \n";
            var dagAantallen = await VerdelingPerDag();
            var totaal = dagAantallen.Select(t => t.aantal).Max();
            foreach (var dagAantal in dagAantallen)
                ret += $"{dagAantal.dag}: {new string('#', (int)(dagAantal.aantal / (double)totaal * 20))}\n";

            ret += $"{await FavorietCorrect()} gasten hebben de favoriete attractie inderdaad het vaakst bezocht. \n";

            return ret;
        }
        private async Task<int> AantalGebruikers() => await Task.Run(() => { return (context.Gasten.Count() + context.Medewerkers.Count()); });
        private async Task<bool> AlleGastenHebbenReservering() => await Task.Run(() => context.Gasten.Any(_g => context.Reserveringen.Any(_r => _r.GastID == _g.ID)));
        private async Task<int> AantalSinds(DateTime sinds) => await Task.Run(() => context.Gasten.Where(_g => _g.EersteBezoek >= sinds).Count());
#pragma warning disable CS8603 // Possible null reference return.
        private async Task<Gast> GastBijEmail(string email) => await Task.Run(() =>
        {
            var _obj = context.Gasten.Where(_g => _g.Email == email);

            return !_obj.Any() || _obj.Count() > 1 || _obj == null ? null : _obj.ElementAt(0);
        });
#pragma warning restore CS8603 // Possible null reference return.
        private async Task<Gast?> GastBijGeboorteDatum(DateTime d) => await Task.Run(() =>
        {
            var _obj = context.Gasten.Where(_g => _g.GeboorteDatum == d);

            return !_obj.Any() || _obj.Count() > 1 || _obj == null ? null : _obj.ElementAt(0);
        });
        private async Task<double> PercentageBejaarden() => await Task.Run(() => context.Gasten.Average(_g => (DateTime.Now.Year - _g.GeboorteDatum.Year)));
        private async Task<int> HoogsteLeeftijd() => await Task.Run(() => DateTime.Today.Year - (context.Gasten.Min(_g => _g.GeboorteDatum).Year));
        private async Task<(string dag, int aantal)[]> VerdelingPerDag() => await Task.Run(() =>
        {
            (string, int)[] _list = new (string, int)[7];

            foreach (DayOfWeek _w in Enum.GetValues(typeof(DayOfWeek)))
            {
                var _tmp = context.Gasten.Where(_g => _g.EersteBezoek.DayOfWeek == _w).ToList();
                _list.SetValue((_w.ToString(), _tmp.Count), Convert.ToInt32(_w));
            }

            return _list;
        });
        private async Task<int> FavorietCorrect() => 0;
    }
}
