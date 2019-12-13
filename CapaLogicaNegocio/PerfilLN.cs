using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaAccesoDatos;
using System.Data;

namespace CapaLogicaNegocio
{
    public class PerfilLN
    {
        #region "PATRON SINGLETON"
        private static PerfilLN objPerfil = null;
        private PerfilLN() { }
        public static PerfilLN getInstance()
        {
            if (objPerfil == null)
            {
                objPerfil = new PerfilLN();
            }
            return objPerfil;
        }
        #endregion
        public DataSet ListarPerfil()
        {
            try
            {
                return PerfilDAO.getInstance().ListarPerfil();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
