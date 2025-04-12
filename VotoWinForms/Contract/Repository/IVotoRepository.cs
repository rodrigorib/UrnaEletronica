using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotoWinForms.Model;

namespace VotoWinForms.Contract.Repository
{
    public interface IVotoRepository
    {
        string GetLastHash();
        void Register(Voto voto);
    }
}
