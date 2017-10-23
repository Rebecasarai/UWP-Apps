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

namespace _10_Control_And_Patterns
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private int riesgo = 0;
        private bool pressed;
        public MainPage()
        {
            this.InitializeComponent();
            calendar.MinDate = DateTime.Now;
        }

        private void ProgressBarcontrol_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            
        }

        
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
        }

        private void comentarios_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void alergies_Toggled(object sender, RoutedEventArgs e)
        {
            if (!pressed)
            {
                pressed = false;
                riesgo += 30;
                ProgressBarcontrol.Value = riesgo;

            }
        }
    }
}
