﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _17_ListadoPersonaCommandBar.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml;
using _17_ListadoPersonaCommandBar.ViewModels;

namespace _17_ListadoPersonaCommandBar.ViewModels
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
            ListadoPersona mlistPersona = new ListadoPersona();
            _mListadoColecPersons = mlistPersona.instaPersonas();
            //_mPersonasIntantactas = mListadoColecPersons;
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

        public DelegateCommand cmdSearch
        {
            get
            {
                _cmdSearch = new DelegateCommand(ExecuteSearch);
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

        public bool CanExecuteSearch()
        {
            return !String.IsNullOrWhiteSpace(textoABuscar);
        }

        public void ExecuteSearch()
        {
            _mListadoColecPersons = mPersonasIntantactas;
            if (!String.IsNullOrWhiteSpace(textoABuscar))
            {
                mPersonasFiltradas = new ObservableCollection<clsPersona>();
                for (int i = 0; i < mListadoColecPersons.Count; i++)
                {
                    if ((mListadoColecPersons.ElementAt(i).Nombre.ToLower().Contains(textoABuscar)) ||
                        (mListadoColecPersons.ElementAt(i).Apellido.ToLower().Contains(textoABuscar)))
                    {
                        mPersonasFiltradas.Add(mListadoColecPersons.ElementAt(i));
                        //_mListadoColecPersons.Remove(mListadoColecPersons.ElementAt(i));
                    }
                }
                _mListadoColecPersons = mPersonasFiltradas;
                NotifyPropertyChanged("mListadoColecPersons"); 
            }
            
        }

        public void ExecuteDelete()
        {
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
            _personSeleccionada.IdPersona = mListadoColecPersons.ElementAt(mListadoColecPersons.Count() - 1).IdPersona - 1;
            NotifyPropertyChanged("personSeleccionada");
            mListadoColecPersons.Add(_personSeleccionada);
            NotifyPropertyChanged("mListadoColecPersons");
        }

    }
}

