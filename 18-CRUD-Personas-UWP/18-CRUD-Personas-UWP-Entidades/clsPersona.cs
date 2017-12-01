using _18_CRUD_Personas_UWP_UI;
using _18_CRUD_Personas_UWP_UI.ViewModels;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace _18_CRUD_Personas_UWP_UI.Models
{
    public class clsPersona: clsVMBase
    {
        //Propiedades
        private string _nombre;
        private String _apellido;
        private String _direccion;
        private String _telefono;
        private int _idPersona;
        private DateTime _fechaNac;
        private int _idDepartamento;
        public string Nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
                NotifyPropertyChanged("Nombre");
            }
        }
        public string Apellido
        {
            get
            {
                return _apellido;
            }
            set
            {
                _apellido = value;
                NotifyPropertyChanged("Apellido");
            }
        }
        public string Direccion
        {
            get
            {
                return _direccion;
            }
            set
            {
                _direccion = value;
                NotifyPropertyChanged("Direccion");
            }
        }
        public string Telefono
        {
            get
            {
                return _telefono;
            }
            set
            {
                _telefono = value;
                NotifyPropertyChanged("Telefono");
            }
        }
        public int IdPersona
        {
            get
            {
                return _idPersona;
            }
            set
            {
                _idPersona = value;
                NotifyPropertyChanged("IdPersona");
            }
        }
        public DateTime FechaNac
        {
            get
            {
                return _fechaNac;
            }
            set
            {
                _fechaNac = value;
                NotifyPropertyChanged("FechaNac");
            }
        }
        public int IdDepartamento
        {
            get
            {
                return _idDepartamento;
            }
            set
            {
                _idDepartamento = value;
                NotifyPropertyChanged("IdDepartamento");
            }
        }
        
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        /// <param name="idPersona"></param>
        /// <param name="nombre"></param>
        /// <param name="apellidos"></param>
        /// <param name="fechaNac"></param>
        /// <param name="direccion"></param>
        /// <param name="telefono"></param>
        public clsPersona(int idPersona, string nombre, string apellidos, DateTime fechaNac, string direccion,
            string telefono)
        {
            this.IdPersona = idPersona;
            this.Nombre = nombre;
            this.Apellido = apellidos;
            this.FechaNac = fechaNac;
            this.Direccion = direccion;
            this.Telefono = telefono;
        }
        public clsPersona()
        {
        }

        public clsPersona(int idPersona, string nombre, string apellidos, DateTime fechaNac, string direccion, string telefono, int idDepartamento)
        {
            this.IdPersona = idPersona;
            this.Nombre = nombre;
            this.Apellido = apellidos;
            this.FechaNac = fechaNac;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.IdDepartamento = idDepartamento;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


    }

}