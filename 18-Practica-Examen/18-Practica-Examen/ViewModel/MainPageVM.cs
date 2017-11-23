
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
        private Categoria _categoriaSeleccionada;
        private ObservableCollection<Categoria> _mListadoCategoria;
        private ObservableCollection<Categoria> _mCategoriasIntactas;
        private String textABuscar;
        private DelegateCommand _cmdSearch;
        private clsPersona _personSeleccionada;


        #region "constructor"
        public MainPageVM()
        {
            ListadoCategoria mlistCategoria = new ListadoCategoria();
            _mListadoCategoria = mlistCategoria.instaCategorias();
            _mCategoriasIntactas = _mListadoCategoria;
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


        public clsPersona personSeleccionada
        {
            get { return _personSeleccionada; }
            set
            {
                _personSeleccionada = value;
                //Notificación a la vista
                NotifyPropertyChanged("personSeleccionada");
            }
        }

        #endregion



    }
}
