using MemoryGame.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Animation;

namespace MemoryGame.ViewModels
{
    public class MemoryGameVM : clsVMBase
    {
        #region Atributos

        private ObservableCollection<Cart> _mCarts;

        private Cart _mCartseleccionada;
        private Cart _mCartToCompareAux;

        private int __mMatchingCarts;
        private int _mIntentsCont;
        private bool _mFinal;
        private bool _mSelectioned;

        DispatcherTimer mTempo;
        public Stopwatch mTime = new Stopwatch();
        private String _mWatch;
        private String _mTxtFinal;
        private Uri uridefault = new Uri("ms-appx://MemoryGame/Assets/Images/monkey.png", UriKind.Absolute);

        CartList mCartList = new CartList();


        public MemoryGameVM()
        {
            _mCarts = mCartList.obtenerCarts();
            NotifyPropertyChanged("mCarts");

            __mMatchingCarts = 0;
            _mIntentsCont = 0;
            mFinal = false;
            mSelectioned = true;

            mTempo = new DispatcherTimer();
            mTempo.Interval = TimeSpan.FromSeconds(1);
            mTempo.Tick += tiempoTranscurrido;
            mTempo.Start();

            mTime.Start();


        }
        #endregion


        #region Propiedades públicas

        public bool mSelectioned
        {
            get { return this._mSelectioned; }
            set
            {
                this._mSelectioned = value;
                NotifyPropertyChanged("mSelectioned");
            }
        }

        public int mIntentsCont
        {
            get { return _mIntentsCont; }
            set
            {
                this._mIntentsCont = value;
                NotifyPropertyChanged("mIntentsCont");
            }
        }

        public String mWatch
        {
            get { return this._mWatch; }
            set
            {
                this._mWatch = value;
                NotifyPropertyChanged("mWatch");
            }
        }

        
        /// <summary>
        /// La siguiente propiedad publica, permite que cada vez que se selecciona la carta, verifique su estado.
        /// Si es nula o no es igual a la auxiliar, asigna su valor. Actualiza su valoren caso de tener imagen default, 
        /// para colocar la imagen que debe tener boca abajo.
        /// </summary>
        public Cart mCartseleccionada
        {
            get { return this._mCartseleccionada; }
            set
            {

                if (_mCartseleccionada == null || _mCartseleccionada != _mCartToCompareAux)
                {

                    this._mCartseleccionada = value;

                    if (_mCartseleccionada.uri == uridefault)
                    {
                        _mCartseleccionada.uri = this.flipCart(mCartseleccionada.nombre);
                        NotifyPropertyChanged("mCartseleccionada");

                        _mCartToCompareAux = _mCartseleccionada;
                    }
                }
                else
                {
                    this._mCartseleccionada = value;
                    NotifyPropertyChanged("mCartseleccionada");

                    if (!(_mCartseleccionada == _mCartToCompareAux) && _mCartseleccionada.uri == uridefault)
                    {
                        _mCartseleccionada.uri = this.flipCart(mCartseleccionada.nombre);
                        NotifyPropertyChanged("mCartseleccionada");

                    }

                    this.checkStatus();
                }


            }
        }



        public bool mFinal
        {
            get { return this._mFinal; }
            set
            {
                this._mFinal = value;
                NotifyPropertyChanged("mFinal");
            }
        }

        public String mTxtFinal
        {
            get { return this._mTxtFinal; }
            set
            {
                this._mTxtFinal = value;
                NotifyPropertyChanged("mTxtFinal");
            }

        }


        public Cart mCartToCompareAux
        {
            get { return this._mCartToCompareAux; }
            set
            {
                this._mCartToCompareAux = value;
                NotifyPropertyChanged("mCartToCompareAux");
            }
        }

        public ObservableCollection<Cart> mCarts
        {
            get { return this._mCarts; }
            set
            {
                this._mCarts = value;
                NotifyPropertyChanged("mCarts");
            }
        }

        #endregion

        #region Methods


