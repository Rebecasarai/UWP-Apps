
using _18_CRUD_Personas_UWP_DAL.Conexion;
using _18_CRUD_Personas_UWP_Entidades;
using _18_CRUD_Personas_UWP_UI;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Windows.Web.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace _18_CRUD_Personas_UWP_DAL.Manejadoras
{
    public class ManejadoraDAL
    {
        /// <summary>
        /// Funcion que busca una persona por id
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public clsPersona buscarPersonaDAl(int id)
        {
            //Creamos el objeto de tipo conexion de mi conexion
            clsConnection miConexion = new clsConnection();

            //Creamos la sql Connection
            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            clsPersona person = new clsPersona();

            try
            {
                conexion = miConexion.conexion;
                //Creamos comandos
                miComando.CommandText = "Select ID, NOMBRE, APELLIDO, FECHANACIMIENT, DIRECCION, TELEFONO from PersonasBD where ID=@id";
                /**creamos la variable que le pondremos en el where*/
                SqlParameter param;
                param = new SqlParameter();
                param.ParameterName = "@id";
                param.SqlDbType = System.Data.SqlDbType.Int;
                param.Value = id;

                //Le damos al comando el paramentro
                miComando.Parameters.Add(param);

                /*aqui termina la declaracion de la variable */

                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el Lector
                if (miLector.HasRows)
                {
                    miLector.Read();

                    person = new clsPersona();
                    person.IdPersona = (Int32)miLector["ID"];
                    person.Nombre = (String)miLector["NOMBRE"];
                    person.Apellido = (String)miLector["APELLIDO"];
                    person.FechaNac = (DateTime)miLector["FECHANACIMIENT"];
                    person.Direccion = (String)miLector["DIRECCION"];
                    person.Telefono = (String)miLector["TELEFONO"];
                }//fin while
            }
            catch (SqlException sql) { throw sql; }


            return (person);
        }//fin metodo buscarPersona


        /// <summary>
        /// este metodo esta guarda los cambios de la persona editada
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public int guardarPersonaDAL(clsPersona persona)
        {
            clsConnection miConexion = new clsConnection();
            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();

            int resultado = 0;

            //
            miComando.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = persona.IdPersona;
            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = persona.Nombre;
            miComando.Parameters.Add("@apellido", System.Data.SqlDbType.VarChar).Value = persona.Apellido;
            miComando.Parameters.Add("@fechanacimient", System.Data.SqlDbType.DateTime2).Value = persona.FechaNac;
            miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = persona.Direccion;
            miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = persona.Telefono;

            try
            {
                conexion = miConexion.conexion;
                //Actualizamos los datos de la persona en la base de datos
                miComando.CommandText = "Update PersonasBD set NOMBRE=@NOMBRE,APELLIDO=@apellido," +
                                        "FECHANACIMIENT=@fechanacimient,DIRECCION=@direccion,TELEFONO=@telefono " +
                                        "where ID=@ID";
                //
                miComando.Connection = conexion;

                //ejecutamos el comando de actualizar
                resultado = miComando.ExecuteNonQuery();
            }
            catch (SqlException sql) { throw sql; }

            return (resultado);
        }//fin guardarPersonaDAL

        /// <summary>
        /// Eliminamos a una persona con el verbo delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> eliminarPersonaDALAsync(int id)
        {
            clsConnection mConexion = new clsConnection();
            int mResultado = 0;
            HttpClient client = new HttpClient();
            HttpResponseMessage respuesta;
            Uri mUri = new Uri(mConexion.uriBase + "/" + id);
            try
            {
                respuesta = await client.DeleteAsync(mUri);
                client.Dispose();
                
                if (respuesta.IsSuccessStatusCode)
                {
                    mResultado = 1;
                }
            }
            catch (Exception e) { throw e; }

            return mResultado;

        }

        /// <summary>
        /// Este metodo inserta una nueva persona
        /// </summary>
        /// <param name="persona">Recibe un objeto persona</param>
        /// <returns>Devuelve un 1 si se ha creado correctamente. Un 0 si ha fallado.</returns>
        public async Task<int> crearPersonaDALAsync(clsPersona persona)
        {
            clsConnection miConexion = new clsConnection();
            int resultado = 0;
            HttpClient client = new HttpClient();
            String body;
            HttpStringContent mContenido;
            HttpResponseMessage mRespuesta;
            try
            {
                // Serializamos al objeto persona que recibe
                body = JsonConvert.SerializeObject(persona);

                mContenido = new HttpStringContent(body, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json");
                    
                mRespuesta = await client.PostAsync(miConexion.uriBase, mContenido);

                if (mRespuesta.IsSuccessStatusCode)
                {
                    resultado = 1;
                }
            }
            catch (Exception e) { throw e; }


            return (resultado);
        }
        //fin crearPersonaDAL

        /// <summary>
        /// 
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> updatePersonaAsync(clsPersona persona)
        {
            clsConnection miConexion = new clsConnection();
            HttpClient client = new HttpClient();
            String body;
            HttpStringContent mContenido;
            HttpResponseMessage mRespuesta;
            Uri mUri = new Uri(miConexion.uriBase+"/"+persona.IdPersona);
            try
            {
                // Serializamos al objeto persona que recibe
                body = JsonConvert.SerializeObject(persona);

                mContenido = new HttpStringContent(body, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json");

                mRespuesta = await client.PutAsync(mUri, mContenido);
                
            }
            catch (Exception e) { throw e; }

            return mRespuesta.StatusCode;
            
        }

        public clsPersona getPersonaDAL(int id)
        {
            //Creamos el objeto de tipo conexion de mi conexion
            clsConnection miConexion = new clsConnection();

            //Creamos la sql Connection
            SqlConnection conexion = new SqlConnection();

            //
            SqlCommand miComando = new SqlCommand();

            //
            SqlDataReader miLector;

            //
            clsPersona person = new clsPersona();

            try
            {
                conexion = miConexion.conexion;
                //Creamos comandos
                miComando.CommandText = "Select ID, NOMBRE, APELLIDO, FECHANACIMIENT, DIRECCION,TELEFONO from PersonasBD where ID=@id";
                /**creamos la variable que le pondremos en el where*/
                SqlParameter param;
                param = new SqlParameter();
                param.ParameterName = "@id";
                param.SqlDbType = System.Data.SqlDbType.Int;
                param.Value = id;

                //Le damos al comando el paramentro
                miComando.Parameters.Add(param);

                /*aqui termina la declaracion de la variable */

                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el Lector
                if (miLector.HasRows)
                {
                    miLector.Read();

                    person = new clsPersona();
                    person.IdPersona = (Int32)miLector["ID"];
                    person.Nombre = (String)miLector["NOMBRE"];
                    person.Apellido = (String)miLector["APELLIDO"];
                    person.FechaNac = (DateTime)miLector["FECHANACIMIENT"];
                    person.Direccion = (String)miLector["DIRECCION"];
                    person.Telefono = (String)miLector["TELEFONO"];


                }//fin while
            }
            catch (SqlException sql) { throw sql; }


            return (person);
        }//fin metodo buscarPersona

    }
}
