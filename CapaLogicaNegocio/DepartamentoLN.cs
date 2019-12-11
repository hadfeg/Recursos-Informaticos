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
    public class DepartamentoLN
    {
        #region "PATRON SINGLETON"
        private static DepartamentoLN objDepartamento = null;
        private DepartamentoLN() { }
        public static DepartamentoLN getInstance()
        {
            if (objDepartamento == null)
            {
                objDepartamento = new DepartamentoLN();
            }
            return objDepartamento;
        }
        #endregion
        public bool RegistrarDepartamento(Departamento objDepartamento)
        {
            try
            {
                return DepartamentoDAO.getInstance().RegistrarDepartamento(objDepartamento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet ListarDepartamento()
        {
            try
            {
                return DepartamentoDAO.getInstance().ListarDeparamentos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
