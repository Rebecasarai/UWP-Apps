using System;
using System.Collections.Generic;
using System.Linq;


namespace _08___Grid_Layouts_and_Date.Models
{
    public class clsPersona
    {
        //Propiedades
        public int idPersona { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public DateTime fechaNac { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        
        //Constructor por defecto
        /*public clsPersona(int idPersona, string nombre, string apellidos, DateTime fechaNac, string direccion,
            string telefono)
        {
            this.idPersona = idPersona;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.fechaNac = fechaNac;
            this.direccion = direccion;
            this.telefono = telefono;
        }*/
        public clsPersona()
        {
            this.idPersona = 1;
            this.nombre = "Rebeca";
            this.apellidos = "Gonzalez";
            this.fechaNac = DateTime.Now;
            this.direccion = "Calle";
            this.telefono = "5873485746";

        }

    }

}