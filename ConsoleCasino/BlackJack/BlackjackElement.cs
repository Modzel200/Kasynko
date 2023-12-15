using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCasino.BlackJack
{
    public class BlackjackElement
    {
        public BlackjackElement(int Id, string Name, string ImageUrl, List<string> AsciTab, int Weight)
        {
            this.Id = Id;
            this.Name = Name;
            this.ImageUrl = ImageUrl;
            this.AsciTab = AsciTab;
            this.Weight = Weight;
            this.Quantity = 4;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public List<string> AsciTab { get; set; }
        public int Weight { get; set; }
        public int Quantity { get; set; }
    }
}
