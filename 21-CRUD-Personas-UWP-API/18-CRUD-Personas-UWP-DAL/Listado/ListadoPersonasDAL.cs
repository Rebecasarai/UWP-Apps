using _18_CRUD_Personas_UWP_DAL.Conexion;
using _18_CRUD_Personas_UWP_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
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
        public async Task<List<clsPersona>> getPersonas()
        {
            clsConnection mCon = new clsConnection();
            HttpClient client = new HttpClient();
            String resultadoJSON;

            try
            {
                resultadoJSON = await client.GetStringAsync(mCon.uriBase);
                

            }
            catch (SqlException e)
            {
                throw e;
            }

            return this.listado;
        }
    }
}