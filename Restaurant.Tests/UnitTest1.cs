using System;
using System.Text;
using System.Text.Json;

namespace Restaurant.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestReadDrinkData()
        {
            // Arrange
            var filePath = "C:\\Users\\deiwu\\source\\repos\\Restaurant\\Restaurant/drinks.json";

            // Act
            var drinks = ReadDrinkData(filePath);

            // Assert
            Assert.IsNotNull(drinks);
            Assert.IsTrue(drinks.Count > 0);
        }

        [TestMethod]
        public void TestReadFoodData()
        {
            // Arrange
            var filePath = "C:\\Users\\deiwu\\source\\repos\\Restaurant\\Restaurant/food.json";

            // Act
            var food = ReadFoodData(filePath);

            // Assert
            Assert.IsNotNull(food);
            Assert.IsTrue(food.Count > 0);
        }

        [TestMethod]
        public void TestReadTableData()
        {
            // Arrange
            var filePath = "./staliukai.json";

            // Act
            var tables = ReadTableData(filePath);

            // Assert
            Assert.IsNotNull(tables);
            Assert.IsTrue(tables.Count > 0);
        }

        public static List<Table> _tables = new List<Table>();

        [TestMethod]
        public void TestReserveTable_SuccessIfIsOccupiedUpdates()
        {
            // Arrange
            var inputId = 2;
            var chooseTable = new Table { TableSize = 2, IsOccupied = false };
            _tables = new List<Table> { chooseTable };

            // Act
            ReserveTable(inputId);

            // Assert
            Assert.IsTrue(chooseTable.IsOccupied);
        }
        public void ReserveTable(int inputId)
        {
            var chooseTable = _tables.FirstOrDefault(table => table.TableSize == inputId);

            if (chooseTable == null)
            {
                Console.WriteLine("Tokio dydzio staliukas neegzistuoja");
                return;
            }
            else if (chooseTable.IsOccupied == true)
            {
                Console.WriteLine("Visi tokio tipo staliukai uzimti, apsilankykite veliau");
                return;
            }
            Console.WriteLine("Prašome prisėsti ir užsisakyti");
            chooseTable.IsOccupied = true;
        }


        [TestMethod]
        public void TestReserveTable_TableNotFound()
        {
            // Arrange
            var inputId = 8;
            _tables = new List<Table>();
            var chooseTable = new Table { TableSize = 2, IsOccupied = false };

            // Act
            var message = ReserveTableTest(inputId);

            // Assert
            Assert.AreEqual("Tokio dydzio staliukas neegzistuoja", message);
        }

        private string ReserveTableTest(int inputId)
        {
            var chooseTable = _tables.FirstOrDefault(table => table.TableSize == inputId);

            if (chooseTable == null)
            {
                return "Tokio dydzio staliukas neegzistuoja";
            }
            else if (chooseTable.IsOccupied == true)
            {
                return "Visi tokio tipo staliukai uzimti, apsilankykite veliau";
            }
            return "Prašome prisėsti ir užsisakyti";
            chooseTable.IsOccupied = true;
        }
        [TestMethod]
        public void TestReserveTable_TableAlreadyOccupied()
        {
            // Arrange
            var inputId = 2;
            var chooseTable = new Table { TableSize = 2, IsOccupied = true };
            _tables = new List<Table> { chooseTable };

            // Act
            var message = ReserveTableTest(inputId);

            // Assert
            Assert.AreEqual("Visi tokio tipo staliukai uzimti, apsilankykite veliau", message);
        }
        [TestMethod]
        public void TestPrintOrderDetails_PrintsTimestamp()
        {
            // Arrange
            var console = new TestConsole();
            var order = new Order
            {
                Table = new Table { TableName = 1, TableSize = 4 },
                FullOrder = new List<Menu>
        {
            new Menu { Name = "Pizza", Price = 10.50F },
            new Menu { Name = "Soda", Price = 2.50F }
        },
                
            };

            // Act
            order.PrintOrderDetails(console);

            // Assert
            Assert.IsTrue(console.Output.ToString().Contains(DateTime.Now.ToString()));
        }

        [TestMethod]
        public void TestPrintOrderDetails_PrintsOrderDetails()
        {
            // Arrange
            var console = new TestConsole();
            var order = new Order
            {
                Table = new Table { TableName = 1, TableSize = 4 },
                FullOrder = new List<Menu>
        {
            new Menu { Name = "Pizza", Price = 10.50F },
            new Menu { Name = "Soda", Price = 2.50F }
        },

            };

            // Act
            order.PrintOrderDetails(console);

            // Assert
            Assert.IsTrue(console.Output.ToString().Contains("Your order:"));
            Assert.IsTrue(console.Output.ToString().Contains("Table number: 1"));
            Assert.IsTrue(console.Output.ToString().Contains("Table seating: 4"));
         }

        static List<Menu> ReadDrinkData(string path)
        {
            string fileContent = File.ReadAllText(path);
            var drinkList = JsonSerializer.Deserialize<List<Menu>>(fileContent);
            return drinkList;
        }

        static List<Menu> ReadFoodData(string path)
        {
            string fileContent = File.ReadAllText(path);
            var foodList = JsonSerializer.Deserialize<List<Menu>>(fileContent);
            return foodList;
        }

        static List<Table> ReadTableData(string path)
        {
            string fileContent = File.ReadAllText(path);
            var tableList = JsonSerializer.Deserialize<List<Table>>(fileContent);
            return tableList;
        }

        public class TestConsole : IConsole
        {
            public StringBuilder Output { get; } = new StringBuilder();
            public string ReadLineResult { get; set; }
            public string WriteLineResult { get; set; }
            private int _counter = -1;

            public List<string> ReadLineList { get; set; } = new List<string>();



            public string ReadLine()
            {
                if (ReadLineResult is not null)
                {
                    return ReadLineResult;
                }

                _counter++;

                return ReadLineList[_counter];


            }

            public void WriteLine(string value)
            {
                WriteLineResult = value;
            }

            public static IConsole _console = new CustomConsole();

            private List<Table> _tables;

        }
    }
}
