using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _15_BindingConDatacontextPersona.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml;
using BindingPersonaListaPersonaConDataContext.ViewModels;

namespace _15_BindingConDatacontextPersona.ViewModels
{
    public class MainPageVM: clsVMBase
    {
        #region "Atributos"
        public clsPersona _personSeleccionada;
        public ObservableCollection<clsPersona> _mListadoColecPersons;
        private string _search;
        private DelegateCommand _delete;
        private DelegateCommand _addPersona;
        private DelegateCommand _savePersona;
        private DelegateCommand _searchPersona;

        #endregion

        #region "constructor"
        public MainPageVM()
        {
            ListadoPersona mlistPersona = new ListadoPersona();
            _mListadoColecPersons = mlistPersona.instaPersonas();
        }
        #endregion


        #region "Propiedades públicas"
        public DelegateCommand delete
        {
            get
            {
                _delete = new DelegateCommand(ExecuteDelete, CanExecuteDelete);
                return _delete;
            }

            set
            {
                _delete = value;
            }
        }
        public string search
        {
            get
            {
                return _search;
            }

            set
            {
                _search = value;
            }
        }
        public DelegateCommand addPersona
        {
            get
            {
                _addPersona = new DelegateCommand(ExecuteAddPersona);
                return _addPersona;
            }
            set
            {
                _addPersona = value;
            }
        }
        public DelegateCommand savePersona
        {
            get
            {
                _savePersona = new DelegateCommand(ExecuteSavePersona);
                return _savePersona;
            }
            set
            {
                _savePersona = value;
            }
        }
        public ObservableCollection<clsPersona> mListadoColecPersons
        {
            get { return _mListadoColecPersons; }
        }
        public clsPersona personSeleccionada
        {
            get { return _personSeleccionada; }
            set
            {
                _personSeleccionada = value;
                _delete.RaiseCanExecuteChanged();
                _savePersona.RaiseCanExecuteChanged();
                //Notificación de cambio a la vista
                NotifyPropertyChanged("_personSeleccionada");
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
        public void ExecuteAddPersona()
        {
            _personSeleccionada = new clsPersona();
            NotifyPropertyChanged("_personSeleccionada");
        }
<<<<<<< HEAD
        /// <summary>
        /// eVENTO DEL CLICK, EN vm, NO ES CODIGO BEHIND
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BorrarClick(object sender, RoutedEventArgs e)
=======
        //private bool canExecuteSavePersona()
        //{
        //    bool sePuede = false;
        //    if (_personaSeleccionada != null)
        //    {
        //        sePuede = true;

        //    }
        //    return sePuede;
        //}
        private void ExecuteSavePersona()
>>>>>>> 740e3f811f2665d6c4c7488d0b399a8113fba3d3
        {
            if (_personSeleccionada.IdPersona == 0)
            {
                _personSeleccionada.IdPersona = mListadoColecPersons.ElementAt(mListadoColecPersons.Count - 1).IdPersona + 1;
                NotifyPropertyChanged("personSeleccionada");
                mListadoColecPersons.Add(_personSeleccionada);
                NotifyPropertyChanged("listado");
            }
        }

    }
}