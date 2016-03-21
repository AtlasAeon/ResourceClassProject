using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ResourceClassProject {
    class Student {
        string name;
        List<string> studentAccountList = new List<string>();

        public Student(string name) {
            this.name = name;
            Program.studentList.Add(this.name);
            studentAccountList.Add(this.name);
            //studentAccountList.Add("Resources Checked Out");
            FileUpdater();
        }

        void FileUpdater() {
            using (StreamWriter studentAccountWriter = new StreamWriter($"{this.name}.txt")) {
                foreach (string item in studentAccountList)
                    studentAccountWriter.WriteLine(item);
            }
        }

        public void ViewAccount() {
            Console.WriteLine($"{this.name}'s Account:");
            foreach (string item in studentAccountList)
                Console.WriteLine($"\t{item}");
        }

        public void AddResourceToFile(string resource) {
            studentAccountList.Add(resource);
            FileUpdater();
        }

        public void RemoveResourceFromFile(string resource) {
            studentAccountList.Remove(resource);
            FileUpdater();
        }

        public string Name {
            get { return this.name; }
        }
    }
}
