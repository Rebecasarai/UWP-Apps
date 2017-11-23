
using _18_Practica_Examen.Models;
using _18_Practica_Examen.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_Practica_Examen.Model
{
    public class Categoria: clsVMBase
    {
        //Atributos
        private String _nombre;
        private Uri _imagen;
        private ObservableCollection<clsPersona> _vendedores;

        public Categoria(string nombre, Uri imagen, ObservableCollection<clsPersona> vendedores)
        {
            this.nombre = nombre;
            this.imagen = imagen;
            this.vendedores = vendedores;
        }

        public string nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
                NotifyPropertyChanged("nombre");
            }
        }

        public Uri imagen
        {
            get
            {
                return _imagen;
            }
            set
            {
                _imagen = value;
                NotifyPropertyChanged("imagen");
            }
        }

        public ObservableCollection<clsPersona> vendedores
        {
            get
            {
                return _vendedores;
            }
            set
            {
                _vendedores = value;
                NotifyPropertyChanged("vendedores");
            }
        }
    }
}
