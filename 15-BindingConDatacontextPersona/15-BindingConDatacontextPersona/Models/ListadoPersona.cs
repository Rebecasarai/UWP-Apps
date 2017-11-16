using System;
using System.Collections.Generic;
using _15_BindingConDatacontextPersona.Models;
using System.Collections.ObjectModel;

namespace _15_BindingConDatacontextPersona.Models
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
            clsPersona persona6 = new clsPersona(6, "Ginés", "Sevilla", DateTime.Now, "Calle Ejemplo, 20, 41005, Sevilla", "235423");
            clsPersona persona7 = new clsPersona(7, "José", "Gomez", DateTime.Now, "Calle Ejemplo, 20, 41005, Sevilla", "287423");
            clsPersona persona8 = new clsPersona(8, "Luis", "Sanchez", DateTime.Now, "Calle Ejemplo, 20, 41005, Sevilla", "287423");
            clsPersona persona9 = new clsPersona(9, "Juan", "Martinez", DateTime.Now, "Calle Ejemplo, 20, 41005, Sevilla", "235423");
            clsPersona persona10 = new clsPersona(10, "Gabriel", "González", DateTime.Now, "Calle Ejemplo, 20, 41005, Sevilla", "235423");
            clsPersona persona11 = new clsPersona(11, "Ginés", "Sevilla", DateTime.Now, "Calle Ejemplo, 20, 41005, Sevilla", "235423");

            personaslist.Add(persona1);
            personaslist.Add(persona2);
            personaslist.Add(persona3);
            personaslist.Add(persona4);
            personaslist.Add(persona5);
            personaslist.Add(persona6);
            personaslist.Add(persona7);
            personaslist.Add(persona8);
            personaslist.Add(persona9);
            personaslist.Add(persona10);
            personaslist.Add(persona11);
            return personaslist;
         }
        
    }
}