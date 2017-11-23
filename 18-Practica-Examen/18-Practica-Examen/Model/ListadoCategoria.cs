using _18_Practica_Examen.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_Practica_Examen.Model
{
    public class ListadoCategoria
    {
        public clsPersona _personSeleccionada;
        public ObservableCollection<clsPersona> _mListadoColecPersons;

        public ObservableCollection<Categoria> instaCategorias()
        {
            //Relleno lista de personas de una vez para que lista de catehoria vaya con el array de Vendedores lleno de default
            ListadoPersona mlistPersona = new ListadoPersona();
            _mListadoColecPersons = mlistPersona.instaPersonas();

            ObservableCollection<Categoria> categorylist = new ObservableCollection<Categoria>();

            categorylist.Add(new Categoria("Informatica", new Uri("ms-appx://_18_Practica_Examen/Assets/StoreLogo.png", UriKind.Absolute), _mListadoColecPersons));
            categorylist.Add(new Categoria("Belleza", new Uri("ms-appx://_18_Practica_Examen/Assets/StoreLogo.png", UriKind.Absolute), _mListadoColecPersons));
            categorylist.Add(new Categoria("Moda", new Uri("ms-appx://_18_Practica_Examen/Assets/StoreLogo.png", UriKind.Absolute), _mListadoColecPersons));
            return categorylist;
        }


    }
}
