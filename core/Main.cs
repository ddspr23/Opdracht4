using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht4.core
{
    internal class _Main
    {
        private static async Task<T> Willekeurig<T>(DbContext c) where T : class => await c.Set<T>().OrderBy(r => EF.Functions.Random()).FirstAsync();
        public static async Task Main()
        {
            Random random = new(1);
            using (DatabaseContext c = new())
            {
                c.Database.EnsureDeleted();
                c.Database.EnsureCreated();

                using (var transaction = c.Database.BeginTransaction())
                {
                    try
                    {
                        c.Attracties.RemoveRange(c.Attracties);
                        c.Gasten.RemoveRange(c.Gasten);
                        c.Medewerkers.RemoveRange(c.Medewerkers);
                        c.Reserveringen.RemoveRange(c.Reserveringen);
                        c.Onderhoud.RemoveRange(c.Onderhoud);

                        c.SaveChanges();

                        string[] _str = { "Reuzenrad", "Spookhuis", "Achtbaan 1", "Achtbaan 2", "Draaimolen 1", "Draaimolen 2" };

                        foreach (string attractie in _str)
                        {
                            c.Attracties.Add(new Attractie(attractie));
                        }

                        c.SaveChanges();

                        for (int i = 0; i < 40; i++)
                            c.Medewerkers.Add(new Medewerker($"medewerker{i}@mail.com"));
                        c.SaveChanges();

                        for (int i = 0; i < 1000; i++)
                        {
                            var geboren = DateTime.Now.AddDays(-random.Next(36500));
                            var nieuweGast = new Gast($"gast{i}@mail.com") { GeboorteDatum = geboren, EersteBezoek = geboren + (DateTime.Now - geboren) * random.NextDouble(), Credits = random.Next(5) };
                            var attr = await Willekeurig<Attractie>(c);

                            nieuweGast.Attractie = attr; // nieuweGast.Attractie = await Willekeurig<Attractie>(); doet het niet.
                            c.Gasten.Add(nieuweGast);
                        }

                        c.SaveChanges();

                        for (int i = 0; i < 10; i++)
                            (await Willekeurig<Gast>(c)).Begeleider = await Willekeurig<Gast>(c);
                        c.SaveChanges();


                        for (int i = 0; i < 10; i++)
                        {
                            var _c = await Willekeurig<Medewerker>(c);

                            Onderhoud _oh = new() { coordinator = _c, Probleem = $"Hele koele probleem{i}", _dtb = new DateTimeBereik(), Attractie = await Willekeurig<Attractie>(c) };
                            c.Onderhoud.Add(_oh);
                        }

                        c.SaveChanges();

                        for (int i = 0; i < 20; i++)
                        {
                            var _a = await Willekeurig<Attractie>(c);
                            var _g = await Willekeurig<Gast>(c);

                            Reservering _r = new() { _attr = _a, _gast = _g, _dtb = new DateTimeBereik() };

                            c.Reserveringen.Add(_r);
                        }

                        c.SaveChanges();

                        transaction.Commit();
                    }
                    catch (Exception _ex)
                    {
                        Console.WriteLine(_ex.Message);
                    }
                }

                Console.WriteLine("Finished initialization");

                Console.Write(await new DemografischRapport(c).Genereer());
                Console.ReadLine();
            }
        }
    }
}