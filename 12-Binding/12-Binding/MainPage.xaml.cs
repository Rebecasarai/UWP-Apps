using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace _12_Binding
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        /// <summary>
        /// Bindeado cada vez que se dispare el evento. Se puede colocar directamente en XAML.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTamano_TextChanged(object sender, TextChangedEventArgs e)
        {
            Binding mBinding = new Binding();
            mBinding.Source = sliderSize;
            mBinding.Path = new PropertyPath(" Value ");
            mBinding.Mode = BindingMode.TwoWay;
            mBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(txtTamano, TextBlock.FontSizeProperty, mBinding);
        }
        /// <summary>
        /// Controla la introducción de números mediante el teclado, tanto numberpad como linea superior numerica
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTamano_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if ((e.Key < Windows.System.VirtualKey.NumberPad0 || e.Key > Windows.System.VirtualKey.NumberPad9) 
                & (e.Key < Windows.System.VirtualKey.Number0 || e.Key > Windows.System.VirtualKey.Number9)
                & (e.Key < Windows.System.VirtualKey.LeftShift || e.Key < Windows.System.VirtualKey.RightShift))
            {
                e.Handled = true;
            }

        }
    }
}
