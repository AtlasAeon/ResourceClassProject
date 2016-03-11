using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceClassProject {
    class Program {
        static void Main(string[] args) {
            DVD dvd = new DVD();
            Book book = new Book();
            Magazine magazine = new Magazine();

            string argument = args[5];

            dvd.ViewTitle();
            dvd.AddTitle();
            dvd.ViewTitle();
            dvd.CheckIn();
            dvd.ViewTitle();
            dvd.CheckOut();
            dvd.ViewTitle();

            book.ViewTitle();
            book.AddTitle();
            book.ViewTitle();
            book.CheckIn();
            book.ViewTitle();
            book.CheckOut();
            book.ViewTitle();

            magazine.ViewTitle();
            magazine.AddTitle();
            magazine.ViewTitle();
            magazine.CheckIn();
            magazine.ViewTitle();
            magazine.CheckOut();
            magazine.ViewTitle();

            Console.ReadKey();
        }
    }
}
