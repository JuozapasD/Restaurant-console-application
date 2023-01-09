using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Table
    {
        public int TableName { get; set; }
        public int TableSize { get; set; }
        public bool IsOccupied { get; set; }

    }



}

// sut._tables // sito reiks teste, kai rasysiu testus
// kai kurisu testus reiks pasirasyti visus mockus, tables/food/drink
// kaip darem pavyzdyje