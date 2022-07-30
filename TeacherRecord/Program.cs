using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherRecord
{
    internal class Program

    {

        static void Main(string[] args)
        {
            string path = @"C:\Users\Hemanth Nandyala\Desktop\TeacherRecord.txt";//path of the text file

            if (File.Exists(path))//to check wheher file exists or not
            {
                Console.WriteLine("File Exists");
                Console.WriteLine("\nSelect 1 to Display data \nSelect 2 to Append new line  \nSelect 3 to Delete data \nSelect 4 to Sort by First Name \nSelect 5 to Sort by Id \nSelect 6 to Search data \nSelect 7 to Update data");

                Selection();
            }
            else
            {
                Console.WriteLine("File does not Exists");
            }
           
        }

        static void Selection()
        {
            while (true)
            {

                Console.WriteLine("\nEnter option for the required operation ");


                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("\nDisplaying the file\n");
                        Display();
                        break;
                    case 2:
                        Console.WriteLine("Adding new line to file\n");
                        Appending();
                        break;
                    case 3:
                        Console.WriteLine("Deleting a line having the given id in text file \n ");
                        Delete();
                        break;
                    case 4:
                        Console.WriteLine("Sorting data in file according to the FirstName values\n");
                        SortByFirstName();
                        break;
                    case 5:
                        Console.WriteLine("Sorting data in file according to Id \n");
                        SortById();
                        break;
                    case 6:
                        Console.WriteLine("Searching data in file according to the provided id\n");
                        Searching();
                        break;

                    case 7:
                        Console.WriteLine("");
                        Update();
                        break;

                    default:
                        Console.WriteLine("Invalid input\n");
                        break;
                }
            
                
            }

        }

        static void Display()
        {
            String path = @"C:\Users\Hemanth Nandyala\Desktop\TeacherRecord.txt";

            String[] lines;
            lines = File.ReadAllLines(path);
            for (int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine(lines[i]);
            }

        }

        static void Appending()
        {

            List<Teacher> listTeachers = new List<Teacher>();
            string teacherfile = (@"C:\Users\Hemanth Nandyala\Desktop\TeacherRecord.txt");
            string[] arrteacher = System.IO.File.ReadAllLines(teacherfile);

            foreach (string line in arrteacher)
            {
                string[] l = line.Split(',');
                Teacher teacher = new Teacher();
                teacher.Id = l[0];
                teacher.FirstName = l[1];
                teacher.LastName = l[2];
                teacher.CClass = l[3];
                teacher.Section = l[4];
                listTeachers.Add(teacher);

            }
            string UIId = "";
            string UIFirstName = "";
            string UILastName = "";
            string UIClass = "";
            string UIsection = "";
            using (FileStream fs = new FileStream(@"C:\Users\Hemanth Nandyala\Desktop\TeacherRecord.txt", FileMode.Append))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                Teacher teacher = new Teacher();
                teacher.Id = UIId;
                teacher.FirstName = UIFirstName;
                teacher.LastName = UILastName;
                teacher.CClass = UIClass;
                teacher.Section = UIsection;
                                
                Console.WriteLine("Please enter the id: ");
                UIId = Console.ReadLine();
                Console.WriteLine("Please enter the firstname: ");
                UIFirstName = Console.ReadLine();
                Console.WriteLine("Please enter the Lastname: ");
                UILastName = Console.ReadLine();
                Console.WriteLine("Please enter the class: ");
                UIClass = Console.ReadLine();
                Console.WriteLine("Please enter the section: ");
                UIsection = Console.ReadLine();
                string fullText = (UIId + "," + UIFirstName + "," + UILastName + "," + UIClass + "," + UIsection);
                sw.WriteLine(fullText);
               
                string[] arr = new string[listTeachers.Count];
                

            }
            Console.WriteLine("Displaying data after adding new line \n");
            Display();


        }

        static void Delete()
        {
            Console.WriteLine("Data Before Deletion\n");
            Display();
                   
            List<Teacher> listTeachers = new List<Teacher>();
            string teacherfile = (@"C:\Users\Hemanth Nandyala\Desktop\TeacherRecord.txt");
            string[] arrteacher = System.IO.File.ReadAllLines(teacherfile);

            foreach (string line in arrteacher)
            {
                string[] l = line.Split(',');
                Teacher teacher = new Teacher();
                teacher.Id = l[0];
                teacher.FirstName = l[1];
                teacher.LastName = l[2];
                teacher.CClass = l[3];
                teacher.Section = l[4];
                listTeachers.Add(teacher);

            }
            string id;
            Console.WriteLine("\nEnter the id to delete:");
            id = Console.ReadLine();
            foreach (Teacher t in listTeachers)
            {
                if (t.Id == id)
                {
                    listTeachers.Remove(t);
                    break;

                }
                //else
                //{
                //    Console.WriteLine("enterd id is not there");
                //}
            }

            int count = 0;
            string[] arr = new string[listTeachers.Count];
            foreach (Teacher t1 in listTeachers)
            {
                string s = ($"{t1.Id},{t1.FirstName},{t1.LastName},{t1.CClass},{t1.Section}");
                arr[count] = s;
                count++;

            }
            File.WriteAllLines(@"C:\Users\Hemanth Nandyala\Desktop\TeacherRecord.txt", arr);
            Console.WriteLine("Displaying data after Delete Operation\n");
            Display();

        }

        static void SortByFirstName()
        {
            List<Teacher> listTeachers = new List<Teacher>();
            string teacherfile = (@"C:\Users\Hemanth Nandyala\Desktop\TeacherRecord.txt");
            string[] arrteacher = System.IO.File.ReadAllLines(teacherfile);

            foreach (string line in arrteacher)
            {
                string[] l = line.Split(',');
                Teacher teacher = new Teacher();
                teacher.Id = l[0];
                teacher.FirstName = l[1];
                teacher.LastName = l[2];
                teacher.CClass = l[3];
                teacher.Section = l[4];
                listTeachers.Add(teacher);

            }

            Console.WriteLine("After sorting by First Name:");
            listTeachers.Sort((a, b) => a.FirstName.CompareTo(b.FirstName));

            foreach (Teacher s in listTeachers)
            {
                Console.WriteLine($"{ s.Id},{ s.FirstName},{ s.LastName},{ s.CClass},{ s.Section}");


            }

            int count = 0;
            string[] arr = new string[listTeachers.Count];
            foreach (Teacher t1 in listTeachers)
            {
                string s = ($"{t1.Id},{t1.FirstName},{t1.LastName},{t1.CClass},{t1.Section}");
                arr[count] = s;
                count++;

            }
            File.WriteAllLines(@"C:\Users\Hemanth Nandyala\Desktop\TeacherRecord.txt", arr);


        }
        static void SortById()
        {
            List<Teacher> listTeachers = new List<Teacher>();
            string teacherfile = @"C:\Users\Hemanth Nandyala\Desktop\TeacherRecord.txt";
            string[] arrteacher = System.IO.File.ReadAllLines(teacherfile);
            foreach (string line in arrteacher)
            {
                string[] l = line.Split(',');
                Teacher teacher = new Teacher();
                teacher.Id = l[0];
                teacher.FirstName = l[1];
                teacher.LastName = l[2];
                teacher.CClass = l[3];
                teacher.Section = l[4];
                listTeachers.Add(teacher);
            }



            listTeachers.Sort((a, b) => a.Id.CompareTo(b.Id));

            foreach (Teacher s in listTeachers)
            {
                Console.WriteLine($"{ s.Id},{ s.FirstName},{ s.LastName},{ s.CClass},{ s.Section}");

            }

            int count = 0;
            string[] arr = new string[listTeachers.Count];
            foreach (Teacher t1 in listTeachers)
            {
                string s = ($"{t1.Id},{t1.FirstName},{t1.LastName},{t1.CClass},{t1.Section}");
                arr[count] = s;
                count++;

            }
            File.WriteAllLines(@"C:\Users\Hemanth Nandyala\Desktop\TeacherRecord.txt", arr);

        }

        static void Searching()
        {
            List<Teacher> listTeachers = new List<Teacher>();
            string teacherfile = (@"C:\Users\Hemanth Nandyala\Desktop\TeacherRecord.txt");
            string[] arrteacher = System.IO.File.ReadAllLines(teacherfile);

            foreach (string line in arrteacher)
            {
                string[] l = line.Split(',');
                Teacher teacher = new Teacher();
                teacher.Id = l[0];
                teacher.FirstName = l[1];
                teacher.LastName = l[2];
                teacher.CClass = l[3];
                teacher.Section = l[4];
                listTeachers.Add(teacher);

            }
            Console.WriteLine("enter id:");
            string id = Console.ReadLine();
            foreach (Teacher t in listTeachers)
            {
                if (t.Id == id)
                {
                    Console.WriteLine("given {0} is present in the given file", id);
                    Console.WriteLine($"{t.Id},{t.FirstName},{t.LastName},{t.CClass},{t.Section}");
                    break;

                }
                //else
                //{
                //    Console.WriteLine("enterd id is not there");
                //}
            }
        }
        static void Update()
        {

            List<Teacher> listTeachers = new List<Teacher>();
            string teacherfile = (@"C:\Users\Hemanth Nandyala\Desktop\TeacherRecord.txt");
            string[] arrteacher = System.IO.File.ReadAllLines(teacherfile);

            foreach (string line in arrteacher)
            {
                string[] l = line.Split(',');
                Teacher teacher = new Teacher();
                teacher.Id = l[0];
                teacher.FirstName = l[1];
                teacher.LastName = l[2];
                teacher.CClass = l[3];
                teacher.Section = l[4];
                listTeachers.Add(teacher);

            }
            string id;
            Console.WriteLine("Enter the id you want to update:");
            id = Console.ReadLine();
            foreach (Teacher t in listTeachers)
            {
                if (t.Id == id)
                {
                    Console.WriteLine("enter first name:");
                    string ufirstname = Console.ReadLine();
                    Console.WriteLine("enter last name:");
                    string ulastname = Console.ReadLine();
                    Console.WriteLine("enter class:");
                    string uclass = Console.ReadLine();
                    Console.WriteLine("enter section:");
                    string usection = Console.ReadLine();
                    t.FirstName = ufirstname;
                    t.LastName = ulastname;
                    t.CClass = uclass;
                    t.Section = usection;
                    Console.WriteLine("updated one is:");
                    Console.WriteLine($"{ t.Id},{ t.FirstName},{ t.LastName},{ t.CClass},{ t.Section}");


                    break;

                }

            }
            int count = 0;
            string[] arr = new string[listTeachers.Count];
            foreach (Teacher t1 in listTeachers)
            {
                string s = ($"{t1.Id},{t1.FirstName},{t1.LastName},{t1.CClass},{t1.Section}");
                arr[count] = s;
                count++;

            }
            File.WriteAllLines(@"C:\Users\Hemanth Nandyala\Desktop\TeacherRecord.txt", arr);


        }
    }
        
}

