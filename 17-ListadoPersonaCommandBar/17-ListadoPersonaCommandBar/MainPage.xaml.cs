﻿using System;
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

namespace _17_ListadoPersonaCommandBar
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
        /// Avisamos a la vista de que debe de actualizar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            this.txtBlcNombre.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            this.txtBlcapellido.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            this.txtBlcDireccion.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            this.txtBlcFechaNacimiento.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            this.txtBlctelefono.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }
        /// <summary>
        /// Se debe colocar ya que trabajamos dando al boton.
        /// Se debe de actualizar la vista por este medio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.searchBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }
    }
}
