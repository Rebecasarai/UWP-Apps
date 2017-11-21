using System;
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
        private DelegateCommand _cmdDelete;
        private DelegateCommand _cmdAdd;
        private DelegateCommand _cmdSave;

        #endregion

        #region "constructor"
        public MainPageVM()
        {
            ListadoPersona mlistPersona = new ListadoPersona();
            _mListadoColecPersons = mlistPersona.instaPersonas();
        }
        #endregion
        #region "Propiedades"
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
        
        #endregion


        #region "Propiedades públicas"
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

