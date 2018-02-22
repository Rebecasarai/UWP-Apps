using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Personaje
    {
        public int id { get; set; }
        public String nombre { get; set; }
        public float alias { get; set; }
        public float vida { get; set; }
        public float armadura { get; set; }

        public Personaje()
        {
        }
    }
}
