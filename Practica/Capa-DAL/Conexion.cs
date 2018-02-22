using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_DAL
{
    public class Conexion
    {
        private Uri api;
        private Uri _photosApi;
        public SqlConnection con { get; }


        public Conexion()
        {
            api = new Uri("https://swapi.co/api/planets");
            _photosApi = new Uri("https://jsonplaceholder.typicode.com/photos");

            this.con = new SqlConnection();
            this.con.ConnectionString = string.Format("DESKTOP-V62RJ47");
            this.con.Open();

        }

        public Uri Api
        {
            get
            {
                return api;
            }
        }

        public Uri photosApi
        {
            get
            {
                return _photosApi;
            }
        }

        public void closeCon()
        {
            this.con.Close();
        }

    }
}