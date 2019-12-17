using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class SistemaOperativo
    {
        public int IdSistemaOperativo { get; set; }
        public String NombreSO { get; set; }
        public float Version { get; set; }
        public String ServiPack { get; set; }
        public String Suscripcion { get; set; }
        public SistemaOperativo() { }
    }
}
