using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Transactions;

namespace Restaurant
{
    public class Menu
    {
        private readonly IConsole _console = new ReadWriteLine();
        public string Name { get; set; }
        public float Price { get; set; }
        public float PriceTotal { get; set; }
        public int Id { get; set; }



    }
}



    

