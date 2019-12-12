using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Usuario
    {
        public String Rut { get; set; }
        public String User { get; set; }
        public String Pass { get; set; }
        public String Name { get; set; }
        public int Departamento { get; set; }
        public int Empresa { get; set; }
        public String LastName { get; set; }
        public int Rol { get; set; }
        public String Mail { get; set; }
        public int Estado { get; set; }
        public String UsrImage { get; set; }

        public Usuario() { }
        public Usuario(String Rut, String User, String Pass, String Name, String LastName, int Rol, String Mail, int Estado, int Department, int Enterprise, String UsrImage)
        {
            this.Rut = Rut;
            this.User = User;
            this.Pass = Pass;
            this.Name = Name;
            this.LastName = LastName;
            this.Rol = Rol;
            this.Mail = Mail;
            this.Estado = Estado;
            this.Empresa = Enterprise;
            this.Departamento = Department;
            this.UsrImage = UsrImage;
        }

    }
}
