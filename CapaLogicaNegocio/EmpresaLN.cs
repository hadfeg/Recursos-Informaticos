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
    public class EmpresaLN
    {
        #region "PATRON SINGLETON"
        private static EmpresaLN objEmpresa = null;
        private EmpresaLN() { }
        public static EmpresaLN getInstance()
        {
            if (objEmpresa == null)
            {
                objEmpresa = new EmpresaLN();
            }
            return objEmpresa;
        }
        #endregion
        public bool RegistrarEmpresa(Empresa objEmpresa)
        {
            try
            {
                return EmpresaDAO.getInstance().RegistrarEmpresa(objEmpresa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet ListarEmpresa()
        {
            try
            {
                return EmpresaDAO.getInstance().ListarEmpresas();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
