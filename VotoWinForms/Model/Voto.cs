using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotoWinForms.Model
{
    public class Voto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Numero { get; set; }
        public DateTime DataHora { get; set; } = DateTime.Now;
        public string CodigoUrna { get; set; }
        public string HashAnterior { get; set; }
        public string HashAtual { get; set; }

        public string GerarStringHash()
        {
            return $"{Id}-{Numero}-{DataHora:yyyy-MM-dd HH:mm:ss}-{CodigoUrna}-{HashAnterior}";
        }
    }
}
