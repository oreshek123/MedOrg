using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MedOrganization.DAL.Classes;

namespace MedOrganization.DAL.Modules
{
    public class ModulPatientAttach
    {
        public List<MedOrg> MedOrgs { get; set; }
        public List<Patient> BaseOfPatients { get; set; }
        public List<QueryToAdd> QueriesToAdd { get; set; }
        public List<Patient> patientsQueries { get; set; }
        public Generation Generation { get; set; } = new Generation();

        public void GenerateBase()
        {
            MedOrgs = Generation.GenerateMedOrgs();
            BaseOfPatients = Generation.GeneratePatients();
        }
        public Patient CheckForNullAndPrintInfoAboutPatient(ref Patient patient)
        {
            if (patient != null)
                patient.PrintInfo();
            else
            {
                Console.WriteLine("Проверьте ввод, такой пациент или организация не найдены");
                patient = null;
            }

            return patient;
        }
        public Patient Search(out MedOrg med)
        {
            int i = 0;
            MedOrg org = null;
            Patient patient = null;
            QueryToAdd query = null;
            Console.WriteLine("Введите название мед. организации");
            foreach (MedOrg item in MedOrgs)
            {
                Console.WriteLine($"{++i} {item.Name} {item.Address}");
            }

            string name = Console.ReadLine();

            foreach (var o in MedOrgs)
            {
                if (o.Name == name)
                {
                    org = o;
                    break;
                }
            }

            if (org != null)
            {
                foreach (Patient item in org.Patients)
                {
                    query = null;
                    if (QueriesToAdd != null)
                    {
                        foreach (QueryToAdd q in QueriesToAdd)
                        {
                            if (q.Patient == item)
                            {
                                query = q;
                                break;
                            }
                        }
                    }

                    if (query == null || query.Patient != item)
                        item.PrintInfo();
                }

                Console.WriteLine("Введите имя, фамилию,отчество или ИИН пациента");
                string fio = Console.ReadLine();

                foreach (var o in org.Patients)
                {
                    string f = $"{o.LastName} {o.FirstName} {o.SecondName}";
                    if (f.Contains(fio ?? throw new InvalidOperationException())|| o.IIN == fio)
                    {
                        patient = o;
                        break;
                    }
                }


            }

            med = org;
            return patient;
        }
        public void CheckForNullsAndPrintInfoAboutQuery(ref QueryToAdd query)
        {
            if (query != null)
                query.PrintInfo();
            else
                Console.WriteLine("Запрос не найден");
        }
        public QueryToAdd CreateQuaryToAdd(DateTime date, ref Patient patient, ref MedOrg medOrg)
        {
            QueryToAdd query = new QueryToAdd()
            {
                Patient = patient,
                MedOrg = medOrg,
                CreateDate = date,
                Active = true
            };

            if (QueriesToAdd != null) QueriesToAdd.Add(query);
            else
            {
                QueriesToAdd = new List<QueryToAdd>();
                QueriesToAdd.Add(query);
            }

            Console.WriteLine("Запрос был отправлен в обработку");
            return query;
        }





    }
}
