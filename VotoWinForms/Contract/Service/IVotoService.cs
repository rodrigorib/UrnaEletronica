using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotoWinForms.Model;

namespace VotoWinForms.Contract.Service
{
    public interface IVotoService
    {
        Candidato? GetByNumber(int numero);
        Voto Register(int numeroCandidato);
    }
}
