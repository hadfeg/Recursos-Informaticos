using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    class SistemaOperativo
    {
        public int IdSistemaOperativo { get; set; }
        public String SO { get; set; }
        public float Version { get; set; }
        public String ServiPack { get; set; }
        public String Suscripcion { get; set; }
        public SistemaOperativo() { }
    }
}
