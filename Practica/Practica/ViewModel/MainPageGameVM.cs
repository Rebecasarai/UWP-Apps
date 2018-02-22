using Capa_BL;
using Entidades;
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
        private Photo _photoSeleccionada;
        private ObservableCollection<Planeta> _mListaPlanetas;
        private ObservableCollection<Photo> _mListaPhotos;
        private String _palabraAdivinar;
        private String _letraElegida;
        public Uri uri;

        public Planeta planeta;
        

        private DelegateCommand _delete;
        
        #endregion
        #region contructor
        public MainPageGameVM()
        {
            getPhotos();
            planeta = new Planeta(1, "Rebecalis", 100, 100, new Uri("https://orig00.deviantart.net/c484/f/2014/351/b/9/planet_epsilon__transparent__by_oceanbluewolf1997-d8a8ms5.png") );

        }



        public async void getPhotos()
        {
            await GetPhotosAsync();
            NotifyPropertyChanged("mListaPhotos");

        }

        public async Task<ObservableCollection<Photo>> GetPhotosAsync()
        {
            ManejadoraBL manejadoraBl = new ManejadoraBL();
            _mListaPhotos = new ObservableCollection<Photo>(await manejadoraBl.getPhotos());
            NotifyPropertyChanged("mListaPhotos");
            return _mListaPhotos;
        }
        
        public async void chequearPalabraAsync()
        {
            char[] letras = palabraAdivinar.ToCharArray();
            for (int i =0; i<letras.Length; i++)
            {
                if (letraElegida.ToUpper() == (String)letras.GetValue(i))
                {
                    await mostrarCuadroAsync();
                }
            }
        }

        public async Task mostrarCuadroAsync()
        {
            ContentDialog noWifiDialog = new ContentDialog()
            {
                Title = "No wifi connection",
                Content = "Check connection and try again.",
                CloseButtonText = "Ok"
            };

            await noWifiDialog.ShowAsync();
        }


        #endregion

        #region Propiedades Publicas
        
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

        private bool CanExecuteDelete()
        {
            bool puede = false;
            if (photoSeleccionada != null)
            {
                puede = true;
            }
            return puede;
        }

        private async void ExecuteDelete()
        {
            await ExecuteDeleteAsync();
        }

        private async Task ExecuteDeleteAsync()
        {
            ManejadoraBL manejadora = new ManejadoraBL();
            await manejadora.borrarPersonaAsync(photoSeleccionada.id);
            uri = new Uri("https://www.youtube.com/watch?v=-C_rvt0SwLE");
        }


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


        

        public String letraElegida
        {

            set
            {
                _letraElegida = value;
                NotifyPropertyChanged("letraElegida");
            }
            get
            {
                return _letraElegida;
            }
        }

        public string palabraAdivinar
        {

            set
            {
                _palabraAdivinar = value;
                NotifyPropertyChanged("palabraAdivinar");
            }
            get
            {
                return _palabraAdivinar;
            }
        }

        public Photo photoSeleccionada
        {

            set
            {
                _photoSeleccionada = value;
                NotifyPropertyChanged("photoSeleccionada");

                _palabraAdivinar = _photoSeleccionada.title;
                NotifyPropertyChanged("palabraAdivinar");

                

            }
            get
            {
                return _photoSeleccionada;
            }
        }


        public ObservableCollection<Photo> mListaPhotos
        {

            set
            {
                _mListaPhotos = value;
                NotifyPropertyChanged("mListaPhotos");
            }
            get
            {
                return _mListaPhotos;
            }
        }


        public void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            if (photoSeleccionada != null)
            {
                Frame navigationFrame = Window.Current.Content as Frame;
                navigationFrame.Navigate(typeof(prueba), photoSeleccionada);
            }

        }





    }
}

#endregion