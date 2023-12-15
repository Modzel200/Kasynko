using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCasino.Roulette
{
    public class RouletteElement
    {
        public int number;
        public string image;

        public RouletteElement(int number, string image)
        {
            this.number = number;
            this.image = image;
        }
    }
}
