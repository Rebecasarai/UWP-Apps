﻿using System;
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


        private string _txtCronometro;
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


            timer = new DispatcherTimer();
            _segundos = 30;
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        #endregion
        
        #region "Propiedades públicas"
        /// <summary>
        /// Persona seleccionada que utilizaremos para actualizar, crear nueva persona o eliminar.
        /// </summary>
        public clsPersona personSeleccionada
        {
            get { return _personSeleccionada; }
            set {
                _personSeleccionada = value;
                _cmdDelete.RaiseCanExecuteChanged();
                _cmdSave.RaiseCanExecuteChanged();

                //Notificación a la vista
                NotifyPropertyChanged("personSeleccionada");
            }
        }

        /// <summary>
        /// Lista compketa de personas, que carga de la BD. Lista original, de partida, sin filtros.
        /// </summary>
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

        /// <summary>
        /// Lista que será utilizada para mostrar la lista de personas filtrada por la busqueda
        /// </summary>
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

        /// <summary>
        /// Texto a Buscar, String obtenido a través del cuadro de texto
        /// </summary>
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
        /// Delegate que invoca el delegate ExecuteSearch: Metodo que se encarga de buscar en la lista de personas, a través de un cuadro de texto de busqueda
        /// Es llamado al ser presionado el boton "Buscar"
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
        
        /// <summary>
        /// Delegate que se encarga de invocar el metodo ExecuteDelete: Metodo que se encarga de borrar a un persona.
        /// Es llamado al ser presionado el botón "Borrar"
        /// </summary>
        public DelegateCommand cmdDelete
        {
            get
            {
                _cmdDelete = new DelegateCommand(ExecuteDelete, CanExecuteDelete);
                return _cmdDelete;
            }

            set
            {
                _cmdDelete = value;
            }
        }
        /// <summary>
        /// Delegado que invoca al metodo ExecuteAddPersona: Encargado de limpiar los campos a introducir información de la persona, para añadirla a la lista y BD.
        /// Es llamado al ser presionado
        /// </summary>
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

        /// <summary>
        /// Delega el guardar, invocando a ExecuteSave: Encargado de guardar o insertar una nueva persona a la BD.
        /// Es llamado al ser presionado el boton "Guardar"
        /// </summary>
        public DelegateCommand cmdSave
        {
            get
            {
                _cmdSave = new DelegateCommand(ExecuteSave, canExecuteSavePersona);
                return _cmdSave;
            }

            set
            {
                _cmdSave = value;
            }
        }

        public string txtCronometro
        {
            get { return _txtCronometro; }
            set
            {
                _txtCronometro = value;
            }
        }

        #endregion
        /// <summary>
        /// Metodo que permite desactivar o activar el boton de borrar
        /// </summary>
        /// <returns>Booleano, que representa si desactiva o no el boton</returns>
        public bool CanExecuteDelete()
        {
            bool canExecute = false;
            if (_personSeleccionada != null)
            {
                if (!String.IsNullOrEmpty(_personSeleccionada.Nombre))
                {
                    canExecute = true;
                }
                canExecute = true;
            }
            return canExecute;
        }

        /// <summary>
        /// Permite desactivar el boton de buscar al estar en blanco el campo de texto
        /// </summary>
        /// <returns>Booleano buscara, que representa si procede o no</returns>
        public bool CanExecuteSearch()
        {
            bool buscara = false;
            if (!String.IsNullOrEmpty(textoABuscar))
            {
                buscara = true;
            }
            else
            {
                mListaConBusqueda = _mListaCompleta;
                NotifyPropertyChanged("mListaConBusqueda");
            }
            return buscara;
        }

        /// <summary>
        /// Metodo Execute que realiza la busqueda de personas, por nombre, a través de un cuadro de texto
        /// </summary>
        public void ExecuteSearch()
            {
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

        /// <summary>
        /// Metodo Execute que realiza el eliminar a una persona de la BD
        /// </summary>
        public void ExecuteDelete()
        {
            cuadroDelete();
        }

        /// <summary>
        /// Metodo que se encarga de poder añadir la persona nueva, a través de la interfaz.
        /// Es invocado por Delegate cmdAdd
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

        /// <summary>
        /// Metodo que realiza el guardar.
        /// Es invocado atraves de cmdSave, al ser presionado el boton de "Guardar"
        /// </summary>
        private void ExecuteSave()
        {
            if (_personSeleccionada.IdPersona == 0)
            {
                //Añadimos a la BD, a través de la BL
                //Colocar insertar a la tabla
                _personSeleccionada.IdPersona = mListaCompleta.ElementAt(mListaCompleta.Count() - 1).IdPersona - 1;
        
                _manejadoraBL.addPersona(_personSeleccionada);

                mListaCompleta.Add(_personSeleccionada);
                //NotifyPropertyChanged("mListaCompleta");
            }
            else
            {
                _manejadoraBL.updatePersona(_personSeleccionada);
                _mListaCompleta = new ObservableCollection<clsPersona>(_listadoBL.getListadoBL());
                _mListaConBusqueda = mListaCompleta;
                NotifyPropertyChanged("personSeleccionada");
            }

        }

        /// <summary>
        /// Metodo que 
        /// </summary>
        public async void cuadroDelete()
        {
            ContentDialog volverAJugar = new ContentDialog();
            volverAJugar.Title = "Eliminar";
            volverAJugar.Content = $"¿Está seguro de que de que desea eliminar el usuario {_personSeleccionada.Nombre} {_personSeleccionada.Apellido}?";
            volverAJugar.PrimaryButtonText = "Si";
            volverAJugar.SecondaryButtonText = "No";
            ContentDialogResult resultado = await volverAJugar.ShowAsync();
            if (resultado == ContentDialogResult.Primary)
            {
                //Llamamos a la BL para borrar de la BD
                ManejadoraBL manejadorabl = new ManejadoraBL();
                manejadorabl.borrarPersona(_personSeleccionada.IdPersona);

                //Hace el efecto inmediato de que borra de lista
                mListaCompleta.Remove(_personSeleccionada);
                NotifyPropertyChanged("mListaCompleta");
            }

        }
        private void timer_Tick(object sender, object e)
        {
            _segundos--;
            if (_segundos >= 10)
            {
                _txtCronometro = $"0:{_segundos.ToString()}";
                NotifyPropertyChanged("txtCronometro");
            }
            else
            {
                _txtCronometro = $"0:0{_segundos.ToString()}";
                NotifyPropertyChanged("txtCronometro");
            }
            if (_segundos == 0)
            {
                _listadoBL = new ListadoPersonasBL();
                this._mListaCompleta = new ObservableCollection<clsPersona>(_listadoBL.getListadoBL());
                this._mListaConBusqueda = this._mListaCompleta;
                NotifyPropertyChanged("mListaCompleta");
                NotifyPropertyChanged("mListaConBusqueda");
                _segundos = 60;
            }
        }

        private void ExecuteActualizar()
        {
            mListaCompleta = new ObservableCollection<clsPersona>(_listadoBL.getListadoBL());
            mListaConBusqueda = this._mListaCompleta;
            NotifyPropertyChanged("mListaCompleta");
            NotifyPropertyChanged("mListaConBusqueda");
        }
    }
}


