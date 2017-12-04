using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

// Esta clase contiene los métodos necesarios para trabajar con el acceso a una base de datos SQL Server
//PROPIEDADES
//   _server: cadena 
//   _database: cadena, básica. Consultable/modificable.
//   _user: cadena, básica. Consultable/modificable.
//   _pass: cadena, básica. Consultable/modificable.

// MÉTODOS
//   Function getConnection() As SqlConnection
//       Este método abre una conexión con la base de datos. Lanza excepciones de tipo: SqlExcepion, InvalidOperationException y Exception.
//   
//   Sub closeConnection(ByRef connection As SqlConnection)
//       Este método cierra una conexión con la base de datos. Lanza excepciones de tipo: SqlExcepion, InvalidOperationException y Exception.
//


namespace _18_CRUD_Personas_UWP_DAL.Conexion
{
    public class clsConnection { 


        public String dataBase { get; set; }
        public String user { get; set; }
        public String pass { get; set; }
        public SqlConnection conexion { get; }
    
        public clsConnection()
        {
            this.dataBase = "Personas";
            //El primer usuario es de de la base de datos del instituto, el segundo la de casa
            this.user = "rsgonzalez";
            //this.user = "pruebaResident";
            this.pass = "IwRmGaM-23";
            this.conexion = new SqlConnection();
            try
            {
                //connection.ConnectionString = "Data Source=" & My.Computer.Name & "Initial Catalog=" & _database & ";uid=" & _user & ";pwd=" & _user & ";"
                //connection.ConnectionString = "server=(local);database=" + dataBase + ";uid=" + user + ";pwd=" + pass + ";";
                //Muy cómoda esta forma de escribir la cadena conStringFormat, metiendo los parametros entre llaves y asignandoselo tras la coma
                this.conexion.ConnectionString = string.Format($"server=personasdb.database.windows.net;database={dataBase};uid={user};pwd={pass};");
                this.conexion.Open();
            }
            catch (SqlException)
            {
                throw;
            }

        }
        //Con parámetros por si quisiera cambiar las conexiones
        public clsConnection(String database, String user, String pass)
        {
            this.dataBase = database;
            this.user = user;
            this.pass = pass;
            this.conexion = new SqlConnection();
            try
            {
                //connection.ConnectionString = "Data Source=" & My.Computer.Name & "Initial Catalog=" & _database & ";uid=" & _user & ";pwd=" & _user & ";"
                //connection.ConnectionString = "server=(local);database=" + dataBase + ";uid=" + user + ";pwd=" + pass + ";";
                //Muy cómoda esta forma de escribir la cadena conStringFormat, metiendo los parametros entre llaves y asignandoselo tras la coma
                this.conexion.ConnectionString = string.Format("server=personasdbserver2.database.windows.net;database={0};uid={1};pwd={2};", dataBase, user, pass);
                this.conexion.Open();
            }
            catch (SqlException)
            {
                throw;
            }
        }

        //METODOS

        /// <summary>
        /// Método que abre una conexión con la base de datos
        /// </summary>
        /// <pre>Nada.</pre>
        /// <returns>Una conexión con la base de datso</returns>
       /* public SqlConnection getConnection()
        {
            SqlConnection connection = new SqlConnection();
            try
            {
                //connection.ConnectionString = string.Format("server={0};database={1};uid={2};pwd={3};", server, dataBase, user, pass);
                connection.ConnectionString = $"server={server};database={dataBase};uid={user};pwd={pass};";
                connection.Open();
            }
            catch (SqlException)
            {
                throw;
            }

            return connection;

        }*/

        /// <summary>
        /// Este metodo cierra una conexión con la Base de datos
        /// </summary>
        /// <post>The connection is closed.</post>
        /// <param name="connection">La entrada es la conexión a cerrar
        /// </param>
        public void closeConnection()
        {
            try
            {
                this.conexion.Close();
            }
            catch (SqlException)
            {
                throw;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }

}
