using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using RandomNameGenerator;

namespace MedOrganization.DAL.Classes
{
    public class MedOrg
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public List<Patient> Patients { get; set; } = new List<Patient>();
        public List<Users> UsersOfMedOrg { get; set; } = new List<Users>();

        public void PrintInfo()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("---------------------Медицинская организация----------------------------");
            Console.WriteLine($"Название : {Name} Адрес : {Address} Телефонный номер : {PhoneNumber}\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Пациенты, прикрепленные к медицинской организации {Name}");
            foreach (Patient patient in Patients)
                patient.PrintInfo();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Пациентов в организации : {Patients.Count}");
            Console.ForegroundColor = ConsoleColor.White;
            //Console.WriteLine($"Пользователи, прикрепленные к медицинской организации {Name}");
            //foreach (Users user in UsersOfMedOrg)
            //    user.PrintInfo();

        }
    }
}
