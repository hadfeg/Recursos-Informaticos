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
    public class MarcaLN
    {
        #region "PATRON SINGLETON"
        private static MarcaLN objMarca= null;
        private MarcaLN() { }
        public static MarcaLN getInstance()
        {
            if (objMarca == null)
            {
                objMarca = new MarcaLN();
            }
            return objMarca;
        }
        #endregion
        public bool RegistrarMarca(Marca objMarca)
        {
            try
            {
                return MarcaDAO.getInstance().RegistrarMarca(objMarca);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ListarMarcas()
        {
            try
            {
                return MarcaDAO.getInstance().ListarMarcas();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
