using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidades;
using CapaAccesoDatos;

namespace CapaLogicaNegocio
{
    public class ModeloLN
    {

        #region "PATRON SINGLETON"
        private static ModeloLN objModelo = null;
        private ModeloLN() { }
        public static ModeloLN getInstance()
        {
            if (objModelo == null)
            {
                objModelo = new ModeloLN();
            }
            return objModelo;
        }
        #endregion
        ]
        public bool RegistrarModelo(Modelo objModelo)
        {
            try
            {
                return ModeloDAO.getInstance().RegistrarModelo(objModelo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ListarModelos(int idMarca, String nombreModelo)
        {
            try
            {
                return ModeloDAO.getInstance().ListarModelos(idMarca,nombreModelo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ListarModelos()
        {
            try
            {
                return ModeloDAO.getInstance().ListarModelos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
