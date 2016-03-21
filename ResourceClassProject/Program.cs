using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ResourceClassProject {
    class Program {
        static public List<string> studentList = new List<string>();
        static public List<string> resourceList = new List<string>();

        static void ResourceInit() {
            //resourceList.Add(cSharp.Title);
            //resourceList.Add(java.Title);
            //resourceList.Add(javaScript.Title);
            //resourceList.Add(lionKing.Title);
            //resourceList.Add(backToTheFuture.Title);
            //resourceList.Add(betterOffTed.Title);
            //resourceList.Add(natGeo.Title);
            //resourceList.Add(entrepreneur.Title);
            //resourceList.Add(motorsports.Title);
            string[] typeResourceArray = { "DVD", "Book", "Magazine" };
            foreach (string item in typeResourceArray) {
                List<string> tempList = new List<string>();
                for (int i = 0; i < resources.Count(); i++) {
                    if (item == resources[i].Type) {
                        tempList.Add(resources[i].Title);
                    }
                }
                using (StreamWriter resourceTypeWriter = new StreamWriter($"{item}.txt")) {
                    foreach (string listItem in tempList) {
                        resourceTypeWriter.WriteLine(listItem);
                    }
                }
            }
            using (StreamWriter resourceWriter = new StreamWriter("Resources.txt")) {
                for (int i = 0; i < resources.Count(); i++)
                    resourceWriter.WriteLine($"{resources[i].Title} ({resources[i].Type})");
            }
        }

        static void StudentInit() {
            //studentList.Add(cadale.Name);
            //studentList.Add(mary.Name);
            //studentList.Add(cameron.Name);
            //studentList.Add(quinn.Name);
            //studentList.Add(kim.Name);
            using (StreamWriter studentWriter = new StreamWriter("Students.txt")) {
                foreach (string student in studentList)
                    studentWriter.WriteLine(student);
            }
        }

        static public List <Student> students = new List <Student>() {
            new Student("Cadale Thomas"),
            new Student("Mary Winkelman"),
            new Student("Cameron Robinson"),
            new Student("Quinn Bennett"),
            new Student("Kim Vargas")
        };

        static public List <Resource> resources = new List <Resource>() {
            new Book("C# Player's Guide", "9780985580124", 368),
            new Book("Java: A Beginner's Guide", "9780071809252", 728),
            new Book("JavaScript and JQuery", "9781118531648", 640),
            new DVD("The Lion King", "6341247091256", 89),
            new DVD("Back To The Future", "3787534912686", 120),
            new DVD("Better Off Ted", "9348237342874", 300),
            new Magazine("National Geograhpic", "5234219563465", 154),
            new Magazine("Entrepreneur", "5239851268964", 273),
            new Magazine("MotorSport", "3459861247536", 197)
        };
        //static Book cSharp = new Book("C# Player's Guide", "9780985580124", 368);
        //static Book java = new Book("Java: A Beginner's Guide", "9780071809252", 728);
        //static Book javaScript = new Book("JavaScript and JQuery", "9781118531648", 640);
        //static DVD lionKing = new DVD("The Lion King", "6341247091256", 89);
        //static DVD backToTheFuture = new DVD("Back To The Future", "3787534912686", 120);
        //static DVD betterOffTed = new DVD("Better Off Ted", "9348237342874", 300);
        //static Magazine natGeo = new Magazine("National Geograhpic", "5234219563465", 154);
        //static Magazine entrepreneur = new Magazine("Entrepreneur", "5239851268964", 273);
        //static Magazine motorsports = new Magazine("MotorSport", "3459861247536", 197);

        static Menu menus = new Menu();

        static public void Menu() {
            string[] menuItems = {
                "View All Resources",
                "View Available Resources",
                "Edit Resources",
                "View Student Accounts",
                "View All Students",
                "Check Out Resource",
                "Check In Resource",
                "Exit"
            };

            int counter = 1;
            foreach (string item in menuItems) {
                Console.WriteLine($"\t{counter}. {item}");
                counter++;
            }

            string menuInput = Console.ReadLine();
            switch (menuInput) {
                case "1":
                    menus.ViewResources();
                    Menu();
                    break;
                case "2":
                    menus.ViewAvailableResources();
                    Menu();
                    break;
                case "3":
                    menus.EditResources();
                    Menu();
                    break;
                case "4":
                    menus.ViewStudentAccounts();
                    Menu();
                    break;
                case "5":
                    menus.ViewStudents();
                    Menu();
                    break;
                case "6":
                    menus.CheckOut();
                    Menu();
                    break;
                case "7":
                    menus.CheckIn();
                    Menu();
                    break;
                case "8":
                    Console.WriteLine("Press any key to exit. Goodbye!");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Invalid selection. Press any key to return to menu.");
                    Console.ReadKey();
                    Menu();
                    break;
            }
        }

        static void Main(string[] args) {
            ResourceInit();
            StudentInit();
            Menu();
        }
    }
}
