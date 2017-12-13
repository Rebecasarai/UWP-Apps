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
using Windows.UI.Xaml.Controls;

namespace _18_CRUD_Personas_UWP_UI.ViewModels
{
    public class MainPageVM : clsVMBase
    {
        #region "Atributos"
        private clsPersona _personSeleccionada;
        private ObservableCollection<clsPersona> _mListaCompleta;
        private ObservableCollection<clsPersona> _mListaConBusqueda; /*= new ObservableCollection<clsPersona>();*/
        //public ObservableCollection<clsPersona> _mPersonasIntantactas;
        private String _textoABuscar;
        
        private DelegateCommand _cmdSearch;
        private DelegateCommand _cmdDelete;
        private DelegateCommand _cmdAdd;
        private DelegateCommand _cmdSave;

        private ManejadoraBL _manejadoraBL;
        private ListadoPersonasBL _listadoBL;


        private string _textoReloj;
        private DispatcherTimer timer;
        private int _segundos;
        #endregion

        #region "constructor"
        public MainPageVM()
        {
            _manejadoraBL = new ManejadoraBL();
            _listadoBL = new ListadoPersonasBL();
            this._mListaCompleta = new ObservableCollection<clsPersona>(_listadoBL.getListadoBL());
            this._mListaConBusqueda = this._mListaCompleta;
            //this._mPersonasIntantactas = this._mListadoColecPersons;
        }
        #endregion
        
        #region "Propiedades públicas"
        public clsPersona personSeleccionada
        {
            get { return _personSeleccionada; }
            set {
                _personSeleccionada = value;
                //Notificación a la vista
                NotifyPropertyChanged("personSeleccionada");
            }
        }

        public ObservableCollection<clsPersona> mListaCompleta
        {

            get { return _mListaCompleta; }
            set
            {
                _mListaCompleta = value;
                //Notificación a la vista
                NotifyPropertyChanged("mListaCompleta");
            }
        }

        public ObservableCollection<clsPersona> mListaConBusqueda
        {
            get { return _mListaConBusqueda; }
            set
            {
                _mListaConBusqueda = value;
                //Notificación a la vista
                NotifyPropertyChanged("mListaConBusqueda");
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
                _cmdSave = new DelegateCommand(ExecuteSave);
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
                if (!String.IsNullOrEmpty(_personSeleccionada.Nombre))
                {
                    canExecute = true;
                }

            }
            return canExecute;
        }
        /// <summary>
        /// Permite desactivar el boton de buscar al estar en blanco el campo de texto
        /// </summary>
        /// <returns></returns>
    public bool CanExecuteSearch()
    {
        bool buscado = false;
        if (!String.IsNullOrEmpty(textoABuscar))
        {
            buscado = true;
        }
        else
        {
            
            mListaConBusqueda = _mListaCompleta;
            NotifyPropertyChanged("mListaConBusqueda");
        }
        return buscado;
    }
    /// <summary>
    /// Al ejecutarse la busqueda
    /// </summary>
    public void ExecuteSearch()
        {
            //_mListadoColecPersons = mPersonasIntantactas;

            //Listado para buscar LAMBDA EXPRESION TO SEARCH
            //LINQ expresion para buscar

            mListaConBusqueda = new ObservableCollection<clsPersona>();
            NotifyPropertyChanged("mListaConBusqueda");
                for (int i = 0; i < mListaCompleta.Count; i++)
                {
                    if ((mListaCompleta.ElementAt(i).Nombre.ToLower().Contains(textoABuscar)) ||
                        (mListaCompleta.ElementAt(i).Apellido.ToLower().Contains(textoABuscar)))
                    {
                        mListaConBusqueda.Add(mListaCompleta.ElementAt(i));
                    }
                }
            //_mListaCompleta = mListaConBusqueda;
            
            NotifyPropertyChanged("mListaConBusqueda");
        }

        public void ExecuteDelete()
        {
            //Llamamos a la BL para borrar de la BD
            ManejadoraBL manejadorabl = new ManejadoraBL();
            manejadorabl.borrarPersona(_personSeleccionada.IdPersona);

            //Hace el efecto inmediato de que borra de lista
            //eliminamos del List
            mListaCompleta.Remove(_personSeleccionada);
            NotifyPropertyChanged("mListaCompleta");
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
            bool proceder = false;
            if (_personSeleccionada != null)
            {
                proceder = true;
            }
            return proceder;
        }

        private void ExecuteSave()
        {
            if (_personSeleccionada.IdPersona == 0)
            {
                //Añadimos a la BD, a través de la BL
                //Colocar insertar a la tabla
                _personSeleccionada.IdPersona = mListaCompleta.ElementAt(mListaCompleta.Count() - 1).IdPersona - 1;
        
                _manejadoraBL.addPersona(_personSeleccionada);

                mListaCompleta.Add(_personSeleccionada);
                NotifyPropertyChanged("mListaCompleta");
            }
            else
            {
                //_manejadoraBL.updatePersona(_personSeleccionada);
                _mListaCompleta = new ObservableCollection<clsPersona>(_listadoBL.getListadoBL());
                _mListaConBusqueda = mListaCompleta;
                NotifyPropertyChanged("personSeleccionada");
            }

        }
        public async void mostrarSeguroDelete()
        {
            ContentDialog volverAJugar = new ContentDialog();
            volverAJugar.Title = "Eliminar";
            volverAJugar.Content = $"¿Está seguro de que de que desea eliminar el usuario {_personSeleccionada.Nombre} {_personSeleccionada.Apellido}?";
            volverAJugar.PrimaryButtonText = "Si";
            volverAJugar.SecondaryButtonText = "No";
            ContentDialogResult resultado = await volverAJugar.ShowAsync();
            if (resultado == ContentDialogResult.Primary)
            {
                _manejadoraBL.borrarPersona(_personSeleccionada.IdPersona);
                _mListaCompleta = new ObservableCollection<clsPersona>(_listadoBL.getListadoBL());
                _mListaConBusqueda = mListaCompleta; //No borra la persona seleccionada en el listado original, dnt know why
                //NotifyPropertyChanged("listado");
                //NotifyPropertyChanged("listadoAux");
            }

        }
        private void timer_Tick(object sender, object e)
        {
            _segundos--;
            if (_segundos >= 10)
            {
                _textoReloj = $"0:{_segundos.ToString()}";
                NotifyPropertyChanged("textoReloj");
            }
            else
            {
                _textoReloj = $"0:0{_segundos.ToString()}";
                NotifyPropertyChanged("textoReloj");
            }
            if (_segundos == 0)
            {
                _listadoBL = new ListadoPersonasBL();
                this._mListaCompleta = new ObservableCollection<clsPersona>(_listadoBL.getListadoBL());
                this._mListaConBusqueda = this._mListaCompleta;
                NotifyPropertyChanged("mListaCompleta");
                NotifyPropertyChanged("mListaConBusqueda");
                _segundos = 30;
            }
        }
    }
}


