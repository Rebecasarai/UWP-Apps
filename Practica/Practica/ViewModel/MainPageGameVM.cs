using Entidades;
using Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace Practica.ViewModel
{
    public class MainPageGameVM : clsVMBase
    {
        #region Atributos
        private String _puntaje;
        private ObservableCollection<Planeta> _mListaPlanetas;

        #endregion
        #region contructor
        public MainPageGameVM()
        {



        }


        #endregion

        #region Propiedades Publicas

        public string puntaje
        {

            set
            {
                _puntaje = value;
                NotifyPropertyChanged("puntaje");
            }
            get
            {
                return _puntaje;
            }
        }



        public ObservableCollection<Planeta> mListaPlanetas
        {

            set
            {
                _mListaPlanetas = value;
                NotifyPropertyChanged("mListaPlanetas");
            }
            get
            {
                return _mListaPlanetas;
            }
        }
    }
}

