using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;

namespace Restaurant
{
    public class Order
    {
        public List<Menu> FullOrder { get; set; }
        public double Total { get {return FullOrder.Select(x => x.Price).Sum(); } }

        public Table Table { get; set; }

        public Order()
        {
            FullOrder = new List<Menu>();
            
        }

        public void PrintOrderDetails(IConsole console)
        {

            console.WriteLine(DateTime.Now.ToString());
            console.WriteLine("Your order:");
            console.WriteLine($"Table number: {this.Table.TableName}");
            console.WriteLine($"Table seating: {this.Table.TableSize}");

            foreach (var item in this.FullOrder)
            {
                console.WriteLine($"You are ordering {item.Name}, for {item.Price} EUR.");
            }
            console.WriteLine($"Total to pay: {this.Total} EUR.");

        }

 


           public bool IsValidEmail()
           {
            
            Console.WriteLine("Iveskite savo el. pasto adresa jei norite ceki gauti el. pastu. Kitu atveju spauskite X");
                    var emailInput = Console.ReadLine();
                    string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";

                    return Regex.IsMatch(emailInput, regex, RegexOptions.IgnoreCase);
            // sita regex radau internete, pasirode paprasciausias budas patikrinti ar tikrai ivede email adresa


           }
     }
    }