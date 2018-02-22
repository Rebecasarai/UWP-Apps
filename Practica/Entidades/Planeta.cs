using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Planeta
    {
        public int id { get; set; }
        public String name { get; set; }
        public int posicionX { get; set; }
        public int posicionY { get; set; }
        public Uri uri { get; set; }

        public Planeta(int id, string name, int posicionX, int posicionY, Uri uri)
        {
            this.id = id;
            this.name = name;
            this.posicionX = posicionX;
            this.posicionY = posicionY;
            this.uri = uri;
        }
    }
}
