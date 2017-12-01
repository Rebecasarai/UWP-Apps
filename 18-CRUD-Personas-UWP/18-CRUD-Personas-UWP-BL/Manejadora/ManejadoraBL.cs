using _18_CRUD_Personas_UWP_UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_CRUD_Personas_UWP_BL.Manejadoras
{
    public class ManejadoraBL
    {
        clsPersona mPerson = new clsPersona();


        public clsPersona getPersona(int id)
        {
            clsPersona person = new clsPersona();
            ManejadoraBL manejadoraDAL = new ManejadoraBL();
            manejadoraDAL.getPersona(id);

            return person;
        }

        public int updatePersona(clsPersona p)
        {
            int resultado = 0;
            ManejadoraBL manejadoraDAL = new ManejadoraBL();
            resultado = manejadoraDAL.updatePersonaDAL(p);

            return resultado;
        }

    }

}
