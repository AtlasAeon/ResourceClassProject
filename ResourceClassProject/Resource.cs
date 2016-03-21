using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ResourceClassProject {
    abstract class Resource {
        string title;
        string isbn;
        int length;
        string status;
        string type;
        protected string[] typeResourceArray = {"DVD", "Book", "Magazine"};
        static protected List<string> checkedOutList = new List<string>();

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
            Console.WriteLine($"{this.Title} has been checked out.");
            checkedOutList.Add(this.Title);
            WriteToFile();

            //DateTime date = DateTime.Now.AddDays(3);
            //Console.WriteLine($"This item is due back at {date:d}\n{this.Title} has been checked out.");
        }

        protected void WriteToFile() {
            using (StreamWriter checkedOutWriter = new StreamWriter("Currently Checked Out Resources.txt")) {
                foreach (string item in checkedOutList)
                    checkedOutWriter.WriteLine(item);
            }
        }

        public void CheckIn() {
            this.Status = "Available";
            checkedOutList.Remove(this.Title);
            WriteToFile();
        }

        public string Title {
            get { return this.title; }
            set {
                if (!checkedOutList.Equals(this.Title)) {
                    this.title = value;
                } else {
                    checkedOutList.Remove(this.title);
                    this.title = value;
                    checkedOutList.Add(this.title);
                }
            }
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

        public string Type {
            get { return this.type; }
            protected set { this.type = value; }
        }
    }

    class DVD : Resource {
        public DVD(string title, string isbn, int length) {
            this.Title = title;
            this.ISBN = isbn;
            this.Length = length;
            this.Status = "Available";
            this.Type = "DVD";
            Program.resourceList.Add(this.Title);
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
        }
    }

    class Book : Resource {
        public Book(string title, string isbn, int length) {
            this.Title = title;
            this.ISBN = isbn;
            this.Length = length;
            this.Status = "Available";
            this.Type = "Book";
            Program.resourceList.Add(this.Title);
        }

        public override void CheckOut() {
            this.Status = "Checked Out";
            Console.WriteLine($"{this.Title} has been checked out.");
            checkedOutList.Add(this.Title);
            WriteToFile();
            //DateTime date = DateTime.Now.AddDays(5);
            //Console.WriteLine($"This item is due back at {date:d}\n{this.Title} has been checked out.");
        }
    }

    class Magazine : Resource {
        public Magazine(string title, string isbn, int length) {
            this.Title = title;
            this.ISBN = isbn;
            this.Length = length;
            this.Status = "Available";
            this.Type = "Magazine";
            Program.resourceList.Add(this.Title);
        }

        public override void CheckOut() {
            this.Status = "Checked Out";
            checkedOutList.Add(this.Title);
            WriteToFile();
            //DateTime date = DateTime.Now.AddDays(2);
            //Console.WriteLine($"This item is due back at {date:d}\n{this.Title} has been checked out.");
        }
    }
}
