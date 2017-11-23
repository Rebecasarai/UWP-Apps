
using _18_Practica_Examen.Model;
using _18_Practica_Examen.Models;
using _18_Practica_Examen.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_Practica_Examen.ViewModel
{
    class MainPageVM:clsVMBase
    {
        public Categoria _categoriaSeleccionada;
        public ObservableCollection<Categoria> _mListadoCategoria;


        #region "constructor"
        public MainPageVM()
        {

            ListadoCategoria mlistCategoria = new ListadoCategoria();
            _mListadoCategoria = mlistCategoria.instaCategorias();
        }
        #endregion

        #region "Propiedades públicas"

        public Categoria categoriaSeleccionada
        {
            get { return _categoriaSeleccionada; }
            set
            {
                _categoriaSeleccionada = value;
                //Notificación a la vista
                NotifyPropertyChanged("categoriaSeleccionada");
            }
        }

        public ObservableCollection<Categoria> mListadoCategoria
        {
            get { return _mListadoCategoria; }
            set
            {
                _mListadoCategoria = value;
                //Notificación a la vista
                NotifyPropertyChanged("mListadoCategoria");
            }
        }

        #endregion
    }
}
