using ApiRestJavascript.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestJavascript.Data
{
    public interface ICervezaRepository
    {
        Cerveza GetCervezaById(int id);
        IEnumerable<Cerveza> GetAllCervezas();
        Cerveza CreateCerveza(CervezaRequest cerveza);
        Task DeleteCerveza(int id);
        void UpdateCerveza(int id, CervezaRequest cerveza);
    }
}
