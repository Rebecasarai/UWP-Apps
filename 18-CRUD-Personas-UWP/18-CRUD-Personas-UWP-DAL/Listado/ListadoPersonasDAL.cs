using _18_CRUD_Personas_UWP_DAL.Conexion;
using _18_CRUD_Personas_UWP_Entidades;
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
            clsConnection cx = new clsConnection();
            SqlDataReader lector;
            clsPersona p;
            SqlCommand consulta = new SqlCommand();
            try
            {
                consulta.CommandText = "Select IDPERSONA, NOMBRE, APELLIDO, DIRECCION, TELEFONO From Personas";
                consulta.Connection = cx.conexion;
                lector = consulta.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        p = new clsPersona();
                        p.IdPersona = (int)lector["IDPERSONA"];
                        p.Nombre = (string)lector["NOMBRE"];
                        p.Apellido = (string)lector["APELLIDO"];
                        p.Direccion = (string)lector["DIRECCION"];
                        p.Telefono = (string)lector["TELEFONO"];

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