        /// <summary>
        /// Metodo que voltea la carta, dependiendo del nombre de la carta, le asigna su imagen al voltearse
        /// </summary>
        /// <param name="nombre">Recibe un string que representa el nombre de la carta</param>
        /// <returns>Retorna una uri de imagen</returns>
        public Uri flipCart(String nombre)
        {
            Uri uri = null;

            switch (nombre)
            {
                case "moon":
                    uri = new Uri("ms-appx://MemoryGame/Assets/Images/moon.png", UriKind.Absolute);
                    break;

                case "moon1":
                    uri = new Uri("ms-appx://MemoryGame/Assets/Images/moon1.png", UriKind.Absolute);
                    break;

                case "Pig":
                    uri = new Uri("ms-appx://MemoryGame/Assets/Images/pig.png", UriKind.Absolute);
                    break;

                case "PigNose":
                    uri = new Uri("ms-appx://MemoryGame/Assets/Images/pig1.png", UriKind.Absolute);
                    break;

                case "chicken":
                    uri = new Uri("ms-appx://MemoryGame/Assets/Images/chicken.png", UriKind.Absolute);
                    break;

                case "chickenSide":
                    uri = new Uri("ms-appx://MemoryGame/Assets/Images/chicken1.png", UriKind.Absolute);
                    break;

                case "cat":
                    uri = new Uri("ms-appx://MemoryGame/Assets/Images/cat.png", UriKind.Absolute);
                    break;

                case "catFace":
                    uri = new Uri("ms-appx://MemoryGame/Assets/Images/cat1.png", UriKind.Absolute);
                    break;

                case "Squid":
                    uri = new Uri("ms-appx://MemoryGame/Assets/Images/squid.png", UriKind.Absolute);
                    break;

                case "SquidOctupus":
                    uri = new Uri("ms-appx://MemoryGame/Assets/Images/octopus.png", UriKind.Absolute);
                    break;

                case "Dinosaur":
                    uri = new Uri("ms-appx://MemoryGame/Assets/Images/dinosaur.png", UriKind.Absolute);
                    break;

                case "tyranosau":
                    uri = new Uri("ms-appx://MemoryGame/Assets/Images/tyrannosaurus-rex.png", UriKind.Absolute);
                    break;
            }

            return uri;

        
        }

        /// <summary>
        /// Chequea el estado actual del juego y el de la jugada.
        /// Metodo que es llamado cada vez que se seleccionada una carta, para contar los intentos
        /// Mientras los intentos sean igual o menor a 10, seguirá contando y dará posibilidad de ganar
        /// </summary>
        private void checkStatus()
        {

            _mIntentsCont++;
            NotifyPropertyChanged("mIntentsCont");
            if (mIntentsCont <= 10)
            {
                if (_mCartToCompareAux.idCarta == _mCartseleccionada.idCarta)
                {
                    __mMatchingCarts++;
                    _mCartseleccionada = null;
                    _mCartToCompareAux = null;
                    NotifyPropertyChanged("mCartseleccionada");
                }
                else
                {
                    stopCartsForAWhile();
                }
                if (__mMatchingCarts == 6)
                {
                    mFinal = true;
                    _mTxtFinal = "Ha ganado";
                    NotifyPropertyChanged("mTxtFinal");
                    mTime.Stop();
                }
            }
            else
            {
                mFinal = true;
                _mTxtFinal = "Ha perdido";
                NotifyPropertyChanged("mTxtFinal");
                mTime.Stop();

                mSelectioned = false;
            }

        }

        

        /// <summary>
        /// Deshabilita pot un segundo el click de las cartas. De esta manera evitamos que se bugee.
        /// Si ya ha eligido dos (2) cartas y estas no son correctas, se tendrán levantadas, mostradas por un minuto
        /// y no se permitirá clickear en otra o sleccionar otra hasta pasar el segundo, luego deque se volteen de nuevo hacia abajo.
        /// </summary>
        public async void stopCartsForAWhile()
        {
            mSelectioned = false;
            await Task.Delay(1000);
            mSelectioned = true;

            _mCartseleccionada.uri = uridefault;
            NotifyPropertyChanged("mCartseleccionada");

            _mCartseleccionada = _mCartToCompareAux;
            _mCartseleccionada.uri = uridefault;
            NotifyPropertyChanged("mCartseleccionada");

            _mCartseleccionada = null;
            _mCartToCompareAux = null;
            NotifyPropertyChanged("mCartseleccionada");

        }


        /// <summary>
        /// Este método toma el tiempo transcurrido en ser clickeado el elipse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void tiempoTranscurrido(object sender, object e)
        {
            mWatch = string.Format("{0}:{1}:{2}", mTime.Elapsed.Hours.ToString(), mTime.Elapsed.Minutes.ToString(), mTime.Elapsed.Seconds.ToString());
        }
        
        

        /// <summary>
        /// El metodo que maneja el evento de ser clickeada la carta para mostrar la animación de voltear.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void giraCartaPointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Storyboard storyboard = new Storyboard();
            storyboard.Duration = new Duration(TimeSpan.FromSeconds(1.0));
            DoubleAnimation rotateAnimation = new DoubleAnimation();

            rotateAnimation.From = 90.0;
            rotateAnimation.To = 0.0;
            rotateAnimation.Duration = storyboard.Duration;

            Storyboard.SetTarget(rotateAnimation, (Image)e.OriginalSource);
            Storyboard.SetTargetProperty(rotateAnimation, "(UIElement.Projection).(PlaneProjection.RotationY)");


            storyboard.Children.Add(rotateAnimation);

            storyboard.Begin();
        }
        #endregion
    }
}


