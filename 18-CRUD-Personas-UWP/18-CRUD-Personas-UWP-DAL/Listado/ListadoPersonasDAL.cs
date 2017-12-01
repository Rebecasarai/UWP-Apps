using _18_CRUD_Personas_UWP_UI.Conexion;
using _18_CRUD_Personas_UWP_UI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_CRUD_Personas_UWP_UI.Listado
{
    public class ListadoPersonasDAL
    {
        public List<clsPersona> listado { get; set; }

        public ListadoPersonasDAL()
        {
            this.listado = new List<clsPersona>();
        }
        public List<clsPersona> getPersonas()
        {
            Connection cx = new Connection();
            SqlDataReader lector;
            clsPersona p;
            SqlCommand consulta = new SqlCommand();
            try
            {
                consulta.CommandText = "Select * From Personas";
                consulta.Connection = cx.conexion;
                lector = consulta.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        p = new clsPersona();
                        p.IdPersona = (int)lector["ID"];
                        p.Nombre = (string)lector["nombre"];
                        p.Apellido = (string)lector["apellidos"];
                        p.Direccion = (string)lector["direccion"];
                        p.Telefono = (string)lector["telefono"];
                        this.listado.Add(p);
                    }
                }
                cx.closeConnection();
            }
            catch (SqlException)
            {
                throw;
            }

            return this.listado;
        }
    }
}
