using FileTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FileTask.Utilies.Validations
{
    internal class Validation
    {
        public static void ValidateStudent(Student student)
        { 
            if (string.IsNullOrWhiteSpace(student.Name) || string.IsNullOrWhiteSpace(student.Surname) || string.IsNullOrWhiteSpace(student.Code))
            {
                throw new Exception("Name, surname, and code cannot be empty.");
            }
            string codePattern = @"^Mi\d{7}$";
            if (!Regex.IsMatch(student.Code, codePattern))
            {
                throw new Exception("Invalid student code format. Minimum 9 characater and must start with (Mi) letter");
            }
            
     }   }
}
