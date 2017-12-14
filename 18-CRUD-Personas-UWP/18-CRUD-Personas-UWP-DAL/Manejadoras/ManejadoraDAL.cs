
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
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
                miComando.CommandText = "Delete From PersonasBD where ID=@id";
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

            //miComando.Parameters.Add("@IDPERSONA", System.Data.SqlDbType.Int).Value = persona.IdPersona;
            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = persona.Nombre;
            miComando.Parameters.Add("@apellido", System.Data.SqlDbType.VarChar).Value = persona.Apellido;
            miComando.Parameters.Add("@fechanacimient", System.Data.SqlDbType.DateTime2).Value = persona.FechaNac;
            miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = persona.Direccion;
            miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = persona.Telefono;

            try
            {
                conexion = miConexion.conexion;
                //Insertamos los datos de la persona en la base de datos
                miComando.CommandText = "INSERT INTO PERSONASBD (NOMBRE,APELLIDO,DIRECCION,TELEFONO, FECHANACIMIENT) VALUES (@nombre, @apellido," +
                                        " @direccion, @telefono, @fechanacimient)";
                miComando.Connection = conexion;

                //ejecutamos el comando de actualizar
                resultado = miComando.ExecuteNonQuery();

                conexion.Close();
            }
            catch (SqlException sql) { throw sql; }

            return (resultado);
        }//fin crearPersonaDAL

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
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
            SqlParameter fechanacimient = new SqlParameter();
            try
            {
                nombre.ParameterName = "@nombre";
                nombre.SqlDbType = System.Data.SqlDbType.NVarChar;
                nombre.Value = p.Nombre;

                idDepartamento.ParameterName = "@iddepartamento";
                idDepartamento.SqlDbType = System.Data.SqlDbType.Int;
                idDepartamento.Value = p.idDepartamento;

                apellidos.ParameterName = "@apellido";
                apellidos.SqlDbType = System.Data.SqlDbType.NVarChar;
                apellidos.Value = p.Apellido;

                direccion.ParameterName = "@direccion";
                direccion.SqlDbType = System.Data.SqlDbType.NVarChar;
                direccion.Value = p.Direccion;

                telefono.ParameterName = "@telefono";
                telefono.SqlDbType = System.Data.SqlDbType.Char;
                telefono.Value = p.Telefono;

                id.ParameterName = "@fechanacimient";
                id.SqlDbType = System.Data.SqlDbType.DateTime2;
                id.Value = p.FechaNac;

                id.ParameterName = "@id";
                id.SqlDbType = System.Data.SqlDbType.Int;
                id.Value = p.IdPersona;
                

                consulta.Parameters.Add(nombre);
                consulta.Parameters.Add(apellidos);
                consulta.Parameters.Add(direccion);
                consulta.Parameters.Add(telefono);
                consulta.Parameters.Add(id);
                consulta.Parameters.Add(idDepartamento);
                consulta.CommandText = "Update PersonasBD Set nombre=@nombre, apellido=@apellido, direccion=@direccion, telefono=@telefono, iddepartamento=@iddepartamento WHERE id=@id";
                consulta.Connection = cx.conexion;
                consulta.ExecuteNonQuery();
                cx.closeConnection();
            }
            catch (SqlException e)
            {
                throw e;
            }
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
