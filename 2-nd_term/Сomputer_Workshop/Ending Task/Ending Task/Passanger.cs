using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ending_Task
{
    public class Passanger
    {
        public string Surname { get; set; }
        public int CountItems { get; set; }
        public int Weight { get; set; }
        public Passanger(string surname, int countItems, int weight)
        {
            this.Surname = surname;
            this.CountItems = countItems;
            this.Weight = weight;
        }
        public override string ToString()
        {
            return "Фамилия "+this.Surname+" Вещей "+this.CountItems+" Вес багажа "+this.Weight;
        }
    }
}
