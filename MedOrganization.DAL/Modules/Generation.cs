using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using MedOrganization.DAL.Classes;
using RandomNameGenerator;

namespace MedOrganization.DAL.Modules
{
    public class Generation
    {
        private Random random = new Random();
        public List<Patient> GeneratePatients()
        {
            List<Patient> patients = new List<Patient>();
            for (int i = 0; i < random.Next(1, 50); i++)
            {
                Patient patient = new Patient()
                {
                    FirstName = NameGenerator.GenerateFirstName((Gender)random.Next(0, 2)).ToLower(),
                    SecondName = NameGenerator.GenerateFirstName((Gender)random.Next(0, 2)).ToLower(),
                    LastName = NameGenerator.GenerateLastName().ToLower(),
                    IIN = $"{random.Next(1000, 9999)}{random.Next(1000, 9999)}{random.Next(1000, 9999)}"
                };
                Thread.Sleep(30);
                patients.Add(patient);
            }

            return patients;
        }
        public List<Users> GenerateUsers()
        {
            List<Users> users = new List<Users>();
            for (int i = 0; i < random.Next(1,50); i++)
            {
                Users user = new Users()
                {
                    AccessLevel = AccessLevel.NoPrivileges,
                    Login = NameGenerator.GenerateFirstName((Gender) random.Next(0, 2)).ToLower(),
                    Password = "123"
                };
                users.Add(user);
            }

            return users;
        }
        public List<MedOrg> GenerateMedOrgs()
        {
            List<MedOrg> medOrgs = new List<MedOrg>();
            DirectoryInfo directory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent?.Parent;
            XDocument xdoc = XDocument.Load(directory?.FullName + ".DAL/Classes/Addresses.xml");
            List<string> elem = xdoc.Root?.Elements().Elements().Select(s => s.Value).ToList();
            for (int i = 0; i < random.Next(1, 10); i++)
            {
                MedOrg medOrg = new MedOrg()
                {
                    Name = NameGenerator.GenerateLastName().ToLower(),
                    PhoneNumber = $"+7({random.Next(100, 1000)})-" +
                                  $"{random.Next(100, 1000)}-" +
                                  $"{random.Next(10, 100)}-" +
                                  $"{random.Next(10, 100)}",
                    Address = elem?[random.Next(elem.Count)],
                    Patients = GeneratePatients(),
                    UsersOfMedOrg = GenerateUsers()
                };
                Thread.Sleep(30);
                medOrgs.Add(medOrg);
            }
            return medOrgs;
        }

        //public void GenerateQueries(ref Patient patient)
        //{
        //    if (random.Next(0, 2) == 1)
        //    {
        //        DateTime validValue;
        //        string day = random.Next(1, 32).ToString();
        //        string month = random.Next(1, 13).ToString();
        //        string year = random.Next(2017, 2019).ToString();
        //        string date = $"{day}-{month}-{year}";
        //        DateTime obrabotka = DateTime.Parse(date).AddDays(random.Next(2, 7));
        //        QueryToAdd queryTo = new QueryToAdd()
        //        {
        //            CreateDate = DateTime.TryParse(date, out validValue) ? validValue : (DateTime?) null,
        //            Obrabotka = DateTime.TryParse(obrabotka.ToString(), out validValue) ? validValue : (DateTime?) null,
        //            MedOrg = MedOrgs[random.Next(1, MedOrgs.Count)],
        //            patientsQueries = new List<Patient>()
        //        };
        //        queryTo.patientsQueries.Add(patient);
        //        QueriesToAdd.Add(queryTo);
        //    }
        //}
    }
}
