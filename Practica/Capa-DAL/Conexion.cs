using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_DAL
{
    public class Conexion
    {
        private Uri api;


        public Conexion()
        {
            api = new Uri("https://swapi.co/api/planets");
        }

        public Uri Api
        {
            get
            {
                return api;
            }
        }

    }
}