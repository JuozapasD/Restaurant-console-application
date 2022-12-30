using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Transactions;

namespace Restaurant
{
    public class Program
    {
        public static List<Table> _tables = new List<Table>();
        public static List<Menu> _drinks = new List<Menu>();
        public static List<Menu> _food = new List<Menu>();
        public static IConsole _console = new CustomConsole();
        static void Main(string[] args)
        {

            _drinks = ReadDrinkData("C:\\Users\\deiwu\\source\\repos\\Restaurant\\Restaurant/drinks.json");
            _food = ReadFoodData("C:\\Users\\deiwu\\source\\repos\\Restaurant\\Restaurant/food.json");
            _tables = ReadTableData("./staliukai.json");
            Console.WriteLine("Kokio dydzio staliuko noretumete? Pasirinkite 2, 4 arba 6 vietų staliuką");
            var inputId = int.Parse(Console.ReadLine());

            if (inputId == 1)
            {

                inputId += 1;
            }
            else if (inputId == 3)
            {
                inputId += 1;
            }
            else if (inputId == 5)
            {
                inputId += 1;
            }

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

            //================================================================================//
            Console.WriteLine("Galimi pasirinkimai:");
            Console.WriteLine("1 - Rinktis gėrimą");
            Console.WriteLine("2 - Rinktis maistą");
            Console.WriteLine("3 - Apmokėti");
            Console.WriteLine("4 - Išeiti");

            var newOrder = new Order
            {
                Table = chooseTable
            };
            while (true)
            {
                Console.WriteLine("Pasirinkite veiksmą");
                var userInputChoice = int.Parse(Console.ReadLine());

                switch (userInputChoice)
                {
                    case 1:
                        Console.WriteLine("Galimi pasirinkimai:");
                        Console.WriteLine("1 - CocaCola 0.5l, 1.50e");
                        Console.WriteLine("2 - Pepsi 0.5l, 1.50e");
                        Console.WriteLine("3 - Sprite 0.5l, 1.50e");
                        Console.WriteLine("4 - Vilnelė 0.5l, 2.50e");
                        Console.WriteLine("5 - Išeiti");

                        int input = int.Parse(Console.ReadLine());
                        var chooseDrink = _drinks.FirstOrDefault(drinks => drinks.Id == input);
                      
                        while (true)
                        {
                            if (_drinks == null)
                            {
                                Console.WriteLine("Tokio gerimo pasirinkimu sarase nera");
                                return;
                            }

                            if(input > 4)
                            {
                                Console.WriteLine("//////////////////////////////////");
                                Console.WriteLine("Galimi pasirinkimai:");
                                Console.WriteLine("1 - Rinktis gėrimą");
                                Console.WriteLine("2 - Rinktis maistą");
                                Console.WriteLine("3 - Apmokėti");
                                Console.WriteLine("4 - Išeiti");
                                break;
                            }

                            

                            Console.WriteLine($"Pridetas gerimo pasirinkimas {input}");
                            Console.WriteLine("//////////////////////////////////");
                            Console.WriteLine("Galimi pasirinkimai:");
                            Console.WriteLine("1 - Rinktis gėrimą");
                            Console.WriteLine("2 - Rinktis maistą");
                            Console.WriteLine("3 - Apmokėti");
                            Console.WriteLine("4 - Išeiti");
                            break;                        
                        }
                       
 
                        newOrder.FullOrder.Add(chooseDrink);

                        break;
                    case 2:
                        Console.WriteLine("Galimi pasirinkimai:");
                        Console.WriteLine("1 - Pica su grybais, 10.50e");
                        Console.WriteLine("2 - Pica su ananasais, 9.50e");
                        Console.WriteLine("3 - Kebabas lėkštėje, 5.50e");
                        Console.WriteLine("4 - Kebabas lavaše, 4.50e");
                        Console.WriteLine("5 - Išeiti");

                        int inputFood = int.Parse(Console.ReadLine());
                        var chooseFood = _food.FirstOrDefault(x => x.Id == inputFood);

                        while (true)
                        {
                            if (_drinks == null)
                            {
                                Console.WriteLine("Tokio gerimo pasirinkimu sarase nera");
                                return;
                            }

                            if (inputFood > 4)
                            {
                                Console.WriteLine("//////////////////////////////////");
                                Console.WriteLine("Galimi pasirinkimai:");
                                Console.WriteLine("1 - Rinktis gėrimą");
                                Console.WriteLine("2 - Rinktis maistą");
                                Console.WriteLine("3 - Apmokėti");
                                Console.WriteLine("4 - Išeiti");
                                break;
                            }

                            Console.WriteLine($"Pridetas maisto pasirinkimas {inputFood}");
                            Console.WriteLine("//////////////////////////////////");
                            Console.WriteLine("Galimi pasirinkimai:");
                            Console.WriteLine("1 - Rinktis gėrimą");
                            Console.WriteLine("2 - Rinktis maistą");
                            Console.WriteLine("3 - Apmokėti");
                            Console.WriteLine("4 - Išeiti");
                            break;
                        }


                        newOrder.FullOrder.Add(chooseFood);
                        break;
                    case 3:

                        newOrder.PrintOrderDetails(_console);


                        break;

                    case 4:

                        return;
                    default:
                        Console.WriteLine("Pasirinkimas nerastas");
                        break;
                }
            }
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
        }


}

