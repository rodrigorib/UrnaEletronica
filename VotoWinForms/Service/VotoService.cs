using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public Candidato GetBranco()
        {
            return new Candidato()
            {
                Numero = -2,
                Nome = "Voto em Branco",
                CaminhoFoto = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "data\\images\\votoembranco.jpg")
            };
        }

        public Candidato GetNulo()
        {
            Candidato candidato = new Candidato()
            {
                Numero = -1,
                Nome = "Voto Nulo",
                CaminhoFoto = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "data\\images\\votonulo.jpg")
            };

            return candidato;
        }

        public Candidato? GetByNumber(int numero)
        {
            Candidato? candidato = _candidatoRepository.GetByNumber(numero);

            if (candidato != null)
                candidato.CaminhoFoto = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), candidato.CaminhoFoto);

            return candidato;
        }

        public Voto Register(TipoVoto tipoVoto, int numero)
        {
            var voto = new Voto
            {
                Numero = numero,
                Tipo = tipoVoto,
                CodigoUrna = _codigoUrna,
                HashAnterior = _votoRepository.GetLastHash()
            };

            voto.HashAtual = HashHelper.GerarHash(voto.GerarStringHash());
            _votoRepository.Register(voto);

            return voto;
        }
    }
}
