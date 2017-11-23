using _18_Practica_Examen.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace _18_Practica_Examen.Models
{
    public class ListadoPersona
    {
        /// <summary>
        /// Metodo de instaPersonas que crea y añade personas a la lista de personas
        /// Y retorna esa lista
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<clsPersona> instaPersonas()
        {
            ObservableCollection<clsPersona> personaslist = new ObservableCollection<clsPersona>();

            clsPersona persona1 = new clsPersona(1, "Maria", "Sanchez", DateTime.Now, "Calle Ejemplo, 20, 41005, Sevilla", "287423");
            clsPersona persona2 = new clsPersona(2, "José", "Gomez", DateTime.Now, "Calle Ejemplo, 20, 41005, Sevilla", "287423");
            clsPersona persona3 = new clsPersona(3,"Luis","Sanchez",DateTime.Now, "Calle Ejemplo, 20, 41005, Sevilla","287423");
            clsPersona persona4 = new clsPersona(4, "Juan", "Martinez", DateTime.Now, "Calle Ejemplo, 20, 41005, Sevilla", "235423");
            clsPersona persona5 = new clsPersona(5, "Gabriel", "González", DateTime.Now, "Calle Ejemplo, 20, 41005, Sevilla", "235423");
            clsPersona persona6 = new clsPersona(6, "ginés", "Sevilla", DateTime.Now, "Calle Ejemplo, 20, 41005, Sevilla", "235423");
           
            personaslist.Add(persona1);
            personaslist.Add(persona2);
            personaslist.Add(persona3);
            personaslist.Add(persona4);
            personaslist.Add(persona5);
            personaslist.Add(persona6);
            return personaslist;
         }


        
    }
}