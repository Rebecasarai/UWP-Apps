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

namespace _15_BindingConDatacontextPersona.ViewModels
{
    public class MainPageVM: INotifyPropertyChanged
    {
        #region "Atributos"
        public clsPersona _personSeleccionada;
        public ObservableCollection<clsPersona> _mListadoColecPersons;
        public int _indiceDePersonaSelec;

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

        public int indiceDePersonaSelec
        {
            get { return _indiceDePersonaSelec; }
            set
            {
                _indiceDePersonaSelec = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        /// <summary>
        /// Notifica los cambios
        /// </summary>
        /// <param name="propertyName"></param>
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public static implicit operator MainPageVM(MainPage v)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Evento de click en icono guardar, aquí en VM. No es codigo Behind
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Guardar_Click(object sender, RoutedEventArgs e)
        {
            //Código para guardar
        }
        /// <summary>
        /// eVENTO DEL CLICK, EN vm, NO ES CODIGO BEHIND
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BorrarClick(object sender, RoutedEventArgs e)
        {
            mListadoColecPersons.RemoveAt(indiceDePersonaSelec);
            NotifyPropertyChanged("mListadoColecPersons");
        }

    }
}
