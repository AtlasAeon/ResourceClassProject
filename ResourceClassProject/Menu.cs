using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ResourceClassProject {
    class Menu {
        public void ViewResources() {
            using (StreamReader resourceReader = new StreamReader("Resources.txt")) {
                int counter = 1;
                Console.WriteLine("All Available Resources");
                while (!resourceReader.EndOfStream) {
                    string line = resourceReader.ReadLine();
                    if (String.IsNullOrWhiteSpace(line))
                        continue;
                    Console.WriteLine($"\t{counter}. {line}");
                    counter++;
                }
            }
        }

        public void ViewAvailableResources() {
            for (int i = 0; i < Program.resources.Count(); i++) {
                if (Program.resources[i].Status == "Checked Out")
                    continue;
                Console.WriteLine(Program.resources[i].Title);
            }
        }

        public void EditResources() {
            Console.WriteLine("Which resource would you like to edit?");
            int counter = 1;
            for (int i = 0; i < Program.resources.Count(); i++) {
                Console.WriteLine($"{counter}. {Program.resources[i].Title}");
                counter++;
            }
            Console.WriteLine("Enter the corresponding number to select a resource");
            string userInputString = Console.ReadLine();
            int userInputSelection = int.Parse(userInputString);
            //try {
            //    userInputSelection = int.Parse(userInputString) - 1; //Takes user input and corrects to zero index
            //} catch (FormatException) {
            //    Console.Error.WriteLine("Invalid selection. Please use a corresponding number.");
            //    Program.Menu();
            //}
            string[] menuEdit = {"Title", "ISBN", "Length"};
            Console.WriteLine("What would you like to edit for this resource");
            counter = 1;
            foreach (string item in menuEdit) {
                Console.WriteLine($"{counter}. {item}");
                counter++;
            }
            Console.WriteLine("Enter the corresponding number to select what you would like to edit.");
            string userEditInput = Console.ReadLine();
            switch (userEditInput) {
                case "1":
                    Console.WriteLine("Enter the new title or press enter to cancel.");
                    string userEditTitle = Console.ReadLine();
                    if (!String.IsNullOrWhiteSpace(userEditTitle)) {
                        Program.resources[userInputSelection].Title = userEditTitle;
                    }
                    break;
                case "2":
                    Console.WriteLine("Enter the new ISBN or press enter to cancel.");
                    string userEditISBN = Console.ReadLine();
                    if (!String.IsNullOrWhiteSpace(userEditISBN)) {
                        Program.resources[userInputSelection].ISBN = userEditISBN;
                    }
                    break;
                case "3":
                    Console.WriteLine("Enter the new title or press enter to cancel.");
                    string userEditLength = Console.ReadLine();
                    if (!String.IsNullOrWhiteSpace(userEditLength)) {
                        Program.resources[userInputSelection].Title = userEditLength;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid selection. Press any key to return to menu.");
                    Console.ReadKey();
                    break;
            }
        }

        public void ViewStudentAccounts() {
            Console.WriteLine("Which student account would you like to view?");
            int counter = 1;
            for (int i = 0; i < Program.students.Count(); i++) {
                Console.WriteLine($"{counter}. {Program.students[i].Name}");
                counter++;
            }
            string userStudentAccountSelectionString = Console.ReadLine();
            int userStudentAccountSelection = int.Parse(userStudentAccountSelectionString) - 1; //Takes user input and corrects to zero index
            Program.students[userStudentAccountSelection].ViewAccount();
        }

        public void ViewStudents() {
            using (StreamReader studentReader = new StreamReader("Students.txt")) {
                int counter = 1;
                Console.WriteLine("All Students");
                while (!studentReader.EndOfStream) {
                    string line = studentReader.ReadLine();
                    if (String.IsNullOrWhiteSpace(line))
                        continue;
                    Console.WriteLine($"\t{counter}. {line}");
                    counter++;
                }
            }
        }

        public void CheckOut() {
            int checkedOutResources = 0;
            Console.WriteLine("Which resources would you like to check out?");
            for (int i = 0; i < Program.resources.Count(); i++) {
                if (Program.resources[i].Status == "Checked Out") {
                    checkedOutResources++;
                    continue;
                }
                Console.WriteLine($"\t{i + 1 - checkedOutResources}. {Program.resources[i].Title}");
            }
            Console.WriteLine("Enter the corresponding number to check out the resource.");

            int userSelection = int.Parse(Console.ReadLine());
            int checkedOutResourcesIndex = 0;
            for (int i = 0; i < Program.resources.Count(); i++) {
                if (Program.resources[i].Status == "Checked Out")
                    checkedOutResourcesIndex++;
                if (userSelection == i + 1 - checkedOutResourcesIndex) {
                    Program.resources[i].CheckOut();
                }
            }
        }

        public void CheckIn() {
            int checkedInResources = 0;
            Console.WriteLine("Which resources would you like to check out?");
            for (int i = 0; i < Program.resources.Count(); i++) {
                if (Program.resources[i].Status == "Available") {
                    checkedInResources++;
                    continue;
                }
                Console.WriteLine($"\t{i + 1 - checkedInResources}. {Program.resources[i].Title}");
            }
            Console.WriteLine("Enter the corresponding number to check in the resource.");

            int userSelection = int.Parse(Console.ReadLine());
            int checkedInResourcesIndex = 0;
            for (int i = 0; i < Program.resources.Count(); i++) {
                if (Program.resources[i].Status == "Available")
                    checkedInResourcesIndex++;
                if (userSelection == i + 1 - checkedInResourcesIndex) {
                    Program.resources[i].CheckIn();
                }
            }
            //Console.WriteLine("Which resources would you like to check in?");
            //for (int i = 0; i < Program.resources.Count(); i++) {
            //    if (Program.resources[i].Status == "Available") {
            //        continue;
            //    }
            //    Console.WriteLine($"\t{i + 1}. {Program.resources[i].Title}");
            //}
        }
    }
}
