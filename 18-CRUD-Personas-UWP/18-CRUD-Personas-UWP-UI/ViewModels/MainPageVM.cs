using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml;
using _18_CRUD_Personas_UWP_UI.ViewModels;
using _18_CRUD_Personas_UWP_BL.Listados;
using _18_CRUD_Personas_UWP_Entidades;
using _18_CRUD_Personas_UWP_BL.Manejadoras;

namespace _18_CRUD_Personas_UWP_UI.ViewModels
{
    public class MainPageVM : clsVMBase
    {
        #region "Atributos"
        public clsPersona _personSeleccionada;
        public ObservableCollection<clsPersona> _mListadoColecPersons;
        public ObservableCollection<clsPersona> _mPersonasFiltradas = new ObservableCollection<clsPersona>();
        public ObservableCollection<clsPersona> _mPersonasIntantactas;
        private String _textoABuscar;
        
        private DelegateCommand _cmdSearch;
        private DelegateCommand _cmdDelete;
        private DelegateCommand _cmdAdd;
        private DelegateCommand _cmdSave;

        #endregion

        #region "constructor"
        public MainPageVM()
        {
            ListadoPersonasBL listado = new ListadoPersonasBL();
            this._mListadoColecPersons = new ObservableCollection<clsPersona>(listado.getListadoBL());
            this._mPersonasIntantactas = this._mListadoColecPersons;
        }
        #endregion
        
        #region "Propiedades públicas"
        public ObservableCollection<clsPersona> mListadoColecPersons
        {
            get { return _mListadoColecPersons; }
        }
        public clsPersona personSeleccionada
        {
            get { return _personSeleccionada; }
            set {
                _personSeleccionada = value;
                //Notificación a la vista
                NotifyPropertyChanged("personSeleccionada");
            }
        }


        public ObservableCollection<clsPersona> mPersonasFiltradas
        {
            
            get { return _mPersonasFiltradas; }
            set
            {
                _mPersonasFiltradas = value;
                //Notificación a la vista
                NotifyPropertyChanged("mPersonasFiltradas");
            }
        }
        public ObservableCollection<clsPersona> mPersonasIntantactas
        {

            get { return _mPersonasIntantactas; }
            set
            {
                _mPersonasIntantactas = value;
                //Notificación a la vista
                NotifyPropertyChanged("mPersonasIntantactas");
            }
        }

        public String textoABuscar
        {
            get { return _textoABuscar; }
            set
            {
                _textoABuscar = value;
                //Notificación a la vista
                //NotifyPropertyChanged("textoABuscar");
                _cmdSearch.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DelegateCommand cmdSearch
        {
            get
            {
                _cmdSearch = new DelegateCommand(ExecuteSearch, CanExecuteSearch);
                return _cmdSearch;
            }

            set
            {
                _cmdSearch = value;
            }
        }
        
        public DelegateCommand cmdDelete
        {
            get
            {
                _cmdDelete = new DelegateCommand(ExecuteDelete);
                return _cmdDelete;
            }

            set
            {
                _cmdDelete = value;
            }
        }
        public DelegateCommand cmdAdd
        {
            get
            {
                _cmdAdd = new DelegateCommand(ExecuteAddPersona);
                return _cmdAdd;
            }

            set
            {
                _cmdAdd = value;
            }
        }
        public DelegateCommand cmdSave
        {
            get
            {
                _cmdSave = new DelegateCommand(ExecuteSavePersona);
                return _cmdSave;
            }

            set
            {
                _cmdSave = value;
            }
        }
        #endregion
        public bool CanExecuteDelete()
        {
            bool canExecute = false;
            if (_personSeleccionada != null)
            {
                canExecute = true;
            }
            return canExecute;
        }
        /// <summary>
        /// Si va a buscar o no
        /// </summary>
        /// <returns></returns>
        public bool CanExecuteSearch()
        {
            bool puede= false;
            if (!String.IsNullOrWhiteSpace(textoABuscar))
            {
                puede = true;
            }
            //Si es nulo o vacio, al volver despues de borrar, recargue la lista
            //Al igual que si es la primera vez cargando la lista
            else
            {
                _mListadoColecPersons = mPersonasIntantactas;
                NotifyPropertyChanged("mListadoColecPersons");
            }
            return puede;
        }
        /// <summary>
        /// Al ejecutarse la busqueda
        /// </summary>
        public void ExecuteSearch()
        {
            //_mListadoColecPersons = mPersonasIntantactas;
            
            //Listado para buscar LAMBDA EXPRESION TO SEARCH
            //LINQ expresion para buscar

                mPersonasFiltradas = new ObservableCollection<clsPersona>();
                for (int i = 0; i < mListadoColecPersons.Count; i++)
                {
                    if ((mListadoColecPersons.ElementAt(i).Nombre.ToLower().StartsWith(textoABuscar)) ||
                        (mListadoColecPersons.ElementAt(i).Apellido.ToLower().StartsWith(textoABuscar)))
                    {
                        mPersonasFiltradas.Add(mListadoColecPersons.ElementAt(i));
                    }
                }
                _mListadoColecPersons = mPersonasFiltradas;
            
            NotifyPropertyChanged("mListadoColecPersons");
        }

        public void ExecuteDelete()
        {
            //Llamamos a la BL para borrar de la BD
            ManejadoraBL manejadorabl = new ManejadoraBL();
            manejadorabl.borrarPersona(_personSeleccionada.IdPersona);
            //eliminamos del List
            mListadoColecPersons.Remove(_personSeleccionada);
            NotifyPropertyChanged("mListadoColecPersons");
        }
        /// <summary>
        /// Se añade una nueva persona
        /// </summary>
        public void ExecuteAddPersona()
        {
            _personSeleccionada = new clsPersona();
            NotifyPropertyChanged("personSeleccionada");
            
        }
        private bool canExecuteSavePersona()
        {
            bool sePuede = false;
            if (_personSeleccionada != null)
            {
                sePuede = true;
            }
            return sePuede;
        }
        private void ExecuteSavePersona()
        {
            //Añadimos a la BD, a través de la BL
            ManejadoraBL manejadoraBL = new ManejadoraBL();
            manejadoraBL.addPersona(_personSeleccionada);
            //Colocar insertar a la tabla
            _personSeleccionada.IdPersona = mListadoColecPersons.ElementAt(mListadoColecPersons.Count() - 1).IdPersona - 1;
            NotifyPropertyChanged("personSeleccionada");
            mListadoColecPersons.Add(_personSeleccionada);
            NotifyPropertyChanged("mListadoColecPersons");


        }

    }
}

