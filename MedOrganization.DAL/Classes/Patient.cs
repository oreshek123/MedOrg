using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RandomNameGenerator;


namespace MedOrganization.DAL.Classes
{
    public class Patient
    {
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string IIN { get; set; }
        public void PrintInfo()
        {
            Console.WriteLine("-----------------------------Пациент------------------------------------");
            Console.WriteLine($"Фио : {LastName} {FirstName} {SecondName} ИИН : {IIN}\n");
        }
    }
}
