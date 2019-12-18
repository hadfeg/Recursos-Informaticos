using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaAccesoDatos;
using CapaEntidades;

namespace CapaLogicaNegocio
{
    public class SistemaOperativoLN
    {
        #region "PATRON SINGLETON"
        private static SistemaOperativoLN objSO = null;
        private SistemaOperativoLN() { }
        public static SistemaOperativoLN getInstance()
        {
            if (objSO == null)
            {
                objSO = new SistemaOperativoLN();
            }
            return objSO;
        }
        #endregion

        public bool RegistrarSistemaOperativo(SistemaOperativo objSistemaOperativo)
        {
            try
            {
                return SistemaOperativoDAO.getInstance().RegistrarSO(objSistemaOperativo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ListarSistemasOperativos()
        {
            try
            {
                return SistemaOperativoDAO.getInstance().ListarSistemasOperativos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}