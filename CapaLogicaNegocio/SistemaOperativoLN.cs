﻿using System;
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
        
        public List<SistemaOperativo> ListarSistemasOperativos()
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