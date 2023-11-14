using FileTask.Models;
using FileTask.Utilies.Services;
using Newtonsoft.Json;
using System.Xml;

namespace FileTask
{
    public class Program
    {
        static void Main(string[] args)
        {
           /*StudentDatabase.students.Add(new Student("Fuad", "Khalilov", "Mi1234"));*/

           StudentDatabase studentDatabase = new StudentDatabase();
            while (true)
            {

                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Remove Student");
                Console.WriteLine("3. Edit Student");
                Console.WriteLine("4. View Students (JSON)");
                Console.WriteLine("5. Exit");


                string opt = Console.ReadLine();

                switch (opt)
                {
                    case "1":
                        Console.WriteLine("Name");
                        string name = Console.ReadLine();
                        Console.WriteLine("Surname");
                        string surname = Console.ReadLine();
                        Console.WriteLine("Code: example(Mi98983)");
                        string code = Console.ReadLine();
                       StudentService.AddStudent(new Student { Name = name, Surname = surname, Code = code });
                        
                        break;
                    case "2":
                        Console.Write("Enter student code to remove: ");
                        string codeToRemove = Console.ReadLine();
                        StudentService.RemoveStudent(codeToRemove);
                       
                     break;
                    case "3":
                        Console.Write("Enter student code to edit: ");
                        string codeToEdit = Console.ReadLine();
                        Console.Write("Enter new student name: ");
                        string newName = Console.ReadLine();
                        Console.Write("Enter new student surname: ");
                        string newSurname = Console.ReadLine();
                        Console.Write("Enter new student code: ");
                        string newCode = Console.ReadLine();
                        StudentService.EditStudent(codeToEdit, new Student { Name = newName, Surname = newSurname, Code = newCode });
                     break;
                        
                    case "4":
                        try
                        {
                            string Root = @"C:\Users\msi\OneDrive\Desktop\FileTask\FileTask";
                            //Creating Data Folder
                            string data = Path.Combine(Root, "Folder");
                            if (!Directory.Exists(data))
                            {
                                Directory.CreateDirectory(data);
                                Console.WriteLine("Data Folder is created \n");
                            }

                            string jsonData = Path.Combine(data, "jsonData.json");

                            if (!File.Exists(jsonData))
                            {
                                File.Create(jsonData);
                                Console.WriteLine("JsonData is Created");
                            }
                            else
                            {
                                Console.WriteLine("JsonData is Exist :");
                            }

                            if(StudentDatabase.students == null)
                            {
                                throw new Exception("Json Bosdur");
                            }
                            else
                            {
                                string stds = JsonConvert.SerializeObject(StudentDatabase.students);

                                StreamWriter sw = new StreamWriter(Path.Combine(Root, jsonData));
                                sw.Write(stds);
                                sw.Close();
                                Console.WriteLine(stds);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                     break;
                    case "5":
                        Console.WriteLine("Quitting succesfully!");
                     break;
                    default:
                        Console.WriteLine("Invalid Choice");
                     break;
                }
                
            }
            


        }
    }
}