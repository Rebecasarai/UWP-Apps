using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame.Models
{
    /*
     * Clase con el modelo de la lista de cartas. DEsde aquí se carga la lista de cartas 
     * */
    public class CartList
    {
        ObservableCollection<Cart> Carts = new ObservableCollection<Cart>();

        /// <summary>
        /// Metodo que obtiene todas las cartas del juego
        /// </summary>
        /// <returns>Una lista observable de cartas</returns>
        public ObservableCollection<Cart> obtenerCarts()
        {
            Carts.Add( new Cart(0, new Uri("ms-appx://MemoryGame/Assets/Images/monkey.png", UriKind.Absolute), "moon"));
            Carts.Add( new Cart(0, new Uri("ms-appx://MemoryGame/Assets/Images/monkey.png", UriKind.Absolute), "moon1"));
            Carts.Add( new Cart(1, new Uri("ms-appx://MemoryGame/Assets/Images/monkey.png", UriKind.Absolute), "Pig"));
            Carts.Add( new Cart(1, new Uri("ms-appx://MemoryGame/Assets/Images/monkey.png", UriKind.Absolute), "PigNose"));
            Carts.Add(new Cart(2, new Uri("ms-appx://MemoryGame/Assets/Images/monkey.png", UriKind.Absolute), "chicken"));
            Carts.Add(new Cart(2, new Uri("ms-appx://MemoryGame/Assets/Images/monkey.png", UriKind.Absolute), "chickenSide"));
            Carts.Add(new Cart(3, new Uri("ms-appx://MemoryGame/Assets/Images/monkey.png", UriKind.Absolute), "cat"));
            Carts.Add(new Cart(3, new Uri("ms-appx://MemoryGame/Assets/Images/monkey.png", UriKind.Absolute), "catFace"));
            Carts.Add(new Cart(4, new Uri("ms-appx://MemoryGame/Assets/Images/monkey.png", UriKind.Absolute), "Squid"));
            Carts.Add(new Cart(4, new Uri("ms-appx://MemoryGame/Assets/Images/monkey.png", UriKind.Absolute), "SquidOctupus"));
            Carts.Add(new Cart(5, new Uri("ms-appx://MemoryGame/Assets/Images/monkey.png", UriKind.Absolute), "Dinosaur"));
            Carts.Add(new Cart(5, new Uri("ms-appx://MemoryGame/Assets/Images/monkey.png", UriKind.Absolute), "tyranosau"));
            
            randomize();

            return Carts;
        }

        /// <summary>
        /// Metodo que ordena de forma aleatoria las cartas del juego
        /// </summary>
        public void randomize()
        {
            int pos1, pos2;
            Random aleatorio = new Random();

            for (int i = 0; i < 200; i++)
            {
                pos1 = aleatorio.Next(0, 12);
                pos2 = aleatorio.Next(0, 12);

                Carts.Move(pos1, pos2);
            }


        }

    }
}
