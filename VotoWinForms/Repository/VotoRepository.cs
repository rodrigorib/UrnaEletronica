using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VotoWinForms.Contract.Repository;
using VotoWinForms.Model;

namespace VotoWinForms.Repository
{
    public class VotoRepository: IVotoRepository
    {
        private const string CaminhoArquivo = "Data\\votos.txt";

        public string GetLastHash()
        {
            string caminhoArquivo = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), CaminhoArquivo);

            if (!File.Exists(caminhoArquivo))
                return "0000000000000000";

            var ultimaLinha = File.ReadLines(caminhoArquivo).LastOrDefault();
            if (ultimaLinha == null)
                return "0000000000000000";

            var partes = ultimaLinha.Split('|');
            var hashAtual = partes.LastOrDefault(p => p.Trim().StartsWith("HashAtual"));
            return hashAtual?.Split(":")[1].Trim() ?? "0000000000000000";
        }

        public void Register(Voto voto)
        {
            string caminho = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), CaminhoArquivo);

            var linha = $"Id: {voto.Id} | Nº: {voto.Numero} | TipoVoto: {voto.Tipo} | Data: {voto.DataHora:yyyy-MM-dd HH:mm:ss} | Urna: {voto.CodigoUrna} | HashAnterior: {voto.HashAnterior} | HashAtual: {voto.HashAtual}";
            File.AppendAllText(caminho, linha + Environment.NewLine);
        }
    }
}
