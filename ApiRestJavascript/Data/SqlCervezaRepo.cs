using ApiRestJavascript.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestJavascript.Data
{
    public class SqlCervezaRepo : ICervezaRepository
    {
        private readonly PruebaContext context;
        public SqlCervezaRepo(PruebaContext _context)
        {
            context = _context;
        }
        public Cerveza CreateCerveza(CervezaRequest cerveza)
        {
            var cervezadb = new Cerveza();
            cervezadb.Nombre = cerveza.Nombre;

            context.Cervezas.Add(cervezadb);
            context.SaveChanges();

            return context.Cervezas.Where(c => c.Nombre == cerveza.Nombre).First();
        }

        public async Task DeleteCerveza(int id)
        {
            var cervezaDb = await context.Cervezas.FindAsync(id);
            context.Cervezas.Remove(cervezaDb);
            context.SaveChanges();
        }

        public IEnumerable<Cerveza> GetAllCervezas()
        {
            return context.Cervezas.ToList();
        }

        public Cerveza GetCervezaById(int id)
        {
            var cervezaDb = context.Cervezas.Find(id);

            return cervezaDb;
        }

        public void UpdateCerveza(int id, CervezaRequest cerveza)
        {
            var cervezaDb = context.Cervezas.Find(id);

            cervezaDb.Nombre = cerveza.Nombre;

            context.Entry(cervezaDb).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
