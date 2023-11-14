using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileTask.Models;

namespace FileTask.Utilies.Services
{
    internal static class StudentService 
    {
        public static void AddStudent(Student student)
        {
            try
            {
               Validations.Validation.ValidateStudent(student);

                StudentDatabase.students.Add(student);

                Console.WriteLine($"Student added: {student.Name} {student.Surname} {student.Code}");
            }
            
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void RemoveStudent(string code)
        {
            Student studentremove = StudentDatabase.students.FirstOrDefault(x => x.Code == code);
            if (studentremove != null)
            {
               
                StudentDatabase.students.Remove(studentremove);
            }
            else
            {
                throw new Exception("User Not Exist!");
            }
        }

        public static void EditStudent(string code, Student student)
        {
            Student existstudent = StudentDatabase.students.Find(y => y.Code == code);
            
            if (existstudent != null)
            {
                existstudent.Name = student.Name;
                existstudent.Code = student.Code;
                existstudent.Surname = student.Surname;
                Validations.Validation.ValidateStudent(student);
            }
            else
            {
                throw new Exception("User Not Exist!");
            }
        }

    }
}
