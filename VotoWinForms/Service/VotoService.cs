using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotoWinForms.Contract.Repository;
using VotoWinForms.Contract.Service;
using VotoWinForms.Model;
using VotoWinForms.Utils;

namespace VotoWinForms.Service
{
    public class VotoService : IVotoService
    {
        private readonly IVotoRepository _votoRepository;
        private readonly ICandidatoRepository _candidatoRepository;
        private readonly string _codigoUrna;

        public VotoService(IVotoRepository votoRepository, ICandidatoRepository candidatoRepository)
        {
            _votoRepository = votoRepository;
            _candidatoRepository = candidatoRepository;
            _codigoUrna = "URNA-001";
        }

        public Candidato? GetByNumber(int numero)
        {
            return _candidatoRepository.GetByNumber(numero);
        }

        public Voto Register(int numero)
        {
            var voto = new Voto
            {
                Numero = numero,
                CodigoUrna = _codigoUrna,
                HashAnterior = _votoRepository.GetLastHash()
            };

            voto.HashAtual = HashHelper.GerarHash(voto.GerarStringHash());
            _votoRepository.Register(voto);

            return voto;
        }
    }
}
