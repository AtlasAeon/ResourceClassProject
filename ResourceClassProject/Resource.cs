using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceClassProject {
    abstract class Resource {
        string title;
        string isbn;
        int length;
        string status;

        public virtual void ViewTitle() {
            Console.WriteLine($"Title:{this.title}\nISBN:{this.isbn}\nLength:{this.length} Pages\nStatus:{this.status}");
        }

        public virtual void AddTitle() {
            Console.WriteLine("Enter the name of the title:");
            this.Title = Console.ReadLine();
            Console.WriteLine($"Enter the ISBN of {this.Title}:");
            this.ISBN = Console.ReadLine();
            Console.WriteLine($"Enter the length of {this.Title} in pages:");
            this.Length = int.Parse(Console.ReadLine());
            this.Status = "Available";
        }

        public virtual void CheckOut() {
            this.Status = "Checked Out";
            DateTime date = DateTime.Now.AddDays(3);
            Console.WriteLine($"This item is due back at {date:d}\n{this.Title} has been checked out.");
        }

        public void CheckIn() {
            this.Status = "Available";
        }

        public string Title {
            get { return this.title; }
            set { this.title = value; }
        }

        public string ISBN {
            get { return this.isbn; }
            set { this.isbn = value; }
        }

        public int Length {
            get { return this.length; }
            set { this.length = value; }
        }

        public string Status {
            get { return this.status; }
            set { this.status = value; }
        }

    }

    class DVD : Resource {
        public DVD() {
            this.Title = "";
            this.ISBN = "";
            this.Length = 0;
            this.Status = "Available";
        }

        public override void ViewTitle() {
            Console.WriteLine($"Title:{this.Title}\nISBN:{this.ISBN}\nLength:{this.Length} Minutes\nStatus:{this.Status}");
        }

        public override void AddTitle() {
            Console.WriteLine("Enter the name of the title:");
            this.Title = Console.ReadLine();
            Console.WriteLine($"Enter the ISBN of {this.Title}:");
            this.ISBN = Console.ReadLine();
            Console.WriteLine($"Enter the length of {this.Title} in minutes:");
            this.Length = int.Parse(Console.ReadLine());
            this.Status = "Available";
        }
    }

    class Book : Resource {
        public Book() {
            this.Title = "";
            this.ISBN = "";
            this.Length = 0;
            this.Status = "Available";
        }

        public override void CheckOut() {
            this.Status = "Checked Out";
            DateTime date = DateTime.Now.AddDays(5);
            Console.WriteLine($"This item is due back at {date:d}\n{this.Title} has been checked out.");
        }
    }

    class Magazine : Resource {
        public Magazine() {
            this.Title = "";
            this.ISBN = "";
            this.Length = 0;
            this.Status = "Available";
        }

        public override void CheckOut() {
            this.Status = "Checked Out";
            DateTime date = DateTime.Now.AddDays(2);
            Console.WriteLine($"This item is due back at {date:d}\n{this.Title} has been checked out.");
        }
    }
}
