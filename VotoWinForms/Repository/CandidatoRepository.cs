using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VotoWinForms.Contract.Repository;
using VotoWinForms.Model;

namespace VotoWinForms.Repository
{
    public class CandidatoRepository: ICandidatoRepository
    {
        private readonly List<Candidato> _candidatos;

        public CandidatoRepository()
        {
            var json = File.ReadAllText("Data/candidatos.json");
            _candidatos = JsonSerializer.Deserialize<List<Candidato>>(json) ?? new List<Candidato>();
        }

        public List<Candidato> GetAll()
        {
            return _candidatos;
        }

        public Candidato? GetByNumber(int numero)
        {
            return _candidatos.FirstOrDefault(c => c.Numero == numero);
        }
    }
}
