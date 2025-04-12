using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotoWinForms.Model;

namespace VotoWinForms.Contract.Repository
{
    public interface ICandidatoRepository
    {
        List<Candidato> GetAll();
        Candidato? GetByNumber(int numero);
    }
}
