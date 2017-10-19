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

namespace _08___Grid_Layouts_and_Date
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private String nombre, apellido;
        private DateTime fechaActual = DateTime.Now;


        public MainPage()
        {
            this.InitializeComponent();
            campoDate.PlaceholderText = fechaActual.ToString();
        }

        private void date_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void campoApellido_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void campoName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        /// <summary>
        /// Cuando se da click al boton de enviar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enviar_Click(object sender, RoutedEventArgs e)
        {
            //Declaración de variables
            nombre = campoName.Text;
            apellido = campoApellido.Text;
            DateTime fecha;
            if (String.IsNullOrWhiteSpace(nombre)&&String.IsNullOrWhiteSpace(apellido) && !DateTime.TryParse(this.campoDate.Text, out fecha))
            {
                errorName.Text = "Debe ingresar el nombre";
                errorApellido.Text = "Debe ingresar el apellido";
                errorFecha.Text = "Fecha no valida";
            }
            if (String.IsNullOrWhiteSpace(nombre))
            {
                errorName.Text = "Debe ingresar el nombre";
            }
            if (String.IsNullOrWhiteSpace(apellido))
            {

                errorApellido.Text = "Debe ingresar el apellido";
            }

            //fechadate = DateTime.TryParseExact(fecha.Text);

        }
    }
}
