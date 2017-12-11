
using _18_CRUD_Personas_UWP_DAL.Conexion;
using _18_CRUD_Personas_UWP_Entidades;
using _18_CRUD_Personas_UWP_UI;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                miComando.CommandText = "Select ID, Nombre,Apellidos,FechaNacimiento,Direccion,Telefono from Personas where ID=@id";
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
                    person.Nombre = (String)miLector["Nombre"];
                    person.Apellido = (String)miLector["Apellidos"];
                    person.FechaNac = (DateTime)miLector["FechaNacimiento"];
                    person.Direccion = (String)miLector["Direccion"];
                    person.Telefono = (String)miLector["Telefono"];


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
            miComando.Parameters.Add("@IDPERSONA", System.Data.SqlDbType.Int).Value = persona.IdPersona;
            miComando.Parameters.Add("@NOMBRE", System.Data.SqlDbType.VarChar).Value = persona.Nombre;
            miComando.Parameters.Add("@APELLIDO", System.Data.SqlDbType.VarChar).Value = persona.Apellido;
            miComando.Parameters.Add("@FECHANACIMIENT", System.Data.SqlDbType.DateTime).Value = persona.FechaNac;
            miComando.Parameters.Add("@DIRECCION", System.Data.SqlDbType.VarChar).Value = persona.Direccion;
            miComando.Parameters.Add("@TELEFONO", System.Data.SqlDbType.VarChar).Value = persona.Telefono;

            try
            {
                conexion = miConexion.conexion;
                //Actualizamos los datos de la persona en la base de datos
                miComando.CommandText = "Update Personas set NOMBRE=@NOMBRE,APELLIDO=@APELLIDO," +
                                        "FECHANACIMIENT=@FECHANACIMIENT,DIRECCION=@DIRECCION,TELEFONO=@TELEFONO " +
                                        "where IDPERSONA=@IDPERSONA";
                //
                miComando.Connection = conexion;

                //ejecutamos el comando de actualizar
                resultado = miComando.ExecuteNonQuery();
            }
            catch (SqlException sql) { throw sql; }

            return (resultado);
        }//fin guardarPersonaDAL

        public int eliminarPersonaDAL(int id)
        {
            clsConnection miConexion = new clsConnection();
            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();

            int filasAfectadas = 0;

            SqlParameter param;
            param = new SqlParameter();
            param.ParameterName = "@id";
            param.SqlDbType = System.Data.SqlDbType.Int;
            param.Value = id;

            //Le damos al comando el paramentro
            miComando.Parameters.Add(param);

            try
            {
                conexion = miConexion.conexion;
                miComando.CommandText = "Delete From Personas where IDPERSONA=@id";
                miComando.Connection = conexion; //no olvides esto
                filasAfectadas = miComando.ExecuteNonQuery();

            }
            catch (Exception e) { throw e; }
            
            return filasAfectadas;

        }

        /// <summary>
        /// este metodo inserta una nueva persona
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public int crearPersonaDAL(clsPersona persona)
        {
            clsConnection miConexion = new clsConnection();
            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();

            int resultado = 0;
            
            miComando.Parameters.Add("@IDPERSONA", System.Data.SqlDbType.Int).Value = persona.IdPersona;
            miComando.Parameters.Add("@NOMBRE", System.Data.SqlDbType.VarChar).Value = persona.Nombre;
            miComando.Parameters.Add("@APELLIDO", System.Data.SqlDbType.VarChar).Value = persona.Apellido;
            //miComando.Parameters.Add("@FECHANACIMIENT", System.Data.SqlDbType.DateTime).Value = persona.FechaNac;
            miComando.Parameters.Add("@DIRECCION", System.Data.SqlDbType.VarChar).Value = persona.Direccion;
            miComando.Parameters.Add("@TELEFONO", System.Data.SqlDbType.VarChar).Value = persona.Telefono;

            try
            {
                conexion = miConexion.conexion;
                //Insertamos los datos de la persona en la base de datos
                miComando.CommandText = "INSERT INTO PERSONAS (IDPERSONA, NOMBRE,APELLIDO,DIRECCION,TELEFONO) VALUES (@IDPERSONA, @NOMBRE, @APELLIDO," +
                                        " @DIRECCION, @TELEFONO)";
                miComando.Connection = conexion;

                //ejecutamos el comando de actualizar
                resultado = miComando.ExecuteNonQuery();

                conexion.Close();
            }
            catch (SqlException sql) { throw sql; }

            return (resultado);
        }//fin guardarPersonaDAL


        public void updatePersona(clsPersona p)
        {
            clsConnection cx = new clsConnection();
            SqlCommand consulta = new SqlCommand();
            SqlParameter nombre = new SqlParameter();
            SqlParameter apellidos = new SqlParameter();
            SqlParameter id = new SqlParameter();
            SqlParameter idDepartamento = new SqlParameter();
            SqlParameter direccion = new SqlParameter();
            SqlParameter telefono = new SqlParameter();
            try
            {
                nombre.ParameterName = "@nombre";
                nombre.SqlDbType = System.Data.SqlDbType.NVarChar;
                nombre.Value = p.Nombre;

                idDepartamento.ParameterName = "@idDepartamento";
                idDepartamento.SqlDbType = System.Data.SqlDbType.Int;
                idDepartamento.Value = p.idDepartamento;

                apellidos.ParameterName = "@apellidos";
                apellidos.SqlDbType = System.Data.SqlDbType.NVarChar;
                apellidos.Value = p.Apellido;

                direccion.ParameterName = "@direccion";
                direccion.SqlDbType = System.Data.SqlDbType.NVarChar;
                direccion.Value = p.Direccion;

                telefono.ParameterName = "@telefono";
                telefono.SqlDbType = System.Data.SqlDbType.Char;
                telefono.Value = p.Telefono;

                id.ParameterName = "@id";
                id.SqlDbType = System.Data.SqlDbType.Int;
                id.Value = p.IdPersona;

                consulta.Parameters.Add(nombre);
                consulta.Parameters.Add(apellidos);
                consulta.Parameters.Add(direccion);
                consulta.Parameters.Add(telefono);
                consulta.Parameters.Add(id);
                consulta.Parameters.Add(idDepartamento);
                consulta.CommandText = "Update Personas Set Nombre=@nombre, Apellidos=@apellidos, Direccion=@direccion, Telefono=@telefono, ID_Departamento=@idDepartamento WHERE ID=@id";
                consulta.Connection = cx.conexion;
                consulta.ExecuteNonQuery();
                cx.closeConnection();
            }
            catch (SqlException e)
            {
                throw e;   
            }
        }

    }
}
